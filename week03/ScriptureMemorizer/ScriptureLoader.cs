using System;
using System.Collections.Generic;
using System.IO;

public class ScriptureLoader
{
    public static List<Scripture> LoadFromFile(string filePath)
    {
        var scriptures = new List<Scripture>();

        foreach (string line in File.ReadLines(filePath))
        {
            string trimmed = line.Trim();
            if (string.IsNullOrEmpty(trimmed)) continue;

            string[] parts = trimmed.Split('|');
            if (parts.Length != 2) continue;

            string refText = parts[0].Trim();
            string text = parts[1].Trim();

            Reference reference = ParseReference(refText);
            if (reference != null)
                scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }

    private static Reference ParseReference(string refText)
    {
        // Expected formats: "Book chapter:verse" or "Book chapter:startVerse-endVerse"
        // Book name may have spaces, e.g. "2 Nephi 2:25"
        int colonIndex = refText.LastIndexOf(':');
        if (colonIndex < 0) return null;

        string bookAndChapter = refText.Substring(0, colonIndex).Trim();
        string versePart = refText.Substring(colonIndex + 1).Trim();

        int lastSpace = bookAndChapter.LastIndexOf(' ');
        if (lastSpace < 0) return null;

        string book = bookAndChapter.Substring(0, lastSpace).Trim();
        if (!int.TryParse(bookAndChapter.Substring(lastSpace + 1), out int chapter)) return null;

        if (versePart.Contains('-'))
        {
            string[] verseRange = versePart.Split('-');
            if (verseRange.Length != 2) return null;
            if (!int.TryParse(verseRange[0], out int start)) return null;
            if (!int.TryParse(verseRange[1], out int end)) return null;
            return new Reference(book, chapter, start, end);
        }
        else
        {
            if (!int.TryParse(versePart, out int verse)) return null;
            return new Reference(book, chapter, verse);
        }
    }
}
