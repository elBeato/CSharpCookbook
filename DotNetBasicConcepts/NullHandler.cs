using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBasicConcepts
{
	internal static class NullHandler
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		/// <exception cref="NullReferenceException"></exception>
		internal static T ClassicNullChecker<T>(T obj)
		{
			Console.WriteLine("Traditinal null checker with if condition");
			if (obj == null)
			{
				throw new NullReferenceException();
			}
			return obj;
		}


	}
}
