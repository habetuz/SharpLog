---
title: Getting started
---

# Getting started

## Installation
[![Build Status](https://img.shields.io/nuget/v/MarvinFuchs.SharpLog.svg)](https://www.nuget.org/packages/MarvinFuchs.SharpLog)

Install the package from [nuget](https://www.nuget.org/packages/MarvinFuchs.SharpLog/).

## Usage

### [`Logger`](Logger.md)
Create a new logger.
```c#
Logger MyLogger = new Logger()
{
    Ident      = "Test",
    LogFlags   = LogType.Debug | LogType.Info | LogType.Warning | LogType.Error,
    Outputs    = new List<IOutput>() { new ConsoleOutput() }
};
```
??? Info "Default settings"
    ```c#
    Ident      = "NoName",
    LogFlags   = LogType.Info | LogType.Warning | LogType.Error,
    Outputs    = new List<IOutput>() { new ConsoleOutput() },
    ```

Log to the console.
```c#
MyLogger.Log("Test", LogType.Debug);
```
??? example "Output"
    ```
    [04-07-2021 | 12:53:34.372] [Debug] [Test]: Test
    ```

??? Tip "Debug is optional"
    When the `level` argument is left blank the logger automatically logs on level `#!c# LogType.Debug`

### [`MassLogger`](MassLogger.md)
This is a special logger that is able to log a large quantity of logs compressed into a single log. Use it when logging the same type of info many times (like keyboard inputs or many server requests).

Create a new logger.
```c#
MassLogger MyMassLogger = new MassLogger(30000)
{
    Ident = "MassTest",
    InfoLogText = "Keyboard inputs:"
    LogFlags   = LogType.Debug | LogType.Info | LogType.Warning | LogType.Error,
    Outputs    = new List<IOutput>() { new ConsoleOutput() }
};
```

The `30000` specify that the logger prints his info logs every `30000` milliseconds.

??? Info "Default settings"
    ```c#
    Ident = "NoName",
    InfoLogText = "",
    LogFlags   = LogType.Info | LogType.Warning | LogType.Error,
    Outputs    = new List<IOutput>() { new ConsoleOutput() }
    ```

[`LogType`](LogType.md) `debug`, `warning` and `error` get logged just like the normal [`Logger`](Logger.md).
```c#
MyMassLogger.Log("Test", LogType.Debug);
```
??? example "Output"
    ```
    [04-07-2021 | 12:53:34.372] [Debug] [Test]: Test
    ```

??? Tip "Debug is optional"
    Again, when the `level` argument is left blank the logger automatically logs on level `#!c# LogType.Debug`


**Info-logs are special. Take this example:**

We want to log every key press on our keyboard, we can use the [`MassLogger`](MassLogger.md).
```c#
MyLogger.Log(Keyboard.pressedKey(), LogType.Info);
```

??? example "Output"
    Every `30000` milliseconds:
    ```
    [04-07-2021 | 12:55:34.372] [Info] [MassTest]: Keyboard inputs:
    | 63x Left
    | 16x Return
    | 39x LShiftKey
    | 12x RShiftKey
    | 39x Back
    | 28x Space
    | 36x LControlKey
    ```
??? note
    Note that `#!c# InfoLogText` was set to `#!c# "Keyboard inputs:"` in the constructor.

When you want to log an info log instantly (just like the normal [`Logger`](Logger.md)) set the `instant` argument to `#!c# true`.
```c#
MyLogger.Log("Instant info", LogType.Info, true);
```
??? example "Output"
    ```
    [04-07-2021 | 12:53:34.372] [Info] [MassTest]: Instant info
    ```

## [Outputs](IOutput.md)
On default [`Logger`](Logger.md) and [`MassLogger`](MassLogger.md) have their [`Outputs`](Logger.md#outputs) list filled with a [`ConsoleOutput`](ConsoleOutput.md).

A [`ConsoleOutput`](ConsoleOutput.md) logs to the console window and colors the different log levels.

You can add one or multiple [`FileOutput`](FileOutput.md) to log to one or multiple files or you can create your own [`IOutput`](IOutput.md) to log to other outputs.

Notice that outputs log every log level on default but you can restrict them to only some log levels with their [`LogFlags`](IOutput.md#logflags) property.
