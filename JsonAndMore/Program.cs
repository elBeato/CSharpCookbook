// See https://aka.ms/new-console-template for more information
using JsonAndMore;
using System.Net.Http.Json;
using System.Reflection;

new MyHttpClient();

//PrintProperties(user);

static void PrintProperties(object obj)
{
	Type type = obj.GetType();
	PropertyInfo[] properties = type.GetProperties();

	foreach (PropertyInfo property in properties)
	{
		var value = property.GetValue(obj) ?? "N/A"; // Handle null values
		Console.WriteLine($"{property.Name}: {value}");
	}
}

static void PrintPropertiesLinq(object obj)
{
	Type type = obj.GetType();
	PropertyInfo[] properties = type.GetProperties();

	properties
	.Select(property => new
	{
		property.Name,
		Value = property.GetValue(obj) ?? "N/A" // Handle null values
	})
	.ToList()
	.ForEach(item => Console.WriteLine($"{item.Name}: {item.Value}"));

}

public class User
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Username { get; set; }
	public string? Email { get; set; }
}

public record Photos(int AlbumId, int Id, string? Title, string? Url, string? ThumbnailUrl);
