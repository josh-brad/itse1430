
Console.WriteLine("Joshua Bradshaw");
Console.WriteLine("ITSE 1430");
Console.WriteLine("Fall Semester");

string[] processor = { "AMD Ryzen 9 5900x", "AMD Ryzen 7 5700x", "AMD Ryzen 5600x", "Intel i9-12900k", "Intel i7-12700k", "Intel i5-12600k" };
int[] processorPrice = { 1410, 1270, 1200, 1590, 1400, 1280 };
string[] memory = { "8 GB", "16 GB", "32 GB", "64 GB", "128 GB" };
int[] memoryPrice = { 30, 40, 90, 410, 600 };
string[] primaryStorage = { "SSD 256 GB", "SSD 512 GB", "SSD 1 TB", "SSD 2 TB" };
int[] primaryStoragePrice = { 90, 100, 125, 230 };
string[] secondaryStorage = { "None", "HDD 1TB", "HDD 2 TB", "HDD 4 TB", "SSD 512 GB", " SSD 1 TB", "SSD 2 TB" };
int[] secondaryStoragePrice = { 0, 40, 50, 70, 100, 125, 230 };
string[] graphicsCard = { "Nome", "GeForce RTX 3070", "GeForce RTX 2070", "Radeon RX 6600", "Radeon RX 5600" };
int[] graphicsCardPrice = { 0, 580, 400, 300, 325 };
string[] operatingSystem = { "Windows 11 Home", "Windows 11 Pro", "Windows 10 Home", "Windows 10 Pro", "Linux (Fedora)", "Linux (Read Hat)" };
int[] operatingSystemPrice = { 140, 160, 150, 170, 20, 60 };
double cartAmount = 0;
List<string> cartItems = new List<string>();
List<int> cartItemsPrice = new List<int>();

Console.WriteLine("Press Enter to Start");
Console.ReadLine();
Menu();

int Menu ()
{
    Console.WriteLine("\n------------------");
    Console.WriteLine("Your cart total is $" + cartAmount);
    Console.WriteLine("\nS: Start Order ");
    Console.WriteLine("F: See Order");
    Console.WriteLine("D: Continue Order");
    Console.WriteLine("Q: Quit");


    while (true)
    {

        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.S)
            StartOrder();

        if (key.Key == ConsoleKey.Q)
            Console.WriteLine("Quit");

        if (key.Key == ConsoleKey.F)
            ViewOrder();

        if (key.Key == ConsoleKey.D)
            Order();

        else
            Console.WriteLine(" \nEnter Valid Input");
    }

}

void ViewOrder ()
{
    Console.WriteLine("\n-----------------");
    for (int i = 0; i < cartItems.Count; i++)
    {
        Console.WriteLine( cartItems[i] + "..........$" + cartItemsPrice[i]);
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
    Order();
}

void Order()
{

    Console.WriteLine("\n------------------");
    Console.WriteLine("A: Select Prossesor");
    Console.WriteLine("S: Select Memory");
    Console.WriteLine("D: Select Primary Storage");
    Console.WriteLine("F: Select Secondary Storage");
    Console.WriteLine("G: Select Graphics Card");
    Console.WriteLine("Q: Menu");

    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.A)
            Select(processor, processorPrice);
        if (key.Key == ConsoleKey.S)
            Select(memory, processorPrice);
        if (key.Key == ConsoleKey.D)
            Select(primaryStorage, primaryStoragePrice);
        if (key.Key == ConsoleKey.F)
            Select(secondaryStorage, secondaryStoragePrice);
        if (key.Key == ConsoleKey.G)
            Select(graphicsCard, graphicsCardPrice);
        if (key.Key == ConsoleKey.Q)
            Menu();
        else
            Console.WriteLine("Enter Valid Input");
            
    }

}

void Select ( string[] array, int[] arrayPrice )
{
    Console.WriteLine("\n------------------");

    for (int i=0; i < array.Length; i++)
    {
        
        int order = i + 1;
        Console.WriteLine(order + ". " + array[i] + "...........Price: $" + arrayPrice[i]);

    }
    Console.WriteLine("Q: Menu");
    

    while (true)
    {
        string input;
        input = Console.ReadLine();

        if (Int32.TryParse(input, out int result))
        {
            cartAmount = cartAmount + arrayPrice[result - 1];
            cartItems.Add(array[result - 1]);
            cartItemsPrice.Add(arrayPrice[result - 1]);
            Console.WriteLine("Thank You For Your Purchase\nPress Enter To Continue");
            Console.ReadLine();
            Order();
        }
        if (input == "Q" || input == "q")
            Menu();
        else
            Console.WriteLine("Enter Valid input");      
    }    
}
