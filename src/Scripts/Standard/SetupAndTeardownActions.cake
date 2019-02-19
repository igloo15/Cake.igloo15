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
    GlobalProjectData.Context = c;
    _setupAction?.Invoke(c, GlobalProjectData);
    
    Information("Finished setting up ProjectData");
    return GlobalProjectData;
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
