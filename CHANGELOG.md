# Changelog
## v2.0.1
### Summary


### Add
*  N/A 


### Changes
*  Update Readme with more information
*  update packages with links to changelog


### Fixed
*  N/A 


### Other Commits
*  N/A 




## v2.0.0
### Summary


### Add
*  introduced new ArgValue class to handle determining if an argument is the default value or not as well as if it should be marked private
*  many new methods added to ProjectData to handle a multitude of ways of using it


### Changes
*  updated documentation
*  continue to update tasks to match ProjectData changes
*  Update all Scripts files to new ProjectData functionality
*  update to latest changelog generator
*  updated markdown generator to latest version
*  modified changelog config to include additional keys
*  updated documentation
*  only master branch will not be built on appveyor
*  updated NuGet Scripts to better handle private arguments like NuGetApiKey
*  updated build scripts to latest version


### Fixed
*  comments in changelog extensions fixed
*  changed markdown filter to be more specific


### Other Commits
* Merge branch 'develop'




## v1.1.0
### Summary


### Add
*  N/A 


### Changes
*  Update changelog generator to latest version
*  Update Api Documentation
*  Update changelog config file
*  update to new changelog generator
*  update to latest markdown generator tool


### Fixed
*  N/A 


### Other Commits
* Merge branch 'develop'
* Getting ready for final release
* Merge branch 'master' into develop




## v1.0.0
### Summary


### Add
*  markdown is now part of csharp bundle
*  logging added to markdown api documentation
*  Create SearchArea in MarkdownApi Addin allows you to create a search area to do markdown on
*  Api Documentation now being added
*  current task executing to ProjectData
*  CompleteTask now takes parameter to determine if it should continue on error
*  SetupProjectData is now a task method that can be executed
*  Functionality to stop execution if error occurs
*  Functionality to add a complete task if you don't intend to use Does and just want to know task completes
*  new changelog methods in addin to support testing changelog and next version arguments
*  new tasks to create and/or clean standard folders
*  Markdown Merger is now functional it will merge markdown files into one large file
*  initial markdown tasks
*  Changelog config added
*  QuickError Added to all tasks
*  Path Extensions to clean and create a directory and also combine paths
*  Flesh out all comments
*  Documentation added to all addins
*  Bundle added for csharp
*  fix solution path csharp scripts
*  backup scripts to allow for downgrading
*  nuspec files for cake scripts
*  ReplaceKey Method
*  Markdown, CSharp, Nuget, and Changelog Scripts added
*  Changelog cake dll added
*  Nuget package reference to helper tasks
*  Helper Addins and MarkdownApi Addins
*  Create Standard Cake scripts and CSharp Cake scripts


### Changes
*  Update Build Scripts to latest dev version
*  Api Documentation Updated
*  update MarkdownApi Addin to use latest version
*  Many tasks updated to use CompleteTask
*  remove code in Setup to allow for calling new addin function SetupProjectData
*  CreateConfig now checks if config already exists Generate Changelog now creates config if none exists
*  update cake version and fix git ignore
*  update to new build scripts
*  don't need markdown dependencies
*  update packaging on markdown api addin
*  refactor markdown doc creator methods
*  try with private assets again
*  add more space to test linking
*  update readme
*  add build ci settings to only build on certian branches
*  References are now packaged inside Cake.igloo15.Changelog addin
*  now referencing cake nuget packages
*  remove information logging in filter for nuget tasks
*  Project Data and Events moved to Helper Dll
*  clean up csproj nuspec settings
*  update csproj files for addins


### Fixed
*  logging statements not flushed before task finishes
*  fix how creating search area is done
*  teardown, tasksetup and taskteardown fixed to work properly with lazy loading of ProjectData
*  attempt to fix missing projectdata
*  clean and create packages.local folder
*  move build.cake back to old version in order to fix it
*  missing an s on task
*  Does requires an argument
*  standard folder creation fix
*  remove private assets tag on ChangelogGenerator so that all libs are generated correctly
*  attempt to fix appveyor.yml file
*  nuget packages doesn't include all files
*  Changelog should now load since Cake.Git is no longer referenced
*  build system doesn't have packages.local which causes error in running script
*  CSharp Tasks now reference the correct buildsettings
*  Missing dll tasks are removed


### Other Commits
* Merge branch 'develop'
* update changelog generator
* #New standard folder tasks




## v0.1.0
### Summary


### Add
*  N/A 


### Changes
*  N/A 


### Fixed
*  N/A 


### Other Commits
* Initial Commits





