
ArgumentOrEnvironmentVariable("Configuration", "Release");

Task("CSharp-NetCore-Setup")
    .IsDependentOn("Standard-Update-Version")
    .Does<ProjectData>(data => {

        var buildSettings = new DotNetCoreMSBuildSettings()
                            .WithProperty("Version", data.ProjectVersion.LegacySemVerPadded)
                            .WithProperty("AssemblyVersion", data.ProjectVersion.MajorMinorPatch)
                            .WithProperty("FileVersion",  data.ProjectVersion.MajorMinorPatch)
                            .WithProperty("AssemblyInformationalVersion", data.ProjectVersion.InformationalVersion);

        data["MSBuildSettings"] = buildSettings;
    })
    .CompleteTask();

Task("CSharp-NetCore-Build-All")
    .IsDependentOn("CSharp-NetCore-Setup")
    .Does<ProjectData>(data => {
        var buildSettings = data.Get<DotNetCoreMSBuildSettings>("MSBuildSettings");
        var solutionFiles = GetFiles(System.IO.Path.Combine(data.GetStr("SrcFolder"), "**","*.sln"));
        foreach(var solution in solutionFiles)
        {
            DotNetCoreBuild(solution.FullPath, new DotNetCoreBuildSettings {
                Configuration = data.GetStr("Configuration"),
                MSBuildSettings = buildSettings
            });
        }
    })
    .CompleteTask();

Task("CSharp-NetCore-Publish-All")
    .IsDependentOn("CSharp-NetCore-Setup")
    .Does<ProjectData>(data => {
        var buildSettings = data.Get<DotNetCoreMSBuildSettings>("MSBuildSettings");
        var solutionFiles = GetFiles(System.IO.Path.Combine(data.GetStr("SrcFolder"), "**","*.sln"));
        foreach(var solution in solutionFiles)
        {
            DotNetCorePublish(solution.FullPath, new DotNetCorePublishSettings {
                Configuration = data.GetStr("Configuration"),
                MSBuildSettings = buildSettings
            });
        }
        
    })
    .CompleteTask();

Task("CSharp-NetCore-Pack-All")
    .IsDependentOn("CSharp-NetCore-Publish-All")
    .Does<ProjectData>(data => {
        var buildSettings = data.Get<DotNetCoreMSBuildSettings>("MSBuildSettings");
        var solutionFiles = GetFiles(System.IO.Path.Combine(data.GetStr("SrcFolder"), "**","*.sln"));
        foreach(var solution in solutionFiles)
        {
            DotNetCorePack(solution.FullPath, new DotNetCorePackSettings {
                NoBuild = true,
                Configuration = data.GetStr("Configuration"),
                OutputDirectory = data.GetStr("PackagesLocal"),
                MSBuildSettings = buildSettings
            });
        }
    })
    .CompleteTask();

