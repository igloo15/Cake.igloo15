#tool "nuget:?package=GitVersion.CommandLine&version=4.0.0"
#addin "Cake.Incubator&version=3.1.0"
#addin "nuget:?package=Cake.Git&version=0.19.0"

#l Arguments.cake

Task("Standard-ProjectData-Dump")
    .Does<ProjectData>(data => {
        Information(data.ToString());
    });

Task("Standard-Update-Version")
    .Does<ProjectData>(data => {
        Information("Calculating Semantic Version...");

        var fullBranchName = "refs/"+GitDescribe(".", false, GitDescribeStrategy.All);

		Environment.SetEnvironmentVariable("Git_Branch", fullBranchName, EnvironmentVariableTarget.Process);
        		
		var result = GitVersion(new GitVersionSettings {
					UpdateAssemblyInfo = true,
					OutputType = GitVersionOutput.Json,
                    Branch = fullBranchName,
					NoFetch = true
				});

		var cakeVersion = typeof(ICakeContext).Assembly.GetName().Version.ToString();

		Information($"Cake Version : {cakeVersion}");
        Information("");
        Information("GitVersion:");
        Information(result.Dump());

        data.Version = result;
    });