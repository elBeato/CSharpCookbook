using System.Text.Json;

namespace JsonAndMore
{
	internal class MyHttpClient
	{
		/// <summary>
		/// Use the HttpClient only ones with static, 
		/// </summary>
		private static HttpClient _httpClient = new()
		{
			BaseAddress = new Uri("https://jsonplaceholder.typicode.com/")
		};

		/// <summary>
		/// Using the JsonSerializerOptions only ones as static
		/// Property: WriteIndented = true - Makes it easier to read. 
		/// {
		///		"name": "Anna Nalani",
		///		"age": 1
		/// }
		/// Property: WriteIndented = false - Is a compact output without extra whitespaces or line brakes 
		/// </summary>

		private static readonly JsonSerializerOptions _serializerOptions = new(JsonSerializerDefaults.Web)
		{
			WriteIndented = true,
		};

		/// <summary>
		/// It is a good idea to close the tcp connection immediatly after the PooledConnectionLifetime. 
		/// But it is still connected. 
		/// </summary>
		private static SocketsHttpHandler socketsHandler = new()
		{
			PooledConnectionLifetime = TimeSpan.FromSeconds(5)  // just for demo purpose
		};

		public MyHttpClient()
		{
			GetAsync(_httpClient).Wait();
		}

		public async Task GetAsync(HttpClient httpClient)
		{
			try
			{
				using HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync("/photos");

				Console.WriteLine(httpResponseMessage.EnsureSuccessStatusCode());

				var jsonResponse_2 = await httpResponseMessage.Content.ReadAsStringAsync();
				await Task.Delay(6000);
				// Nothing happen
				var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

				var photosList = JsonSerializer.Deserialize<List<Photos>>(jsonResponse, _serializerOptions);
				if (photosList is not null)
				{

					photosList[0..5].ForEach(x => Console.WriteLine(x.Title));
				}
				else
				{
					Console.WriteLine($"List is empty: {jsonResponse}");
				}
			}
			catch (Exception ex)
			{
				Console.Write(ex.Message);
			}
			Console.WriteLine($"Start sleep current thread: {DateTime.UtcNow}");
			Thread.Sleep(500);
			Console.WriteLine($"Stop sleeping: {DateTime.UtcNow}");

			Console.WriteLine($"Start delay current thread: {DateTime.UtcNow}");
			await Task.Delay(500);
			Console.WriteLine($"Stop sleeping: {DateTime.UtcNow}");
		}
	}
}