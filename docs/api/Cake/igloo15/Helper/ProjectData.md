# [ProjectData](./ProjectData.md)

Namespace: [Cake]() > [igloo15]() > [Helper](./README.md)

Assembly: Cake.igloo15.Helper.dll

## Summary
A generic class used to store project data

## Constructors

| Name | Summary | 
| --- | --- | 
| ProjectData ( [`ICakeContext`](./ProjectData.md) context, [`Dictionary`](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.Dictionary-2)\<[`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String), [`Object`](https://docs.microsoft.com/en-us/dotnet/api/System.Object)> arguments ) |  | 


## Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| [ICakeContext](./ProjectData.md) | Context | The General Cake Context | 
| [ICakeTaskInfo](./ProjectData.md) | CurrentTask | The current task | 
| [Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object) | Item [ [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) index ] | Indexer for the project data it will search in order the following data: Public, Private, Arguments | 
| [GitVersion](./ProjectData.md) | Version | The Git Version | 


## Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [T](./ProjectData.md) | GetArgument ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ) | Gets an argument defined via the constructor | 
| [T](./ProjectData.md) | GetProperty ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ) | Returns a value of the specified type | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | GetString ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key ) | Returns a string value of the given key | 
| void | SetPrivateProperty ( [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) key, [`Object`](https://docs.microsoft.com/en-us/dotnet/api/System.Object) value ) | Set a private property with given key and value. This value will not show up when printing the values of this object via ToString() | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | ToString (  ) | Print the values of all data in project data except private data | 


