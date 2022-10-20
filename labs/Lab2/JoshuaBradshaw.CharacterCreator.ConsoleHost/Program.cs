using System.Diagnostics;
using System.Xml.Linq;
using JoshuaBradshaw.CharacterCreator;
// Joshua Bradshaw
// ISTE 1430
// Fall Semester: 10-19-22

string[] races = { "Human", "Dwarf", "Gnome", "Elf", "Half Elf" };
string[] profession = { "Fighter", "Hunter", "Priest", "Rogue", "Wizard" };

Character theCharacter = null;
bool done = false;

Console.WriteLine("Joshua Bradshaw");
Console.WriteLine("ISTE 1430");
Console.WriteLine("Fall Semester: 10-19-22");
do
{
    Console.WriteLine("------------------");
    DisplayMenu();
    ConsoleKeyInfo key = Console.ReadKey(true);
    switch (key.Key)
    {
        case ConsoleKey.A: theCharacter = AddCharacter();                  
        break;
        case ConsoleKey.V: ViewCharacter(theCharacter);        
        break;
        case ConsoleKey.Q: Quit();
        break;
        case ConsoleKey.E:
        {
            if (theCharacter != null)
                EditCharacter();
            else
            {
                Console.WriteLine("------------------");
                Console.WriteLine("No Current Character");
            }
        }
        break;
        case ConsoleKey.D: DeleteCharacter();
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

void DeleteCharacter ()
{
    if (theCharacter != null)
    {
        Console.WriteLine("Are you sure you want delete current character? Y/N");
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.Y:
            theCharacter = null;
            break;
            case ConsoleKey.N: return;
        }
    }
    else
    {
        Console.WriteLine("------------------");
        Console.WriteLine("No Current Character");
    }
}

void ViewCharacter (Character character)
{
    Console.WriteLine("------------------");
    if (character == null)
    {
        Console.WriteLine("No Character");
        return;
    } else
        DisplayCharacter();    
}

void EditCharacter ()
{
    while (true)
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
                Console.WriteLine("------------------");
                Console.WriteLine(" Edit Race");
                theCharacter.Race = MenuItemSelect(races);
            }
            break;
            case ConsoleKey.P:
            {
                Console.WriteLine("------------------");
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

string ReadString (string message, bool required )
{
    Console.WriteLine("------------------");
    Console.WriteLine(message);

    while (true)
    {
        string value = Console.ReadLine();

        if (value != "" || required == false)
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
    Console.WriteLine("------------------");
    Console.WriteLine("Are you sure you want to quit? Y/N");
    ConsoleKeyInfo key = Console.ReadKey(true);
    switch (key.Key)
    {
        case ConsoleKey.Y : done = true;
        break;
        case ConsoleKey.N: return;
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

void DisplayCharacter ()
{
    Console.WriteLine("Name: ".PadRight(20, ' ') + theCharacter.Name);
    Console.WriteLine("Race: ".PadRight(20, ' ') + theCharacter.Race);
    Console.WriteLine("Profession: ".PadRight(20, ' ') + theCharacter.Profession);
    Console.WriteLine("Biography: ".PadRight(20, ' ') + theCharacter.Biography);
    Console.WriteLine("Strength: ".PadRight(20, ' ') + theCharacter.Strength);
    Console.WriteLine("Intelligence: ".PadRight(20, ' ') + theCharacter.Intelligence);
    Console.WriteLine("Agility: ".PadRight(20, ' ') + theCharacter.Agility);
    Console.WriteLine("Constitution: ".PadRight(20, ' ') + theCharacter.Constitution);
    Console.WriteLine("Charisma: ".PadRight(20, ' ') + theCharacter.Charisma);
}

void DisplayMenu ()
{
    Console.WriteLine("A) Add Character");    
    Console.WriteLine("V) View");
    Console.WriteLine("E) Edit Character");
    Console.WriteLine("D) Delete Character"); 
    Console.WriteLine("Q) Quit");
}
