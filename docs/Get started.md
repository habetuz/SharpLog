---
title: Get started
---
## Installation

[![Build Status](https://img.shields.io/nuget/v/MarvinFuchs.SharpLog.svg)](https://www.nuget.org/packages/MarvinFuchs.SharpLog)

Install the package from [nuget](https://www.nuget.org/packages/MarvinFuchs.SharpLog/).

## Usage

Sharplog automatically tries to load the settings from `sharplog.yml`. A Yaml file containing all changes to the default settings you want to make.

Read [here](/Setup/) how you can customize your logger!

To log a message just use `#!c# Logging.log(LogLevel.Debug, "Your Message")` or a log level specific logging method:

``` c# title="Log level specific logging methods"
Logging.LogDebug("Debug!");
Logging.LogTrace("Trace!");
Logging.LogInfo("Info!");
Logging.LogWarning("Warning!");
Logging.LogError("Error!");
Logging.LogFatal("Fatal!");
```

<div class="result" markdown>
```
18.10.2022 20:31:12: [Debug][SharpLogAndGameSenseTest.Program->Main(...)] Debug!
18.10.2022 20:31:12: [Trace][SharpLogAndGameSenseTest.Program->Main(...)] Trace!
18.10.2022 20:31:12: [Info][SharpLogAndGameSenseTest.Program->Main(...)] Info!
18.10.2022 20:31:12: [Warn][SharpLogAndGameSenseTest.Program->Main(...)] Warning!
18.10.2022 20:31:12: [Error][SharpLogAndGameSenseTest.Program->Main(...)] Error!
18.10.2022 20:31:12: [Fatal][SharpLogAndGameSenseTest.Program->Main(...)] Fatal!
```
</div>

Note that you can pass additional information for your log message:

``` yaml
string: tag #(1)
Exception: exception #(2)
bool: stacktrace #(3)
```

1. The tag of the message to better organize your logs.
2. An exception you want to log.
3. Wether you want to log the stack trace for better a better understanding what happened with your program.

### Exit your program correctly

!!! Warning
    If you do not exit your program correctly async outputs may not be finished writing or sending your logs!

Some outputs (like the file output) write your logs asynchronously and therefore could need some time until they pick up your message to log it.

Dispose the logger to ensure that you wait until all messages are logged before your program exits.

``` c# title="Possible ways of disposing the logger"
Logging.Dispose(); //(1)

Logging.LogFatal("Something went terribly wrong! We cannot continue the program."); //(2)
```

1. Halts the program until all log messages are written.
2. Writes all log messages and then exits the program using [`#!c# Environment.Exit(1)`](https://docs.microsoft.com/en-us/dotnet/api/system.environment.exit)
