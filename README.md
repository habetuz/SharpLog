[![Build Status](https://img.shields.io/nuget/v/MarvinFuchs.SharpLog.svg)](https://www.nuget.org/packages/MarvinFuchs.SharpLog)
# SharpLog
With SharpLog you are able to make organized logs when building a large project. 

## Getting started

Install [the package from nuget](https://www.nuget.org/packages/MarvinFuchs.SharpLog/).
---

### Logger

You can create a new logger the following:
```cs
Logger MyLogger = new Logger()
{
    Ident = "Test",
    LogDebug = true,
    LogInfo = true,
    LogWarning = true,
    LogError = true
};
```

You can log the following:
```cs
MyLogger.Log("Test", LoggerType.Debug);
```

This will produce the following:
```
[04-07-2021 | 12:53:34.372] [Debug] [Test]: Test
```
Note that you don't have to pass ``LoggerType.Debug`` if you want to log on debug level.

Also note that the default settings are:
- ``Ident = "NoName"``
- ``LogDebug = false``
- ``LogInfo = false``
- ``LogWarning = false``
- ``LogError = false``

### MassLogger

This is a special logger that is able to log a large amount of data compressed into a single log. Use it when logging the same type of info many times (like keyboard inputs or many server requests).

You can create a new logger in the following:
```cs
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
The ``30000`` specify that the logger prints his info logs every ``30000`` milliseconds.

You can log ``debug``, ``warning`` and ``error`` like the normal logger:
```cs
MyLogger.Log("Test", LoggerType.Debug);
```
Note that you don't have to pass ``LoggerType.Debug`` if you want to log on debug level.

This will produce the following:
```
[04-07-2021 | 12:53:34.372] [Debug] [MassTest]: Test
```

When you want to log ``info`` like the normal logger, do the following:
```cs
MyLogger.Log("Instant info", LoggerType.Info, true);
```

#### Now to the specialty
When we want to log every key press on our keyboard, we could log them like the following:
```cs
MyLogger.Log(Keyboard.pressedKey(), LoggerType.Info);
```

And every ``30000`` milliseconds the logger would log something like the following:
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
The numbers get reset.
Note that we set ``Keyboard inputs:`` in the constructor as ``InfoLogText``.

Note that the default settings are:
- ``Ident = "NoName"``
- ``InfoLogText = ""``
- ``LogDebug = false``
- ``LogInfo = false``
- ``LogWarning = false``
- ``LogError = false``
