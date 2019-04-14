# [ArgumentExtensions](./ArgumentExtensions.md)

Namespace: [Cake]() > [igloo15]() > [Helper](./README.md)

Assembly: Cake.igloo15.Helper.dll

## Summary
Extensions to allow for generic arguments or environments

## Static Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [T](./ArgumentExtensions.md) | ArgumentOrEnvironmentVariable ( [`ICakeContext`](./ArgumentExtensions.md) context, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) name, [`T`](./ArgumentExtensions.md) defaultValue, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) isPrivate, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) prefix ) | Get an Argument, EnvironmentVariable, or Default Value resolved in that order  It will also add the argument to GlobalArguments | 
| [Dictionary](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2)\<[String](https://docs.microsoft.com/en-us/dotnet/api/System.String), [ArgumentValue](./ArgumentValue.md)> | GlobalArguments ( [`ICakeContext`](./ArgumentExtensions.md) context ) | Global Arguments properties this property contains all the arguments defined using ArgumentOrEnvironmentVariable | 
| void | PrintArguments ( [`ICakeContext`](./ArgumentExtensions.md) context ) | Print all arguments except private ones | 


