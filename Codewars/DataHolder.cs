using DigitecGalaxus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitecGalaxus
{
	internal class DataHolder
	{
		private List<Employee>	employees = new List<Employee>();

		public DataHolder()
		{
			
		}

		public List<Employee> Employees { get; set; }	
	}
}
