---
title: Home
---

# Welcome to SharpLog

A small logger for big projects.

[Installation](Get started/#installation) and [usage](Get started/#usage) under [Get started](Get started/).

Full documentation under [Reference](/Reference/Logger/).

!!! warning ""
    This documentation is up to date with version `3.6.*`

## Features

- [x] Fast and easy to use
- [x] No setup required
- [x] Easy to customize

## Outputs

[Outputs](Reference/Outputs/Output.md) are used to display, pass or store your log messages. Sharplog can write to one ore multiple outputs.

Some outputs are already provided out-of-the-box:

- [:material-console:](Reference/Outputs/ConsoleOutput.md) Print your logs to the standard console including color coding!
- [:material-console:{.ansiConsoleIcon}](Reference/Outputs/AnsiConsoleOutput.md) Print your logs to [Spectre.Console.AnsiConsole](https://spectreconsole.net/)!

- [:material-file:](Reference/Outputs/FileOutput.md) Store your logs in a log file without blocking the file!

- [:material-email:](Reference/Outputs/EmailOutput.md) Send your logs via email!

## Example

``` c#
SharpLog.Logging.LogDebug("Debug!");
SharpLog.Logging.LogTrace("Trace!");
SharpLog.Logging.LogInfo("Info!");
SharpLog.Logging.LogWarning("Warning!");
SharpLog.Logging.LogError("Error!");
SharpLog.Logging.LogFatal( //(1)
    "Fatal!", 
    exception: new Exception("Test"), 
    stackTrace: true;
```

1. :material-exit-to-app: Exits program after logging your message.
