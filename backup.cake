#addin "Cake.Incubator&version=3.1.0"

#r "./dist/Cake.igloo15.Helper/Debug/netstandard2.0/Cake.igloo15.Helper.dll"

var target = Argument<string>("target", "Default");

Task("Copy-Folder")
    .Does<ProjectData>((data) => {
        CopyDirectory(Directory(data["SrcFolder"].ToString()) + Directory("Scripts"), Directory(data["DistFolder"].ToString()) + Directory("Scripts"));
    });

Task("DownVersion")
    .Does(() => {
        ReplaceKey("0.2.0-dev0006", "0.2.0-dev0005", "./dist/Scripts/**/*.cake");
    });
   

Task("Default")
    .IsDependentOn("Copy-Folder");

RunTarget(target);
