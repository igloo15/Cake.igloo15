
ArgumentOrEnvironmentVariable<string>("Markdown-Generator-Filter", "./dist/**/publish/*.dll");

Task("Markdown-Generate-Api")
    .Does<ProjectData>((data) => {
        GenerateMarkdownApi(data.GetStr("Markdown-Generator-Filter"), CombinePaths(data.GetStr("DocsFolder"), "Api"));
    })
    .CompleteTask();
