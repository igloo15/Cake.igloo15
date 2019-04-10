#addin "Cake.Incubator&version=3.1.0"
#addin "nuget:?package=Cake.igloo15.Helper&version=0.2.0-dev0011"

#l "nuget:?package=Cake.igloo15.Scripts.Changelog&version=0.2.0-dev0012"
#l "./dist/Scripts/Standard/Standard.cake"

var target = Argument<string>("target", "Default");

Task("Copy-Folder")
    .Does((data) => {
        //CopyDirectory(Directory(data["SrcFolder"].ToString()) + Directory("Scripts"), Directory(data["DistFolder"].ToString()) + Directory("Scripts"));
    });

Task("DownVersion")
    .Does(() => {
        ReplaceKey("0.2.0-dev0006", "0.2.0-dev0005", "./dist/Scripts/**/*.cake");
    });
   

Task("Default")
    .IsDependentOn("Standard-Update-Version")
    .IsDependentOn("Changelog-CreateConfig")
    .Does(() => {
        Information("It Built");
    });

RunTarget(target);
