using System.Reflection.Metadata;

namespace MyLINQ
{
	internal class StandardProblems
	{
		/// <summary>
		/// Count frequency of elements in a list or string, this function is frequently asked and used. 
		/// Creates a dictionary with all items and to number of occurences (count).
		/// 
		/// Think what if the questions: Which element occures most? Can me more then one element
		/// </summary>
		/// <param name="elements"></param>
		/// <returns>max occurence</returns>
		public int MaxFrequencyOfElement(List<int> elements)
		{
			var result = elements.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
			return result.Max(x => x.Value);
		}
	}
}
