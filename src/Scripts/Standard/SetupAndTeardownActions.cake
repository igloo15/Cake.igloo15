#addin "nuget:?package=Cake.igloo15.Helper&version=0.2.0-dev0004"

#l ProjectData.cake

Action<ISetupContext, ProjectData> _setupAction = null;
Action<ITeardownContext, ProjectData> _teardownAction = null;
Action<ITaskSetupContext, ProjectData> _taskSetupAction = null;
Action<ITaskTeardownContext, ProjectData> _taskTeardownAction = null;

public void AddSetup(Action<ISetupContext, ProjectData> cakeAction)
{
    _setupAction += cakeAction;
}

public void AddTeardown(Action<ITeardownContext, ProjectData> cakeAction)
{
    _teardownAction += cakeAction;
}

public void AddTaskSetup(Action<ITaskSetupContext, ProjectData> cakeAction)
{
    _taskSetupAction += cakeAction;
}

public void AddTaskTeardown(Action<ITaskTeardownContext, ProjectData> cakeAction)
{
    _taskTeardownAction += cakeAction;
}

Setup<ProjectData>((c) => {
    // AddErrorListener((task, error) => {
    //     Error($"{task} : {error.Message}");
    // });
    var projectData = new ProjectData(c, null);
    
    _setupAction?.Invoke(c, projectData);
    
    Information("Finished setting up ProjectData");
    return projectData;
});

Teardown<ProjectData>((c, data) => {
    _teardownAction?.Invoke(c, data);
});

TaskSetup<ProjectData>((c, data) => {
    _taskSetupAction?.Invoke(c, data);
});

TaskTeardown<ProjectData>((c, data) => {
    _taskTeardownAction?.Invoke(c, data);
});
