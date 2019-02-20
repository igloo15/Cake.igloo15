
#addin "Cake.Incubator"
#r "./dist/Cake.igloo15.MarkdownApi/Debug/netstandard2.0/Cake.igloo15.MarkdownApi.dll"
#r "./dist/Cake.igloo15.Helper/Debug/netstandard2.0/Cake.igloo15.Helper.dll"

#l "./src/Scripts/Standard/Standard.cake"
#l "./src/Scripts/CSharp/CSharp.cake"

var target = ArgumentOrEnvironmentVariable<string>("target", "Default");

DotNetCoreMSBuildSettings MSBuildSettings;
string SolutionLocation = "./src/Addins/Cake.igloo15.Addins.sln";
string PackagesLocation = "./packages.local";

AddSetup((c, d) => {
    d["MyItems"] = "Stuff";
});

AddTeardown((c, d) => {
    Information("Finished All Tasks");
});


Task("Update-Settings-With-Version")
    .IsDependentOn("Standard-ProjectData-Dump")
    .IsDependentOn("Standard-Update-Version")
    .IsDependentOn("CSharp-NetCore-Setup")
	.Does<ProjectData>((data) => {

        Information($"Updating MSBuild with Version {data.Version.LegacySemVerPadded}");

        if(AppVeyor.IsRunningOnAppVeyor)
			AppVeyor.UpdateBuildVersion(data.Version.LegacySemVerPadded);
	})
    .QuickError();

Task("Clean-Packages-Local")
    .Does(() => {
        CleanDirectories(PackagesLocation);
    });

Task("Pack")
    .IsDependentOn("Clean-Packages-Local")
    .IsDependentOn("Update-Settings-With-Version")
    .IsDependentOn("CSharp-NetCore-Pack-All")
    .Does(() => {
        
    });

Task("Push")
    .IsDependentOn("Pack")
    .Does(() => {
        foreach(var nupkgFile in GetFiles(PackagesLocation+"/*.nupkg"))
        {
            Information($"Pushing Package {nupkgFile}");
            NuGetPush(nupkgFile, new NuGetPushSettings {
                Source = "https://api.nuget.org/v3/index.json",
				ApiKey = EnvironmentVariable("apikey") 
            });
            Information($"Succesfully Pushed Package {nupkgFile}");
        }
    })
    .QuickError();

    

Task("Default")
    .IsDependentOn("Pack");

Task("Deploy")
	.IsDependentOn("Push");

RunTarget(target);
