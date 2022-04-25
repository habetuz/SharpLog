---
title: Formatting
---

Specify the formatting of you logs using a string with placeholders that get replaced with information.

A placeholder is build up the following:

``` c#
//(1)                               (4)                       (3)
   $Da{yyyy'-'MM'-'dd'T'HH':'mm':'ss}p{SomePrefix}s{SomeSuffix}$
//  (2)                                          (5)
```

1. The capitalized letter specifies the type of the placeholder.
2. The argument property.
3. Each placeholder starts and ends with `$`
4. The prefix property.
5. The suffix property.

!!! Tip
    To write `$` to your log write `$$` in your format string.

Add up to three properties to each placeholder for more customization:

!!! note inline end
    Prefix and suffix properties cannot contain nested placeholders.

| Property | Description                                                        |
| :------: | ------------------------------------------------------------------ |
| `p{...}` | Prefix that will be displayed before of the information.           |
| `s{...}` | Suffix that will be displayed after the information.               |
| `a{...}` | Arguments that some placeholders need to specify their formatting. |

## List of placeholders

| Placeholder | Description                                   | Arguments                                                                                                                                                                      |
| :---------: | --------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
|     `C`     | The namespace and class of the source.        | :material-minus-box:                                                                                                                                                           |
|     `D`     | The timestamp.                                | [Date and time format string](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings) or empty for standard format of your culture. |
|     `E`     | The exception of the log source if available. | :material-minus-box:                                                                                                                                                           |
|     `L`     | The log level.                                | `l` or empty for a written log level.<br>`s` for the short form specified in the [level settings](./index.md#set-tag-specific-settings).                                       |
|     `M`     | The message.                                  | :material-minus-box:                                                                                                                                                           |
|     `S`     | The stack trace if available.                 | :material-minus-box:                                                                                                                                                           |
|     `T`     | The tag if available.                         | :material-minus-box:                                                                                                                                                           |

