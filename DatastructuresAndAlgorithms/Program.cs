// See https://aka.ms/new-console-template for more information
using DatastructuresAndAlgorithms.Sets;
using System.Collections.Immutable;


var ints = new SortedSet<int>();
var rand = new Random();

for (int i = 0; i < 1_000_000; i++)
{
	ints.Add(rand.Next(-1_000_000_000, 1_000_000_000));
}

var ints_2 = Enumerable.Range(0, 10).Select(_ => rand.NextInt64()).ToImmutableSortedSet();

// path of the file that we want to create
string pathName = @".\Numbers.txt";

try
{
	//Write a line of text
	File.WriteAllText(pathName, string.Join("\n", ints));
}
catch (Exception e)
{
	Console.WriteLine("Exception: " + e.Message);
}
finally
{
	Console.WriteLine("Executing finally block.");
}

Console.WriteLine(ints.Contains(0));

Console.WriteLine(new SortedSets());

Console.WriteLine("Ende");

var test = new List<int>() { 1, 2, 3, 4 };
