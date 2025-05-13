using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

	public class MyProperties : INotifyPropertyChanged
	{
		private int x;
		private int y;

		public int X
		{
			get { return x; }
			set
			{
				x = value;
				OnPropertyChanged(nameof(x));
			}
		}
		public int Y
		{
			get => y;
			set
			{
				y = value;
				OnPropertyChanged(nameof(y));
			} 
		}
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
