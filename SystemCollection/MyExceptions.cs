using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
	internal static class MyExceptions
	{ 
		public static void Logger(Exception ex) => Console.WriteLine($"Type: {ex.GetType()}, Message: {ex.Message}");
	}
}
