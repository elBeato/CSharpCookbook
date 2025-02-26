// See https://aka.ms/new-console-template for more information

//Some syntatic sugers
Console.Beep();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.BackgroundColor = ConsoleColor.DarkMagenta;
Console.Title = "Hello from the other side";
Console.OpenStandardError();

Console.WriteLine("Hello, World!");

Console.WriteLine(CalcHashcode(DateTime.Today));

int CalcHashcode(DateTime date)
{
	var test = new object();

	unchecked
	{
		int result = "myString".GetHashCode();
		return result;
	}
}




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