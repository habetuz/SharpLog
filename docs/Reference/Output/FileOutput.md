---
title: FileOutput
---

# FileOutput
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/FileOutput.cs)

`#!c# namespace SharpLog.Output`

`#!c# public class FileOutput`

:material-subdirectory-arrow-right: [`IOutput`](IOutput.md)

&ensp;&ensp;&ensp;&ensp; :material-subdirectory-arrow-right: [`FileOutput`]()

---

Class for file outputs.

## Summary
### Constructors
| Constructor                       |
| --------------------------------- | 
| [`FileOutput`](#fileoutput_1)`()` | 

### Properties
| Type     | Property                | Get              | Set              |
| -------- | ----------------------- | ---------------- | ---------------- | 
| `string` | [`FileName`](#filename) |                  | :material-check: | 

### Implemented methods from [`IOutput`](IOutput.md)
| Type               | Method                                                                 |
| ------------------ | ---------------------------------------------------------------------- |
| `void`             | [`Write`](#write)`(string text,`  [`LogType `](LogType.md)  `logType)` |

## Constructors
### `FileOutput`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/FileOutput.cs#L38-L41)

`#!c# public FileOutput(string fileName = ".log")`

Initializes a new instance of the [`FileOutput`]() class.

#### Parameters
| Type     | Name       | Description                                             | Default  |
| -------- | ---------- | ------------------------------------------------------- | -------- |
| `string` | `fileName` | The name or path of the file the output should write to | `".log"` |

---
## Properties
### `FileName`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/FileOutput.cs#L43-L48) · :material-sign-direction: Default: `#!c# "NoName"`

`#!c# public string FileName {set;}`

Sets the name or path of the file the output should write to.

---
## Methods
### `Write`
[:material-file-code: Source](https://github.com/habetuz/SharpLog/blob/main/Output/FileOutput.cs#L55-L58)

`#!c# void Write(string text,`  [`LogType `](LogType.md)  `type)`

Writes text to a file.

#### Parameters
| Type                       | Name   | Description              |
| -------------------------- | ------ | ------------------------ |
| `string`                   | `text` | The text to be written   |
| [`LogType`](LogType.md)    | `type` | The log level of the log |