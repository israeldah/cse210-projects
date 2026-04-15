// Eternal Quest Program
// Author: Israel Dah
// Creativity: A fourth goal type (NegativeGoal) that penalizes bad habits, a score-based leveling/rank system, and a score floor of zero
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        Console.WriteLine("Welcome to the Eternal Quest Goal Tracker!");

        while (running)
        {
            manager.DisplayScore();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    Console.Write("What is the filename for the goal file? ");
                    manager.SaveGoals(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("What is the filename for the goal file? ");
                    manager.LoadGoals(Console.ReadLine());
                    break;
                case "5":
                    manager.RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}
