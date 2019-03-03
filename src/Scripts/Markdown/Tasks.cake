


Task("MarkdownGenerator-Generate")
    .Does(() => {
        GenerateMarkdownApi();
    })
    .QuickError();