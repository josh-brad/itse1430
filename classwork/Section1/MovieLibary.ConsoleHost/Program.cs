//Movie definition
string title = "";
string description = "";
int runLength = 0; //in minutes
int releaseYear = 1900;
string rating = "";
bool isClassic = false;


DisplayInformation();
bool done = false;
do 
{
    //type infenceing coplileir figures out type based on context
    //MenuOption input = DisplayMenu();
    var input = DisplayMenu();
    Console.WriteLine();
    switch (input)
    {        
        case MenuOption.Add: AddMovie(); break;
        case MenuOption.Edit: EditMovie(); break;
        case MenuOption.View: ViewMovie(); break;   
        case MenuOption.Delete: DeleteMovie(); break;
        case MenuOption.Quit: done = true; break;
    }
   
    //if (input == 'A')
    //    AddMovie();
    //else if (input == 'V')
    //    EditMovie();
    //else if (input == 'E')
    //    ViewMovie();
    //else if (input == 'D')
    //    DeleteMovie();
    //else if (input == 'Q')
    //    break;
}   while (!done);

/// Functions
void DisplayInformation ()
{
    Console.WriteLine("Moive Library");
    Console.WriteLine("ITSE 1430 Sample");
    Console.WriteLine("Fall 2022");
}

MenuOption DisplayMenu ()
{
    Console.WriteLine();
    //Console.WriteLine("--------------");
    Console.WriteLine("".PadLeft(10, '-'));
    Console.WriteLine("A)dd Movie");
    Console.WriteLine("E)dit Moive");
    Console.WriteLine("V)eiw Movie");
    Console.WriteLine("D)elete Moive");
    Console.WriteLine("Q)uit");

    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.A: return MenuOption.Add;
            case ConsoleKey.E: return MenuOption.Edit;
            case ConsoleKey.V: return MenuOption.View;
            case ConsoleKey.D: return MenuOption.Delete;
            case ConsoleKey.Q: return MenuOption.Quit;
        };

            //if (key.Key == ConsoleKey.A)
            //    return 'A';
            //else if (key.Key == ConsoleKey.V)
            //    return 'V';
            //else if (key.Key == ConsoleKey.E)
            //    return 'E';
            //else if (key.Key == ConsoleKey.D)
            //    return 'D';
            //else if (key.Key == ConsoleKey.Q)
            //    return 'Q';        
    } while(true); 
}

bool ReadBoolean ( string message )
{
    Console.Write ( message );

    //Looking for y or n
    do
    {
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Y)
            return true;
        else if (key.Key == ConsoleKey.N)
            return false;
    } while (true);    
}


string ReadString ( string message, bool required  )
{
    Console.Write(message);
    
    while (true)
    {
        string value = Console.ReadLine();

        if (value != "" || !required)
            return value;

        //Value is not empty 
        // emty required
        Console.WriteLine("Value is required");
    };

}

int ReadInt32 ( string message, int minimunValue, int maximumValue)
{
    Console.Write(message);

    do
    { 
         string value = Console.ReadLine();

        //inline vari declaration
        //int result;
        //if (Int32.TryParse(value, out result))
        //if (Int32.TryParse(value, out int result))
        if (Int32.TryParse(value, out var result))
        {
            if (result >= minimunValue && result <= maximumValue)
            return result;
        };

        //if (false)
            //break;    exit loop
            //continue;  exit iteration 

        Console.WriteLine("Value must be between " + minimunValue + " and " + maximumValue);
    } while (true);
}

void AddMovie ()
{
    title = ReadString("Enter a title: ", true);

    description = ReadString("Enter an optional description: ", false);

    runLength = ReadInt32("Enter a run legth (in minutes): ", 0, 300);

    releaseYear = ReadInt32("enter the release year: ", 1900, 2100);

    rating = ReadString("Entering the MPAA: ", true);

    isClassic = ReadBoolean("Is this a classic? ");


}

void EditMovie ()
{

}

void DeleteMovie ()
{
    if (title == "")         
        return;

    if (!ReadBoolean("Are you sure you want to delete the movie (Y/N)"))
        return;
    
    title = "";    

}

void ViewMovie()
{
    if (title == "")
    {
        Console.WriteLine("No movies available");
        return;
    }
    
    Console.WriteLine($"{title}  ({releaseYear})");
    
    //1- Concatenation
    //2- String.Format
    //3- String interpolations
    //To String
    //Console.WriteLine(releaseYear);
    //Console.WriteLine("Length:  " + runLength + "mins");
    //Console.WriteLine(releaseYear.ToString());
    //Console.WriteLine("Length:  " + runLength + "mins");
    //Console.WriteLine(String.Format("Length:  {0} mins ", runLength);
    //Console.WriteLine("Length:  {0} mins", runLength);
    Console.WriteLine($"Length:  {runLength} mins");
    
    Console.WriteLine($"Rated {rating}");
    Console.WriteLine($"This {(isClassic  ? "Is": "is Not")} a Classic");
    Console.WriteLine(description);
}