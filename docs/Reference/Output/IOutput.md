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
| bool                    | [`Instant`](#instant)   | :material-check: |                  | 

### Methods
| Type               | Method                                                                 |
| ------------------ | ---------------------------------------------------------------------- |
| `void`             | [`Write`](#write)`(string text,`  [`LogType `](LogType.md)  `logType)` |

## Properties
### `LogFlags`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/IOutput.cs#L18)

[`LogType`](LogType.md) `#!c# LogFlags { get; set; }`

Sets or gets the [`LogType`](LogType.md)'s the output should log. Should be set to all log types by default.

### `Instant`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/IOutput.cs#L20)

`#!c# bool Instant { get; set; }`

Gets a value indicating wether the output should log instant or non-instant (asynchronous).

---

## Methods
### `Write`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/IOutput.cs#L27)

`#!c# void Write(string text, `[`LogType`](LogType.md)  `logType);`

Writes the text to the output.

#### Parameters
| Type                       | Name   | Description              |
| -------------------------- | ------ | ------------------------ |
| `string`                   | `text` | The text to be written   |
| [`LogType`](LogType.md)    | `type` | The log level of the log |

---