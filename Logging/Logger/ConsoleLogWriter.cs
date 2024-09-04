// See https://aka.ms/new-console-template for more information

internal class ConsoleLogWriter : ILogWriter
{
    public void Write(string message)
    {
        Console.WriteLine(message);
    }
}