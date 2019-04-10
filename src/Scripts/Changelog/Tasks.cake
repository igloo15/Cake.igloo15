

Task("Changelog-Generate")
    .IsDependentOn("Changelog-CreateConfig")
    .Does(() => {
        GenerateChangelog();
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