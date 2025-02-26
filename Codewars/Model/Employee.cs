using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitecGalaxus.Model
{
	internal class Employee
	{
		public string LastName {  get; set; } = string.Empty;

		public string FirstName { get; set; } = string.Empty;

		public string Birthday { get; set; } = string.Empty ;

		public List<Color> FavoriteColors { get; set; } = [];


	}
}
