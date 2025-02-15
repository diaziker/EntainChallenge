namespace CompressionAlgorithm;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Entain Compression Algorithm\r");

        while (true)
        {
            Console.Write("Type a string, and then press Enter or 'n' to close the app: ");
            var input = Console.ReadLine();

            if (!ValidatedString.TryCreate(input, out var validatedInput))
            {
                Console.WriteLine("Invalid input.\n");
                continue;
            }

            if (input == "n")
                break;
            
            var output = Compressor.StringCompress(validatedInput.Value);
            
            Console.WriteLine($"Output: {output}");
        }
    }
}