#tool "nuget:?package=GitVersion.CommandLine&version=4.0.0"
#addin "Cake.Incubator&version=3.1.0"

#l Arguments.cake

Task("Standard-ProjectData-Dump")
    .Does<ProjectData>(data => {
        Information(data.ToString());
    })
    .QuickError();

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
    .QuickError();

Task("Standard-Package-Local")
    .Does<ProjectData>(data => {
        CleanCreateDirectory(ProjectData.GetString("PackagesLocal"));
    })
    .QuickError();

Task("Standard-Src-Folder")
    .Does<ProjectData>(data => {
        CreateDirectory(ProjectDat.GetString("SrcFolder"));
    })
    .QuickError();

Task("Standard-Dist-Folder")
    .Does<ProjectData>(data => {
        CleanCreateDirectory(ProjectData.GetString("DistFolder"));
    })
    .QuickError();

Task("Standard-Docs-Folder")
    .Does<ProjectData>(data => {
        CreateDirectory(ProjectData.GetString("DocsFolder"));
    })
    .QuickError();

Task("Standard-Folders")
    .IsDependentOn("Standard-Docs-Folder")
    .IsDependentOn("Standard-Dist-Folder")
    .IsDependentOn("Standard-Src-Folder")
    .IsDependentOn("Standard-Packages-Local")
    .Does<ProjectData>(data => {

    })
    .QuickError();


Task("Standard-All")
    .IsDependentOn("Standard-Folders")
    .IsDependentOn("Standard-ProjectData-Dump")
    .IsDependentOn("Standard-Update-Version")
    .Does()
    .QuickError();