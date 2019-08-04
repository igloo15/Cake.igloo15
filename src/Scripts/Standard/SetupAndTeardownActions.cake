#addin "nuget:?package=Cake.igloo15.Helper&version=###VERSION###&prerelease"

Setup((c) => {
    c.SetupProjectData();    
    Information("Finished setting up ProjectData");
});

Teardown((c) => {
    var data = c.Data.Get<ProjectData>();
    InvokeTeardown(data);
});

TaskSetup((c) => {
    var data = c.Data.Get<ProjectData>();
    InvokeTaskSetup(data);
});

TaskTeardown((c) => {
    var data = c.Data.Get<ProjectData>();
    InvokeTaskTeardown(data);
});
