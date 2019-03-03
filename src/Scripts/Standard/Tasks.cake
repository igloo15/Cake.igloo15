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