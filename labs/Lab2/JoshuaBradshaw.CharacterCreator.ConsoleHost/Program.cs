using JoshuaBradshaw.CharacterCreator;
/* Joshua Bradshaw
 * ISTE 1430
 */
string[] races = { "Human", "Dwarf", "Gnome", "Elf", "Half Elf" };
string[] profession = { "Fighter", "Hunter", "Priest", "Rogue", "Wizard" };

Character theCharacter = null;
bool done = false;

do
{
    Console.WriteLine("------------------");
    DisplayMenu();
    ConsoleKeyInfo key = Console.ReadKey(true);
    switch (key.Key)
    {
        case ConsoleKey.A: theCharacter = AddCharacter();                  
        break;
        case ConsoleKey.V : ViewCharacter(theCharacter);        
        break;
        case ConsoleKey.Q: Quit();
        break;
        case ConsoleKey.E:
        {
            if (theCharacter != null)
                EditCharacter();
            else
                Console.WriteLine("No Current Character");
        }
        break;
        default: Console.WriteLine("Enter Valid Input");
        break;
    }

} while (!done);

Character AddCharacter ()
{
    Character character = new Character();

    character.Name = ReadString("Enter Character Name", true);
    Console.WriteLine("Chosse Race");
    character.Race = MenuItemSelect(races);
    Console.WriteLine("Chosse Profession");
    character.Profession = MenuItemSelect(profession);
    character.Biography = ReadString("Enter Optional Biography", false);
    character.Strength = ReadInt("Enter Strength", 1, 100);
    character.Intelligence = ReadInt("Enter Intelligence", 1, 100);
    character.Agility = ReadInt("Enter Agility", 1, 100);
    character.Constitution = ReadInt("Enter Constitution", 1, 100);
    character.Charisma = ReadInt("Enter Charisma", 1, 100);
    return character;    
}

void ViewCharacter (Character character)
{
    Console.WriteLine("------------------");
    if (character == null)
    {
        Console.WriteLine("No Character");
        return;
    }

    Console.WriteLine(character.ToString());
}

string ReadString (string message, bool required )
{
    Console.WriteLine("------------------");
    Console.WriteLine(message);

    while (true)
    {
        string value = Console.ReadLine();

        if (value != null || !required)
            return value;
        else
            Console.WriteLine("Value is required");
    }
}

int ReadInt (string message, int minValue, int maxValue)
{
    Console.WriteLine("------------------");
    Console.WriteLine(message);

    while (true)
    {
        string value = Console.ReadLine();

        if (Int32.TryParse(value, out var result) && result >= minValue && result <= maxValue )
            return result;
        else
            Console.WriteLine($"Value must be between {minValue} and {maxValue}");

    }
}

void DisplayMenu ()
{
    Console.WriteLine("A) Add Character");
    Console.WriteLine("Q) Quit");
    Console.WriteLine("V) View");
    Console.WriteLine("E) Edit Character");
}

string MenuItemSelect ( string[] array)
{
    Console.WriteLine("------------------");

    for (int i = 0; i < array.Length; i++)
    {
        int order = i + 1;
        Console.WriteLine(order + ". " + array[i]);
    }

    while (true)
    {
        int value = ReadInt("", 0, array.Length + 1);
        return array[value -1];
    }
        
}

void Quit ()
{
    Console.WriteLine("Are you sure you want to quit? Y/N");
    ConsoleKeyInfo key = Console.ReadKey(true);
    switch (key.Key)
    {
        case ConsoleKey.Y : done = true;
        break;
        case ConsoleKey.N: return;
    }
}     

void EditCharacter ()
{
    while(true)
    {
        DisplayEditMenu();

        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
        switch (keyPressed.Key)
        {
            case ConsoleKey.C:
            theCharacter.Name = ReadString("Edit Character Name: " + theCharacter.Name, true);
            break;
            case ConsoleKey.R:
            {
                Console.WriteLine(" Edit Race");
                theCharacter.Race = MenuItemSelect(races);
            }
            break;
            case ConsoleKey.P:
            {
                Console.WriteLine("Edit Profession");
                theCharacter.Profession = MenuItemSelect(profession);
            }
            break;
            case ConsoleKey.B:
            theCharacter.Biography = ReadString("Edit Optional Biography", false);
            break;
            case ConsoleKey.S:
            theCharacter.Strength = ReadInt("Edit Strength", 1, 100);
            break;
            case ConsoleKey.I:
            theCharacter.Intelligence = ReadInt("Edit Intelligence", 1, 100);
            break;
            case ConsoleKey.A:
            theCharacter.Agility = ReadInt("Edit Agility", 1, 100);
            break;
            case ConsoleKey.O:
            theCharacter.Constitution = ReadInt("Edit Constitution", 1, 100);
            break;
            case ConsoleKey.E:
            theCharacter.Charisma = ReadInt("Edit Charisma", 1, 100);
            break;
            case ConsoleKey.Q: return;
            default:
            Console.WriteLine("Enter Valid Input");
            break;
        }
    }
}

void DisplayEditMenu ()
{
    Console.WriteLine();
    Console.WriteLine("Choose What To Edit");
    Console.WriteLine();
    Console.WriteLine("C) Name");
    Console.WriteLine("R) Race");
    Console.WriteLine("P) Profession");
    Console.WriteLine("B) Biography");
    Console.WriteLine("S) Stength");
    Console.WriteLine("I) Intelligence");
    Console.WriteLine("A) Agility");
    Console.WriteLine("O) Constitution");
    Console.WriteLine("E) Charisma");
    Console.WriteLine("Q) Quit");
}