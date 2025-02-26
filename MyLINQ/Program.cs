// See https://aka.ms/new-console-template for more information
using MyLINQ;

Console.WriteLine(new string('-', 25));

// Deferred execution is a performance practice where the query only runs when it needed
var _ = new DeferredExecution();

var myIntegers = new List<int>() { 1, 2, 3, 4, 5 };

var test = myIntegers.Where(x => x % 2 == 0);

myIntegers.Add(6);

foreach (var i in test)
{
	Console.WriteLine(i);
}

var selectLinq = new SelectLinq();
selectLinq.Example1Select();
selectLinq.Example2Select();
selectLinq.Example3Select();
selectLinq.Example4Select();
selectLinq.Example5Select();


// Common problems and a fast solution
var commonProblems = new StandardProblems();
// How frequently a element occures inside a list or a string, number 4 and 6 occures 6 times
Console.WriteLine(commonProblems.MaxFrequencyOfElement(new List<int>() { 1, 2, 2, 5, 6, 4, 5, 3, 2, 1, 4, 5, 7, 8, 9, 5, 6, 4, 2, 3, 5, 1, 5, 4, 8, 1, 4, 4 }));


Console.ReadKey();