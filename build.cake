#addin "Cake.Incubator&version=3.1.0"
#addin "nuget:?package=Cake.igloo15.MarkdownApi&version=0.2.0-dev0039"

#l "nuget:?package=Cake.igloo15.Scripts.Bundle.CSharp&version=0.2.0-dev0039"



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
    .IsDependentOn("Standard-All")
    .IsDependentOn("Copy-Folder")
	.Does<ProjectData>((data) => {

        Information($"Updating MSBuild with Version {data.Version.LegacySemVerPadded}");

        if(AppVeyor.IsRunningOnAppVeyor)
			AppVeyor.UpdateBuildVersion(data.Version.LegacySemVerPadded);

        ReplaceKey("###VERSION###", data.Version.LegacySemVerPadded, "./dist/Scripts/**/*.cake");
	})
    .CompleteTask();

Task("Copy-Folder")
    .Does<ProjectData>((data) => {
        var srcFolder = CombinePaths(data.GetString("SrcFolder"), "Scripts");
        var distFolder = CombinePaths(data.GetString("DistFolder"), "Scripts");
        CopyDirectory(srcFolder, distFolder);
    })
    .CompleteTask();

Task("Pack")
    .IsDependentOn("Update-Settings-With-Version")
    .IsDependentOn("CSharp-NetCore-Pack-All")
    .IsDependentOn("NuGet-Package")
    .IsDependentOn("Changelog-Generate")
    .Does<ProjectData>((data) => {
        var searchPath = "";
        searchPath += CombinePaths(data.GetString("DistFolder"), "Cake.igloo15.ChangelogGenerator", "Release", "netstandard2.0")+"/*.dll;";
        searchPath += CombinePaths(data.GetString("DistFolder"), "Cake.igloo15.Helper", "Release", "netstandard2.0")+"/*.dll;";
        searchPath += CombinePaths(data.GetString("DistFolder"), "Cake.igloo15.MarkdownApi", "Release", "netstandard2.0")+"/*.dll;";
        searchPath += CombinePaths(data.GetString("DistFolder"), "Cake.igloo15.MarkdownDocument", "Release", "netstandard2.0")+"/*.dll";
        GenerateMarkdownApi(searchPath, "./docs/api");
    })
    .CompleteTask();

Task("Push")
    .IsDependentOn("Pack")
    .IsDependentOn("NuGet-Push")
    .CompleteTask();

    

Task("Default")
    .IsDependentOn("Pack")
    .CompleteTask();

Task("Deploy")
	.IsDependentOn("Push")
    .CompleteTask();

RunTarget(target);
