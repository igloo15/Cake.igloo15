#addin "nuget:?package=Cake.igloo15.Helper&version=###VERSION###"

Setup((c) => {
    c.SetupProjectData();    
    Information("Finished setting up ProjectData");
});

Teardown<ProjectData>((c, data) => {
    InvokeTeardown(data);
});

TaskSetup<ProjectData>((c, data) => {
    InvokeTaskSetup(data);
});

TaskTeardown<ProjectData>((c, data) => {
    InvokeTaskTeardown(data);
});
