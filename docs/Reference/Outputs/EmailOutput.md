# EmailOutput Class

## Definition

`#!c# namespace Sharplog.Outputs`

``` c#
 public class EmailOutput : AsyncOutput
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [Output](Output.md)<br>
&emsp;&ensp;:material-subdirectory-arrow-right: [AsyncOutput](AsyncOutput.md)<br>
&emsp;&ensp;&emsp;&ensp;:material-subdirectory-arrow-right: [**EmailOutput**](./)

*Implements*: [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

:   Output sending mails.

### Constructors

| Name                                                                                                                                                                                                                |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| [EmailOutput()](#emailoutput)                                                                                                                                                                                       |
| [EmailOutput(SmtpClient, MailAddress, MailAddress[], MailAddress[], MailAddress[], int, string, LevelContainer)](#emailoutputsmtpclient-mailaddress-mailaddress-mailaddress-mailaddress-int-string-levelconatainer) |

### Properties

| Name                                      | Type                                                                                  | GET                 | SET                 |
| ----------------------------------------- | ------------------------------------------------------------------------------------- | ------------------- | ------------------- |
| [Format](Output.md#format)                | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)                   | :octicons-check-16: | :octicons-check-16: |
| [Levels](Output.md#levels)                | [LevelContainer](LevelContainer.md)                                                   | :octicons-check-16: | :octicons-check-16: |
| [SuspendTime](AsyncOutput.md#suspendtime) | [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)                       | :octicons-check-16: | :octicons-check-16: |
| [Client](#client)                         | [SmtpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient) | :octicons-check-16: | :octicons-check-16: |
| [From](#from)                             | [MailAddress](MailAddress.md)                                                         | :octicons-check-16: | :octicons-check-16: |
| [To](#to)                                 | [MailAddress[]](MailAddress.md)                                                       | :octicons-check-16: | :octicons-check-16: |
| [Bcc](#bcc)                               | [MailAddress[]](MailAddress.md)                                                       | :octicons-check-16: | :octicons-check-16: |
| [CC](#cc)                                 | [MailAddress[]](MailAddress.md)                                                       | :octicons-check-16: | :octicons-check-16: |
| [SubjectFormat](#subjectformat)           | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)                   | :octicons-check-16: | :octicons-check-16: |

### Inherited Methods

| Name                                                                                | Modifiers     | Returns         |
| ----------------------------------------------------------------------------------- | ------------- | --------------- |
| [Write(string, Log)](Output.md#writestring-log)                                     | `#!c# public` | :octicons-x-16: |
| [Start()](AsyncOutput.md#start)                                                     | `#!c# public` | :octicons-x-16: |
| [WriteNonBlocking((string, Log)[])](AsyncOutput.md#writenonblockingstring-log)      | `#!c# public` | :octicons-x-16: |
| [Dispose()](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose) | `#!c# public` | :octicons-x-16: |

## Constructors

### EmailOutput()

```c#
public EmailOutput()
    : this(null, null)
```

:   Initializes a new instance of the [EmailOutput](./) class.

### EmailOutput(SmtpClient, MailAddress, MailAddress[], MailAddress[], MailAddress[], int, string, LevelContainer)

```c#
public EmailOutput(
    SmtpClient client,
    MailAddress from,
    MailAddress[] to = null,
    MailAddress[] bcc = null,
    MailAddress[] cc = null,
    string formatSubject = "[$La{l}$] $C$",
    int suspendTime = 5000,
    string format = null,
    LevelContainer levels = null)
    : base(suspendTime, format, levels)
```

:   Initializes a new instance of the [EmailOutput](./) class.

#### Parameter

`client` [SmtpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient) · :octicons-milestone-16: :octicons-x-16:
:   The smtp client.

`from` [MailAddress](MailAddress.md) · :octicons-milestone-16: :octicons-x-16:
:   The email from field.

`to` [MailAddress[]](MailAddress.md) · :octicons-milestone-16: `null`
:   The email to field.

`bcc` [MailAddress[]](MailAddress.md) · :octicons-milestone-16: `null`
:   The email bcc field.

`cc` [MailAddress[]](MailAddress.md) · :octicons-milestone-16: `null`
:   The email cc field.

`formatSubject` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `"[$La{l}$] $C$"`
:   The format of the subject field.

`suspendTime` [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32) · :octicons-milestone-16: `500`
:   The suspend time between logs in ms.

`format` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `null`
:   The format.

`levels` [LevelContainer](LevelContainer.md) · :octicons-milestone-16: `null`
:   The level settings.

## Properties

### Client

```c#
public SmtpClient Client { get; set; }
```

Type: [SmtpClient](https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient)

:   Gets or sets the smtp client.

### From

```c#
public MailAddress From { get; set; }
```

Type: [MailAddress](MailAddress.md)

:   Gets or sets the email from field.

### To

```c#
public MailAddress[] To { get; set; }
```

Type: [MailAddress[]](MailAddress.md)

:   Gets or sets the email to field.

### Bcc

```c#
public MailAddress[] Bcc { get; set; }
```

Type: [MailAddress[]](MailAddress.md)

:   Gets or sets the email bcc field.

### CC

```c#
public MailAddress[] CC { get; set; }
```

Type: [MailAddress[]](MailAddress.md)

:   Gets or sets the email cc field.

### FormatSubject

```c#
public string FormatSubject { get; set; }
```

Type: [string](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)

:   Gets or sets the format of the subject field.