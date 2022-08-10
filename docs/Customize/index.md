---
title: Customize
---

Either customize your logger by editing the `sharplog.yml` file or by modifying the [`SettingsManager.Settings`](SettingsManager#Settings) property.

One important customization option is the format of your log messages. Read [here](Formatting.md) for more information about formatting.

## Set global format

The global format gets used when there is no other format is provided.

=== "sharplog.yml"
    ```yaml
    format: '$D$: [$L$]$Cp{ [}s{] }$$Tp{ [}s{] }$ $M$$Ep{\n}$$Sp{\n}$'
    ```

=== "C#"
    ```c#
    SettingsManager.Settings.Format = "$D$: [$L$]$Cp{ [}s{] }$$Tp{ [}s{] }$ $M$$Ep{\n}$$Sp{\n}$"
    ```

## Set the global level settings

The global level settings that get used when no other level setting is provided.

!!! Tip
    If you only want to change one or multiple level settings you only need to provide this level setting. The others still remain their default value.

=== "sharplog.yml"
    ```yaml
    levels:
      debug:
        short: '?' #(1)
        enabled: true
        format: null
      trace:
        short: '&'
        enabled: true #(2)
        format: null
      info:
        short: '+'
        enabled: true
        format: null #(3)
      warn:
        short: '!'
        enabled: true
        format: null
      error:
        short: 'x'
        enabled: true
        format: null
      fatal:
        short: 'X'
        enabled: true
        format: null
    ```

    1. The short value is the `#!c# char` representation of the level.
    2. `#!c# true` if the level is enabled, else `#!c# false`.
    3. You can specify level specific formats that override the [global format](#set-global-format).

=== "C#"
    ```c#
    SettingsManager.Settings.Levels = new LevelContainer(
        debug: new Level('?'),
        trace: new Level('&'),
        info: new Level('+'),
        warn: new Level('!'),
        error: new Level('x'),
        fatal: new Level('X'));
    ```

## Set global outputs

The global outputs get used if there is no [tag that specifies outputs](#set-tag-specific-settings).

Settings specified for an output have the highest priority and overwrite every other defined setting.

On default only a console output is set, but you can also add a file output.

=== "sharplog.yml"
    ```yaml
    outputs:
      console:
        ...
      file:
        ...
    ```

=== "C#"
    ```c#
    SettingsManager.Settings.Outputs = new OutputContainer()
    ```

### Set a console output

=== "sharplog.yml"
    !!! note inline end "Colors"
        `black` `blue` `cyan` `darkBlue` `darkCyan` `darkGray` `darkGreen` `darkMagenta` `darkRed` `darkYellow` `gray` `green` `magenta` `red` `white` `yellow`
    ```yaml
    console:
      levels: null #(1)
      format: null #(2)
      color_enabled: true #(3)
      colors: #(4)
        debug:
          background: black #(5)
          foreground: darkGray
        trace:
          background: black
          foreground: white #(6)
        info:
          background: black
          foreground: green
        warn:
          background: black
          foreground: yellow
        error:
          background: black
          foreground: red
        fatal:
          background: red
          foreground: black
    ```

    1. Level settings for the output. Read [here](#set-the-global-level-settings) for more information about level settings but **note that levels that are left blank will fallback to the global level settings instead of receiving a default value.**
    2. A format for the output.
    3. `#!c# true` if the output should log with color, else `#!c# false`.
    4. Colors for each level. **Note that if no or only one color is provided for a level the default value from the level trace get used.**
    6. The background color. `black` is "transparent".
    5. The foreground or font color.

=== "C#"
    ```c#
    new ConsoleOutput()
    ```

### Set a file output

=== "sharplog.yml"
    ```yaml
    file:
      levels: null #(1)
      format: null #(2)
      path: .log #(3)
      suspend_time: 500 #(4)
    ```

    1. Level settings for the output. Read [here](#set-the-global-level-settings) for more information about level settings but **note that levels that are left blank will fallback to the global level settings instead of receiving a default value.**
    2. A format for the output.
    3. The relativ or absolut path of the file the output writes to.
    4. The file output logs asynchronously and waits `suspend_time` milliseconds between checking for new log messages to write.

=== "C#"
    ```c#
    new FileOutput()
    ```

### Set a custom output

Create a class that extends the [`Outputs.Output`](Output.md) class.

=== "Synchronous"
    ```c#
    class CustomOutput : SharpLog.Outputs.Output
    {
        public override void Write(string formattedLog, Log log)
        {
            //(1)
        }
    }
    ```

    1. Write the formatted log to your output. The log object contains all the information about the log.

=== "Asynchronous"
    ```c#
    class CustomOutput : SharpLog.Outputs.AsyncOutput
    {
        public override void WriteNonBlocking((string, Log)[] logs)
        {
            //(1)
        }
    }
    ```

    1. Write the formatted logs to your output. This method gets called asynchronously.

Now you have to add the output to an [`OutputContainer`](OutputContainer.md).

=== "General output"
    ```c#
    SettingsManager.Settings.Outputs.AddOutput(new CustomOutput())
    ```

=== "Tag output"
    ```c#
    SettingsManager.Settings.Tags["YOUR_TAG"].Outputs.AddOutput(new CustomOutput())
    ```

## Set tag specific settings

The tag specific settings get used when a matching tag is provided with the log message.

These settings overwrite global format, level and output settings.

=== "sharplog.yml"
    ``` yaml
    tags:
      YOUR_TAG:
        enabled: true #(1)
        format: null
        levels: null #(2)
        outputs: null
      anotherTag: #(3)
        enabled: true
        format: null #(4)
        levels: null
        outputs: null #(5)
    ```

    1. `#!c# true` if the tag is enabled, else `#!c# false`
    2. Level settings for the output. Read [here](#set-the-global-level-settings) for more information about level settings but **note that levels that are left blank will fallback to the global level settings instead of receiving a default value.**
    3. The format of your tag does not matter.
    4. A format for the tag.
    5. Outputs for the tag. **Note that tag specific outputs replace the global outputs (instead of adding to them).**

=== "C#"
    ``` c#
    SettingsManager.Settings.Tags["YOUR_TAG"] = new Tag();
    SettingsManager.Settings.Tags["anotherTag"] = new Tag();
    ```
