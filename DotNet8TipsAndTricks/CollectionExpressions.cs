using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8TipsAndTricks
{
	public class CollectionExpressions
	{
		int[] number = [1, 2, 3, 4];
		List<int> list = [];

		public int[] Number { get { return number; } }

		private void SpreadExpression()
		{
			int[] numbers1 = [1, 2, 3];
			int[] numbers2 = [4, 5, 6];
			int[] moreNumbers = [.. numbers1, .. numbers2, 7, 8, 9];
		}
	}
}
