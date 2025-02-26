using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBasicConcepts
{
	internal class FileReader
	{
		internal async System.Threading.Tasks.Task<string> ReadFromUrl(string url)
		{
			using var client = new HttpClient();
			return await client.GetStringAsync(url);
		}
	}
}
