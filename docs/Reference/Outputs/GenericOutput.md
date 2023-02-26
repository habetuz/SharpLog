# GenericOutput Class

## Definition

`#!c# namespace Sharplog.Outputs`

``` c#
public class GenericOutput : Output
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [Output](Output.md)<br>
&emsp;&ensp;:material-subdirectory-arrow-right: [**GenericOutput**](./)

*Implements*: [IDictionary<_string, object_>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2)

:   Generic output that can generate an output from the [`Type`](#type) parameter. Used to parse the settings file. Gets automatically constructed when provided to an [`OutputContainer`](../Settings/OutputContainer.md).

### Constructors

| Name                                                                                                                                                  |
| ----------------------------------------------------------------------------------------------------------------------------------------------------- |
| [GenericOutput()](#genericoutput)                                                                                                                     |
| [GenericOutput(string?, Dictionary<_string, object_>?, string?, LevelContainer?)](#genericoutputstring-dictionarystring-object-string-levelcontainer) |

### Properties

| Name                                                                                                           | Type                                                                                                                                                 | GET                 | SET                 |
| -------------------------------------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------- | ------------------- |
| [Format](Output.md#format)                                                                                     | [string?][stringLink]                                                                                                                                | :octicons-check-16: | :octicons-check-16: |
| [Levels](Output.md#levels)                                                                                     | [LevelContainer?](../Settings/LevelContainer.md)                                                                                                     | :octicons-check-16: | :octicons-check-16: |
| [Count](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.count)           | [int][intLink]                                                                                                                                       | :octicons-check-16: | :octicons-x-16:     |
| [Item[_string_]](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2.item)   | [object](https://learn.microsoft.com/en-us/dotnet/api/system.object)                                                                                 | :octicons-check-16: | :octicons-check-16: |
| [Keys](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2.keys)             | [Dictionary<_string, object_>.KeyCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.keycollection)     | :octicons-check-16: | :octicons-x-16:     |
| [Values](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.values)          | [Dictionary<_string, object_>.ValueCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.valuecollection) | :octicons-check-16: | :octicons-x-16:     |
| [IsReadOnly](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.isreadonly) | [bool][boolLink]                                                                                                                                     | :octicons-check-16: | :octicons-x-16:     |
| [Type](#type)                                                                                                  | [string?][stringLink]                                                                                                                                | :octicons-check-16: | :octicons-check-16: |

### Inherited Methods

| Name                                                                                                                                          | Modifiers     | Returns                                                     |
| --------------------------------------------------------------------------------------------------------------------------------------------- | ------------- | ----------------------------------------------------------- |
| [Write(string, Log)](Output.md#writestring-log)                                                                                               | `#!c# public` | :octicons-x-16:                                             |
| [Add(KeyValuePair<_string, object_>)](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.add)              | `#!c# public` | :octicons-x-16:                                             |
| [Add(string, object)](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2.add)                              | `#!c# public` | :octicons-x-16:                                             |
| [Clear()](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.clear)                                        | `#!c# public` | :octicons-x-16:                                             |
| [Contains(KeyValuePair<_string, object_>)](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.contains)    | `#!c# public` | [bool][boolLink]                                            |
| [ContainsKey(string)](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2.containskey)                      | `#!c# public` | [bool][boolLink]                                            |
| [CopyTo(KeyValuePair<_string, object_>[], int)](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.copyto) | `#!c# public` | :octicons-x-16:                                             |
| [GetEnumerator()](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable.getenumerator)                                  | `#!c# public` | [IEnumerator<_KeyValuePair<*string, object*>_>][enumerator] |
| [Remove(string)](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2.remove)                                | `#!c# public` | [bool][boolLink]                                            |
| [TryGetValue(string, out object)](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.idictionary-2.trygetvalue)          | `#!c# public` | [bool][boolLink]                                            |

### Methods
| Name                                  | Modifiers     | Returns             |
| ------------------------------------- | ------------- | ------------------- |
| [ConstructOutput()](#constructoutput) | `#!c# public` | [Output](Output.md) |

## Constructors

### GenericOutput()

```c#
public GenericOutput()
    : this(null, null, null, null)
```

:   Initializes a new instance of the [GenericOutput](./) class.

### GenericOutput(string?, Dictionary<_string, object_>?, string?, LevelContainer?)

```c#
public GenericOutput(
    string? type = null,
    Dictionary<string, object>? parameter = null,
    string? format = null,
    LevelContainer? levels = null)
```

:   Initializes a new instance of the [GenericOutput](./) class.

#### Parameter

`type` [string?][stringLink] · :octicons-milestone-16: `null`
:   The type.

`parameter` [Dictionary<_string, object_>?](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) · :octicons-milestone-16: `null`
:   The parameter dictionary.

`format` [string?][stringLink] · :octicons-milestone-16: `null`
:   The format.

`levels` [LevelContainer?](../Settings/LevelContainer.md) · :octicons-milestone-16: `null`
:   The level settings.

## Properties

### Type

```c#
public string? Type { get; set; }
```

Type: [string?][stringLink]

:   The type name of the output (found in namespace `SharpLog.Outputs`).

## Methods

### ConstructOutput()

```c#
public Output ConstructOutput()
```

:   Constructs an output from the given type and parameter.

#### Returns

Type: [Output](Output.md)

:   The constructed output.

#### Throws

[NullReferenceException](https://learn.microsoft.com/en-us/dotnet/api/system.nullreferenceexception)
:   Thrown when [GenericOutput.Type](#type) is `null`. 

[ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception)
:   Thrown when [GenericOutput.Type](#type) class cannot be found. 

[boolLink]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool
[intLink]: https://learn.microsoft.com/en-us/dotnet/api/system.int32
[stringLink]: https://docs.microsoft.com/en-us/dotnet/api/system.string
[enumerator]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerator