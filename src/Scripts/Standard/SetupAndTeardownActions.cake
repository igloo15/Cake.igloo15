#addin "nuget:?package=Cake.igloo15.Helper&version=###VERSION###"

Setup<ProjectData>((c) => {
    // AddErrorListener((task, error) => {
    //     Error($"{task} : {error.Message}");
    // });
    var projectData = new ProjectData(c, GlobalArguments);
    
    InvokeSetup(projectData);
    
    Information("Finished setting up ProjectData");
    return projectData;
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
