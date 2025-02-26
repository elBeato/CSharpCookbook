using DigitecGalaxus.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DigitecGalaxus
{
	internal class JsonReader
	{

		private DataHolder _dataHolder;

		public JsonReader()
		{
			
		}

		internal List<Employee> Read(string jsonString)
		{
			if (jsonString == null)
				return JsonSerializer.Deserialize<List<Employee>>(jsonString, 
					new JsonSerializerOptions { PropertyNameCaseInsensitive = true});
			return new List<Employee>();
		}
	}
}
