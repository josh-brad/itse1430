Console.WriteLine("Joshua Bradshaw");
Console.WriteLine("ITSE 1430");
Console.WriteLine("Fall Semester");

Console.WriteLine("Press Anything to Start");
Console.ReadLine();

string[] processor = { "AMD Ryzen 9 5900x", "AMD Ryzen 7 5700x", "AMD Ryzen 5600x", "Intel i9-12900k", "Intel i7-12700k", "Intel i5-12600k" };
string[] memory = { "8 GB", "16 GB", "32 GB", "64 GB", "128 GB" };
int[] processorPrice = { 1410, 1270, 1200, 1590, 1400, 1280 };




double cartAmount = 0;
int flow;
int Menu ()
{
    Console.WriteLine("Start Order S");
    Console.WriteLine("Quit Q");
    Console.WriteLine("See Order F");



    while (true)
    {

        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.S)
            return 1;

        if (key.Key == ConsoleKey.Q)
            return 2;

        if (key.Key == ConsoleKey.F)
            Console.WriteLine("Your Cart Total is: $" + cartAmount);

        else
            Console.WriteLine(" Enter Valid Input");
    }

}

flow = Menu ();

void Flow ()
{
    if (flow == 1)
        Order();
    if (flow == 2)
        Console.WriteLine("Quit");
    if (flow == 3)
        Console.WriteLine(cartAmount);
  

}

Flow();
void Order()
{
    cartAmount = 0;
    Console.WriteLine("");    
    Console.WriteLine("Select Prossesor:A");
    Console.WriteLine("Select Memory:S");
    Console.WriteLine("Select Primary Storage:D");
    Console.WriteLine("Select Secondary Storage:F");
    Console.WriteLine("Select Graphics Card:G");

    while (true)
    {
        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.A)
            Select(processor, processorPrice);
            

        if (key.Key == ConsoleKey.S)
            Select(memory, processorPrice);
            
    }

}


void Select ( string[] array, int[] arrayPrice )
{
    Console.WriteLine("");
   
    for (int i=0; i < array.Length; i++)
    {
        
        int order = i + 1;
        Console.WriteLine(order + ". " + array[i] + "...........Price: $" + arrayPrice[i]);

    }
    string input;
    input = Console.ReadLine();       
    if (Int32.TryParse(input, out int result))                
    cartAmount = cartAmount + arrayPrice[result - 1];
    Console.WriteLine("Thank You For YOur Purchase");
    Console.ReadLine();
    Menu();

          
}
Console.WriteLine(cartAmount);