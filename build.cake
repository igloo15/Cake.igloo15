using System;

#addin "Cake.Incubator&version=3.1.0"

#l "nuget:?package=Cake.igloo15.Scripts.Standard&version=0.2.0-dev0006"
#l "nuget:?package=Cake.igloo15.Scripts.CSharp&version=0.2.0-dev0006"
#l "nuget:?package=Cake.igloo15.Scripts.NuGet&version=0.2.0-dev0006"

var target = Argument<string>("target", "Default");

DotNetCoreMSBuildSettings MSBuildSettings;
string SolutionLocation = "./src/Addins/Cake.igloo15.Addins.sln";
string PackagesLocation = "./packages.local";

AddSetup((d) => {
    d["MyItems"] = "Stuff";
    d.SetPrivateProperty("NuGetApiKey", EnvironmentVariable("apikey"));
});

AddTeardown((d) => {
    Information("Finished All Tasks");
});


Task("Update-Settings-With-Version")
    .IsDependentOn("Standard-ProjectData-Dump")
    .IsDependentOn("Copy-Folder")
    .IsDependentOn("Standard-Update-Version")
    .IsDependentOn("CSharp-NetCore-Setup")
	.Does<ProjectData>((data) => {

        Information($"Updating MSBuild with Version {data.Version.LegacySemVerPadded}");

        if(AppVeyor.IsRunningOnAppVeyor)
			AppVeyor.UpdateBuildVersion(data.Version.LegacySemVerPadded);

        ReplaceKey("###VERSION###", data.Version.LegacySemVerPadded, "./dist/Scripts/**/*.cake");
	})
    .QuickError();

Task("Copy-Folder")
    .Does<ProjectData>((data) => {
        CopyDirectory(Directory(data["SrcFolder"].ToString()) + Directory("Scripts"), Directory(data["DistFolder"].ToString()) + Directory("Scripts"));
    });

Task("DownVersion")
    .Does(() => {
        ReplaceKey("0.2.0-dev0006", "0.2.0-dev0005", "./dist/Scripts/**/*.cake");
    });

Task("Clean-Packages-Local")
    .Does(() => {
        CleanDirectories(PackagesLocation);
    });

Task("Pack")
    .IsDependentOn("Clean-Packages-Local")
    .IsDependentOn("Update-Settings-With-Version")
    
    .IsDependentOn("CSharp-NetCore-Pack-All")
    .IsDependentOn("NuGet-Package")
    .Does(() => {
        
    });

Task("Push")
    .IsDependentOn("Pack")
    .IsDependentOn("NuGet-Push")
    .Does(() => {
        // foreach(var nupkgFile in GetFiles(PackagesLocation+"/*.nupkg"))
        // {
        //     Information($"Pushing Package {nupkgFile}");
        //     NuGetPush(nupkgFile, new NuGetPushSettings {
        //         Source = "https://api.nuget.org/v3/index.json",
		// 		ApiKey = EnvironmentVariable("apikey") 
        //     });
        //     Information($"Succesfully Pushed Package {nupkgFile}");
        // }
    });

    

Task("Default")
    .IsDependentOn("Pack");

Task("Deploy")
	.IsDependentOn("Push");

RunTarget(target);
