# ConsoleOutput Class

## Definition

`#!c# namespace Sharplog.Outputs`

``` c#
public class ConsoleOutput : Output
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [Output](Output.md)<br>
&emsp;&ensp;:material-subdirectory-arrow-right: [**ConsoleOutput**](./)

:   Output using the default console output.

### Constructors

| Name                                                                                                                                             |
| ------------------------------------------------------------------------------------------------------------------------------------------------ |
| [ConsoleOutput()](#consoleoutput)                                                                                                                |
| [ConsoleOutput(bool, string, LevelContainer, Dictionary<_LogLevel, Color_>)](#consoleoutputbool-string-levelcontainer-dictionary-loglevel-color) |

### Properties

| Name                          | Type                                                                                                                 | GET                 | SET                 |
| ----------------------------- | -------------------------------------------------------------------------------------------------------------------- | ------------------- | ------------------- |
| [Format](Output.md#format)    | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)                                                  | :octicons-check-16: | :octicons-check-16: |
| [Levels](Output.md#levels)    | [LevelContainer](../Settings/LevelContainer.md)                                                                      | :octicons-check-16: | :octicons-check-16: |
| [ColorEnabled](#colorenabled) | [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)                                                   | :octicons-check-16: | :octicons-check-16: |
| [Colors](#colors)             | [Dictionary<_LogLevel, Color_>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) | :octicons-check-16: | :octicons-check-16: |

### Inherited Methods

| Name                                            | Modifiers     | Returns         |
| ----------------------------------------------- | ------------- | --------------- |
| [Write(string, Log)](Output.md#writestring-log) | `#!c# public` | :octicons-x-16: |

## Constructors

### ConsoleOutput()

```c#
public ConsoleOutput()
    : this(true, null, null, null)
```

:   Initializes a new instance of the [ConsoleOutput](./) class.

### ConsoleOutput(bool, string, LevelContainer, Dictionary<_LogLevel, Color_>)

```c#
public ConsoleOutput(
    bool colorEnabled = true,
    string format = null,
    LevelContainer levels = null,
    Dictionary<LogLevel, Color> colors = null)
```

:   Initializes a new instance of the [ConsoleOutput](./) class.

#### Parameter

`colorEnabled` [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) · :octicons-milestone-16: `true`
:   If set to `true` color output is enabled.

`format` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `null`
:   The format.

`levels` [LevelContainer](../Settings/LevelContainer.md) · :octicons-milestone-16: `null`
:   The level settings.

`colors` [Dictionary<_LogLevel, Color_>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)
:   The colors.

## Properties

### ColorEnabled

```c#
public bool ColorEnabled { get; set; }
```

Type: [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)

:   Gets or sets a value indicating whether color is enabled.

### Colors

```c#
public LevelContainer Levels { get; set; }
```

Type: [Dictionary<_LogLevel, Color_>](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)

:   Gets or sets the colors for each log level.
