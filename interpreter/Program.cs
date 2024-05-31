using ndimInterpreter;

internal class Program
{
	private static void Main(string[] args)
	{
		NdimParser ndim = new();
		Console.Write("Enter the filepath of your Ndim program: ");
		ndim.RunNdimFromFile(Console.ReadLine()!);
	}
}