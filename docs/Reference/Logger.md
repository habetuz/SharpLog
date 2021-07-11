---
title: "Logger"
---

# Logger
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs)

`#!c# namespace SharpLog`

`#!c# public class Logger`

---

Class for easy but clear logging.

## Summary
### Constructors
| Constructor       |
| ------------------| 
| [`Logger`](#logger_1)`()`   | 

### Properties
| Type               | Property           | Get              | Set              |
| ------------------ | ------------------ | ---------------- | ---------------- | 
| `string`           | [`Ident`](#ident)        |                  | :material-check: | 
| `bool`             | [`LogDebug`](#logdebug)     |                  | :material-check: | 
| `bool`             | [`LogInfo`](#loginfo)      |                  | :material-check: | 
| `bool`             | [`LogWarning`](#logwarning)   |                  | :material-check: | 
| `bool`             | [`LogError`](#logerror)     |                  | :material-check: | 

### Methods
| Type               | Method                                                             |
| ------------------ | ------------------------------------------------------------------ |
| `void`             | [`Log`](#log)`(string text,` [`LoggerType `](/Reference/LoggerType/) `type =` [`LoggerType `](/Reference/LoggerType/)`.Debug)`       |

## Constructors
### `Logger`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L18)

`#!c# public Logger()`

## Properties
### `Ident`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L29)

`#!c# public string Ident {set;}`

### `LogDebug`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L40)

`#!c# public bool LogDebug {set;}`

### `LogInfo`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L51)

`#!c# public bool LogInfo {set;}`

### `LogWarning`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L62)

`#!c# public bool LogWarning {set;}`

### `LogError`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L73)

`#!c# public bool LogError {set;}`

## Methods
### `Log`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L86)

`#!c# public void Log(string text,` [`LoggerType `](/Reference/LoggerType/) `type =` [`LoggerType `](/Reference/LoggerType/)`.Debug)`