---
title: Home
---

# Welcome to SharpLog

A small logger for big projects.

[Installation](Get started/#installation) and [usage](Get started/#usage) under [Get started](Get started/).

Full documentation under [Reference](/Reference/Logger/).

!!! warning ""
    This documentation is up to date with version `3.3.*`

## Features

- [x] Fast and easy to use
- [x] No setup required
- [x] Easy to customize

## Outputs

[Outputs](Output.md) are used to display, pass or store your log messages. Sharplog can write to one ore multiple outputs.

Some outputs are already provided out-of-the-box:

- [:material-console:](ConsoleOutput.md) Print your logs to the standard console including color coding!

- [:material-file:](FileOutput.md) Store your logs in a log file without blocking the file!

- [:material-email:](EmailOutput.md) Send your logs via email!

## Example

``` c#
SharpLog.Logging.LogDebug("Debug!", typeof(Program));
SharpLog.Logging.LogTrace("Trace!", typeof(Program));
SharpLog.Logging.LogInfo("Info!", typeof(Program));
SharpLog.Logging.LogWarning("Warning!", typeof(Program));
SharpLog.Logging.LogError("Error!", typeof(Program));
SharpLog.Logging.LogFatal( //(1)
    "Fatal!", 
    typeof(Program), 
    exception: new Exception("Test"), 
    stackTrace: new StackTrace(true).ToString());
```

1. :material-exit-to-app: Exits program after logging your message.
