// See https://aka.ms/new-console-template for more information
public interface ILogFormatter
{
    public string Format(LogLevel logLevel, string message);
}
