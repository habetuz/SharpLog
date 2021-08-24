---
title: "Logger"
---

# Logger
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs)

`#!c# namespace SharpLog`

`#!c# public class Logger`

:material-subdirectory-arrow-right: [`Logger`]()

---

Class for easy but clear logging.

## Summary
### Constructors
| Constructor               |
| ------------------------- | 
| [`Logger`](#logger_1)`()` | 

### Properties
| Type                              | Property                    | Get              | Set              |
| --------------------------------- | --------------------------- | ---------------- | ---------------- | 
| `string`                          | [`Ident`](#ident)           |                  | :material-check: | 
| `List<`[`IOutput`](IOutput.md)`>` | [`Outputs`](#outputs)       | :material-check: | :material-check: | 
| [`LogType`](LogType.md)           | [`LogFlags`](#logflags)     | :material-check: | :material-check: | 
| `bool`                            | [`LogDebug`](#logdebug)     |                  | :material-check: | 
| `bool`                            | [`LogInfo`](#loginfo)       |                  | :material-check: | 
| `bool`                            | [`LogWarning`](#logwarning) |                  | :material-check: | 
| `bool`                            | [`LogError`](#logerror)     |                  | :material-check: | 

### Methods
| Type               | Method                                                       |
| ------------------ | ------------------------------------------------------------ |
| `void`             | [`Log`](#log)`(object log,`  [`LogType `](LogType.md)  `type)` |

## Constructors
### `Logger`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L20)

`#!c# public Logger()`

Initializes a new instance of the [`Logger`]() class.

---
## Properties
### `Ident`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L40-L46) · :material-sign-direction: Default: `#!c# "NoName"`

`#!c# public string Ident {set;}`

Sets the identification-tag of the logger.

---
### `Outputs`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L51-L62) · :material-sign-direction: Default: `#!c# List<`[`IOutput`](IOutput.md)`#!c# > { new`  [`ConsoleOutput`](ConsoleOutput.md)  `#!c# }`

`#!c# public List<`[`IOutput`](IOutput.md)`#!c# > Outputs { get; set; }`

List with all output sources the logger should write to.

---
### `LogFlags`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L51-L62) · :material-sign-direction: Default: [`LogType`](LogType.md)`#!c# .Info |` [`LogType`](LogType.md)`#!c# .Warning |` [`LogType`](LogType.md)`#!c# .Error`

`#!c# public`  [`LogType`](LogType.md)  `LogFlags { get; set; }`

List with all output sources the logger should write to.

---
### `LogDebug`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L83-L96) · :material-sign-direction: Default: `#!c# false`

`#!c# public bool LogDebug {set;}`

Sets a value indicating whether [`Debug`](LogType.md) should be logged.

---
### `LogInfo`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L101-L114) · :material-sign-direction: Default: `#!c# true`

`#!c# public bool LogInfo {set;}`

Sets a value indicating whether [`Info`](LogType.md) should be logged.

---
### `LogWarning`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L119-L132) · :material-sign-direction: Default: `#!c# true`

`#!c# public bool LogWarning {set;}`

Sets a value indicating whether [`Warning`](LogType.md) should be logged.

---
### `LogError`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L137-L150) · :material-sign-direction: Default: `#!c# true`

`#!c# public bool LogError {set;}`

Sets a value indicating whether [`Error`](LogType.md) should be logged.

---
## Methods
### `Log`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L157-L174)

`#!c# public void Log(object log,` [`LogType `](LogType.md) `type =` [`LogType `](LogType.md)`.Debug)`

Logs to the outputs specified in [`Outputs`](#outputs) with time, origin and type information.

#### Parameters
| Type                       | Name   | Description             | Default                         |
| -------------------------- | ------ | ---------------------   | ------------------------------- |
| `object`                   | `log`  | The object to be logged | :octicons-diff-removed-16:      |
| [`LogType`](LogType.md)    | `type` | The type of the log     | [`LogType`](LogType.md)`.Debug` |