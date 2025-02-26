using System.Collections;
using System.Text;

namespace Strings
{
	public class Modifications
	{
		private const string str = "aaaabbcccXxx";

		public static string CountCharsInStrings()
		{
			Console.WriteLine($"\"Hello World\"");

			var strLower = str.ToLower();
			var unique = strLower.Distinct().ToList();
			var sb = new StringBuilder();

			foreach (char u in unique)
			{
				sb.Append(u);
				sb.Append(strLower.Count(x => x == u));
			}

			Console.WriteLine(sb);
			return sb.ToString();
		}

		public static IList Counter()
		{
			var ls = str.Where(char.IsLetter) // Filter only letters
				.GroupBy(c => c) // Group by each letter
				.Select(g => new { Letter = g.Key, Count = g.Count() }) // Create an anonymous type with letter and count
				.ToList(); // Convert to list

			ls.ForEach(l => Console.Write($"{l.Letter}{l.Count}"));
			//Console.WriteLine(string.Join("", letterCounts.Select(x => x.Letter.ToString() + x.Count)));
			return ls;
		}

		public static string Replace(string source = "The mountains are behind the clouds today.")
		{
			// Replace one substring with another with String.Replace.
			// Only exact matches are supported.
			var replacement = source.Replace("mountains", "peaks");
			Console.WriteLine($"The source string is <{source}>");
			Console.WriteLine($"The updated string is <{replacement}>");
			return replacement;
		}

		public static string SnippStrings()
		{
			var parts = $"{str[3..5]}";
			Console.WriteLine(parts);

			return parts;
		}

		public static bool StringEquality()
		{
			var str1 = "furrer";
			var str2 = "Furrer";
			var result = str1.Equals(str2, StringComparison.OrdinalIgnoreCase);
			Console.WriteLine(str1 == str2);
			Console.WriteLine(result);

			return str1.Equals(result);
		}
	}
}
