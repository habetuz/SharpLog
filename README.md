[![Build Status](https://img.shields.io/nuget/v/MarvinFuchs.SharpLog.svg)](https://www.nuget.org/packages/MarvinFuchs.SharpLog)

# Welcome to SharpLog

A small logger for big projects.

[Installation](https://sharplog.marvin-fuchs.de/Get%20started/#installation) and [usage](https://sharplog.marvin-fuchs.de/Get%20started/#usage) under [Get started](https://sharplog.marvin-fuchs.de/Get%20started/).

**Check out the [documentation](https://sharplog.marvin-fuchs.de)!**

## Features

- [x] Fast and easy to use
- [x] No setup required
- [x] Easy to customize

## Outputs

[`Outputs`](https://sharplog.marvin-fuchs.de/Reference/Outputs/) are used to display, pass or store your log messages. Sharplog can write to one ore multiple outputs.

Some outputs are already provided out-of-the-box:

- 💻Print your logs to the standard console including color coding!

- 📂Store your logs in a log file without blocking the file!

- 📮Send your logs via email!

## Example

``` c#
SharpLog.Logging.LogDebug("Debug!", typeof(Program));
SharpLog.Logging.LogTrace("Trace!", typeof(Program));
SharpLog.Logging.LogInfo("Info!", typeof(Program));
SharpLog.Logging.LogWarning("Warning!", typeof(Program));
SharpLog.Logging.LogError("Error!", typeof(Program));
SharpLog.Logging.LogFatal( //🚪Exits program after logging your message.
    "Fatal!", 
    typeof(Program), 
    exception: new Exception("Test"), 
    stackTrace: new StackTrace(true).ToString());
```
