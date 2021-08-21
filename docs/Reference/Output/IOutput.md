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
### Methods
| Type               | Method                                                                 |
| ------------------ | ---------------------------------------------------------------------- |
| `void`             | [`Write`](#write)`(string text,`  [`LogType `](LogType.md)  `logType)` |

## Methods
### `Write`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/IOutput.cs#L23)

`#!c# void Write(string text,`  [`LogType `](LogType.md)  `type)`

Writes the text to the output.

#### Parameters
| Type                       | Name   | Description              |
| -------------------------- | ------ | ------------------------ |
| `string`                   | `text` | The text to be written   |
| [`LogType`](LogType.md)    | `type` | The log level of the log |