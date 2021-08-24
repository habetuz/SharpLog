---
title: ConsoleOutput
---

# ConsoleOutput
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/ConsoleOutput.cs)

`#!c# namespace SharpLog.Output`

`#!c# public class ConsoleOutput`

:material-subdirectory-arrow-right: [`IOutput`](IOutput.md)

&ensp;&ensp;&ensp;&ensp; :material-subdirectory-arrow-right: [`ConsoleOutput`]()

---

Class for console outputs.

## Summary
### Constructors
| Constructor                             |
| --------------------------------------- | 
| [`ConsoleOutput`](#consoleoutput_1)`()` | 

### Implemented properties from [`IOutput`](IOutput.md)
| Type                    | Property                          | Get              | Set              |
| ----------------------- | --------------------------------- | ---------------- | ---------------- | 
| [`LogType`](LogType.md) | [`LogFlags`](IOutput.md#logflags) | :material-check: | :material-check: | 

### Implemented methods from [`IOutput`](IOutput.md)
| Type               | Method                                                                 |
| ------------------ | ---------------------------------------------------------------------- |
| `void`             | [`Write`](#write)`(string text,`  [`LogType `](LogType.md)  `logType)` |

## Constructors
### `ConsoleOutput`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/ConsoleOutput.cs)

`#!c# public ConsoleOutput()`

Initializes a new instance of the [`ConsoleOutput`]() class.

---
## Methods
### `Write`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/ConsoleOutput.cs#L40-L50)

`#!c# void Write(string text,`  [`LogType `](LogType.md)  `type)`

Writes text to the console.

#### Parameters
| Type                       | Name   | Description              |
| -------------------------- | ------ | ------------------------ |
| `string`                   | `text` | The text to be written   |
| [`LogType`](LogType.md)    | `type` | The log level of the log |