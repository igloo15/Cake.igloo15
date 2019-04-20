
ArgumentOrEnvironmentVariable("next-version", "Unreleased");

Task("Changelog-Generate")
    .IsDependentOn("Changelog-CreateConfig")
    .Does<ProjectData>(data => {
        var value = data.GetArgValue("next-version");

        if(value.IsDefault)
        {
            GenerateChangelog();
        }
        else 
        {
            Information($"Using Next Version: {value.GetValue<string>()}");
            GenerateChangelog(value.GetValue<string>());
        }
    })
    .CompleteTask();

Task("Changelog-CreateConfig")
    .Does(() => {
        if(!FileExists("./changelog.json")) 
        {
            CreateChangelogConfig();
        }
    })
    .CompleteTask();