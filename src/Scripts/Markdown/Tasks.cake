


Task("Markdown-Generate-Api")
    .Does<ProjectData>((data) => {
        var searchArea = CreateSearchArea(data.GetString("DistFolder"), (dir) => {
            return !dir.FullPath.Contains("publish");
        });
        
        Information($"Search Area: {searchArea}");
        GenerateMarkdownApi(searchArea, CombinePaths(data.GetString("DocsFolder"), "Api"));
    })
    .CompleteTask();
