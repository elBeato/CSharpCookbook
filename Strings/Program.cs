// See https://aka.ms/new-console-template for more information
using Strings;
// Int
Console.WriteLine(new string('@',70));
Console.WriteLine($"{new string('-', 20)} Tips and tricks for strings {new string('-', 21)}");
Console.WriteLine(new string('@', 70));

// Use string.join()
var ls = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Console.WriteLine(string.Join(", ", ls));

StringKeyWordVsStringClass();

StringFilePath();

static void StringFilePath()
{
	// The @ character in this instance defines a verbatim (wörtlich) string literal (buchstabengetreu).
	// With @ the following sequences are interpreted literally: --> (only a quote escape sequence ("") isn't interpreted literally)
	//		- "\\" for a backslash,
	//		- "\x0041" for an uppercase A,
	//		- "\u0041" for an uppercase A,
	var filepath1 = "D:\\Git_TSB\\TSB Anwendungsdaten\\source\\ConfigurationSolution\\ConfigurationUnitTest\\TestData";
	var filepath2 = @"D:\Git_TSB\TSB Anwendungsdaten\source\ConfigurationSolution\ConfigurationUnitTest\TestData";

	Console.WriteLine(filepath1);
	Console.WriteLine(filepath2);

	string s1 = "This is not verbatim text: \"This is my name: \x42\x65\x61\x74\"";
	string s2 = @"This is verbatim text: ""This is my name: \x42\x65\x61\x74""";

	Console.WriteLine(s1);
	Console.WriteLine(s2);
}

static void StringKeyWordVsStringClass()
{
	Modifications.CountCharsInStrings();
	Modifications.Replace();
	Modifications.SnippStrings();
	Modifications.StringEquality();
	Modifications.Counter();

	/// String and string are essentially the same in terms of functionality
	/// string is a C# keyword
	string s1 = "Hello world!";
	/// String is a class name in the .Net-Framework System and usually need using.System; but not in VS Studio
	String s2 = "Hello world!";
	Console.WriteLine($"{s1} {s2}");
}