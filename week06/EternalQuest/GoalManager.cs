// Manages the list of goals and the user's score
class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Exceeds requirements: returns a rank title based on current score
    private string GetLevel()
    {
        if (_score < 500)   return "Novice Adventurer";
        if (_score < 1500)  return "Apprentice";
        if (_score < 3000)  return "Journeyman";
        if (_score < 6000)  return "Expert";
        if (_score < 10000) return "Master";
        if (_score < 20000) return "Grand Master";
        return "Eternal Champion";
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Current Level: {GetLevel()}");
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet!");
            return;
        }
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (penalty for bad habits)");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid choice. No goal was created.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record!");
            return;
        }
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= _goals.Count)
        {
            int earned = _goals[index - 1].RecordEvent();
            if (earned > 0)
            {
                _score += earned;
                Console.WriteLine($"Congratulations! You have earned {earned} points!");
                Console.WriteLine($"You now have {_score} points.");
            }
            else if (earned < 0)
            {
                // Exceeds requirements: score cannot go below 0
                _score = Math.Max(0, _score + earned);
                Console.WriteLine($"You lost {-earned} points for that bad habit!");
                Console.WriteLine($"You now have {_score} points.");
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals saved to '{filename}'.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File '{filename}' not found.");
            return;
        }
        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(":", 2);
            string type    = parts[0];
            string details = parts[1];
            string[] d     = details.Split(",");

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(d[0], d[1], int.Parse(d[2]), bool.Parse(d[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(d[0], d[1], int.Parse(d[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(d[0], d[1], int.Parse(d[2]),
                                                 int.Parse(d[3]), int.Parse(d[4]), int.Parse(d[5])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(d[0], d[1], int.Parse(d[2])));
                    break;
            }
        }
        Console.WriteLine($"Goals loaded from '{filename}'.");
    }
}
