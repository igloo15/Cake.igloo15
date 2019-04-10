


Task("Markdown-Generate-Api")
    .Does<ProjectData>((data) => {
        var searchArea = CreateSearchArea(data.GetString("DistFolder"), (dir) => {
            return !dir.FullPath.Contains("publish");
        });
        GenerateMarkdownApi(searchArea, CombinePaths(data.GetString("DocsFolder"), "Api"));
    })
    .CompleteTask();
