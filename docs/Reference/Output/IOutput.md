---
title: IOutput
---

# IOutput
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/IOutput.cs)

`#!c# namespace SharpLog.Output`

`#!c# public interface IOutput`

:material-subdirectory-arrow-right: [`IOutput`]()

---

Interface for outputs used by logger.

## Summary
### Properties
| Type                    | Property                | Get              | Set              |
| ----------------------- | ----------------------- | ---------------- | ---------------- | 
| [`LogType`](LogType.md) | [`LogFlags`](#logflags) | :material-check: | :material-check: | 

### Methods
| Type               | Method                                                                 |
| ------------------ | ---------------------------------------------------------------------- |
| `void`             | [`Write`](#write)`(string text,`  [`LogType `](LogType.md)  `logType)` |

## Properties
### `LogFlags`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/IOutput.cs#L18)

`#!c# public string FileName {set;}`

Sets or gets the [`LogType`](LogType.md)'s the output should log. Should be set to all log types on default.

---

## Methods
### `Write`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/IOutput.cs#L23)

`#!c# LogType`  [`LogType`](LogType.md)  `{ get; set; }`

Writes the text to the output.

#### Parameters
| Type                       | Name   | Description              |
| -------------------------- | ------ | ------------------------ |
| `string`                   | `text` | The text to be written   |
| [`LogType`](LogType.md)    | `type` | The log level of the log |

---