﻿int hours;

Console.WriteLine("Hours");
string value = Console.ReadLine();

hours = Int32.Parse(value);

Console.WriteLine("Hours");
value = Console.ReadLine();

double payRate = Double.Parse(value);

Console.WriteLine("Your pay is" + (hours * payRate));