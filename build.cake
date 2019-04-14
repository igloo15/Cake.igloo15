
#l "nuget:?package=Cake.igloo15.Scripts.Bundle.CSharp&version=2.0.0"

var target = Argument<string>("target", "Default");

AddSetup((d) => {
    d.Set("Markdown-Generator-Filter", "./dist/**/publish/Cake.igloo15*.dll");
});

AddTeardown((d) => {
    Information("Finished All Tasks");
});

Task("Update-Settings-With-Version")
    .IsDependentOn("Standard-All")
    .IsDependentOn("Copy-Folder")
	.Does<ProjectData>((data) => {

        Information($"Updating MSBuild with Version {data.ProjectVersion.LegacySemVerPadded}");

        if(AppVeyor.IsRunningOnAppVeyor)
			AppVeyor.UpdateBuildVersion(data.ProjectVersion.LegacySemVerPadded);

        ReplaceKey("###VERSION###", data.ProjectVersion.LegacySemVerPadded, "./dist/Scripts/**/*.cake");
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
    .IsDependentOn("CSharp-Bundle-Pack-All")
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
