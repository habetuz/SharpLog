# Output Class

## Definition

`#!c# namespace Sharplog.Outputs`

``` c#
public abstract class Output
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**Output**](./)

:   Base class for all outputs.

### Constructors

| Name                                                           |
| -------------------------------------------------------------- |
| [Output(string, LevelContainer)](#outputstring-levelcontainer) |

### Properties

| Name              | Type                                                                | GET                 | SET                 |
| ----------------- | ------------------------------------------------------------------- | ------------------- | ------------------- |
| [Format](#format) | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) | :octicons-check-16: | :octicons-check-16: |
| [Levels](#levels) | [LevelContainer](LevelContainer.md)                                 | :octicons-check-16: | :octicons-check-16: |

### Methods

| Name                                   | Modifiers              | Returns         |
| -------------------------------------- | ---------------------- | --------------- |
| [Write(string, Log)](#writestring-log) | `#!c# public abstract` | :octicons-x-16: |

## Constructors

### Output(string, LevelContainer)

```c#
public Output(
    string format = null, 
    LevelContainer levels = null)
```

:   Initializes a new instance of the [Output](./) class.

#### Parameter

`format` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `null`
:   The format.

`levels` [LevelContainer](LevelContainer.md) · :octicons-milestone-16: `null`
:   The level settings.

## Properties

### Format

```c#
public string Format { get; set; }
```

Type: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)

:   Gets or sets the format for the output.

### Levels

```c#
public LevelContainer Levels { get; set; }
```

Type: [LevelContainer](LevelContainer.md)

:   Gets or sets the level settings for the output.

## Methods

### Write(string, Log)

```c#
public abstract void Write(string formattedLog, Log log)
```

:   Writes the specified formatted log.

#### Parameter

`formattedLog` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)  · :octicons-milestone-16: :octicons-x-16:
:   The formatted log.

`log` [Log](Log.md)  · :octicons-milestone-16: :octicons-x-16:
:   The log information.
