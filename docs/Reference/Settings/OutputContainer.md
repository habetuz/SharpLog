# OutputContainer Class

## Definition

`#!c# namespace Sharplog.Settings`

``` c#
public class OutputContainer : IDisposable
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**OutputContainer**](./)

*Implements*: [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable)

:   Container for the output settings.

### Constructors

| Name                                                                                                               |
| ------------------------------------------------------------------------------------------------------------------ |
| [OutputContainer()](#outputcontainer)                                                                              |
| [OutputContainer(ConsoleOutput, FileOutput, List< Output >)](#outputcontainerconsoleoutput-fileoutput-list-output) |

### Properties

| Name                | Type                              | GET                 | SET                 |
| ------------------- | --------------------------------- | ------------------- | ------------------- |
| [Console](#console) | [ConsoleOutput](ConsoleOutput.md) | :octicons-check-16: | :octicons-check-16: |
| [File](#file)       | [FileOutput](FileOutput.md)       | :octicons-check-16: | :octicons-check-16: |

### Inherited methods

| Name                                                                                | Modifiers     | Returns         |
| ----------------------------------------------------------------------------------- | ------------- | --------------- |
| [Dispose()](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose) | `#!c# public` | :octicons-x-16: |

### Methods

| Name                                        | Modifiers     | Returns                          |
| ------------------------------------------- | ------------- | -------------------------------- |
| [AddOutput(Output)](#addoutputoutput)       | `#!c# public` | :octicons-x-16:                  |
| [RemoveOutput(Output)](#removeoutputoutput) | `#!c# public` | :octicons-x-16:                  |
| [GetOutputs()](#getoutputs)                 | `#!c# public` | [Output[]](../Outputs/Output.md) |

## Constructors

### OutputContainer()

```c#
public OutputContainer()
    : this(null, null, null)
```

:   Initializes a new instance of the [OutputContainer](./) class using default settings if not provided.

### OutputContainer(ConsoleOutput, FileOutput, List< Output >)

```c#
public OutputContainer(
    ConsoleOutput console = null,
    FileOutput file = null,
    List<Output> outputs = null)
```

:   Initializes a new instance of the [OutputContainer](./) class using default settings if not provided.

#### Parameter

`console` [ConsoleOutput](ConsoleOutput.md) · :octicons-milestone-16: `null`
:   The console output.

`file` [FileOutput](FileOutput.md) · :octicons-milestone-16: `null`
:   The file output.

`outputs` [List< Output >](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1) · :octicons-milestone-16: `null`
:   The output list.

## Properties

### Console

```c#
public ConsoleOutput Console { get; set; }
```

Type: [ConsoleOutput](ConsoleOutput.md)

:   Gets or sets the console output.

### File

```c#
public FileOutput File { get; set; }
```

Type: [FileOutput](FileOutput.md)

:   Gets or sets the file output.

## Methods

### AddOutput(Output)

```c#
public void AddOutput(Output output)
```

:   Adds an output and starts it if needed.

#### Parameter

`output` [Output](../Outputs/Output.md)  · :octicons-milestone-16: :octicons-x-16:
:   The output.

### RemoveOutput(Output)

```c#
public void RemoveOutput(Output output)
```

:   Removes and disposes an output.

#### Parameter

`output` [Output](../Outputs/Output.md)  · :octicons-milestone-16: :octicons-x-16:
:   The output.

### GetOutputs()

```c#
public Output[] GetOutputs()
```

:   Get the list with outputs.

#### Returns

Type: [Output[]](../Outputs/Output.md)
:   Array containing the outputs.
