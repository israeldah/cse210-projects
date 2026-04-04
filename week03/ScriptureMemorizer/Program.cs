using System;

class Program
{
    static void Main(string[] args)
    {
        var reference = new Reference("John", 3, 16);
        var scripture = new Scripture(reference,
            "For God so loved the world that he gave his only begotten Son " +
            "that whosoever believeth in him should not perish but have everlasting life");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("All words are hidden. Great job!");
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input?.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }
    }
}
