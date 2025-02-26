namespace DigitecGalaxus
{
	internal class MyArray
	{
		public MyArray()
		{
			Program.LogTitle("Arrays");

			var ls = new int[] { -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 910, 25, 26 };
			Array.ForEach(ls, x => Console.Write($"{IsSqure(x)}\n"));
		}

		private static bool IsSqure(int n)
		{
			Console.Write($"Sqrt value: {n}\t= {Math.Sqrt(n):F2}\tgives:\t");
			return Math.Sqrt(n) % 1 == 0;
		}

	}

}
