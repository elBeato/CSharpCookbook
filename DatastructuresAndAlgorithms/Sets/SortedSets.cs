using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatastructuresAndAlgorithms.Sets
{
	internal static class Data
	{
		public static List<int> IntegerDataSet(bool randomized = false)
		{
			if (randomized)
			{
				var list = new List<int>();
				var rand = new Random();
				foreach (int _ in Enumerable.Range(0, 10000000))
				{
					list.Add(rand.Next());
				}
				return list;
			}
			return [2, 5, 1958, 165, 155, 123, 1, 598, 4, 184, 65154, 4741, 51, 5, 1, 5, 4, 51, 158];
		}
	}

	internal class MySortedSet : IDisposable
	{
		private SortedSet<int>? _sorted;
		private SortedSet<int>? _copy;

		public MySortedSet()
		{
			_copy = [];
			_sorted = new SortedSet<int>(Data.IntegerDataSet(true));
		}

		public void SortedSet()
		{
			Console.WriteLine("\n@@@ Sorted sets: @@@");
			
			_copy = _sorted;

			if (_sorted is not null)
			{
				Console.WriteLine(_sorted.Count(x => x == 0));
				_sorted.Add(0);
				_sorted.Add(0);
			}
			
			Console.WriteLine($"Count zeros in sorted: {_sorted.Count(x => x == 0)}");
			Console.WriteLine($"Count zeros in copies: {_sorted.Count(x => x == 0)}");
			Console.WriteLine();
		}

		public void Dispose()
		{
			if (_copy is not null)
			{
				_copy.Clear();
				_copy = null;
			}
			if (_sorted is not null)
			{
				_sorted.Clear();
				_sorted = null;
			}

			GC.SuppressFinalize(this);
			GC.Collect();
		}

		~MySortedSet()
		{
			Dispose(); // Finalizer to ensure resources are cleaned up if Dispose wasn't called
		}
	}

	internal class SortedSets
	{
		public SortedSets()
		{
			using var mySortedSet = new MySortedSet();
			mySortedSet.SortedSet();
			mySortedSet.Dispose();
		}
	}
}
