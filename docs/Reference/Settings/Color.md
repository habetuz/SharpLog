# Color Class

## Definition

`#!c# namespace Sharplog.Settings`

``` c#
public class Color
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**Color**](./)

:   Class containing colors for the [ConsoleOutput](ConsoleOutput.md).

### Constructors

| Name                                                                  |
| --------------------------------------------------------------------- |
| [Color()](#color)                                                     |
| [Color(ConsoleColor, ConsoleColor)](#colorconsolecolor-consolecolor)] |

### Properties

| Name                      | Type                                                                            | GET                 | SET                 |
| ------------------------- | ------------------------------------------------------------------------------- | ------------------- | ------------------- |
| [Background](#background) | [ConsoleColor](https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor) | :octicons-check-16: | :octicons-check-16: |
| [Foreground](#foreground) | [ConsoleColor](https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor) | :octicons-check-16: | :octicons-check-16: |

## Constructors

### Color()

```c#
public Color()
    : this(ConsoleColor.White, ConsoleColor.Black)
```

:   Initializes a new instance of the [Color](./) class.

### Color(ConsoleColor, ConsoleColor)

```c#
public Color(
    ConsoleColor foreground = ConsoleColor.White, 
    ConsoleColor background = ConsoleColor.Black)
```

:   Initializes a new instance of the [Color](./) class.

#### Parameter

`foreground` [ConsoleColor](https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor) · :octicons-milestone-16: `ConsoleColor.White`
:   The foreground color.

`background` [ConsoleColor](https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor) · :octicons-milestone-16: `ConsoleColor.Black`
:   The background color.

## Properties

### Background

```c#
public ConsoleColor Background { get; set; }
```

Type: [ConsoleColor](https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor)

:   Gets or sets the background color.

### Foreground

```c#
public ConsoleColor Foreground { get; set; }
```

Type: [ConsoleColor](https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor)

:   Gets or sets the foreground color.
