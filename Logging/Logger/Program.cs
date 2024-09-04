// See https://aka.ms/new-console-template for more information
Console.WriteLine("Running!");

var logger = new Logger(LogLevel.DEBUG, new JsonLogFormatter(), new ConsoleLogWriter());

logger.Log(LogLevel.INFO, "This is an informational message");
logger.Log(LogLevel.ERROR, "This is an error message");
logger.Log(LogLevel.DEBUG, "This is a debug message");

