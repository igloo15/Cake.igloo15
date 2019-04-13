# [ProjectData](./ProjectData.md)

Namespace: [Cake]() > [igloo15]() > [Helper](./README.md)

Assembly: Cake.igloo15.Helper.dll

## Summary
A generic class used to store project data

## Constructors

| Name | Summary | 
| --- | --- | 
| ProjectData ( [`ICakeContext`](./ProjectData.md) context, [`Dictionary`](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2)\<[`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String), [`ArgumentValue`](./ArgumentValue.md)> arguments ) |  | 


## Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| [ICakeContext](./ProjectData.md) | Context | The General Cake Context | 
| [ICakeTaskInfo](./ProjectData.md) | CurrentTask | The current task | 
| [Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object) | Item [ [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ] | Indexer for the project data it will search in order the following data: Public, Private, Arguments | 
| [GitVersion](./ProjectData.md) | ProjectVersion | The Git Version | 


## Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) | ContainsKey ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ) | Checks if key is in project data | 
| [T](./ProjectData.md) | Get ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ) | Returns a value of the specified type | 
| [Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object) | Get ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ) | Returns a value of the specified type | 
| [T](./ProjectData.md) | GetArg ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ) | Gets an argument defined via the constructor | 
| [ArgumentValue](./ArgumentValue.md) | GetArgValue ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ) | Returns the ArgumentValue | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GetStr ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ) | Short hand for getting a string | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GetString ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ) | Returns a string value of the given key | 
| [ProjectData](./ProjectData.md) | Set ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key, [`Object`](https://docs.microsoft.com/en-us/dotnet/api/System.Object) value, [`ProjectDataType`](./ProjectDataType.md) type, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) overrideNonDefaultArgument ) | This will set the data for the first time as either Public or Private depending on passed type (Public is default). If data already exists at the key it will attempt to update the data and ignore the passed project data type. If you intend to override an argument the 4th param can be used to ensure overriden | 
| [ProjectData](./ProjectData.md) | SetPrivate ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key, [`Object`](https://docs.microsoft.com/en-us/dotnet/api/System.Object) value ) | Set a private property with given key and value. This value will not show up when printing the values of this object via ToString() | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | ToString (  ) | Print the values of all data in project data except private data | 
| [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) | Update ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key, [`Object`](https://docs.microsoft.com/en-us/dotnet/api/System.Object) value, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) overrideNonDefaultArgument ) | Will update a specific piece of data it returns false if data doesn't already exist. if you want to override your passed in arguments you must set last param to true | 


