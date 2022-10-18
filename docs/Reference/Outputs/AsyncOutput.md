# AsyncOutput Class

## Definition

`#!c# namespace Sharplog.Outputs`

``` c#
public abstract class AsyncOutput
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [Output](Output.md)<br>
&emsp;&ensp;:material-subdirectory-arrow-right: [**AsyncOutput**](./)

*Implements*: [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

:   Base class for async outputs.

### Constructors

| Name                                                                              |
| --------------------------------------------------------------------------------- |
| [AsyncOutput(int, string, LevelContainer)](#asyncoutputint-string-levelcontainer) |

### Properties

| Name                        | Type                                                                | GET                 | SET                 |
| --------------------------- | ------------------------------------------------------------------- | ------------------- | ------------------- |
| [SuspendTime](#suspendtime) | [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)     | :octicons-check-16: | :octicons-check-16: |
| [Format](Output.md#format)  | [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) | :octicons-check-16: | :octicons-check-16: |
| [Levels](Output.md#levels)  | [LevelContainer](LevelContainer.md)                                 | :octicons-check-16: | :octicons-check-16: |

### Events

| Name                    | Delegate                                                                         | Modifiers        |
| ----------------------- | -------------------------------------------------------------------------------- | ---------------- |
| [OnStart](#onstart)     | [EventHandler](https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler) | `#!c# protected` |
| [OnDispose](#ondispose) | [EventHandler](https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler) | `#!c# protected` |

### Methods

| Name                                                             | Modifiers              | Returns         |
| ---------------------------------------------------------------- | ---------------------- | --------------- |
| [Start()](#start)                                                | `#!c# public`          | :octicons-x-16: |
| [WriteNonBlocking((string, Log)[])](#writenonblockingstring-log) | `#!c# public abstract` | :octicons-x-16: |

### Inherited methods

| Name                                                                                | Modifiers     | Returns         |
| ----------------------------------------------------------------------------------- | ------------- | --------------- |
| [Write(string, Log)](Output.md#writestring-log)                                     | `#!c# public` | :octicons-x-16: |
| [Dispose()](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose) | `#!c# public` | :octicons-x-16: |

## Constructors

### AsyncOutput(int, string, LevelContainer)

```c#
public AsyncOutput(
    int suspendTime = 500,
    string format = null,
    LevelContainer levels = null)
    : base(format, levels)
```

:   Initializes a new instance of the [AsyncOutput](./) class.

#### Parameter

`suspendTime` [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32) · :octicons-milestone-16: `500`
:   The time the output waits until it checks for new logs in ms.

`format` [string](https://docs.microsoft.com/en-us/dotnet/api/system.string) · :octicons-milestone-16: `null`
:   The format.

`levels` [LevelContainer](LevelContainer.md) · :octicons-milestone-16: `null`
:   The level settings.

## Properties

### SuspendTime

```c#
public int SuspendTime { get; set; }
```

Type: [int](https://docs.microsoft.com/en-us/dotnet/api/system.int32)

:   Gets or sets the time the output waits until it checks for new logs in ms.

## Events

### OnStart

```c#
protected event EventHandler OnStart;
```

Delegate: [EventHandler](https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler)

:   Event called when the output gets started.

### OnDispose

```c#
protected event EventHandler OnDispose;
```

Delegate: [EventHandler](https://learn.microsoft.com/en-us/dotnet/api/system.eventhandler)

:   Event called when the output gets disposed.

## Methods

### Start()

```c#
public void Start()
```

:   Starts this instance.

### WriteNonBlocking((string, Log)[])

```c#
public abstract void WriteNonBlocking((string, Log)[] logs)
```

:   Writes the specified formatted log.

#### Parameter

`logs` [(string, Log)[]](https://docs.microsoft.com/en-us/dotnet/api/system.tuple-2)  · :octicons-milestone-16: :octicons-x-16:
:   The logs.
