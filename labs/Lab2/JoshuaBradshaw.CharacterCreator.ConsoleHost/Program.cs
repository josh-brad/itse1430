using JoshuaBradshaw.CharacterCreator;

//Character myCharacter = new Character("Bob", "Hunter", "Elf");
//Console.WriteLine(myCharacter.Name);
//myCharacter.Strength = 99;
//Console.WriteLine(myCharacter.Strength);

const ConsoleKey viewCharacterCommand = ConsoleKey.S;
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
        case viewCharacterCommand : ViewCharacter(theCharacter);        
        break;
        case ConsoleKey.Q: Quit();
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
    character.Race = ItemSelect(races);
    Console.WriteLine("Chosse Profession");
    character.Profession = ItemSelect(profession);
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

int ReadInt (string message, int minValue, int maxValue )
{
    Console.WriteLine("------------------");
    Console.WriteLine(message);

    while (true)
    {
        string value = Console.ReadLine();

        if (Int32.TryParse(value, out var result) && result >= minValue && result <= maxValue)
            return result;
        else
            Console.WriteLine($"Value must be between {minValue} and {maxValue}");

    }
}

void DisplayMenu ()
{
    Console.WriteLine("A) Add Character");
    Console.WriteLine("Q) Quit");
    Console.WriteLine( $"{viewCharacterCommand}) View");
}

string ItemSelect ( string[] array)
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