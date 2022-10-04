using JoshuaBradshaw.CharacterCreator;

//Character myCharacter = new Character("Bob", "Hunter", "Elf");
//Console.WriteLine(myCharacter.Name);
//myCharacter.Strength = 99;
//Console.WriteLine(myCharacter.Strength);

const ConsoleKey viewCharacterCommand = ConsoleKey.S;

Character theCharacter = null;
bool done = false;

do
{
    DisplayMenu();
    ConsoleKeyInfo key = Console.ReadKey();
    switch (key.Key)
    {
        case ConsoleKey.A: theCharacter = AddCharacter();                  
        break;
        case viewCharacterCommand : ViewCharacter(theCharacter);        
        break;
    }

} while (!done);

Character AddCharacter ()
{
    Character character = new Character();

    character.Name = ReadString("Enter Character Name", true);
    character.Race = ReadString("Enter Race", true);
    character.Profession = ReadString("Enter Profession", true);
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

    if (character == null)
    {
        Console.WriteLine("No Character");
        return;
    }

    Console.WriteLine(character.ToString());
}

string ReadString (string message, bool required )
{
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