public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    // Display this entry to the console
    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"{_entryText}");
        Console.WriteLine();
    }

    // Convert this entry to a string for saving to a file
    public string ToFileString()
    {
        return $"{_date}~|~{_promptText}~|~{_entryText}";
    }
}