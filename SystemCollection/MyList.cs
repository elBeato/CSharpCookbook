using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace SystemCollection
{
	internal class MyList
	{
		private List<int> list;

		public MyList()
		{
			Program.LogTitle("Lists");
			list = [1, 2, 3, 3, 4, 5];
			Modifications();
			ShallowCopies();
			DeepCopies();
			RangesAndSlices();

			Console.WriteLine(string.Join(", ", SummationFunction(["1", "2", "5", "5"])));
			Console.WriteLine(string.Join(", ", SummationFunction([new MyShape(), new MyShape(), new MyShape()])));
		}

		public List<T> BehaviourOfList<T>(List<T> values)
		{
			// Iterating throw a List with index and values, Select return a selector
			// selector = A transform function to apply to each source element; the second parameter of the function represents the index of the source element.
			foreach (var el in values.Select((valueX, indexX) => new { indexX, valueX}))
			{
				Console.Write($"{el.valueX}");
			}

			// Iterating throw a List with anonymous type with Propierties 
			foreach (var el in values.Select((value, index) => new { Index = index, Value = value }))
			{
				Console.Write($"{el.Value}");
			}

			for (var i = 0; i < values.Count; i++)
			{
				var test = values[i];
			}

			Console.WriteLine();
			return [];
		}

		public void SpeedTestListIteration()
		{
			var myList = Enumerable.Range(1, 10_000_000).ToList();
			var sw = new Stopwatch();

			// Classic for loop
			sw.Start();
			List<int> newList1 = [];
			for (var i = 0; i < myList.Count; i++) {
				newList1.Add(myList[i] + 1);
			}
			sw.Stop();
			Console.WriteLine($"Classic for loop: \t\t\tMilliseconds = {sw.Elapsed}");

			sw.Restart();
			List<int> newList2 = [];
			var index = 0;
			foreach (var el in myList.Select((value, index) => new { index, value }))
			{
				newList2.Add(myList[index] + 1);
				index++;
			}
			sw.Stop();
			Console.WriteLine($"Foreach loop with index: \t\tMilliseconds = {sw.Elapsed}");

			sw.Restart();
			List<int> newList3 = [];
			foreach (var el in myList.Select((value, index) => new { index, value }))
			{
				newList3.Add(el.value + 1);
			}
			sw.Stop();
			Console.WriteLine($"Foreach with .Select((idx, val) \tMilliseconds = {sw.Elapsed}");
		}

		public static IEnumerable<T> SummationFunction<T>(IEnumerable<T> values)
		{
			var test = values.GetEnumerator();

			if (typeof(T).IsPrimitive || typeof(T) == typeof(string))
			{
				dynamic? sumValue = default(T); // Use dynamic to handle different types

				foreach (T value in values)
				{
					sumValue += value; // Sum with the current value
					yield return sumValue; // Return the current sum
				}
			}
		}

		public void Modifications()
		{
			list.AddRange(AdditinalData());
			list.AsReadOnly();
			var copy = list;
			list.Reverse();
			list.Add(0);
			copy.RemoveAt(2);

			Console.WriteLine("Copy of list with \"var copy = list\"");
			//Loggen: 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0
			Console.WriteLine(string.Join(", ", list));
			//Loggen: , 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0
			copy.ForEach(element => Console.Write($", {element}"));
			Console.WriteLine();
		}

		public void RangesAndSlices()
		{


			Console.WriteLine($"{new string('-', 15)} Ranges and Slices {new string('-', 15)}");
			Console.WriteLine(string.Join(", ", list));
			Console.WriteLine(list[^1]);  // Get element on the last place
			Console.WriteLine(string.Join(", ", list[^3..^0])); // Start from the third last to the last
			Console.WriteLine(string.Join(", ", list[9..^0])); // Start from the third last to the last
			Console.WriteLine(string.Join(", ", list[^3..])); // Start from the third last to the last
			Console.WriteLine(string.Join(", ", list[..^3])); // Start from the third last to the last
			Console.WriteLine(string.Join(", ", list[..9])); // Start from the third last to the last
			
			
			// Console.WriteLine(list[^0]); causing be an System.ArgumentOutOfRangeException
			// Console.WriteLine(list[^3..^1]);  // Output: System.Collections.Generic.List`1[System.Int32]
		}

		public void ShallowCopies()
		{
			Console.WriteLine("\nShallow copy with \".toList()\"");
			var copy = list.ToList();
			list.Add(333);
			list[0] = 1986;
			Console.WriteLine(string.Join(", ", list));
			Console.WriteLine(string.Join(", ", copy));
		}

		public void DeepCopies()
		{
			Console.WriteLine("\nShallow copy with \".toList()\"");
			List<string> list = ["string", "beat", "furrer"];
			var copy = list.ToList();
			list[0] = "String";
			Console.WriteLine(string.Join(", ", list));
			Console.WriteLine(string.Join(", ", copy));
		}

		public static IEnumerable<int> AdditinalData()
		{
			yield return 6;
			yield return 7;
			yield return 8;
			yield return 9;
			yield return 10;
		}
	}

	public class MyShape
	{
		public MyShape()
		{
			
		}

		int x = 0;
		int y = 0;
	}
}
