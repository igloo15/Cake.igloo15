# [ChangelogExtensions](./ChangelogExtensions.md)

Namespace: [Cake]() > [igloo15]() > [ChangelogGenerator](./README.md)

Assembly: Cake.igloo15.ChangelogGenerator.dll

## Summary
Extensions for cake to generate a changelog

## Static Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| void | CreateChangelogConfig ( [`ICakeContext`](./ChangelogExtensions.md) context ) | Create a changelog config in the current working directory | 
| void | GenerateChangelog ( [`ICakeContext`](./ChangelogExtensions.md) context, [`ChangelogSettings`](./ChangelogExtensions.md) settings ) | Generate a changelog with the given settings | 
| void | GenerateChangelog ( [`ICakeContext`](./ChangelogExtensions.md) context ) | Generate a changelog with the given settings | 
| void | GenerateChangelog ( [`ICakeContext`](./ChangelogExtensions.md) context, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) nextVersion ) | Generate a changelog using the local changelog.json configuration file | 
| void | GenerateTestChangelog ( [`ICakeContext`](./ChangelogExtensions.md) context, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) nextVersion ) | Generate a changelog using the local changelog.json configuration file | 


