// See https://aka.ms/new-console-template for more information

using DotNet8TipsAndTricks;

var MY_CONSTANT_VALUE = 55;

//Some syntatic sugers
Console.Beep();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.BackgroundColor = ConsoleColor.DarkMagenta;
Console.Title = "Hello from the other side";
Console.OpenStandardError();

Console.WriteLine("Hello, World!");

Console.WriteLine(CalcHashcode(DateTime.Today));

//nameof() is used for: 
Console.WriteLine($"Instead of hard coding: {nameof(MY_CONSTANT_VALUE)}");

// Or to evaluate a property of a class
var prop = typeof(MyProperties).GetProperty(nameof(MyProperties.X));
Console.WriteLine(prop.Name);

// Another solution to find a list of PropertyInfo
var props = typeof(MyProperties).GetProperties().ToList();
props.ForEach(x => Console.WriteLine(x.Name));


// Create a sequence from 0 till 100 which are 101 numbers
var seq = Enumerable.Range(0, 100);
Console.WriteLine(seq.Count());
// Create a sequence of repetiion of zeros 
var rep = Enumerable.Repeat(0, 10);
Console.WriteLine(rep.Count());

Console.WriteLine("Type any text and stop with Enter: ");
var test = Console.ReadLine();
var test0 = test.Distinct().First();
var test2 = test0 + '1';
test.Distinct().ToList().ForEach(Console.Write);
Console.WriteLine($"\n{string.Join("", test2)}");
return;

int CalcHashcode(DateTime date)
{
	var test = new object();

	unchecked
	{
		int result = "myString".GetHashCode();
		return result;
	}
}