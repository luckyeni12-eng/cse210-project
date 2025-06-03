using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
        Console.Write("Enter the duration of this activity in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3);

        RunActivity();

        Console.WriteLine("\nGood job!");
        Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected int GetDuration() => _duration;

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinner = { "/", "-", "\\", "|" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }

    protected abstract void RunActivity();
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

    protected override void RunActivity()
    {
        int duration = GetDuration();
        int cycleTime = 6; // 3 seconds in, 3 seconds out
        int cycles = duration / cycleTime;

        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(3);
            Console.WriteLine("Breathe out...");
            ShowCountdown(3);
        }
    }
}

class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string> {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different?",
        "What is your favorite thing about this experience?",
        "What did you learn about yourself?",
        "How can you use this experience in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times when you have shown strength and resilience. It helps you recognize your inner power.") { }

    protected override void RunActivity()
    {
        int duration = GetDuration();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine("\nPrompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("Reflect on the following questions:");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine("> " + question);
            ShowSpinner(5);
        }
    }
}

class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt peace this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by listing as many items as you can.") { }

    protected override void RunActivity()
    {
        int duration = GetDuration();
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine("\nPrompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("You may begin listing items in 3 seconds...");
        ShowCountdown(3);

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("List item: ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} items. Great job!");
    }
}

class Program
{
    static void Main()
    {
        int completedActivities = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    Console.WriteLine($"You completed {completedActivities} activities this session. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            activity.StartActivity();
            completedActivities++;
        }
    }
}

