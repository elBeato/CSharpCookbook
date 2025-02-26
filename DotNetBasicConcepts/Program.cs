using DotNetBasicConcepts;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

internal class Program
{
	private static async Task Main(string[] args)
	{
		ConfigurationReader();

		//Multithreading
		await TasksConcepts();
		NullHandlerMethod();

		// Stop outside Visual studio to stop the console
		Console.ReadLine();
	}

	private static void ConfigurationReader()
	{
		var environment = Environment.GetEnvironmentVariable("NETCORE_ENVIRONMENT") ?? "Production";

		var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			.AddEnvironmentVariables();

		if (environment == "Development")
		{
			builder.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
		}

		IConfiguration config = builder.Build();


		Console.WriteLine(config.GetValue<int>("StarterInformation"));
		Console.WriteLine(config.GetValue<string>("User:FirstName") + " " + config.GetValue<string>("User:LastName"));
	}

	private static void NullHandlerMethod()
	{
		string? nullObject = null;

		try
		{
			NullHandler.ClassicNullChecker(nullObject);

		}
		catch (NullReferenceException ex)
		{
			Console.WriteLine($"{ex.Message}");
		}
	}

	private static async Task TasksConcepts()
	{
		// Depending on the set of the project: "Debug" or "Release", one or the other will preprocessed
		#if (DEBUG || NET8_0_OR_GREATER)
			Console.WriteLine("Hallo with trace");
		#else
			Console.WriteLine("Hallo without trace");
		#endif

		var text = new FileReader().ReadFromUrl(@"https://gist.githubusercontent.com/elBeato/f2fe191ed3e4d14a644d2740e325040c/raw/c8df975f79e47aee2f43460db22c3f72d74c86b5/gistfile1.txt");

		Console.WriteLine(text);

		// If I put an "await" before the then is no asyncronous Task anymore 
		// Inside this method should only be async/await constructs. With: Thread.Sleep() and .Wait() the entire 
		// Thread is blocked and I have no asyncron performance anymore
		_ = MyTask.AsyncTask(); // with a discard varible I indicate that I intentionally not await for the result. It is like fire-and-forget
		MyTask.SyncCode();

		var task1a = MyTask.FileReaderAsync(5000, "1");
		var task1b = MyTask.FileReaderAsync(4000, "2");
		var task1c = MyTask.FileReaderAsync(3000, "3");
		var task1d = MyTask.FileReaderAsync(2000, "4");

		await Task.WhenAll(task1a, task1b, task1c, task1d);

		PrintCurrentThreads();

		Console.ReadLine();
	}

	private static void PrintCurrentThreads()
	{
		// Informations about Thread.Sleep() and await Task.Delay()
		// Use Thread.Sleep() only in sychronous Threads
		MyTask.PrintInformations();
		Console.WriteLine(new string('-', 35));

		// Differences between Thread and Task
		MyTask.PrintThreadVsTask();

		// Get the current process
		Process currentProcess = Process.GetCurrentProcess();

		// Loop through all threads in the current process
		foreach (ProcessThread thread in currentProcess.Threads)
		{
			Console.WriteLine($"Thread ID: {thread.Id}");
			Console.WriteLine($"Thread State: {thread.ThreadState}");
			Console.WriteLine($"Priority: {thread.PriorityLevel}");
			Console.WriteLine($"Start Time: {thread.StartTime}");
			Console.WriteLine(new string('-', 35));
		}

	}
}