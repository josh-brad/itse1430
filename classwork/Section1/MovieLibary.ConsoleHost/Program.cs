//Movie definition
string title = "";
string discription = "";
int runLength = 0; //in minutes
int releaseYear = 1900;
string rating = "";
bool isClassic = false;

AddMovie();

bool ReadBoolean ( string message )
{
    Console.Write ( message );

    //Looking for y or n
    ConsoleKeyInfo key = Console.ReadKey();
    if(key.Key == ConsoleKey.Y)
        return true;
    else if (key.Key == ConsoleKey.N)
        return false;

    return false;
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
        if (Int32.TryParse(value, out int result))
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

    discription = ReadString("Enter an optional description: ", false);

    runLength = ReadInt32("Enter a run legth (in minutes): ", 0, 300);

    releaseYear = ReadInt32("enter the release year: ", 1900, 2100);

    rating = ReadString("Entering the MPAA: ", true);

    isClassic = ReadBoolean("Is this a classic? ");


}