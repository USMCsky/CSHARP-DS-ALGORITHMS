// SPIN THE WHEEL
// Chapter 4 (Variants of Lists)
// C# Data Structures and Algorithms, Second Edition

CircularLinkedList<string> categories = new();
categories.AddLast("C# DATA STRUCTURES");
categories.AddLast("ALGORITHMS");
categories.AddLast("LINKED LISTS");
categories.AddLast("DICTIONARIES");
categories.AddLast("OBJECTS AND CLASSES");
categories.AddLast("FUNDAMENTALS");
categories.AddLast("PLAY 7DTD");
categories.AddLast("WASH THE DOG - CHORES");

bool isStopped = true;
Random random = new();
DateTime targetTime = DateTime.Now;
int ms = 0;
foreach (string category in categories)
{
    if (isStopped)
    {
        Console.WriteLine("Press [Enter] to start.");
        ConsoleKey key = Console.ReadKey().Key;
        if (key == ConsoleKey.Enter)
        {
            ms = random.Next(1000, 6000);
            targetTime = DateTime.Now.AddMilliseconds(ms);
            isStopped = false;
            Console.WriteLine(category);
        }
        else { return; }
    }
    else
    {
        int remaining = (int)(targetTime - DateTime.Now).TotalMilliseconds;
        int waiting = Math.Max(100, (ms - remaining) / 5);
        await Task.Delay(waiting);

        if (DateTime.Now >= targetTime)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            isStopped = true;
        }

        Console.WriteLine(category);
        Console.ResetColor();
    }
}
