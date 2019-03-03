
Task("CSharp-NetCore-Setup")
    .IsDependentOn("Standard-Update-Version")
    .Does<ProjectData>(data => {

        var buildSettings = new DotNetCoreMSBuildSettings()
                            .WithProperty("Version", data.Version.LegacySemVerPadded)
                            .WithProperty("AssemblyVersion", data.Version.MajorMinorPatch)
                            .WithProperty("FileVersion",  data.Version.MajorMinorPatch)
                            .WithProperty("AssemblyInformationalVersion", data.Version.InformationalVersion);

        data["MSBuildSettings"] = buildSettings;
    });

Task("CSharp-NetCore-Build-All")
    .IsDependentOn("CSharp-NetCore-Setup")
    .Does<ProjectData>(data => {
        var buildSettings = data.GetProperty<DotNetCoreMSBuildSettings>("MSBuildSettings");
        var solutionFiles = GetFiles(System.IO.Path.Combine(data["SrcFolder"].ToString(), "**","*.sln"));
        foreach(var solution in solutionFiles)
        {
            DotNetCoreBuild(solution.FullPath, new DotNetCoreBuildSettings {
                Configuration = "Release",
                MSBuildSettings = buildSettings
            });
        }
    });

Task("CSharp-NetCore-Publish-All")
    .IsDependentOn("CSharp-NetCore-Setup")
    .Does<ProjectData>(data => {
        var buildSettings = data.GetProperty<DotNetCoreMSBuildSettings>("MSBuildSettings");
        var solutionFiles = GetFiles(System.IO.Path.Combine(data["SrcFolder"].ToString(), "**","*.sln"));
        foreach(var solution in solutionFiles)
        {
            DotNetCorePublish(solution.FullPath, new DotNetCorePublishSettings {
                Configuration = "Release",
                MSBuildSettings = buildSettings
            });
        }
        
    });

Task("CSharp-NetCore-Pack-All")
    .IsDependentOn("CSharp-NetCore-Publish-All")
    .Does<ProjectData>(data => {
        var buildSettings = data.GetProperty<DotNetCoreMSBuildSettings>("MSBuildSettings");
        var solutionFiles = GetFiles(System.IO.Path.Combine(data["SrcFolder"].ToString(), "**","*.sln"));
        foreach(var solution in solutionFiles)
        {
            DotNetCorePack(solution.FullPath, new DotNetCorePackSettings {
                NoBuild = true,
                Configuration = "Release",
                OutputDirectory = data["PackagesLocal"].ToString(),
                MSBuildSettings = buildSettings
            });
        }
    });

