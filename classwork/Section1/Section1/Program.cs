int hours;

Console.WriteLine("Hours: ");
string value = Console.ReadLine();

hours = Int32.Parse(value);

Console.WriteLine("Pay rate: ");
value = Console.ReadLine();

double payRate = Double.Parse(value);

Console.WriteLine("Your pay is " + (hours * payRate));

int x;
double distanceFromMoon = 0;
//distanceFromMoon = 0;
char letterGrade;
bool isPassing;

string name;
string firstName = "Bob", lastName = "Smith ";

//firstName = lastName = name;
//firstName = "Sam";
//lastName = "Sam";

//string lastName;

//int iHours;
//float fRate;

//Block statement
//{
//    decimal payRate;
//}

//distanceFromMoon = 10.5;
isPassing = distanceFromMoon > 0;

int y = 10;

Console.WriteLine(++y);
Console.WriteLine(y);

Console.WriteLine(--y);
Console.WriteLine(y);

Console.WriteLine(y++);
Console.WriteLine(y);

Console.WriteLine(y--);
Console.WriteLine(y);

//Strings

string emptyString = "";
string emptyString2 = String.Empty;
bool areEmptyStringsEqual = emptyString == emptyString2;
string nullString = null;
bool isEmptyString = (emptyString == null) || (emptyString == "");
isEmptyString = String.IsNullOrEmpty(emptyString);

//Literal
string someString = "Hello \"World";
Console.WriteLine("Hello");
Console.WriteLine("World");
Console.WriteLine("Hello\nWorld");
string filePath = "C:\\windows\\system32";

//Verbatim
filePath = @"C:\windows\system32";

//Concatenation
string fullName = "Bob" + " " + "Smith";
fullName = String.Concat("Bob", " ", "Smith");
string someValues = String.Concat("You are ", 10, "Years Old", true);
string names = String.Join(", ", "Bob", "Sue", "Jan", "George");

int stringLength = fullName.Length;
isEmptyString = fullName.Length == 0;

//Manipulation
string upperName = fullName.ToUpper();
string lowerName = fullName.ToLower();

fullName = "    Bob Smith    ";
fullName = fullName.Trim();   //fullName.TrimStart().TrimEnd()
filePath = filePath.Trim('\\');

fullName = fullName.PadLeft(10);  //.PadRight(10);

//Comparison
filePath.StartsWith("C:\\", StringComparison.OrdinalIgnoreCase);
filePath.EndsWith("\\");

// Comparison 1 - relational ops (culture aware, case sensitive)
bool areEqual = firstName == lastName;

string input = Console.ReadLine();
//if (input == "A")
if (input.ToUpper() == "A")
    Console.WriteLine("A");
else if (input == "B")
    Console.WriteLine("B");
else
    Console.WriteLine("Other");

// Comparison 2 - String.Compare
if (String.Compare(input, "A", StringComparison.OrdinalIgnoreCase) == 0)
    Console.WriteLine("A");
else if (String.Compare(input, "B", true) == 0)
    Console.WriteLine("B");

// Comparison 3 - String.Equal
if (String.Equals(input, "A", StringComparison.OrdinalIgnoreCase))
    Console.WriteLine("A");
