// See https://aka.ms/new-console-template for more information
using DigitecGalaxus;
using System.Globalization;

Console.WriteLine("Hello, World!");

var db = new DataHolder();

var jsonReader = new JsonReader();
// Read the JSON file into a string
string filePath = "employeeList.json";
string jsonString = File.ReadAllText(filePath);

db.Employees = jsonReader.Read(jsonString);

var test = db.Employees;

Console.WriteLine(string.Join("," , GetProductsOfAllIntsExceptAtIndex([1,2,3,4,5,6])));

static string Likes(string[] name)
{
	if (name is null)
		return "";
	if (name.Length == 0)
		return "no one likes this";
	if (name.Length == 1)
	{
		return string.Concat(name[0], " likes this");
	}
	if (name.Length == 2)
	{
		return string.Concat(string.Join(" and ", name), " likes this");
	}
	if (name.Length == 3)
	{
		return string.Concat(name[0], ", ", name[1], " and ", name[2], " like this");
	}
	if (name.Length >= 3)
	{
		return string.Concat(name[0], ", ", name[1], " and ", name.Length - 2, " others like this");
	}
	return "";
}

static int[] GetProductsOfAllIntsExceptAtIndex(int[] intArray)
{
	var factors = new List<int>();

	if (intArray.Length <= 1 || intArray == null)
		throw new ArgumentException("Hello: ", nameof(intArray));

	for (int j = 0; j < intArray.Length; j++)
	{
		var product = 1;
		// Make an array with the products
		for (int i = 0; i < intArray.Length; i++)
		{
			if (j == i)
				continue;
			product *= intArray[i];
		}
		factors.Add(product);
	}

	var test = new List<List<int>>();

	return factors.ToArray();
}

static string ToCamelCase(string str)
{
	var lst = str.Split("_").ToList();

	for (int i = 1; i < lst.Count; i++)
	{
		var temp = Char.ToUpper(lst[i][0]);
		lst[i] = temp + lst[i][1..];
	}

	return string.Join("", lst);
}

Console.WriteLine(ToCamelCase("the_stealth_warrior"));