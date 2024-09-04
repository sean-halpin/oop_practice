// See https://aka.ms/new-console-template for more information
public class Logger
{
    private readonly LogLevel _logLevel;
    private readonly ILogFormatter _logFormatter;
    private readonly ILogWriter _logWriter;

    public Logger(LogLevel logLevel, ILogFormatter logFormatter, ILogWriter logWriter)
    {
        _logLevel = logLevel;
        _logFormatter = logFormatter;
        _logWriter = logWriter;
    }

    public void Log(LogLevel logLevel, string message)
    {
        if (logLevel >= _logLevel)
        {
            var formattedMessage = _logFormatter.Format(logLevel, message);
            _logWriter.Write(formattedMessage);
        }
    }
}
