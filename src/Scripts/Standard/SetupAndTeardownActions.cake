#addin "nuget:?package=Cake.igloo15.Helper&version=###VERSION###"

Setup((c) => {
    c.SetupProjectData();    
    Information("Finished setting up ProjectData");
});

Teardown((c) => {
    var data = c.GetData<ProjectData>();
    InvokeTeardown(data);
});

TaskSetup((c) => {
    var data = c.GetData<ProjectData>();
    InvokeTaskSetup(data);
});

TaskTeardown((c) => {
    var data = c.GetData<ProjectData>();
    InvokeTaskTeardown(data);
});
