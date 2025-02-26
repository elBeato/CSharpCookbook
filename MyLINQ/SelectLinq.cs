using MyLINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLINQ
{
	internal class SelectLinq
	{
		private static string SEPERATOR = new string('-', 25);

		private int[] array = new int[10];
		private List<char> list = new List<char>();
		private Dictionary<int, string> dictionary = new Dictionary<int, string>();
		private HashSet<int> hashSet = new HashSet<int>();
		private SortedSet<int> sortedSet = new SortedSet<int>();

		public SelectLinq() 
		{
			Logger();
			array = Enumerable.Range(0, 10).ToArray();
			list = ['b', 'e', 'a', 't', '-',  'f', 'u', 'r', 'r', 'e', 'r'];
			dictionary = new()
			{
				{0, "Hello" },
				{6, "DICH" },
				{1, "World" },
				{8, "." },
				{4, "kenne" },
				{3, "Ich" }
			};
		}

		/// <summary>
		/// Basic example for .Select() to transform data in a new shape with e.g. x^2
		/// </summary>
		internal void Example1Select() 
		{
			var transformed = array.Select(x => x * x);
			foreach (var item in transformed)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Return a IEnumerable with the value of the dictionary and a space afterwards
		/// </summary>
		internal void Example2Select()
		{
			var transformed = dictionary.Values.Select(x => $"{x} ");
			foreach (var item in transformed)
			{
				Console.Write(item);
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Order the dictionary according the key and do the same as example 2
		/// </summary>
		internal void Example3Select() 
		{
			var transformed = dictionary.OrderBy(x => x.Key).ToDictionary().Values.Select(x => $"{x} ");
			foreach (var item in transformed)
			{
				Console.Write(item);
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Add 1 to any char in string
		/// </summary>
		internal void Example4Select()
		{
			list.ForEach(x => Console.Write(x));
			Console.WriteLine();

			var transformed = list.Select(x => (char)(x + 1));
			
			foreach (var item in transformed)
			{
				Console.Write(item);
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Project or extract properties from an Object and create an anonymous type with var obj = new { Property1 = xxx, Property2 = yyy };
		/// </summary>
		internal void Example5Select()
		{
			var seed = 1986;
			var users = new List<User>()
			{
				new(seed),
				new(seed),
				new(seed),
				new(seed),
				new(seed)
			};
			// Log each user
			users.ForEach(x => x.GetType().GetProperties().ToList().ForEach(prop => Console.Write($"{prop.Name} = {prop.GetValue(x)}\n")));

			//Merge into a new object
			var transformed = users.Select(x => new { BenutzerName = string.Concat(x.Name, " Wisi"), Alter = x.Age });
			foreach (var item in transformed)
			{
				Console.WriteLine($"Benutzername = {item.BenutzerName}");
			}
		}

		private void Logger()
		{
			Console.Write(SEPERATOR);
			Console.Write(" .SELECT() with LINQ");
			Console.Write(SEPERATOR);
			Console.WriteLine();
		}
	}
}
