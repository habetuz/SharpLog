# LevelContainer Class

## Definition

`#!c# namespace Sharplog.Settings`

``` c#
public class LevelContainer
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**LevelContainer**](./)

:   Container for all log level specific settings.

### Constructors

| Name                                                                                                            |
| --------------------------------------------------------------------------------------------------------------- |
| [LevelContainer()](#levelcontainer)                                                                             |
| [LevelContainer(Level, Level, Level, Level, Level, Level)](#levelcontainerlevel-level-level-level-level-level)] |

### Properties

| Name                | Type              | GET                 | SET                 |
| ------------------- | ----------------- | ------------------- | ------------------- |
| [Debug](#debug)     | [Level](Level.md) | :octicons-check-16: | :octicons-check-16: |
| [Trace](#trace)     | [Level](Level.md) | :octicons-check-16: | :octicons-check-16: |
| [Info](#info)       | [Level](Level.md) | :octicons-check-16: | :octicons-check-16: |
| [Warning](#warning) | [Level](Level.md) | :octicons-check-16: | :octicons-check-16: |
| [Error](#error)     | [Level](Level.md) | :octicons-check-16: | :octicons-check-16: |
| [Fatal](#fatal)     | [Level](Level.md) | :octicons-check-16: | :octicons-check-16: |

### Methods

| Name                                                | Modifiers     | Returns           |
| --------------------------------------------------- | ------------- | ----------------- |
| [GetLevel(LogLevel level)](#getlevelloglevel-level) | `#!c# public` | [Level](Level.md) |

## Constructors

### LevelContainer()

```c#
public LevelContainer()
    : this(null, null, null, null, null, null)
```

:   Initializes a new instance of the [LevelContainer](./) class.

### LevelContainer(Level, Level, Level, Level, Level, Level)

```c#
public LevelContainer(
    Level debug = null,
    Level trace = null,
    Level info = null,
    Level warning = null,
    Level error = null,
    Level fatal = null)
```

:   Initializes a new instance of the [LevelContainer](./) class.

#### Parameter

`debug` [Level](Level.md) · :octicons-milestone-16: `null`
:   The debug settings.

`trace` [Level](Level.md) · :octicons-milestone-16: `null`
:   The trace settings.

`info` [Level](Level.md) · :octicons-milestone-16: `null`
:   The info settings.

`warning` [Level](Level.md) · :octicons-milestone-16: `null`
:   The warning settings.

`error` [Level](Level.md) · :octicons-milestone-16: `null`
:   The error settings.

`fatal` [Level](Level.md) · :octicons-milestone-16: `null`
:   The fatal settings.

## Properties

### Debug

```c#
public Level Debug { get; set; }
```

Type: [Level](Level.md)

:   Gets or sets the settings for the log level `debug`.

### Trace

```c#
public Level Trace { get; set; }
```

Type: [Level](Level.md)

:   Gets or sets the settings for the log level `trace`.

### Info

```c#
public Level Info { get; set; }
```

Type: [Level](Level.md)

:   Gets or sets the settings for the log level `info`.

### Warning

```c#
public Level Warning { get; set; }
```

Type: [Level](Level.md)

:   Gets or sets the settings for the log level `warning`.

### Error

```c#
public Level Error { get; set; }
```

Type: [Level](Level.md)

:   Gets or sets the settings for the log level `error`.

### Fatal

```c#
public Level Fatal { get; set; }
```

Type: [Level](Level.md)

:   Gets or sets the settings for the log level `fatal`.

## Methods

### GetLevel(LogLevel)

```c#
public Level GetLevel(LogLevel level)
```

:   Gets the settings for a level.

#### Parameter

`level` [LogLevel](../LogLevel.md)  · :octicons-milestone-16: :octicons-x-16:
:   The level the settings should be returned from.

#### Returns

Type: [Level](Level.md)
:   The requested settings.
