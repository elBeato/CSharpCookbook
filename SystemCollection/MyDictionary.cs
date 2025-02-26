using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MyCollection
{
	internal class MyDictionary
	{
		private readonly Dictionary<string, string> dict = new()
			{
				{ "txt", "nodepad.exe" },
				{ "bmp", "paint.exe" },
				{ "pdf", "acrobat.exe" },
				{ "jpg", "inkscape.exe" }
			};

		private readonly SortedDictionary<string, string> sortedDict = new()
			{
				{ "txt", "nodepad.exe" },
				{ "bmp", "paint.exe" },
				{ "pdf", "acrobat.exe" },
				{ "jpg", "inkscape.exe" },
				{ ".avm", "moviemaker.exe"}
			};

		private readonly Dictionary<string, int> dictInt = new()
			{
				{ "player1", 4 },
				{ "player2", 20 },
				{ "player3", -1 },
				{ "player4", 0 },
				{ "player5", 8 }
			};

		public MyDictionary()
		{
			Program.LogTitle("Dictionaries");
		}

		public Dictionary<string, string> BehaviourOfDictionaries()
		{
			//Adding existing key to dictionary. 
			try
			{
				dict.Add("txt", "winword.exe");
			}
			catch (ArgumentException ex)
			{
				MyExceptions.Logger(ex);
			}
			
			// Add element to dictionary
			dict.Add("rft", "wordpad.exe");

			// Get element by indexer or item[TKey] by omit the .Item()
			Console.WriteLine($"Get key by Item property (or Indexer) Item[TKey] = ... / dict[\"txt\"] = {dict["txt"]}");

			// Change value of key with indexer
			dict["txt"] = "nodepad++.exe";

			// Key not found exception
			try
			{
				var test = dict["E3"];
			}
			catch (KeyNotFoundException ex)
			{
				MyExceptions.Logger(ex);
			}

			// Searching for keys that turn out not to be in the dict (efficent way)
			if (dict.TryGetValue("tif", out var value))
			{
				Console.WriteLine($"dict.TryGetValue is more efficient: {value}");
			}
			else
			{
				Console.WriteLine("key = \"tif\" not found");
			}

			Console.WriteLine("Enumerate dictionary element, the elements are retrieved as \"KeyValuePair\" objects:  ");
			foreach (KeyValuePair<string, string> kvp in dict)
			{
				Console.WriteLine($"Key = {kvp.Key}: Value = {kvp.Value}");
			}

			return dict;
		}

		public SortedDictionary<string, string> BehaviourOfSortedDictionaries()
		{

			return sortedDict;
		}

		public Dictionary<string, int> OrderDictionaries()
		{
			var test = dictInt.OrderBy(x => x.Value).First();
			return dictInt.OrderBy(x => x.Value).ToDictionary();
		}
	}
}
