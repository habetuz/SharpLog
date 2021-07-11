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
| Constructor                        |
| ---------------------------------- | 
| [`MassLogger`](#masslogger_1)`(int logPause)`   | 

### Properties
| Type               | Property           | Get              | Set              |
| ------------------ | ------------------ | ---------------- | ---------------- | 
| `string`           | [`InfoLogText`](#infologtext)  |                  | :material-check: | 

### Inherited properties
| Type               | Property           | Get              | Set              |
| ------------------ | ------------------ | ---------------- | ---------------- | 
| `string`           | [`Ident`](/Reference/Logger/#ident)        |                  | :material-check: |()
| `bool`             | [`LogDebug`](/Reference/Logger/#logdebug)     |                  | :material-check: | 
| `bool`             | [`LogInfo`](/Reference/Logger/#loginfo)      |                  | :material-check: | 
| `bool`             | [`LogWarning`](/Reference/Logger/#logwarning)   |                  | :material-check: | 
| `bool`             | [`LogError`](/Reference/Logger/#logerror)     |                  | :material-check: | 

### Methods
| Type               | Method                                                                                                                    |
| ------------------ | ------------------------------------------------------------------------------------------------------------------------- |
| `void`             | [`Log`](#log)`(string text,` [`LoggerType`](/Reference/LoggerType/) `type, bool instant)`                                      |
| `void`             | [`Log`](#log_1)`(string text,` [`LoggerType `](/Reference/LoggerType/) `type = ` [`LoggerType`](/Reference/LoggerType/)`.Debug)`  |

## Constructors
### `MassLogger`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs#L27)

`#!c# public MassLogger(int logPause)`

## Properties
### `InfoLogText`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs#L38)

`#!c# public string InfoLogText {set;}`

## Methods
### `Log`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs#L46)

`#!c# public void Log(string text,` [`LoggerType `](/Reference/LoggerType/) `type, bool instant)`

### `Log`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/MassLogger.cs#L63)

`#!c# public void Log(string text,` [`LoggerType `](/Reference/LoggerType/) `type =` [`LoggerType `](/Reference/LoggerType/)`.Debug)`