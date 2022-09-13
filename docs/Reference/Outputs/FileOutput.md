# FileOutput Class

## Definition

`#!c# namespace Sharplog.Outputs`

``` c#
 public class FileOutput : AsyncOutput
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [Output](Output.md)<br>
&emsp;&ensp;:material-subdirectory-arrow-right: [AsyncOutput](AsyncOutput.md)<br>
&emsp;&ensp;&emsp;&ensp;:material-subdirectory-arrow-right: [**FileOutput**](./)

:   Output writing asynchronously to a file.

### Constructors

| Name                                                                                           |
| ---------------------------------------------------------------------------------------------- |
| [FileOutput()](#fileoutput)                                                                    |
| [FileOutput(string, int, string, LevelContainer)](#fileoutputstring-int-string-levelcontainer) |

### Properties

| Name                                      | Type                                                                | GET                 | SET                 |
| ----------------------------------------- | ------------------------------------------------------------------- | ------------------- | ------------------- |
| [Format](Output.md#format)                | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) | :octicons-check-16: | :octicons-check-16: |
| [Levels](Output.md#levels)                | [LevelContainer](LevelContainer.md)                                 | :octicons-check-16: | :octicons-check-16: |
| [SuspendTime](AsyncOutput.md#suspendtime) | [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)     | :octicons-check-16: | :octicons-check-16: |
| [Path](#path)                             | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) | :octicons-check-16: | :octicons-check-16: |

### Inherited Methods

| Name                                                                           | Modifiers     | Returns         |
| ------------------------------------------------------------------------------ | ------------- | --------------- |
| [Write(string, Log)](Output.md#writestring-log)                                | `#!c# public` | :octicons-x-16: |
| [Start()](AsyncOutput.md#start)                                                | `#!c# public` | :octicons-x-16: |
| [WriteNonBlocking((string, Log)[])](AsyncOutput.md#writenonblockingstring-log) | `#!c# public` | :octicons-x-16: |

## Constructors

### FileOutput()

```c#
public FileOutput()
    : this(".log", 500, null, null)
```

:   Initializes a new instance of the [FileOutput](./) class.

### FileOutput(string, int, string, LevelContainer)

```c#
public FileOutput(
    string path = ".log",
    int suspendTime = 500,
    string format = null,
    LevelContainer levels = null)
    : base(suspendTime, format, levels)
```

:   Initializes a new instance of the [FileOutput](./) class.

#### Parameter

`path` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `".log"`
:   The path.

`suspendTime` [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32) · :octicons-milestone-16: `500`
:   The suspend time between logs in ms.

`format` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `null`
:   The format.

`levels` [LevelContainer](LevelContainer.md) · :octicons-milestone-16: `null`
:   The level settings.

## Properties

### Path

```c#
public string Path { get; set; }
```

Type: [string](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)

:   Gets or sets the path the output should log to.
