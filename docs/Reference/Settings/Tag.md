# Tag Class

## Definition

`#!c# namespace Sharplog.Settings`

``` c#
public class Tag : IDisposable
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**Tag**](./)

*Implements*: [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

:   Class containing settings of a tag.

### Constructors

| Name                                                                                                 |
| ---------------------------------------------------------------------------------------------------- |
| [Tag()](#tag)                                                                                        |
| [Tag(bool, string, LevelContainer, OutputContainer)](#tagbool-string-levelcontainer-outputcontainer) |

### Properties

| Name                | Type                                                                                         | GET                 | SET                 |
| ------------------- | -------------------------------------------------------------------------------------------- | ------------------- | ------------------- |
| [Enabled](#enabled) | [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool) | :octicons-check-16: | :octicons-check-16: |
| [Format](#format)   | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)                          | :octicons-check-16: | :octicons-check-16: |
| [Levels](#levels)   | [LevelContainer](LevelContainer.md)                                                          | :octicons-check-16: | :octicons-check-16: |
| [Outputs](#outputs) | [OutputContainer](OutputContainer.md)                                                        | :octicons-check-16: | :octicons-check-16: |

### Inherited methods

| Name                                                                                | Modifiers     | Returns         |
| ----------------------------------------------------------------------------------- | ------------- | --------------- |
| [Dispose()](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose) | `#!c# public` | :octicons-x-16: |

## Constructors

### Tag()

```c#
public Tag()
    : this(true, null, null, null)
```

:   Initializes a new instance of the [Tag](./) class using default settings if not provided.

### Tag(bool, string, LevelContainer, OutputContainer)

```c#
public Tag(
    bool enabled = true,
    string format = null,
    LevelContainer levels = null,
    OutputContainer outputs = null)
```

:   Initializes a new instance of the [Tag](./) class using default settings if not provided.

#### Parameter

`enabled` [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool) · :octicons-milestone-16: `true`
:   Wether the tag is enabled.

`format` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `null`
:   The format.

`levels` [LevelContainer](LevelContainer.md) · :octicons-milestone-16: `null`
:   The levels.

`outputs` [OutputContainer](OutputContainer.md) · :octicons-milestone-16: `null`
:   The outputs.

## Properties

### Enabled

```c#
public bool Enabled { get; set; }
```

Type: [bool](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool)

:   Gets or sets a value indicating whether this tag is enabled.

### Format

```c#
public string Format { get; set; }
```

Type: [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)

:   Gets or sets the format.

### Levels

```c#
public LevelContainer Levels { get; set; }
```

Type: [LevelContainer](LevelContainer.md)

:   Gets or sets the level settings.

### Outputs

```c#
public OutputContainer Outputs { get; set; }
```

Type: [OutputContainer](OutputContainer.md)

:   Gets or sets the outputs.
