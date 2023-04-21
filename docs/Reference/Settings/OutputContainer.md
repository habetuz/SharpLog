# OutputContainer Class

## Definition

`#!c# namespace Sharplog.Settings`

``` c#
public class OutputContainer : IDisposable, IList<Output>
```

[Object](https://docs.microsoft.com/en-us/dotnet/api/system.object)<br>
:material-subdirectory-arrow-right: [**OutputContainer**](./)

*Implements*: [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable), [IList<Output>](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.ilist-1)

:   Container for output settings.

### Constructors

| Name                                  |
| ------------------------------------- |
| [OutputContainer()](#outputcontainer) |

### Properties

| Name                                                                                                           | Type                           | GET                 | SET                 |
| -------------------------------------------------------------------------------------------------------------- | ------------------------------ | ------------------- | ------------------- |
| [Count](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.icollection-1.count)           | [int][int]                     | :octicons-check-16: | :octicons-x-16:     |
| [IsReadOnly](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.icollection-1.isreadonly) | [bool][bool]                   | :octicons-check-16: | :octicons-x-16:     |
| [Item[int]](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.ilist-1.item)              | [Output](../Outputs/Output.md) | :octicons-check-16: | :octicons-check-16: |

### Inherited methods

| Name                                                                                                                  | Modifiers     | Returns                             |
| --------------------------------------------------------------------------------------------------------------------- | ------------- | ----------------------------------- |
| [Dispose()](https://docs.microsoft.com/en-us/dotnet/api/system.idisposable.dispose)                                   | `#!c# public` | :octicons-x-16:                     |
| [Add(Output)](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.icollection-1.add)              | `#!c# public` | :octicons-x-16:                     |
| [Clear()](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.icollection-1.clear)                | `#!c# public` | :octicons-x-16:                     |
| [Contains(Output)](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.icollection-1.contains)    | `#!c# public` | [bool][bool]                        |
| [CopyTo(Output[], int)](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.icollection-1.copyto) | `#!c# public` | :octicons-x-16:                     |
| [GetEnumerator()](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable.getenumerator)          | `#!c# public` | [IEnumerator<_Output_>][enumerator] |
| [IndexOf(Output)](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.ilist-1.indexof)            | `#!c# public` | [int][int]                          |
| [Insert(int, Output)](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.ilist-1.insert)         | `#!c# public` | :octicons-x-16:                     |
| [Remove(Output)](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.icollection-1.remove)        | `#!c# public` | [bool][bool]                        |
| [RemoveAt(int)](https://learn.microsoft.com/de-de/dotnet/api/system.collections.generic.ilist-1.removeat)             | `#!c# public` | :octicons-x-16:                     |

## Constructors

### OutputContainer()

```c#
public OutputContainer()
```

:   Initializes a new instance of the [OutputContainer](./) class using default settings if not provided.

[int]: https://learn.microsoft.com/de-de/dotnet/api/system.int32
[enumerator]: https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerator
[bool]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool