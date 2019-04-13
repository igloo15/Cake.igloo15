#addin "nuget:?package=Cake.igloo15.Helper&version=###VERSION###"

ArgumentOrEnvironmentVariable<string>("NuGetApiKey", "", true);
ArgumentOrEnvironmentVariable<string>("NuGetSource", "https://api.nuget.org/v3/index.json");

Task("NuGet-Setup")
    .Does<ProjectData>((data) => {
        Func<IFileSystemInfo, bool> excludeFolders = 
            fileSystemInfo => 
            {
                var result = !fileSystemInfo.Path.FullPath.Contains("node_modules") && !fileSystemInfo.Path.FullPath.Contains("obj");
                return result;
            };

        var settings = new GlobberSettings {
            Predicate = excludeFolders
        };

        data["NuGetGlobSettings"] = settings;
    })
    .CompleteTask();

Task("NuGet-Package")
    .IsDependentOn("NuGet-Setup")
    .Does<ProjectData>((data) => {
        
        var nuspecSearchPath = System.IO.Path.Combine(data["SrcFolder"].ToString(), "**","*.nuspec");
        var files = GetFiles(nuspecSearchPath, data.GetProperty<GlobberSettings>("NuGetGlobSettings"));

        foreach(var file in files)
        {
            NuGetPack(file, new NuGetPackSettings {
                Version = data.Version.NuGetVersion,
                OutputDirectory = data.GetString("PackagesLocal")
            });
        }
    })
    .CompleteTask();


Task("NuGet-Push")
    .IsDependentOn("NuGet-Setup")
    .Does<ProjectData>((data) => {
        

        var nuspecSearchPath = System.IO.Path.Combine(data["PackagesLocal"].ToString(), "**","*.nupkg");
        var files = GetFiles(nuspecSearchPath, data.GetProperty<GlobberSettings>("NuGetGlobSettings"));

        foreach(var file in files)
        {
            NuGetPush(file, new NuGetPushSettings {
                ApiKey = data["NuGetApiKey"].ToString(),
                Source = data["NuGetSource"].ToString()
            });
        }
    })
    .CompleteTask();