Console.WriteLine("Joshua Bradshaw");
Console.WriteLine("ITSE 1430");
Console.WriteLine("Fall Semester");

Console.WriteLine("Press Anything to Start");
Console.ReadLine();

int flow;
int Menu ()
{
    Console.WriteLine("Start Order S");
    Console.WriteLine("Quit Q");



    while (true)
    {

        ConsoleKeyInfo key = Console.ReadKey();

        if (key.Key == ConsoleKey.S)
            return 1;

        if (key.Key == ConsoleKey.Q)
            return 2;

        else
            Console.WriteLine(" Enter Valid Input");
    }

}

flow = Menu ();

void Flow ()
{
    if (flow == 1)
        Console.WriteLine("Started Order");
    if (flow == 2)
        Console.WriteLine("Quit");
  

}

Flow();
void Order()
{







}