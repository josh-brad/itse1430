//Movie definition
string title = "";
String discription = "";
int runLength = 0; //in minutes
int releaseYear = 1900;
string rating = "";
bool isClassic = false;

AddMovie();

string ReadString ( string message )
{
    Console.Write(message);

    string value = Console.ReadLine();

    return value;
}

int ReadInt32 ( string message )
{
    Console.Write(message);

    string value = Console.ReadLine();

    //inline vari declaration
    //int result;
    //if (Int32.TryParse(value, out result))
    if (Int32.TryParse(value, out int result))
        return result;

    return -1;
}

void AddMovie ()
{
    title = ReadString("Enter a title: ");

    discription = ReadString("Enter an optional description: ");

    runLength = ReadInt32("Enter a run legth (in minutes): ");

    releaseYear = ReadInt32("enter the release year: ");

    rating = ReadString("Entering the MPAA: ");

    Console.WriteLine("Is this a classic? ");
}