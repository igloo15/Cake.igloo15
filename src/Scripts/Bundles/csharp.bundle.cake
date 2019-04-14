
#l "nuget:?package=Cake.igloo15.Scripts.Standard&version=###VERSION###"
#l "nuget:?package=Cake.igloo15.Scripts.CSharp&version=###VERSION###"
#l "nuget:?package=Cake.igloo15.Scripts.NuGet&version=###VERSION###"
#l "nuget:?package=Cake.igloo15.Scripts.Changelog&version=###VERSION###"
#l "nuget:?package=Cake.igloo15.Scripts.Markdown&version=###VERSION###"

Task("CSharp-Bundle-Pack-All")
    .IsDependentOn("Standard-All")
    .IsDependentOn("CSharp-NetCore-Pack-All")
    .IsDependentOn("NuGet-Package")
    .IsDependentOn("Changelog-Generate")
    .IsDependentOn("Markdown-Generate-Api")
    .CompleteTask();

Task("CSharp-Bundle-Push-All")
    .IsDependentOn("CSharp-Bundle-Pack-All")
    .IsDependentOn("NuGet-Push")
    .CompleteTask();