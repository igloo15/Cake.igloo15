#addin "nuget:?package=Cake.igloo15.Helper&version=###VERSION###"

var nugetApiKey = ArgumentOrEnvironmentVariable<string>("NuGetApiKey", "", false);
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

        if(!String.IsNullOrEmpty(nugetApiKey))
            data.SetPrivateProperty("NuGetApiKey", nugetApiKey);

        data["NuGetGlobSettings"] = settings;
    });

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
    });


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
    });