
ArgumentOrEnvironmentVariable<string>("Markdown-Generator-Filter", "./dist/**/publish/*.dll");

Task("Markdown-Generate-Api")
    .Does<ProjectData>((data) => {
        GenerateMarkdownApi(data.GetString("Markdown-Generator-Filter"), CombinePaths(data.GetString("DocsFolder"), "Api"));
    })
    .CompleteTask();
