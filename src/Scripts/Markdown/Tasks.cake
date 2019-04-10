


Task("Markdown-Generate-Api")
    .Does(() => {
        GenerateMarkdownApi();
    })
    .CompleteTask();


Task("Markdown-Generate")
    .Does(() => {
        GenerateMarkdownApi();
    })
    .CompleteTask();