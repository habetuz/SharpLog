# MailAddress Class

## Definition

`#!c# namespace Sharplog.Outputs`

``` c#
public abstract class MailAddress
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**MailAddress**](./)

:   Class containing a mail address.

### Constructors

| Name                                                     |
| -------------------------------------------------------- |
| [MailAddress()](#mailaddress)                            |
| [MailAddress(string, string)](#mailaddressstring-string) |

### Properties

| Name                        | Type                                                                | GET                 | SET                 |
| --------------------------- | ------------------------------------------------------------------- | ------------------- | ------------------- |
| [Address](#address)         | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) | :octicons-check-16: | :octicons-check-16: |
| [DisplayName](#displayname) | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) | :octicons-check-16: | :octicons-check-16: |

## Constructors

### MailAddress()

```c#
public MailAddress()
    : this(null, null)
```

:   Initializes a new instance of the [MailAddress](./) class.

### MailAddress(string, string)

```c#
public MailAddress(string address, string displayName = null)
```

:   Initializes a new instance of the [MailAddress](./) class.

#### Parameter

`address` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: :octicons-x-16:
:   The format.

`displayName` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `null`
:   The format.

## Properties

### Address

```c#
public string Address { get; set; }
```

Type:  [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)

:   Gets or sets the mail address.

### DisplayName

```c#
public string DisplayName { get; set; }
```

Type:  [string](https://docs.microsoft.com/en-us/dotnet/api/system.string)

:   Gets or sets the display name.
