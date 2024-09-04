// See https://aka.ms/new-console-template for more information

using System.Text.Json;

public class JsonLogFormatter : ILogFormatter
{
    public string Format(LogLevel logLevel, string message)
    {
        var logEntry = new { Level = logLevel, Message = message };
        return JsonSerializer.Serialize(logEntry);
    }
}
