
using System;

Console.WriteLine("Joshua Bradshaw");
Console.WriteLine("ITSE 1430");
Console.WriteLine("Fall Semester");

string[] processor = { "AMD Ryzen 9 5900x", "AMD Ryzen 7 5700x", "AMD Ryzen 5600x", "Intel i9-12900k", "Intel i7-12700k", "Intel i5-12600k" };
int[] processorPrice = { 1410, 1270, 1200, 1590, 1400, 1280 };
string[] memory = { "8 GB", "16 GB", "32 GB", "64 GB", "128 GB" };
int[] memoryPrice = { 30, 40, 90, 410, 600 };
string[] primaryStorage = { "SSD 256 GB", "SSD 512 GB", "SSD 1 TB", "SSD 2 TB" };
int[] primaryStoragePrice = { 90, 100, 125, 230 };
string[] secondaryStorage = { "None", "HDD 1TB", "HDD 2 TB", "HDD 4 TB", "SSD 512 GB", "SSD 1 TB", "SSD 2 TB" };
int[] secondaryStoragePrice = { 0, 40, 50, 70, 100, 125, 230 };
string[] graphicsCard = { "Nome", "GeForce RTX 3070", "GeForce RTX 2070", "Radeon RX 6600", "Radeon RX 5600" };
int[] graphicsCardPrice = { 0, 580, 400, 300, 325 };
string[] operatingSystem = { "Windows 11 Home", "Windows 11 Pro", "Windows 10 Home", "Windows 10 Pro", "Linux (Fedora)", "Linux (Read Hat)" };
int[] operatingSystemPrice = { 140, 160, 150, 170, 20, 60 };
double cartAmount = 0;

string[] items = { "", "", "", "", "", "" };
int[] itemsPrice = { 0, 0, 0, 0, 0, 0 };

Console.WriteLine("Press Enter to Start");
Console.ReadLine();
Menu();

int Menu ()
{
    Console.WriteLine("\n------------------");
    Console.WriteLine("Your cart total is $" + cartAmount);
    Console.WriteLine("\nS: Start Order ");
    Console.WriteLine("F: See Order");
    Console.WriteLine("D: Modify Order");
    Console.WriteLine("Q: Quit");


    while (true)
    {

        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.S)
            StartOrder();

        if (key.Key == ConsoleKey.F)
            ViewOrderFunc();

        if (key.Key == ConsoleKey.E)
            ModifyOrder(0);

        if (key.Key == ConsoleKey.Q)
        {
            while (true)
            {
                Console.WriteLine("\nAre you sure you want to quit?\nPress Y to confirm N to return to Main Menu");
                ConsoleKeyInfo keyYN = Console.ReadKey();
                if (keyYN.Key == ConsoleKey.Y)
                    Environment.Exit(0);
                if (keyYN.Key == ConsoleKey.N)
                    Menu();
                else
                    Console.WriteLine(" \nEnter Valid Input");
            }
        } 
        else
            Console.WriteLine(" \nEnter Valid Input");
    }

}

void ViewOrderFunc ()
{
    if (itemsPrice[0] != 0)
        ViewOrder();
    else
    {
        Console.WriteLine("\n-----------------");
        Console.WriteLine("\nNo Current Order\nPress Enter to return to Main Menu");
        Console.ReadLine();
        Menu();
    }
}

void ViewOrder ()
{
    Console.WriteLine("\n-----------------");
    for (int i = 0; i < items.Length; i++)
    {
        Console.WriteLine( items[i].PadRight(20, '.') + "$" + itemsPrice[i]);
    }
    Console.WriteLine("-----------------");
    Console.WriteLine("Total:         $" + cartAmount);
    Console.WriteLine("Q: Menu");
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.Q)
        Menu();
}

void StartOrder ()
{
    cartAmount = 0;
    Array.Clear(items, 0, items.Length);
    Array.Clear(itemsPrice, 0, itemsPrice.Length);
    Order(0);
}

void Order (int num)
{
    switch (num)
    {
        case 0: Select(processor, processorPrice, 1, true); break;
        case 1: Select(memory, memoryPrice, 2, true); break;
        case 2: Select(primaryStorage, primaryStoragePrice, 3, true); break;
        case 3: Select(secondaryStorage, secondaryStoragePrice, 4, true); break;
        case 4: Select(graphicsCard, graphicsCardPrice, 5, true); break;
        case 5: Select(operatingSystem, operatingSystemPrice, 6, true); break;
        case 6: Menu(); break;
    } 
}

void ModifyOrder (int num)
{
    string input;
    input = Console.ReadLine();

    while (true)
    {
        if (Int32.TryParse(input, out int result) & result <= 5)
        {
            result = num;
            switch (num)
            {
                case 0: Select(processor, processorPrice, 1, false); break;
                case 1: Select(memory, memoryPrice, 2, false); break;
                case 2: Select(primaryStorage, primaryStoragePrice, 3, false); break;
                case 3: Select(secondaryStorage, secondaryStoragePrice, 4, false); break;
                case 4: Select(graphicsCard, graphicsCardPrice, 5, false); break;
                case 5: Select(operatingSystem, operatingSystemPrice, 6, false); break;
            }
        } else
            Console.WriteLine("Enter Valid Iput");
    }
} 

void Select ( string[] array, int[] arrayPrice, int num, bool flow )
{
    Console.WriteLine("\n------------------");

    for (int i=0; i < array.Length; i++)
    {
        
        int order = i + 1;
        Console.WriteLine(order + ". " + array[i].PadRight(20,'.') + "Price: $" + arrayPrice[i]);

    }
 
    Console.WriteLine("Q: Menu");
    
    while (true)
    {
        string input;
        input = Console.ReadLine();

        if (Int32.TryParse(input, out int result) & result < (array.Length + 1))
        {
            string temp;
            int digit;
            cartAmount = cartAmount + arrayPrice[result - 1];
            temp = array[result-1];
            items[num-1] = temp;
            digit = arrayPrice[result-1];
            itemsPrice[num-1] = digit;

            Console.WriteLine("Thank You For Your Purchase\nPress Enter To Continue");
            Console.ReadLine();
            
                if(flow == true)
                    Order(num);
                else 
                    Menu();
        }
        if (input == "Q" || input == "q")
            Menu();
        else
            Console.WriteLine("Enter Valid input");      
    }    
}