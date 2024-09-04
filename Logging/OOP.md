## Aspects of OOP Used

1. **Encapsulation**:
   - **Private Fields**: The `Logger` class encapsulates the log level, log formatter, and log writer using private fields (`_logLevel`, `_logFormatter`, and `_logWriter`).
   - **Public Methods**: The logging functionality is exposed through the `Log` method, hiding the implementation details of how the log is formatted and written.

2. **Abstraction**:
   - **Interfaces (`ILogWriter` and `ILogFormatter`)**: The use of interfaces provides an abstraction layer, allowing different implementations for writing logs (e.g., `ConsoleLogWriter`) and formatting logs (e.g., `JsonLogFormatter`). This hides the complexity of the specific implementations from the user of the `Logger` class.
   - **Enum (`LogLevel`)**: The `LogLevel` enum abstracts the different levels of logging, providing an easy-to-use set of predefined constants.

3. **Polymorphism**:
   - **Interface Implementation**: The `Logger` class depends on the `ILogWriter` and `ILogFormatter` interfaces rather than concrete classes. This allows the `Logger` to work with any class that implements these interfaces, enabling polymorphic behavior.
   - **Method Overriding**: Different implementations of `ILogFormatter` and `ILogWriter` can be created, allowing the `Logger` to work differently depending on which implementation is passed to it.

## What Is Missing?

1. **Dependency Injection**:
   - While the `Logger` class constructor takes dependencies (`ILogFormatter` and `ILogWriter`) via parameters, it could benefit from using a dependency injection framework to manage these dependencies. This would improve testability and configurability of the `Logger` class.

2. **Logging Strategy or Policy**:
   - The current implementation doesn't support multiple log writers (e.g., logging to both console and file). A more advanced design could include a logging strategy or policy to manage multiple log outputs.

3. **Extensibility**:
   - The current structure supports only one log formatter and writer per `Logger` instance. If you wanted to log in multiple formats or outputs simultaneously, the class would need to be modified.

## What Could Be Made Better?

1. **Support for Multiple Loggers**:
   - Consider allowing multiple log writers and formatters, perhaps by introducing a collection of `ILogWriter` and `ILogFormatter` objects. This would allow a single log message to be formatted differently and written to multiple outputs.

```
   private readonly IEnumerable<ILogWriter> _logWriters;
   private readonly IEnumerable<ILogFormatter> _logFormatters;
   
   public Logger(LogLevel logLevel, IEnumerable<ILogFormatter> logFormatters, IEnumerable<ILogWriter> logWriters)
   {
       _logLevel = logLevel;
       _logFormatters = logFormatters;
       _logWriters = logWriters;
   }

   public void Log(LogLevel logLevel, string message)
   {
       if (logLevel >= _logLevel)
       {
           foreach (var formatter in _logFormatters)
           {
               var formattedMessage = formatter.Format(logLevel, message);
               foreach (var writer in _logWriters)
               {
                   writer.Write(formattedMessage);
               }
           }
       }
   }
```

1. **Customizable Log Level Filtering**:
   - The `Logger` class currently only supports filtering based on a minimum log level. Extending this to allow more complex filtering rules or log level configurations for different outputs could provide greater flexibility.

2. **Error Handling and Logging Failures**:
   - The current implementation does not handle errors that might occur during logging (e.g., `Console.WriteLine` might fail if the console is closed). Adding error handling or fallback mechanisms would make the logging more robust.

3. **Performance Optimization**:
   - If logging is frequent and performance-sensitive, consider optimizing for scenarios where logging is disabled (i.e., when the log level is lower than `_logLevel`). You could check the log level early and return immediately to avoid unnecessary string formatting or JSON serialization.

4. **Thread Safety**:
   - The `Logger` class is not thread-safe in its current form. If the logger will be used in a multi-threaded environment, it might need synchronization mechanisms to ensure consistent behavior.

5. **Configuration from External Sources**:
   - Allowing the logger to be configured via external configuration files (e.g., JSON, XML) can enhance its flexibility, enabling dynamic changes without code modification.

By addressing these areas, the `Logger` implementation would become more robust, flexible, and extensible, aligning better with best practices in OOP design.
