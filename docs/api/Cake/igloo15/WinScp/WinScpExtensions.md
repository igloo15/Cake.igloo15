# [WinScpExtensions](./WinScpExtensions.md)

Namespace: [Cake]() > [igloo15]() > [WinScp](./README.md)

Assembly: Cake.igloo15.WinScp.dll

## Summary
Extensions to use WinScp

## Static Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[ComparisonDifference](./WinScpExtensions.md)> | CompareDirectories ( [`ICakeContext`](./WinScpExtensions.md) context, [`SessionOptions`](./WinScpExtensions.md) options, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) localFolder, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) remoteFolder, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) logDifferences, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) removeFiles, [`SynchronizationMode`](./WinScpExtensions.md) mode, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) mirror, [`SynchronizationCriteria`](./WinScpExtensions.md) criteria, [`TransferOptions`](./WinScpExtensions.md) transferOptions ) |  | 
| [IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1)\<[RemoteFileInfo](./WinScpExtensions.md)> | GetFileList ( [`ICakeContext`](./WinScpExtensions.md) context, [`SessionOptions`](./WinScpExtensions.md) options, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) remoteFolder ) | Get a List of Files from the remote server directory | 
| [ICakeContext](./WinScpExtensions.md) | GetFiles ( [`ICakeContext`](./WinScpExtensions.md) context, [`SessionOptions`](./WinScpExtensions.md) options, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) remoteFolder, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) localFolder, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) remove, [`TransferOptions`](./WinScpExtensions.md) transferOptions ) | Download a file or files from remote server | 
| [ICakeContext](./WinScpExtensions.md) | PutFiles ( [`ICakeContext`](./WinScpExtensions.md) context, [`SessionOptions`](./WinScpExtensions.md) options, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) localFolder, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) remoteFolder, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) remove, [`TransferOptions`](./WinScpExtensions.md) transferOptions ) | Push files in folder to a remote folder | 
| [ICakeContext](./WinScpExtensions.md) | SyncronizeDirectories ( [`ICakeContext`](./WinScpExtensions.md) context, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) url, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) localFolder, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) remoteFolder, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) removeFiles ) | Synchronizes directories. | 
| [ICakeContext](./WinScpExtensions.md) | SyncronizeDirectories ( [`ICakeContext`](./WinScpExtensions.md) context, [`SessionOptions`](./WinScpExtensions.md) options, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) localFolder, [`String`](https://docs.microsoft.com/en-us/dotnet/api/System.String) remoteFolder, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) removeFiles, [`SynchronizationMode`](./WinScpExtensions.md) mode, [`Boolean`](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean) mirror, [`SynchronizationCriteria`](./WinScpExtensions.md) criteria, [`TransferOptions`](./WinScpExtensions.md) transferOptions ) | Synchronizes directories. | 


