// Creativity: loading scriptures from a file and picking one at random


using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "scriptures.txt");

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Error: Could not find '{filePath}'.");
            return;
        }

        List<Scripture> library = ScriptureLoader.LoadFromFile(filePath);

        if (library.Count == 0)
        {
            Console.WriteLine("No scriptures found in the file.");
            return;
        }

        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Well done!");
                break;
            }

            Console.Write("Press Enter to hide more words or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input?.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }
    }
}
