using ndimInterpreter;

internal class Program
{
	private static void Main(string[] args)
	{
		NdimParser ndim = new();
		int exitCode = 0;
		Console.ForegroundColor = ConsoleColor.Green;
		Console.Write("Enter the filepath of your Ndim program: ");
		try
		{
			Console.ForegroundColor = ConsoleColor.White;
			ndim.RunNdimFromFile(Console.ReadLine()!);
		}
		catch (Exception ex)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"ERROR: {ex.Message}");
			exitCode = 10;
		}
		Console.WriteLine();
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.WriteLine($"Ndim program exited with code {exitCode}. Press any key to close.");
		Console.ReadKey();
	}
}