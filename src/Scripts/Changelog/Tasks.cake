
ArgumentOrEnvironmentVariable("NextVersion", "Unreleased");

Task("Changelog-Generate")
    .IsDependentOn("Changelog-CreateConfig")
    .Does<ProjectData>(data => {
        var value = data.GetArgValue("NextVersion");

        if(!value.IsDefault)
        {
            GenerateChangelog();
        }
        else 
        {
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