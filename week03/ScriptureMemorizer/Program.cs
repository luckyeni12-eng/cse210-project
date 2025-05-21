using System;

class Program
{
    static void Main(string[] args)
    {
      Console.Clear();
        Scripture scripture = ScriptureLibrary.GetRandomScripture(); // Pick random scripture

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 words at a time
        }

        // Show final fully hidden scripture
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words hidden. Program ended.");
    }
}

// --- Word.cs ---
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

// --- Reference.cs ---
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null;
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        return _endVerse == null ? $"{_book} {_chapter}:{_verse}" : $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}

// --- Scripture.cs ---
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
        _random = new Random();
    }

    public string GetDisplayText()
    {
        string wordsText = string.Join(" ", _words.Select(w => w.GetDisplayText()));
        return $"{_reference.ToString()} - {wordsText}";
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Any(); i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // Prevent re-hiding
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}

// --- ScriptureLibrary.cs ---
public static class ScriptureLibrary
{
    private static List<Scripture> _scriptures = new List<Scripture>
    {
        new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
        new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
        new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd, I lack nothing.")
    };

    public static Scripture GetRandomScripture()
    {
        Random rand = new Random();
        return _scriptures[rand.Next(_scriptures.Count)];
    }
}
