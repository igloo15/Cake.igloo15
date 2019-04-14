# [ArgumentValue](./ArgumentValue.md)

Namespace: [Cake]() > [igloo15]() > [Helper](./README.md)

Assembly: Cake.igloo15.Helper.dll

## Summary
An internal ArgumentValue created from the ArgumentOrEnvironmentValue extension

## Constructors

| Name | Summary | 
| --- | --- | 
| ArgumentValue ( [`Object`](https://docs.microsoft.com/en-us/dotnet/api/System.Object) value, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) isDefault, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) isPrivate ) | Constructs the argument value | 


## Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) | IsDefault | True if the value is the default argument value and false if the value was passed in via an argument to script | 
| [Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) | IsPrivate | True if the data should be hidden from logging | 
| [Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object) | Value | The internal generic value of the argument | 


## Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [T](./ArgumentValue.md) | GetValue (  ) | Returns the Value as a specific type | 


