int hours;

Console.WriteLine("Hours");
string value = Console.ReadLine();

hours = Int32.Parse(value);

Console.WriteLine("Hours");
value = Console.ReadLine();

double payRate = Double.Parse(value);

Console.WriteLine("Your pay is" + (hours * payRate));

//Varible Declaration 
int x;
double distanceFromMoon = 0;
distanceFromMoon = 0;
char letterGrade;
bool isPassing;
//string name;
string firstname = "Dave", lastname = "Bob";
//firstname = lastname = name;
//int iHours
//Float fRate




//Block Statment
{
//    decimal payRate;
}

//distanceFromMoon = 10.5;
isPassing = distanceFromMoon > 0;

int y = 10;

Console.WriteLine(++y);
Console.WriteLine(y);

Console.WriteLine(--y);
Console.WriteLine(y);

Console.WriteLine(y++);
Console.WriteLine(y);

Console.WriteLine(++y);
Console.WriteLine(y);

//Strings

string emptyString = "";
string emptyString2 = String.Empty;
bool areEmptyStringsEqual = emptyString == emptyString2;
string nullString = null;
bool isEmptyString = (emptyString == null) || (emptyString == "");
isEmptyString = String.IsNullOrEmpty(emptyString);

//Literal
string someString = "Hello \" World";
string filePath = "C:\\windows\\system";

//Verbatim
filePath = @"C:\windows\system32";

//concatenation
string fullName = "Bob" + " " + "Smith";
fullName = String.Concat("Bob", " ", "Smith");
string someValues = String.Concat("You are ", 10, "Years Old", true);
string names = String.Join(", ", "Bob", "Sue", "Jan", "George");

int stringLength = fullName.Length;
isEmptyString = fullName.Length == 0;

//Manipulation
string upperName = fullName.ToUpper();
string lowerName = filePath.ToLower();

fullName = "   Bob Smith   ";
fullName = fullName.Trim(); //fullName.TrimStart().TrimEnd()
filePath = filePath.Trim('\\');

fullName = fullName.PadLeft(10); //.PadRight

filePath.StartsWith("C:\\");
filePath.EndsWith("\\");        //return boolean

bool areEqual = firstname == lastname;


string input = Console.ReadLine();

if (input == "A")
    Console.WriteLine("A");
else if (input == "B")
    Console.WriteLine("B");
else
    Console.WriteLine("Other");

// Compare 2
if (String.Compare(input, "A", StringComparison.OrdinalIgnoreCase) == 0)
    Console.WriteLine("A");
else if (String.Compare(input, "B", true) == 0)
    Console.WriteLine("B");

//Cpompare 3
if (String.Equals(input, "A", StringComparison.OrdinalIgnoreCase))
    Console.WriteLine("A");