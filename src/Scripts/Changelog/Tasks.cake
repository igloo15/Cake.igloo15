

Task("Changelog-Generate")
    .Does(() => {
        GenerateChangelog();
    });

Task("Changelog-CreateConfig")
    .Does(() => {
        CreateChangelogConfig();
    });