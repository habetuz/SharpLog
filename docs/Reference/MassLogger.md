---
title: MassLogger
---

# MassLogger
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs)

`#!c# namespace SharpLog`

`#!c# public class MassLogger`

`#!c# extends` [`Logger`](/Reference/Logger/)

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
| Type               | Property                                      | Get              | Set              |
| ------------------ | --------------------------------------------- | ---------------- | ---------------- | 
| `string`           | [`Ident`](/Reference/Logger/#ident)           |                  | :material-check: |()
| `bool`             | [`LogDebug`](/Reference/Logger/#logdebug)     |                  | :material-check: | 
| `bool`             | [`LogInfo`](/Reference/Logger/#loginfo)       |                  | :material-check: | 
| `bool`             | [`LogWarning`](/Reference/Logger/#logwarning) |                  | :material-check: | 
| `bool`             | [`LogError`](/Reference/Logger/#logerror)     |                  | :material-check: | 

### Methods
| Type               | Method                                                                                                                           |
| ------------------ | -------------------------------------------------------------------------------------------------------------------------------- |
| `void`             | [`Log`](#log)`(string text,` [`LoggerType`](/Reference/LoggerType/) `type, bool instant)`                                        |
| `void`             | [`Log`](#log_1)`(string text,` [`LoggerType `](/Reference/LoggerType/) `type = ` [`LoggerType`](/Reference/LoggerType/)`.Debug)` |

## Constructors
### `MassLogger`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs#L27)

`#!c# public MassLogger(int logPause)`

Initializes a new instance of the class.

#### Parameters
| Type  | Name       | Description                     | Default |
| ----- | ---------- | ------------------------------- | ------- |
| `int` | `logPause` | The interval time of the logger | `30000` |

---
## Properties
### `InfoLogText`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs#L38) · :material-sign-direction: Default: `#!c# ""`

`#!c# public string InfoLogText {set;}`

Gets or sets the text that is displayed before the info log.

---
## Methods
### `Log`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs#L46)

`#!c# public void Log(string text,` [`LoggerType `](/Reference/LoggerType/) `type, bool instant)`

Logs to the console with time, origin and type information.

#### Parameters
| Type                                   | Name    | Description                                                                                             | Default                                        |
| -------------------------------------- | ------- | ------------------------------------------------------------------------------------------------------- | ---------------------------------------------- |
| `string`                               | `text`  | The text to be logged                                                                                   | -                                              |
| [`LoggerType`](/Reference/LoggerType/) | `type`  | The type of the log                                                                                     | [`LoggerType`](/Reference/LoggerType/)`.Debug` |
| `bool`                                 | instant | If true, every log, and especially [`LoggerType`](/Reference/LoggerType/)`.Info`, gets logged instantly | `false`                                        |