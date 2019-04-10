# [EventExtensions](./EventExtensions.md)

Namespace: [Cake]() > [igloo15]() > [Helper](./README.md)

Assembly: Cake.igloo15.Helper.dll

## Summary
Some initial cake events extensions

## Static Methods

| Return | Name | Summary | 
| --- | --- | --- | 
| void | AddSetup ( [`ICakeContext`](./EventExtensions.md) context, [`Action`](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1)\<[`ProjectData`](./ProjectData.md)> cakeAction ) | An method used to add a listener on the setup action | 
| void | AddTaskSetup ( [`ICakeContext`](./EventExtensions.md) context, [`Action`](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1)\<[`ProjectData`](./ProjectData.md)> cakeAction ) | A method used to register to listen on task setup of a cake script | 
| void | AddTaskTeardown ( [`ICakeContext`](./EventExtensions.md) context, [`Action`](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1)\<[`ProjectData`](./ProjectData.md)> cakeAction ) | A method used to register to listen on task teardown of a cake script | 
| void | AddTeardown ( [`ICakeContext`](./EventExtensions.md) context, [`Action`](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1)\<[`ProjectData`](./ProjectData.md)> cakeAction ) | A method used to register to listen on teardown of a cake script | 
| void | InvokeSetup ( [`ICakeContext`](./EventExtensions.md) context, [`ProjectData`](./ProjectData.md) data ) | A method used to invoke the setup action | 
| void | InvokeTaskSetup ( [`ICakeContext`](./EventExtensions.md) context, [`ProjectData`](./ProjectData.md) data ) | Method to be invoked in task setup to trigger all listeners | 
| void | InvokeTaskTeardown ( [`ICakeContext`](./EventExtensions.md) context, [`ProjectData`](./ProjectData.md) data ) | Method to be invoked in task teardown to trigger all listeners | 
| void | InvokeTeardown ( [`ICakeContext`](./EventExtensions.md) context, [`ProjectData`](./ProjectData.md) data ) | Method to be invoked in teardown to trigger all listeners | 


