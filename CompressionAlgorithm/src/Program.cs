using CompressionAlgorithm;

while (true)
{
    Console.Write("Type a string, and then press Enter or 'n' to close the app: ");
    var input = Console.ReadLine();

    if (!ValidatedString.TryCreate(input, out var validatedInput))
    {
        Console.WriteLine("Invalid input.\n");
        continue;
    }

    if (validatedInput.Value.Equals("n", StringComparison.InvariantCultureIgnoreCase))
        break;
    
    var output = Compressor.StringCompress(validatedInput.Value);
    
    Console.WriteLine($"Output: {output}");
}