# BaseSettings Class

## Definition

`#!c# namespace Sharplog.Settings`

``` c#
public class BaseSettings : IDisposable
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**BaseSettings**](./)

*Implements*: [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

:   Base class containing all settings.

### Constructors

| Name                                                                                                                                                      |
| --------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [BaseSettings(string, LevelContainer, OutputContainer, Dictionary< string, Tag >)](#basesettingsstring-levelContainer-outputContainer-dictionary-string-tag) |

### Properties

| Name                | Type                                                                                                           | GET                 | SET                 |
| ------------------- | -------------------------------------------------------------------------------------------------------------- | ------------------- | ------------------- |
| [Format](#format)   | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)                                            | :octicons-check-16: | :octicons-check-16: |
| [Levels](#levels)   | [LevelContainer](LevelContainer.md)                                                                            | :octicons-check-16: | :octicons-check-16: |
| [Outputs](#outputs) | [OutputContainer](OutputContainer.md)                                                                          | :octicons-check-16: | :octicons-check-16: |
| [Tags](#tags)       | [Dictionary< string, Tag >](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) | :octicons-check-16: | :octicons-check-16: |

### Inherited methods

| Name                                                                                | Modifiers     | Returns         |
| ----------------------------------------------------------------------------------- | ------------- | --------------- |
| [Dispose()](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose) | `#!c# public` | :octicons-x-16: |

## Constructors

### BaseSettings(string, LevelContainer, OutputContainer, Dictionary< string, Tag >)

```c#
public BaseSettings(
    string fomat = "$D$: [$L$]$Cp{ [}s{] }$$Tp{ [}s{] }$ $M$$Ep{\nException: }$$Sp{\nStackTrace: }$",
    LevelContainer levels = null,
    OutputContainer outputs = null,
    Dictionary<string, Tag> tags = null)
```

:   Initializes a new instance of the [BaseSettings](./) class using default settings if not provided.

#### Parameter

`format` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `#!c# "$D$: [$L$]$Cp{ [}s{] }$$Tp{ [}s{] }$ $M$$Ep{\nException: }$$Sp{\nStackTrace: }$"`
:   The format.

`levels` [LevelContainer](LevelContainer.md) · :octicons-milestone-16: `null`
:   The levels.

`outputs` [OutputContainer](OutputContainer.md) · :octicons-milestone-16: `null`
:   The outputs.

`tags` [Dictionary< string, Tag >](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) · :octicons-milestone-16: `null`
:   The tags.

## Properties

### Format

```c#
public string Format { get; set; }
```

Type: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)

:   Gets or sets the general format.

### Levels

```c#
public LevelContainer Levels { get; set; }
```

Type: [LevelContainer](LevelContainer.md)

:   Gets or sets the general levels.

### Outputs

```c#
public OutputContainer Outputs { get; set; }
```

Type: [OutputContainer](OutputContainer.md)  

:   Gets or sets the general outputs.

### Tags

```c#
public Dictionary<string, Tag> Tags { get; set; }
```

Type: [Dictionary< string, Tag >](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)

:   Gets or sets the tags.
