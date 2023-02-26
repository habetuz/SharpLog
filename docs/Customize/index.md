---
title: Customize
---

Either customize your logger by editing the `sharplog.yml` file or by modifying the [`SettingsManager.Settings`](SettingsManager#Settings) property.

One important customization option is the format of your log messages. Read [here](Formatting.md) for more information about formatting.

## Set global format

The global format gets used when there is no other format is provided.

=== "sharplog.yml"
    ```yaml
    format: '$D$: [$L$]$Tp{[}s{]}$[$C$->$F$] $M$$Ep{\n}i{   }$$Sp{\n}$$'
    ```

=== "C#"
    ```c#
    SettingsManager.Settings.Format = "$D$: [$L$]$Tp{[}s{]}$[$C$->$F$] $M$$Ep{\n}i{   }$$Sp{\n}$"
    ```

## Set the global level settings

The global level settings that get used when no other level setting is provided.

!!! Tip
    Instead of providing all logging levels you can only specify the logging levels you want to change.

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

=== "sharplog.yml"
    ```yaml
    outputs:
      - type: ConsoleOutput
        ...
      - type: FileOutput
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
    - type: ConsoleOutput
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
    - type: FileOutput
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

### Set an email output

=== "sharplog.yml"
    ```yaml
    - type: EmailOutput
      levels: null
      format: null
      format_subject: '[$La{l}$] $C$'
      client:
        host: smtp.yourdomain.com
        port: 587
        enable_ssl: true
        credentials:
          user_name: yourusername
          password: yourpassword
      from:
        display_name: SharpLog
        address: sharplog@yourdomain.com
      to:
        - display_name: Your Receiver
          address: mail@your-receiver.com
      bcc:
        - display_name: Your Receiver
          address: mail@your-receiver.com
      cc:
        - display_name: Your Receiver
          address: mail@your-receiver.com
    ```

=== "C#"
    ```c#
    new EmailOutput()
    {
        Client = new SmtpClient()
        {
            Port = 587,
            Host = "smtp.yourdomain.com",
            EnableSsl = true,
            Credentials = new NetworkCredential()
            {
                Password = "yourusername",
                UserName = "yourpassword",
            },
        },
        From = new MailAddress()
        {
            Address = "sharplog@yourdomain.com",
            DisplayName = "SharpLog",
        },
        To = new MailAddress[]
        {
            new MailAddress()
            {
                Address = "mail@your-receiver.com",
                DisplayName = "Your Receiver",
            },
        },
        Bcc = new MailAddress[]
        {
            new MailAddress()
            {
                Address = "mail@your-receiver.com",
                DisplayName = "Your Receiver",
            },
        },
        Cc = new MailAddress[]
        {
            new MailAddress()
            {
                Address = "mail@your-receiver.com",
                DisplayName = "Your Receiver",
            },
        },
    };
    ```

### Log using Spectre.Console

You might want to use [AnsiConsoleOutput](../Reference/Outputs/AnsiConsoleOutput.md) for a more customizable console output.

This output uses `AnsiConsole.MarkupLine(log)` from [Spectre.Console](https://spectreconsole.net) to log to the console. Read more about Spectre.Console markup [here](https://spectreconsole.net/markup).

!!! Warning
    Make sure your log messages or formats do not contain unwanted `[...]` because they will be interpreted as markdown! You can escape brackets by doubling them (`[...]` -> `[[...]]`) or by calling `Markup.Escape(yourLogMessage)`.

=== "sharplog.yml"
    ```yaml
    - type: AnsiConsoleOutput
      levels: null #(1)
      format: null #(2)
      ansi_error_print: false #(3)
    ```

    1. Level settings for the output. Read [here](#set-the-global-level-settings) for more information about level settings but **note that levels that are left blank will fallback to the global level settings instead of receiving a default value.**
    2. A format for the output.
    3. `true` if the [build in error logging capability](https://spectreconsole.net/exceptions) of Spectre.Console should be used. Do not [specify an exception placeholder](Formatting.md#list-of-placeholders) if you set this parameter to `true`, else the error will be logged twice.

=== "C#"
    ```c#
    new FileOutput()
    ```

### Set a custom output

Create a class that extends the [`Output`](../Reference/Outputs/Output.md) or [`AsyncOutput`](../Reference/Outputs/AsyncOutput.md) class.

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
        public CustomOutput()
        {
            base.OnStart += (_, _) => {}; //(2)
            base.OnDispose += (_, _) => {}; //(3)
        }

        public override void WriteNonBlocking((string, Log)[] logs)
        {
            //(1)
        }
    }
    ```

    1. Write the formatted logs to your output. This method gets called asynchronously.
    2. Attach to [`OnStart`](../Reference/Outputs/AsyncOutput.md#onstart) for your setup code.
    3. Attach to [`OnDispose`](../Reference/Outputs/AsyncOutput.md#ondispose) for your dispose code. Waiting for your output to finish writing is handled automatically.

Now you have to add the output to an [`OutputContainer`](../Reference/Settings/OutputContainer.md).

=== "General output"
    ```c#
    SettingsManager.Settings.Outputs.Add(new CustomOutput())
    ```

=== "Tag output"
    ```c#
    SettingsManager.Settings.Tags["YOUR_TAG"].Outputs.Add(new CustomOutput())
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
