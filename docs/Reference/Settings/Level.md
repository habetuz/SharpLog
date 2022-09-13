# Level Class

## Definition

`#!c# namespace Sharplog.Settings`

``` c#
public class Level
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**Level**](./)

:   Class containing the settings for a log level.

### Constructors

| Name                                                 |
| ---------------------------------------------------- |
| [Level()](#level)                                    |
| [Level(char, bool, string)](#levelchar-bool-string)] |

### Properties

| Name                | Type                                                                                         | GET                 | SET                 |
| ------------------- | -------------------------------------------------------------------------------------------- | ------------------- | ------------------- |
| [Enabled](#enabled) | [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool) | :octicons-check-16: | :octicons-check-16: |
| [Format](#format)   | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)                          | :octicons-check-16: | :octicons-check-16: |
| [Short](#short)     | [char](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/char) | :octicons-check-16: | :octicons-check-16: |

## Constructors

### Level()

```c#
public Level()
    : this('-', true, null)
```

:   Initializes a new instance of the [level](./) class using default values.

### Level(char, bool, string)

```c#
public Level(
    char @short = '-',
    bool enabled = true,
    string format = null)
```

:   Initializes a new instance of the [Level](./) class.

#### Parameter

`@short` [char](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/char) · :octicons-milestone-16: `-`
:   The short for the log level.

`enabled` [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool) · :octicons-milestone-16: `true`
:   Wether the level is enabled.

`format` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `null`
:   The format.

## Properties

### Enabled

```c#
public bool Enabled { get; set; }
```

Type: [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

:   Gets or sets a value indicating whether this level is enabled.

### Format

```c#
public string Format { get; set; }
```

Type: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)

:   Gets or sets the optional format.

### Short

```c#
public char Short { get; set; }
```

Type: [char](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/char)

:   Gets or sets a char representing the log level.
