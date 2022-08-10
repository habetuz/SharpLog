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

| Name                                                                                                       | Modifiers            | Returns         |
| ---------------------------------------------------------------------------------------------------------- | -------------------- | --------------- |
| [Initialize()](#initialize)                                                                                | `#!c# public static` | :octicons-x-16: |
| [Dispose()](#dispose)                                                                                      | `#!c# public static` | :octicons-x-16: |
| [Log(LogLevel, object, Type, string, Exception, string)](#logloglevel-object-type-string-exception-string) | `#!c# public static` | :octicons-x-16: |
| [LogDebug(object, Type, string, Exception, string)](#logdebugobject-type-string-exception-string)          | `#!c# public static` | :octicons-x-16: |
| [LogTrace(object, Type, string, Exception, string)](#logtraceobject-type-string-exception-string)          | `#!c# public static` | :octicons-x-16: |
| [LogInfo(object, Type, string, Exception, string)](#loginfoobject-type-string-exception-string)            | `#!c# public static` | :octicons-x-16: |
| [LogWarning(object, Type, string, Exception, string)](#logwarningobject-type-string-exception-string)      | `#!c# public static` | :octicons-x-16: |
| [LogError(object, Type, string, Exception, string)](#logerrorobject-type-string-exception-string)          | `#!c# public static` | :octicons-x-16: |
| [LogFatal(object, Type, string, Exception, string)](#logfatalobject-type-string-exception-string)          | `#!c# public static` | :octicons-x-16: |

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

### Log(LogLevel, object, Type, string, Exception, string)

```c#
public static void Log(
    LogLevel level, 
    object message, 
    Type origin, 
    string tag = null, 
    Exception exception = null, 
    string stackTrace = null)
```

:   Logs a log message containing the given information.

#### Parameter

`level` [LogLevel](LogLevel.md)  · :octicons-milestone-16: :octicons-x-16:
:   The log level. If the level is [`LogLevel.Fatal`](LogLevel.md#fatal) the program ends with code 0 after logging all remaining logs.

`message` [object](https://docs.microsoft.com/de-de/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`origin` [Type](https://docs.microsoft.com/de-de/dotnet/api/system.type)  · :octicons-milestone-16: :octicons-x-16:
:   The origin log.

`tag` [string](https://docs.microsoft.com/de-de/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [string](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The current stack trace. Retrieve it using `Environment.StackTrace`.

### LogDebug(object, Type, string, Exception, string)

```c#
public static void LogDebug(
    object message, 
    Type origin, 
    string tag = null, 
    Exception exception = null, 
    string stackTrace = null)
```

:   Logs a debug log message.

#### Parameter

`message` [object](https://docs.microsoft.com/de-de/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`origin` [Type](https://docs.microsoft.com/de-de/dotnet/api/system.type)  · :octicons-milestone-16: :octicons-x-16:
:   The origin log.

`tag` [string](https://docs.microsoft.com/de-de/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [string](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The current stack trace. Retrieve it using `Environment.StackTrace`.

### LogTrace(object, Type, string, Exception, string)

```c#
public static void LogTrace(
    object message, 
    Type origin, 
    string tag = null, 
    Exception exception = null, 
    string stackTrace = null)
```

:   Logs a trace log message.

#### Parameter

`message` [object](https://docs.microsoft.com/de-de/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`origin` [Type](https://docs.microsoft.com/de-de/dotnet/api/system.type)  · :octicons-milestone-16: :octicons-x-16:
:   The origin log.

`tag` [string](https://docs.microsoft.com/de-de/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [string](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The current stack trace. Retrieve it using `Environment.StackTrace`.

### LogInfo(object, Type, string, Exception, string)

```c#
public static void LogInfo(
    object message, 
    Type origin, 
    string tag = null, 
    Exception exception = null, 
    string stackTrace = null)
```

:   Logs an information log message.

#### Parameter

`message` [object](https://docs.microsoft.com/de-de/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`origin` [Type](https://docs.microsoft.com/de-de/dotnet/api/system.type)  · :octicons-milestone-16: :octicons-x-16:
:   The origin log.

`tag` [string](https://docs.microsoft.com/de-de/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [string](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The current stack trace. Retrieve it using `Environment.StackTrace`.

### LogWarning(object, Type, string, Exception, string)

```c#
public static void LogWarning(
    object message, 
    Type origin, 
    string tag = null, 
    Exception exception = null, 
    string stackTrace = null)
```

:   Logs a warning log message.

#### Parameter

`message` [object](https://docs.microsoft.com/de-de/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`origin` [Type](https://docs.microsoft.com/de-de/dotnet/api/system.type)  · :octicons-milestone-16: :octicons-x-16:
:   The origin log.

`tag` [string](https://docs.microsoft.com/de-de/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [string](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The current stack trace. Retrieve it using `Environment.StackTrace`.

### LogError(object, Type, string, Exception, string)

```c#
public static void LogError(
    object message, 
    Type origin, 
    string tag = null, 
    Exception exception = null, 
    string stackTrace = null)
```

:   Logs an error log message.

#### Parameter

`message` [object](https://docs.microsoft.com/de-de/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`origin` [Type](https://docs.microsoft.com/de-de/dotnet/api/system.type)  · :octicons-milestone-16: :octicons-x-16:
:   The origin log.

`tag` [string](https://docs.microsoft.com/de-de/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [string](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The current stack trace. Retrieve it using `Environment.StackTrace`.

### LogFatal(object, Type, string, Exception, string)

```c#
public static void LogFatal(
    object message, 
    Type origin, 
    string tag = null, 
    Exception exception = null, 
    string stackTrace = null)
```

:   Logs a fatal log message and exits the program with code 1.

#### Parameter

`message` [object](https://docs.microsoft.com/de-de/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message of the log. Gets converted to a string using `.toString()`.

`origin` [Type](https://docs.microsoft.com/de-de/dotnet/api/system.type)  · :octicons-milestone-16: :octicons-x-16:
:   The origin log.

`tag` [string](https://docs.microsoft.com/de-de/dotnet/api/system.string)  · :octicons-milestone-16: `null`
:   The tag of the log.

`exception` [Exception](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The exception of the log.

`stackTrace` [string](https://docs.microsoft.com/de-de/dotnet/api/system.exception)  · :octicons-milestone-16: `null`
:   The current stack trace. Retrieve it using `Environment.StackTrace`.