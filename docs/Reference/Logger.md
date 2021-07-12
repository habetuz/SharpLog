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
| Constructor               |
| ------------------------- | 
| [`Logger`](#logger_1)`()` | 

### Properties
#### `public`
| Type               | Property                    | Get              | Set              |
| ------------------ | --------------------------- | ---------------- | ---------------- | 
| `string`           | [`Ident`](#ident)           |                  | :material-check: | 
| `bool`             | [`LogDebug`](#logdebug)     |                  | :material-check: | 
| `bool`             | [`LogInfo`](#loginfo)       |                  | :material-check: | 
| `bool`             | [`LogWarning`](#logwarning) |                  | :material-check: | 
| `bool`             | [`LogError`](#logerror)     |                  | :material-check: | 

### Methods
#### `public`
| Type               | Method                                                                                                                               |
| ------------------ | ------------------------------------------------------------------------------------------------------------------------------------ |
| `void`             | [`Log`](#log)`(string text,` [`LoggerType `](/Reference/LoggerType/) `type =` [`LoggerType `](/Reference/LoggerType/)`.Debug)`       |

## Constructors
### `Logger`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L18)

`#!c# public Logger()`

Default constructor for the logger.

---
## Properties
### `Ident`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L29)

`#!c# public string Ident {set;}`

Sets the identification-tag for the logger.

`#!c# "NoName"` on default.

---
### `LogDebug`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L40)

`#!c# public bool LogDebug {set;}`

Sets a value indication whether [`Debug`](/Reference/LoggerType/) should be logged.

`#!c# false` on default. 

---
### `LogInfo`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L51)

`#!c# public bool LogInfo {set;}`

Sets a value indication whether [`Info`](/Reference/LoggerType/) should be logged.

`#!c# true` on default. 

---
### `LogWarning`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L62)

`#!c# public bool LogWarning {set;}`

Sets a value indication whether [`Warning`](/Reference/LoggerType/) should be logged.

`#!c# true` on default. 

---
### `LogError`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L73)

`#!c# public bool LogError {set;}`

Sets a value indication whether [`Error`](/Reference/LoggerType/) should be logged.

`#!c# true` on default. 

---
## Methods
### `Log`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Logger.cs#L86)

`#!c# public void Log(string text,` [`LoggerType `](/Reference/LoggerType/) `type =` [`LoggerType `](/Reference/LoggerType/)`.Debug)`

Logs to the console with time, origin and type information.

#### Parameters
| Type                                   | Name   | Description           | Default                                        |
| -------------------------------------- | ------ | --------------------- | ---------------------------------------------- |
| `string`                               | `text` | The text to be logged | -                                              |
| [`LoggerType`](/Reference/LoggerType/) | `type` | The type of the log   | [`LoggerType`](/Reference/LoggerType/)`.Debug` |