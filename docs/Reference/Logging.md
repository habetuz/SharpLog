# Logging Class

## Definition

`#!c# namespace Sharplog`

``` c#
public static class Logging
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object?view=net-6.0)<br>
:material-subdirectory-arrow-right: [**Logging**](./)

:   Class responsible for logging.

### Methods

| Name                                                               | Modifiers            | Returns              |
| ------------------------------------------------------------------ | -------------------- | -------------------- |
| [Initialize()](#initialize)                                        | `#!c# public static` | :material-minus-box: |
| [Log(LogLevel, object, Type, string, Exception, string)](#log)     | `#!c# public static` | :material-minus-box: |
| [LogDebug(object, Type, string, Exception, string)](#logdebug)     | `#!c# public static` | :material-minus-box: |
| [LogTrace(object, Type, string, Exception, string)](#logtrace)     | `#!c# public static` | :material-minus-box: |
| [LogInfo(object, Type, string, Exception, string)](#loginfo)       | `#!c# public static` | :material-minus-box: |
| [LogWarning(object, Type, string, Exception, string)](#logwarning) | `#!c# public static` | :material-minus-box: |
| [LogError(object, Type, string, Exception, string)](#logerror)     | `#!c# public static` | :material-minus-box: |
| [LogFatal(object, Type, string, Exception, string)](#logfatal)     | `#!c# public static` | :material-minus-box: |

## Methods

### Initialize()

```c#
public static void Initialize()
```

:   Initializes the logger.

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

`level` [LogLevel](LogLevel.md)  · :octicons-milestone-16: :material-minus-box:
:   The level. If the level is [`LogLevel.Fatal`](LogLevel.md#fatal) the program ends with code 0.
