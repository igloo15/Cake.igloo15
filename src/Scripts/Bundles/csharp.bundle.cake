
#l "nuget:?package=Cake.igloo15.Scripts.Standard&version=###VERSION###&prerelease"
#l "nuget:?package=Cake.igloo15.Scripts.CSharp&version=###VERSION###&prerelease"
#l "nuget:?package=Cake.igloo15.Scripts.NuGet&version=###VERSION###&prerelease"
#l "nuget:?package=Cake.igloo15.Scripts.Changelog&version=###VERSION###&prerelease"
#l "nuget:?package=Cake.igloo15.Scripts.Markdown&version=###VERSION###&prerelease"

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