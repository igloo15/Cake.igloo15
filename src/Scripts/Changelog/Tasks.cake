

Task("Changelog-Generate")
    .IsDependentOn("Changelog-CreateConfig")
    .Does(() => {
        GenerateChangelog();
    })
    .QuickError();

Task("Changelog-CreateConfig")
    .Does(() => {
        if(!FileExists("./changelog.json")) 
        {
            CreateChangelogConfig();
        }
    })
    .QuickError();