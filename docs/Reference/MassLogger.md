---
title: MassLogger
---

# MassLogger
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs)

`#!c# namespace SharpLog`

`#!c# public class MassLogger`

:material-subdirectory-arrow-right: [`Logger`](Logger.md)

&ensp;&ensp;&ensp;&ensp; :material-subdirectory-arrow-right: [`MassLogger`](MassLogger.md)

---

A logger to log a massive amount of similar info logs. It collects info logs and prints them out compressed at a set interval.

## Summary
### Constructors
| Constructor                                     |
| ----------------------------------------------- | 
| [`MassLogger`](#masslogger_1)`(int logPause)`   | 

### Properties
| Type               | Property                       | Get              | Set              |
| ------------------ | ------------------------------ | ---------------- | ---------------- | 
| `string`           | [`InfoLogText`](#infologtext)  |                  | :material-check: | 

### Inherited properties
| Type                              | Property                             | Get              | Set              |
| --------------------------------- | ------------------------------------ | ---------------- | ---------------- | 
| `string`                          | [`Ident`](Logger.md#ident)           |                  | :material-check: | 
| `List<`[`IOutput`](IOutput.md)`>` | [`Outputs`](Logger.md#outputs)       | :material-check: | :material-check: | 
| [`LogType`](LogType.md)           | [`LogFlags`](Logger.md#logflags)     | :material-check: | :material-check: | 
| `bool`                            | [`LogDebug`](Logger.md#logdebug)     |                  | :material-check: | 
| `bool`                            | [`LogInfo`](Logger.md#loginfo)       |                  | :material-check: | 
| `bool`                            | [`LogWarning`](Logger.md#logwarning) |                  | :material-check: | 
| `bool`                            | [`LogError`](Logger.md#logerror)     |                  | :material-check: | 

### Methods
| Type               | Method                                                                    |
| ------------------ | ------------------------------------------------------------------------- |
| `void`             | [`Log`](#log)`(object log,` [`LogType`](LogType.md) `type, bool instant)` |

## Constructors
### `MassLogger`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs#L30-L36)

`#!c# public MassLogger(int logPause)`

Initializes a new instance of the [`MassLogger`]() class.

#### Parameters
| Type  | Name       | Description                     | Default |
| ----- | ---------- | ------------------------------- | ------- |
| `int` | `logPause` | The interval time of the logger | `30000` |

---
## Properties
### `InfoLogText`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs##L41) · :material-sign-direction: Default: `#!c# ""`

`#!c# public string InfoLogText {get; set;}`

Gets or sets the text that is displayed before the info log.

---
## Methods
### `Log`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs#L49-L72)

`#!c# public void Log(object log,`  [`LogType `](LogType.md)  `#!c# type =`  [`LogType`](LogType.md)`#!c# .Debug , bool instant = false)`

Logs to the outputs specified in [`Outputs`](#outputs) with time, origin and type information.

#### Parameters
| Type                    | Name    | Description                                                                              | Default                         |
| ----------------------- | ------- | ---------------------------------------------------------------------------------------- | ------------------------------- |
| `object`                | `log`   | The object to be logged                                                                  | :octicons-diff-removed-16:      |
| [`LogType`](LogType.md) | `type`  | The type of the log                                                                      | [`LogType`](LogType.md)`.Debug` |
| `bool`                  | instant | If true, every log, and especially [`LogType`](LogType.md)`.Info`, gets logged instantly | `false`                         |