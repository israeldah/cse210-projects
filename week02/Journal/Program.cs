// EXCEEDING REQUIREMENTS:
// Added a 5th menu option to quit the program
// Added input validation for menu choices
// Added confirmation messages after save/load operations

using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the journal object
        Journal journal = new Journal();

        // Create the prompt generator
        PromptGenerator promptGenerator = new PromptGenerator();

        // Menu loop
        string choice = "";

        while (choice != "5")
        {
            // Display menu
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                // Get a random prompt and show it
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                // Create the entry with today's date
                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._promptText = prompt;
                newEntry._entryText = response;

                journal.AddEntry(newEntry);
                Console.WriteLine("Entry saved to journal.\n");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded successfully.\n");
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine("Journal saved successfully.\n");
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.\n");
            }
        }
    }
}