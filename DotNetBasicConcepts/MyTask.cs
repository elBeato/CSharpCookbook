using System.Diagnostics;

namespace DotNetBasicConcepts
{
	internal static class MyTask
	{
		public static async Task AsyncTask()
		{
			var sw = new Stopwatch();
			sw.Start();
			Console.WriteLine("async: Starting");
			var delay = Task.Delay(20000);
			Console.WriteLine("async: Running for {0} seconds", sw.Elapsed.TotalSeconds);
			await delay;
			Console.WriteLine("async: Running for {0} seconds", sw.Elapsed.TotalSeconds);
			Console.WriteLine("async: Done");
		}

		public static void SyncCode()
		{
			var sw = new Stopwatch();
			sw.Start();
			Console.WriteLine("sync: Starting");
			Thread.Sleep(2000);
			Console.WriteLine("sync: Running for {0} seconds", sw.Elapsed.TotalSeconds);
			Console.WriteLine("sync: Done");
		}

		internal static void PrintInformations()
		{
			Console.WriteLine("Thread.Sleep(xxx): ");
			Console.WriteLine("Blocks the current thread.");
			Console.WriteLine("await Task.Delay(xxx): ");
			Console.WriteLine("Use that for a logical delay without blocking the entire thread");
		}

		internal static async Task FileReaderAsync(int time, string name)
		{
			Console.WriteLine("Starting file processing...");
			await Task.Delay(time); // Simulate file read
			Console.WriteLine($"File {name} is processed!");
		}

		internal static void PrintThreadVsTask()
		{
			Console.WriteLine("Thread: A basic single unit execution of CPU processing");
			Console.WriteLine(new string('-', 25));
			Console.WriteLine("- low-level concept\n- thread managed by operating system\n- start, stop, joining manually");
			Console.WriteLine("- Create explicitly by: Thread th = new Thread(\"SomeMethod\") --> th.Start();");
			Console.WriteLine("Thread creation and destruction are relatively expensive in term of resources");
			Console.WriteLine();
			Console.WriteLine("Task: A Higher-level abstraction provided by the Task Parallel Library (TPL) in .NET");
			Console.WriteLine(new string('-', 25));
			Console.WriteLine("- Task represent a asynchronous operation\n- typically execute some work in Threads\n- define the work\n- TPL handle, schedule & execute");
			Console.WriteLine("- Create explicitly by: Task ts = Task.Run(() => SomeMethod());");
			Console.WriteLine("Conclusion: Use almost always \"await Task.Delay()\"");
		}
	}
}