#addin "Cake.Incubator&version=3.1.0"

#l "nuget:?package=Cake.igloo15.Scripts.Bundle.CSharp&version=0.2.0-dev0023"


var target = Argument<string>("target", "Default");

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
    .IsDependentOn("Standard-Update-Version")
    .IsDependentOn("Copy-Folder")
	.Does<ProjectData>((data) => {

        Information($"Updating MSBuild with Version {data.Version.LegacySemVerPadded}");

        if(AppVeyor.IsRunningOnAppVeyor)
			AppVeyor.UpdateBuildVersion(data.Version.LegacySemVerPadded);

        ReplaceKey("###VERSION###", data.Version.LegacySemVerPadded, "./dist/Scripts/**/*.cake");
	})
    .QuickError();

Task("Copy-Folder")
    .Does<ProjectData>((data) => {
        var srcFolder = CombinePaths(data.GetString("SrcFolder"), "Scripts");
        var distFolder = CombinePaths(data.GetString("DistFolder"), "Scripts");
        CopyDirectory(srcFolder, distFolder);
    });

Task("Pack")
    .IsDependentOn("Update-Settings-With-Version")
    .IsDependentOn("CSharp-NetCore-Pack-All")
    .IsDependentOn("NuGet-Package")
    .IsDependentOn("Changelog-Generate")
    .Does(() => {
        
    });

Task("Push")
    .IsDependentOn("Pack")
    .IsDependentOn("NuGet-Push")
    .Does(() => {
        
    });

    

Task("Default")
    .IsDependentOn("Pack");

Task("Deploy")
	.IsDependentOn("Push");

RunTarget(target);
