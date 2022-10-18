# Logging Class

## Definition

`#!c# namespace Sharplog`

``` c#
public static class Logging
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**Logging**](./)

:   Class responsible for logging.

### Methods

| Name                                                                                       | Modifiers            | Returns         |
| ------------------------------------------------------------------------------------------ | -------------------- | --------------- |
| [Initialize()](#initialize)                                                                | `#!c# public static` | :octicons-x-16: |
| [Dispose()](#dispose)                                                                      | `#!c# public static` | :octicons-x-16: |
| [LogDebug(object, string, Exception, bool)](#logdebugobject-string-exception-bool)     | `#!c# public static` | :octicons-x-16: |
| [LogTrace(object, string, Exception, bool)](#logtraceobject-string-exception-bool)     | `#!c# public static` | :octicons-x-16: |
| [LogInfo(object, string, Exception, bool)](#loginfoobject-string-exception-bool)       | `#!c# public static` | :octicons-x-16: |
| [LogWarning(object, string, Exception, bool)](#logwarningobject-string-exception-bool) | `#!c# public static` | :octicons-x-16: |
| [LogError(object, string, Exception, bool)](#logerrorobject-string-exception-bool)     | `#!c# public static` | :octicons-x-16: |
| [LogFatal(object, string, Exception, bool)](#logfatalobject-string-exception-bool)     | `#!c# public static` | :octicons-x-16: |

## Methods

### Initialize()

```c#
public static void Initialize()
```

:   Initializes the logger. The logger will automatically initialize itself with the first log function call. Use this function if you want to initialize before you start logging.

### Dispose()

```c#
public static void Dispose()
```

:   Releases resources and logs all remaining logs. Should be called before exiting the program.

### LogDebug(object, string, Exception, bool)

```c#
public static void LogDebug(
    object message,
    string tag = null, 
    Exception exception = null, 
    bool stackTrace = false)
```

:   Logs a debug log message.

#### Parameter

`message` [object](https://docs.microsoft.com/en-us/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.


`tag` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)  · :octicons-milestone-16: `false`
:   Wether the log should include the stack trace.

### LogTrace(object, string, Exception, bool)

```c#
public static void LogTrace(
    object message,
    string tag = null, 
    Exception exception = null, 
    bool stackTrace = false)
```

:   Logs a trace log message.

#### Parameter

`message` [object](https://docs.microsoft.com/en-us/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`tag` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)  · :octicons-milestone-16: `false`
:   Wether the log should include the stack trace.

### LogInfo(object, string, Exception, bool)

```c#
public static void LogInfo(
    object message,
    string tag = null, 
    Exception exception = null, 
    bool stackTrace = false)
```

:   Logs an information log message.

#### Parameter

`message` [object](https://docs.microsoft.com/en-us/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`tag` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)  · :octicons-milestone-16: `false`
:   Wether the log should include the stack trace.

### LogWarning(object, string, Exception, bool)

```c#
public static void LogWarning(
    object message,
    string tag = null, 
    Exception exception = null, 
    bool stackTrace = false)
```

:   Logs a warning log message.

#### Parameter

`message` [object](https://docs.microsoft.com/en-us/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`tag` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)  · :octicons-milestone-16: `false`
:   Wether the log should include the stack trace.

### LogError(object, string, Exception, bool)

```c#
public static void LogError(
    object message,
    string tag = null, 
    Exception exception = null, 
    bool stackTrace = false)
```

:   Logs an error log message.

#### Parameter

`message` [object](https://docs.microsoft.com/en-us/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`tag` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)  · :octicons-milestone-16: `false`
:   Wether the log should include the stack trace.

### LogFatal(object, string, Exception, bool)

```c#
public static void LogFatal(
    object message,
    string tag = null, 
    Exception exception = null, 
    bool stackTrace = false)
```

:   Logs a fatal log message and exits the program with code 1.

#### Parameter

`message` [object](https://docs.microsoft.com/en-us/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`tag` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [bool](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)  · :octicons-milestone-16: `false`
:   Wether the log should include the stack trace.
