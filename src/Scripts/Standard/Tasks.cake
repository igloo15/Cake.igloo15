#tool "nuget:?package=GitVersion.CommandLine&version=4.0.0"
#addin "Cake.Incubator&version=3.1.0"

#l Arguments.cake

Task("Standard-ProjectData-Dump")
    .Does<ProjectData>(data => {
        Information(data.ToString());
    })
    .CompleteTask();

Task("Standard-Update-Version")
    .Does<ProjectData>(data => {
        Information("Calculating Semantic Version...");
        		
		var result = GitVersion(new GitVersionSettings {
					UpdateAssemblyInfo = true,
					OutputType = GitVersionOutput.Json,
					NoFetch = true
				});

		var cakeVersion = typeof(ICakeContext).Assembly.GetName().Version.ToString();

		Information($"Cake Version : {cakeVersion}");
        Information("");
        Information("GitVersion:");
        Information(result.Dump());

        data.Version = result;
    })
    .CompleteTask();

Task("Standard-Packages-Local")
    .Does<ProjectData>(data => {
        CleanCreateDirectory(data.GetString("PackagesLocal"));
    })
    .CompleteTask();

Task("Standard-Src-Folder")
    .Does<ProjectData>(data => {
        CreateDirectory(data.GetString("SrcFolder"));
    })
    .CompleteTask();

Task("Standard-Dist-Folder")
    .Does<ProjectData>(data => {
        CleanCreateDirectory(data.GetString("DistFolder"));
    })
    .CompleteTask();

Task("Standard-Docs-Folder")
    .Does<ProjectData>(data => {
        CreateDirectory(data.GetString("DocsFolder"));
    })
    .CompleteTask();

Task("Standard-Folders")
    .IsDependentOn("Standard-Docs-Folder")
    .IsDependentOn("Standard-Dist-Folder")
    .IsDependentOn("Standard-Src-Folder")
    .IsDependentOn("Standard-Packages-Local")
    .CompleteTask();


Task("Standard-All")
    .IsDependentOn("Standard-Folders")
    .IsDependentOn("Standard-ProjectData-Dump")
    .IsDependentOn("Standard-Update-Version")
    .CompleteTask();