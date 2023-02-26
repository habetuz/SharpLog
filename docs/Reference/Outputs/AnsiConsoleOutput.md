# AnsiConsoleOutput Class

## Definition

`#!c# namespace Sharplog.Outputs`

``` c#
public class AnsiConsoleOutput : Output
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [Output](Output.md)<br>
&emsp;&ensp;:material-subdirectory-arrow-right: [**AnsiConsoleOutput**](./)

:   Output using [Spectre.Console.AnsiConsole](https://spectreconsole.net/).

### Constructors

| Name                                                                                              |
| ------------------------------------------------------------------------------------------------- |
| [AnsiConsoleOutput()](#ansiconsoleoutput)                                                         |
| [AnsiConsoleOutput(bool, string?, LevelContainer?)](#ansiconsoleoutputbool-string-levelcontainer) |

### Properties

| Name                              | Type                                                                | GET                 | SET                 |
| --------------------------------- | ------------------------------------------------------------------- | ------------------- | ------------------- |
| [Format](Output.md#format)        | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) | :octicons-check-16: | :octicons-check-16: |
| [Levels](Output.md#levels)        | [LevelContainer](../Settings/LevelContainer.md)                     | :octicons-check-16: | :octicons-check-16: |
| [AnsiErrorPrint](#ansierrorprint) | [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)  | :octicons-check-16: | :octicons-check-16: |

### Inherited Methods

| Name                                            | Modifiers     | Returns         |
| ----------------------------------------------- | ------------- | --------------- |
| [Write(string, Log)](Output.md#writestring-log) | `#!c# public` | :octicons-x-16: |

## Constructors

### AnsiConsoleOutput()

```c#
public AnsiConsoleOutput()
    : this(false, null, null)
```

:   Initializes a new instance of the [AnsiConsoleOutput](./) class.

### AnsiConsoleOutput(bool, string?, LevelContainer?)

```c#
public AnsiConsoleOutput(
    bool ansiErrorPrint = false,
    string? format = null,
    LevelContainer? levels = null)
```

:   Initializes a new instance of the [AnsiConsoleOutput](./) class.

#### Parameter

`ansiErrorPrint` [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) · :octicons-milestone-16: `false`
:   If set to true the build in error logging capability of [Spectre.Console.AnsiConsole](https://spectreconsole.net/exceptions) get used.

`format` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `null`
:   The format.

`levels` [LevelContainer](../Settings/LevelContainer.md) · :octicons-milestone-16: `null`
:   The level settings.

## Properties

### AnsiErrorPrint

```c#
public bool AnsiErrorPrint { get; set; }
```

Type: [bool](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)

:   Gets or sets a value indicating wether the build in error logging capability of [Spectre.Console.AnsiConsole](https://spectreconsole.net/exceptions) should be used.
    Do not specify an error format if you set this parameter to `true`, else the error will be logged twice.