using ndimInterpreter;

internal class Program
{
	private static void Main(string[] args)
	{
		NdimParser ndim = new();
		Console.Write("Enter the filepath of your Ndim program: ");
		ndim.RunNdimFromFile(Console.ReadLine()!);
		Console.WriteLine();
		Console.WriteLine("Ndim program finished. Press any key to close.");
		Console.ReadKey();
	}
}
