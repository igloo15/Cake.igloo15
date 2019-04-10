# [MarkdownApiExtensions](./MarkdownApiExtensions.md)

Namespace: [Cake]() > [igloo15]() > [MarkdownApi](./README.md)

Assembly: Cake.igloo15.MarkdownApi.dll

## Summary
Extensions that allow execution of MarkdownGenerator

## Static Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [String](https://docs.microsoft.com/en-us/dotnet/api/System.String) | CreateSearchArea ( [`ICakeContext`](./MarkdownApiExtensions.md) context, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) rootFolder, [`Func`](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2)\<[`DirectoryPath`](./MarkdownApiExtensions.md), [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean)> filter ) | Create the dll search area based on root folder | 
| void | GenerateMarkdownApi ( [`ICakeContext`](./MarkdownApiExtensions.md) context, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) searchPath, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) outputPath, [`ITheme`](./MarkdownApiExtensions.md) theme ) | Generate Markdown Api Documentation based on C# dll and Xml Comments | 
| void | GenerateMarkdownApi ( [`ICakeContext`](./MarkdownApiExtensions.md) context, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) searchPath, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) outputPath, [`DefaultOptions`](./MarkdownApiExtensions.md) options ) | Generate Markdown Api using default themes but with specificed options | 


