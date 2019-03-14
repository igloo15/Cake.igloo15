


Task("Markdown-Generate-Api")
    .Does(() => {
        GenerateMarkdownApi();
    })
    .QuickError();


Task("Markdown-Generate")
    .Does(() => {
        GenerateMarkdownApi();
    })
    .QuickError();