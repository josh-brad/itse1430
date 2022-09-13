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
