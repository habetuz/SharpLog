---
title: Get started
---
## Installation

[![Build Status](https://img.shields.io/nuget/v/MarvinFuchs.SharpLog.svg)](https://www.nuget.org/packages/MarvinFuchs.SharpLog)

Install the package from [nuget](https://www.nuget.org/packages/MarvinFuchs.SharpLog/).

## Usage

Sharplog automatically tries to load the settings from `sharplog.yml`. A Yaml file containing all changes to the default settings you want to make.

Read [here](/Setup/) how you can customize your logger!

To log a message just use `#!c# Logging.log(LogLevel.Debug, "Your Message", typeof(YourClass))` or a log level specific logging method:

``` c# title="Log level specific logging methods"
Logging.LogDebug("Debug!", typeof(Program));
Logging.LogTrace("Trace!", typeof(Program));
Logging.LogInfo("Info!", typeof(Program));
Logging.LogWarning("Warning!", typeof(Program));
Logging.LogError("Error!", typeof(Program));
Logging.LogFatal("Fatal!", typeof(Program));
```

<div class="result" markdown>
```
24.04.2022 14:04:47: [Debug] [YourNamespace.Program]  Debug!
24.04.2022 14:04:47: [Trace] [YourNamespace.Program]  Trace!
24.04.2022 14:04:47: [Info] [YourNamespace.Program]  Info!
24.04.2022 14:04:47: [Warn] [YourNamespace.Program]  Warning!
24.04.2022 14:04:47: [Error] [YourNamespace.Program]  Error!
24.04.2022 14:04:47: [Fatal] [YourNamespace.Program]  Fatal!
```
</div>

Note that you can pass additional information for your log message:

``` yaml
string: tag #(1)
Exception: exception #(2)
string: stacktrace #(3)
```

1. The tag of the message to better organize your logs.
2. An exception you want to log.
3. The current stacktrace for better a better understanding what happened with your program.

### Exit your program correctly

!!! Warning
    If you do not exit your program correctly some of your logs may not be written to their desired outputs!

Some outputs (like the file output) write your logs asynchronously and therefore could need some time until they pick up your message to log it.

Disposing the logger ensures that you wait until all messages are logged before your program exits.

``` c# title="Possible ways of disposing the logger"
Logging.Dispose(); //(1)

Logging.LogFatal("Something went terribly wrong! We cannot continue the program.", typeof(Program)); //(2)
```

1. Halts the program until all log messages are written.
2. Writes all log messages and then exits the program using [`#!c# Environment.Exit(1)`](https://docs.microsoft.com/en-us/dotnet/api/system.environment.exit?view=net-6.0)
