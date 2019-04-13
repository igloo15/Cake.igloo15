# Changelog
## Unreleased


## v1.1.0
### Other Commits
* Merge branch 'develop'
* Getting ready for final release
* #Change Update changelog generator to latest version
* #Change Update Api Documentation
* #Change Update changelog config file
* #Change update to new changelog generator
* #Change update to latest markdown generator tool
* Merge branch 'master' into develop




## v1.0.0
### Other Commits
* Merge branch 'develop'
* #Change Update Build Scripts to latest dev version
* #Add markdown is now part of csharp bundle
* #Fix logging statements not flushed before task finishes
* #Fix fix how creating search area is done
* #Change Api Documentation Updated
* #Change update MarkdownApi Addin to use latest version
* #Add logging added to markdown api documentation
* #Add Create SearchArea in MarkdownApi Addin allows you to create a search area to do markdown on
* #Add Api Documentation now being added
* #Fix teardown, tasksetup and taskteardown fixed to work properly with lazy loading of ProjectData
* #Fix attempt to fix missing projectdata
* #Add current task executing to ProjectData
* #Add CompleteTask now takes parameter to determine if it should continue on error
* #Add SetupProjectData is now a task method that can be executed
* #Change Many tasks updated to use CompleteTask
* #Change remove code in Setup to allow for calling new addin function SetupProjectData
* #Add Functionality to stop execution if error occurs
* #Add Functionality to add a complete task if you don't intend to use Does and just want to know task completes
* #Add new changelog methods in addin to support testing changelog and next version arguments
* #Change CreateConfig now checks if config already exists Generate Changelog now creates config if none exists
* #Changes update cake version and fix git ignore
* #Changes update to new build scripts
* #Fix clean and create packages.local folder
* #Fix move build.cake back to old version in order to fix it
* update changelog generator
* #Change don't need markdown dependencies
* #Change update packaging on markdown api addin
* #Change refactor markdown doc creator methods
* #Fix missing an s on task
* #Fix Does requires an argument
* #Fix standard folder creation fix
* #New standard folder tasks
* #Add new tasks to create and/or clean standard folders
* #Fix remove private assets tag on ChangelogGenerator so that all libs are generated correctly
* #Change try with private assets again
* #Add Markdown Merger is now functional it will merge markdown files into one large file
* #Change add more space to test linking
* #Change update readme
* #Fix attempt to fix appveyor.yml file
* #Change add build ci settings to only build on certian branches
* #Add initial markdown tasks
* #Fix nuget packages doesn't include all files
* #Change References are now packaged inside Cake.igloo15.Changelog addin
* #Add Changelog config added
* #Add QuickError Added to all tasks
* #Fix Changelog should now load since Cake.Git is no longer referenced
* #Add Path Extensions to clean and create a directory and also combine paths
* #Fix build system doesn't have packages.local which causes error in running script
* #Add Flesh out all comments
* #Add Documentation added to all addins
* #Add Bundle added for csharp
* #add fix solution path csharp scripts
* #Change now referencing cake nuget packages
* #Fix CSharp Tasks now reference the correct buildsettings
* #Change remove information logging in filter for nuget tasks
* #Add backup scripts to allow for downgrading
* #Add nuspec files for cake scripts
* #Add ReplaceKey Method
* #Change Project Data and Events moved to Helper Dll
* #Add Markdown, CSharp, Nuget, and Changelog Scripts added
* #Add Changelog cake dll added
* #Change clean up csproj nuspec settings
* #Add Nuget package reference to helper tasks
* #Fix Missing dll tasks are removed
* #Add Helper Addins and MarkdownApi Addins
* #Add Create Standard Cake scripts and CSharp Cake scripts
* #Change update csproj files for addins




## v0.1.0
### Other Commits
* Initial Commits




