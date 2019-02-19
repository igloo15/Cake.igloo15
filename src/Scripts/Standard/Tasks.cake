#tool "nuget:?package=GitVersion.CommandLine&version=4.0.0"

#addin "nuget:?package=Cake.Git&version=0.19.0"

Task("Standard-Default-Properties")
    .Does<ProjectData>(data => {
        data["SrcFolder"] = "./src";
        data["PackagesLocal"] = "./packages.local";
        data["DistFolder"] = "./dist";
        data["DocsFolder"] = "./docs";
    });

Task("Standard-ProjectData-Dump")
    .IsDependentOn("Standard-Default-Properties")
    .Does<ProjectData>(data => {
        Information(data.ToString());
    });

Task("Standard-Update-Version")
    .IsDependentOn("Standard-Default-Properties")
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