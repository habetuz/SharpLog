---
title: Getting started
---

# Getting started

## Installation
[![Build Status](https://img.shields.io/nuget/v/MarvinFuchs.SharpLog.svg)](https://www.nuget.org/packages/MarvinFuchs.SharpLog)

Install the package from [nuget](https://www.nuget.org/packages/MarvinFuchs.SharpLog/).

## Usage

### [Logger](../Reference/Logger/)
Create a new logger.
```c#
Logger MyLogger = new Logger()
{
    Ident = "Test",
    LogDebug = true,
    LogInfo = true,
    LogWarning = true,
    LogError = true
};
```
??? Info "Default settings"
    ```c#
    Ident = "NoName",
    LogDebug = false,
    LogInfo = true,
    LogWarning = true,
    LogError = true
    ```

Log to the console.
```c#
MyLogger.Log("Test", LoggerType.Debug);
```
??? example "Output"
    ```
    [04-07-2021 | 12:53:34.372] [Debug] [Test]: Test
    ```

??? Tip "Debug is optional"
    When the `level` argument is left blank the logger automatically logs on level `#!c# LoggerType.Debug`

### [MassLogger](../Reference/MassLogger/)
This is a special logger that is able to log a large quantity of logs compressed into a single log. Use it when logging the same type of info many times (like keyboard inputs or many server requests).

Create a new logger.
```c#
MassLogger MyMassLogger = new MassLogger(30000)
{
    Ident = "MassTest",
    InfoLogText = "Keyboard inputs:"
    LogDebug = true,
    LogInfo = true,
    LogWarning = true,
    LogError = true
};
```

The `30000` specify that the logger prints his info logs every `30000` milliseconds.

??? Info "Default settings"
    ```c#
    Ident = "NoName",
    InfoLogText = "",
    LogDebug = false,
    LogInfo = true,
    LogWarning = true,
    LogError = true
    ```

You can log `debug`, `warning` and `error` just like the normal [logger](#logger).
```c#
MyLogger.Log("Test", LoggerType.Debug);
```
??? example "Output"
    ```
    [04-07-2021 | 12:53:34.372] [Debug] [Test]: Test
    ```

??? Tip "Debug is optional"
    Again, when the `level` argument is left blank the logger automatically logs on level `#!c# LoggerType.Debug`


**Info-logs are special. Take this example:**

We want to log every key press on our keyboard, we can use the [MassLogger](../Reference/MassLogger/).
```c#
MyLogger.Log(Keyboard.pressedKey(), LoggerType.Info);
```

??? example "Output"
    Every `30000` milliseconds:
    ```
    [04-07-2021 | 12:55:34.372] [Info] [MassTest]: Keyboard inputs:
    63x Left
    16x Return
    39x LShiftKey
    12x RShiftKey
    39x Back
    28x Space
    36x LControlKey
    ```
??? note
    Note that we set `#!c# InfoLogText` as `Keyboard inputs:` in the constructor.

??? info "Counter"
    The counters of the logs get reset after every log.

When you want to log a info log instantly set the `instant` argument as `#!c# true`.
```c#
MyLogger.Log("Instant info", LoggerType.Info, true);
```
??? example "Output"
    ```
    [04-07-2021 | 12:53:34.372] [Info] [MassTest]: Instant info
    ```