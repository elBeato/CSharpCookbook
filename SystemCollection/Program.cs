// See https://aka.ms/new-console-template for more information
using DigitecGalaxus;
using MyCollection;
using SystemCollection;

var myList = new MyList();
myList.BehaviourOfList(new List<string> { "Hello", " ", "World", " - ", "What's", " ", "up?" });
myList.SpeedTestListIteration();


var myArray = new MyArray();

var myDict = new MyDictionary();
myDict.BehaviourOfDictionaries();
myDict.BehaviourOfSortedDictionaries();
myDict.OrderDictionaries().ToList().ForEach(x => Console.WriteLine(x));

Console.ReadKey();

public partial class Program
{
	private const int NUMBER_OF_CHARS = 35;

	internal static void LogTitle( string title)
	{
		Console.WriteLine($"\n{new string('-', NUMBER_OF_CHARS * 2 + title.Length + 2)}");
		Console.WriteLine($"{new string('-', NUMBER_OF_CHARS)} {title} {new string('-', NUMBER_OF_CHARS)}" );
		Console.WriteLine($"{new string('-', NUMBER_OF_CHARS * 2 + title.Length + 2)}\n");
	}
}