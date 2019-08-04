
#addin "nuget:?package=Cake.igloo15.Helper&version=###VERSION###&prerelease"

ArgumentOrEnvironmentVariable<string>("SrcFolder", "./src");
ArgumentOrEnvironmentVariable<string>("PackagesLocal", "./packages.local");
ArgumentOrEnvironmentVariable<string>("DistFolder", "./dist");
ArgumentOrEnvironmentVariable<string>("DocsFolder", "./docs");
