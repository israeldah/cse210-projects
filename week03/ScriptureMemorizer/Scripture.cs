using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ')
                     .Select(w => new Word(w))
                     .ToList();
    }

    public bool AllWordsHidden() => _words.All(w => w.IsHidden());

    public void HideRandomWords(int count = 3)
    {
        var visible = _words.Where(w => !w.IsHidden()).ToList();
        int toHide = Math.Min(count, visible.Count);

        for (int i = 0; i < toHide; i++)
        {
            int index = _random.Next(visible.Count);
            visible[index].Hide();
            visible.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string words = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.GetDisplayText()} {words}";
    }
}
