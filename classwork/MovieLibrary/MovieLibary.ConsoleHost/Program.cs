//namespace MovieLibrar.ConsoleHost
using MovieLibary;

DisplayInformation();

Movie movie = null;

var done = false;
do
{
    var input = DisplayMenu();
    Console.WriteLine();
    switch (input)
    {    
        case MenuOption.Add:
        {
            var theMovie = AddMovie();
            movie = theMovie.Clone();
            break;
        }

        case MenuOption.Edit: EditMovie(); break;
        case MenuOption.View: ViewMovie(movie); break;
        case MenuOption.Delete: DeleteMovie(); break;
        case MenuOption.Quit: done = true; break;
    };
} while (!done);

void DisplayInformation ()
{
    Console.WriteLine("Movie Library");
    Console.WriteLine("ITSE 1430 Sample");
    Console.WriteLine("Fall 2022");
}

MenuOption DisplayMenu ()
{
    Console.WriteLine();
    Console.WriteLine("".PadLeft(10, '-'));
    Console.WriteLine("A)dd Movie");
    Console.WriteLine("E)dit Movie");
    Console.WriteLine("V)iew Movie");
    Console.WriteLine("D)elete Movie");
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

    } while (true);
}

bool ReadBoolean ( string message )
{
    Console.Write(message);

    do { 
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Y)
            return true;
        else if (key.Key == ConsoleKey.N)
            return false;
    } while (true);
}

int ReadInt32 ( string message, int minimumValue, int maximumValue )
{
    Console.Write(message);

    do
    {
        string value = Console.ReadLine();
       
        if (Int32.TryParse(value, out var result))
            {
            if (result >= minimumValue && result <= maximumValue)
                return result;
        };
        
        

        Console.WriteLine("Value must be between " + minimumValue + " and " + maximumValue);
    } while (true);
}

string ReadString ( string message, bool required )
{
    //message = "Bob";
    Console.Write(message);

    while (true)
    {
        string value = Console.ReadLine();

        //if value is not empty or not required
        if (value != "" || !required)
            return value;

        // Value is empty and required
        Console.WriteLine("Value is required");
    };
}

Movie AddMovie ()
{
    Movie movie = new Movie("Title");

    //string title = "";
    //movie.title = ReadString("Enter a title: ", true);
    //movie.SetTitle(ReadString("Enter a title: ", true));
    movie.Title = ReadString("Enter a title: ", true);
 
    //string description = "";
    movie.Description = ReadString("Enter an optional description: ", false);

    //var description = movie._description;
    //var description = movie.GetDescription();

    //int runLength = 0; //in minutes
    movie.RunLength = ReadInt32("Enter a run length (in minutes): ", 0, 300);

    movie.ReleaseYear = ReadInt32("Enter the release year: ", 1900, 2100);
    if (movie.ReleaseYear >= Movie.YearColorWasIntroduced)
        Console.WriteLine("Wow that is an old movie");

    //var emptyMovie = Movie.Empty;

    movie.Rating = ReadString("Entering MPAA rating: ", true);

    movie.IsClassic = ReadBoolean("Is this a classic? ");

    return movie;
}

Movie GetSelectedMovie()
{
    //HACK: For now

    //object obj = "hello";
    //obj = 10;
    //obj = 4.15;
    //obj.ToString();

    return movie;
}

void DeleteMovie ()
{
    var selectedMovie = GetSelectedMovie();

    if (selectedMovie == null)
        return;

    if (!ReadBoolean($"Are you sure you want to delete the movie '{selectedMovie.Title}' (Y/N)? "))
        return;

    movie = null;
}

void EditMovie ()
{ }

void ViewMovie ( Movie movie )
{
    if (movie == null)
    {
        Console.WriteLine("No movies available");
        return;
    };
    Console.WriteLine($"{movie.Title} ({movie.ReleaseYear})"); 
    Console.WriteLine($"Length: {movie.RunLength} mins");
    Console.WriteLine($"Rated {movie.Rating}");
    Console.WriteLine($"Is Classic: {(movie.IsClassic ? "Yes" : "No")}");
    Console.WriteLine(movie.Description);

    var blackAndWhite = movie.IsBlackAndWhite;
}

void DisplayObject (object sender )
{
    string str = (string)sender;
    
    if (sender is string)
    {
        str = (string)sender;
    }

    str = sender as string;
    if (str != null) { };

    if (sender is string str1)
    {
    }

    if (str != null)
    {
        var str2 = str.ToString();
    }

    var str3 = (str != null) ? str.ToString() : "";

    str3 = str ?? ""; 

    str3 = str?.ToString();
}