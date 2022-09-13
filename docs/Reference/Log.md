# Log Struct

## Definition

`#!c# namespace Sharplog`

``` c#
public struct Log
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype)<br>
&emsp;&ensp;:material-subdirectory-arrow-right: [**Log**](./)

:   Struct containing all information for a log.

### Constructors

| Name                                                                                                                                                        |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [`Log(LogLevel, object, Type, string, Exception, Level, string, DateTime, string)`](#logloglevel-object-type-string-exception-level-string-datetime-string) |

### Properties

| Name                             | Type                                                                      | GET                 | SET                 |
| -------------------------------- | ------------------------------------------------------------------------- | ------------------- | ------------------- |
| [`Level`](#level)                | [LogLevel](LogLevel.md)                                                   | :octicons-check-16: | :octicons-check-16: |
| [`Class`](#class)                | [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)           | :octicons-check-16: | :octicons-check-16: |
| [`Message`](#message)            | [object](https://docs.microsoft.com/en-us/dotnet/api/system.object)       | :octicons-check-16: | :octicons-check-16: |
| [`Tag`](#tag)                    | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)       | :octicons-check-16: | :octicons-check-16: |
| [`Exception`](#exception)        | [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception) | :octicons-check-16: | :octicons-check-16: |
| [`LevelSettings`](levelsettings) | [Level](Level.md)                                                         | :octicons-check-16: | :octicons-check-16: |
| [`Format`](#format)              | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)       | :octicons-check-16: | :octicons-check-16: |
| [`Time`](#time)                  | [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)   | :octicons-check-16: | :octicons-check-16: |
| [`StackTrace`](#stacktrace)      | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)       | :octicons-check-16: | :octicons-check-16: |

## Constructors

### Log(LogLevel, object, Type, string, Exception, Level, string, DateTime, string)

```c#
public Log(
    LogLevel level, 
    object message, 
    Type @class, 
    string tag, 
    Exception exception, 
    Level levelSettings, 
    string format, 
    DateTime time, 
    string stackTrace)
```

:   Initializes a new instance of the [Log](./) struct.

#### Parameter

`level` [LogLevel](LogLevel.md)  · :octicons-milestone-16: :octicons-x-16:
:   The level.

`message` [object](https://docs.microsoft.com/en-us/dotnet/api/system.object)  · :octicons-milestone-16: :octicons-x-16:
:   The message.

`@class` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)  · :octicons-milestone-16: :octicons-x-16:
:   The class.

`tag` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)  · :octicons-milestone-16: :octicons-x-16:
:   The tag.

`exception` [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)  · :octicons-milestone-16: :octicons-x-16:
:   The exception.

`levelSettings` [Level](Level.md)  · :octicons-milestone-16: :octicons-x-16:
:   The level settings.

`format` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)  · :octicons-milestone-16: :octicons-x-16:
:   The format.

`time` [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)  · :octicons-milestone-16: :octicons-x-16:
:   The time.

`stackTrace` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)  · :octicons-milestone-16: :octicons-x-16:
:   The stackTrace.

## Properties

### Level

```c#
public LogLevel Level { get; set; }
```

Type: [LogLevel](LogLevel.md)

:   Gets or sets the level of the log.

### Class

```c#
public Type Class { get; set; }
```

Type: [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)

:   Gets or sets the class from wich the log comes from.

### Message

```c#
public object Message { get; set; }
```

Type: [object](https://docs.microsoft.com/en-us/dotnet/api/system.object)

:   Gets or sets the message.

### Tag

```c#
public string Tag { get; set; }
```

Type: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)

:   Gets or sets the tag.

### Exception

```c#
public Exception Exception { get; set; }
```

Type: [Exception](https://docs.microsoft.com/en-us/dotnet/api/system.exception)

:   Gets or sets the exception.

### Format

```c#
public string Format { get; set; }
```

Type: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)

:   Gets or sets the format of the log.

### LevelSettings

```c#
public Level LevelSettings { get; set; }
```

Type: [Level](Level.md)

:   Gets or sets the level settings.

### Time

```c#
public DateTime Time { get; set; }
```

Type: [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)

:   Gets or sets the level settings.

### StackTrace

```c#
public string StackTrace { get; set; }
```

Type: [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.string)

:   Gets or sets the stack trace.
