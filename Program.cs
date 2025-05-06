using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new journal instance
        Journal journal = new Journal();
        bool running = true;
        
        // List of prompts (including extra ones for creativity)
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What was the most challenging part of my day?", // Extra prompt
            "What am I grateful for today?" // Extra prompt
        };

        // Main program loop
        while (running)
        {
            // Display menu
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();

            // Handle user choice
            switch (choice)
            {
                case "1": // Write new entry
                    Entry entry = new Entry();
                    Random random = new Random();
                    int index = random.Next(prompts.Count);
                    string prompt = prompts[index];
                    
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    
                    entry._date = DateTime.Now.ToShortDateString();
                    entry._promptText = prompt;
                    entry._entryText = response;
                    
                    journal.AddEntry(entry);
                    break;
                    
                case "2": // Display journal
                    journal.DisplayAll();
                    break;
                    
                case "3": // Save to file
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    Console.WriteLine("Journal saved successfully.");
                    break;
                    
                case "4": // Load from file
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    Console.WriteLine("Journal loaded successfully.");
                    break;
                    
                case "5": // Exit
                    running = false;
                    break;
                    
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}