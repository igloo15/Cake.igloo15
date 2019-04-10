


Task("Markdown-Generate-Api")
    .Does<ProjectData>((data) => {
        var searchPath = "";
        var directories = GetDirectories(data.GetString("DistFolder")+"/**/*");
        foreach (var item in directories)   
        {
            var dirSearchPath = item.FullPath + "/*.dll";
            searchPath += dirSearchPath+";";
            Information($"Searching {dirSearchPath}");
        }

        GenerateMarkdownApi(searchPath, CombinePaths(data.GetString("DocsFolder"), "Api"));
    })
    .CompleteTask();
