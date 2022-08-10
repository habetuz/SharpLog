# SettingsManager Class

## Definition

`#!c# namespace Sharplog`

``` c#
public static class SettingsManager
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**SettingsManager**](./)

:   Class responsible for managing the settings.

### Properties

| Name                        | Type                                                                                         | GET                 | SET                 |
| --------------------------- | -------------------------------------------------------------------------------------------- | ------------------- | ------------------- |
| [`Settings`](#settings)     | [`BaseSettings`](BaseSettings.md)                                                            | :octicons-check-16: | :octicons-check-16: |

### Methods

| Name                                        | Modifiers            | Returns         |
| ------------------------------------------- | -------------------- | --------------- |
| [ReloadSettings(bool)](#reloadsettingsbool) | `#!c# public static` | :octicons-x-16: |

## Properties

### Settings

```c#
public static BaseSettings Settings { get; set; }
```

Type: [BaseSettings](BaseSettings.md)

:   Gets or sets the settings.

## Methods

### ReloadSettings(bool)

```c#
public static void ReloadSettings(bool fromFile = true)
```

:   Reloads the settings.

#### Parameter

`fromFile` [bool](https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/builtin-types/bool)  · :octicons-milestone-16: `#!c# true`
:   The message of the log. Gets converted to a string using `.toString()`.
