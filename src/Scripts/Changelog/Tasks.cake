

Task("Changelog-Generate")
    .Does(() => {
        GenerateChangelog();
    })
    .QuickError();

Task("Changelog-CreateConfig")
    .Does(() => {
        CreateChangelogConfig();
    })
    .QuickError();