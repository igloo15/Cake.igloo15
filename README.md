Cake.igloo15 Scripts
===
A collection of cake scripts and addins used in various projects

### Master
[![Build status](https://ci.appveyor.com/api/projects/status/vvgxhewiu4wpo9ri/branch/master?svg=true)](https://ci.appveyor.com/project/igloo15/cake-igloo15/branch/master)

### Nuget Packages
#### Addins
[![Nuget](https://img.shields.io/nuget/vpre/Cake.igloo15.ChangelogGenerator.svg?label=Cake.igloo15.ChangelogGenerator)](https://www.nuget.org/packages/Cake.igloo15.ChangelogGenerator/)
[![Nuget](https://img.shields.io/nuget/vpre/Cake.igloo15.Helper.svg?label=Cake.igloo15.Helper)](https://www.nuget.org/packages/Cake.igloo15.Helper/)
[![Nuget](https://img.shields.io/nuget/vpre/Cake.igloo15.MarkdownApi.svg?label=Cake.igloo15.MarkdownApi)](https://www.nuget.org/packages/Cake.igloo15.MarkdownApi/)
[![Nuget](https://img.shields.io/nuget/vpre/Cake.igloo15.MarkdownApi.svg?label=Cake.igloo15.MarkdownDocument)](https://www.nuget.org/packages/Cake.igloo15.MarkdownDocument/)
#### Scripts
[![Nuget](https://img.shields.io/nuget/vpre/Cake.igloo15.Scripts.Standard.svg?label=Cake.igloo15.Scripts.Standard)](https://www.nuget.org/packages/Cake.igloo15.Scripts.Standard/)
[![Nuget](https://img.shields.io/nuget/vpre/Cake.igloo15.Scripts.CSharp.svg?label=Cake.igloo15.Scripts.CSharp)](https://www.nuget.org/packages/Cake.igloo15.Scripts.CSharp/)
[![Nuget](https://img.shields.io/nuget/vpre/Cake.igloo15.Scripts.NuGet.svg?label=Cake.igloo15.Scripts.NuGet)](https://www.nuget.org/packages/Cake.igloo15.Scripts.NuGet/)
[![Nuget](https://img.shields.io/nuget/vpre/Cake.igloo15.Scripts.Changelog.svg?label=Cake.igloo15.Scripts.Changelog)](https://www.nuget.org/packages/Cake.igloo15.Scripts.Changelog/)
[![Nuget](https://img.shields.io/nuget/vpre/Cake.igloo15.Scripts.Markdown.svg?label=Cake.igloo15.Scripts.Markdown)](https://www.nuget.org/packages/Cake.igloo15.Scripts.Markdown/)

#### Script Bundles
[![Nuget](https://img.shields.io/nuget/vpre/Cake.igloo15.Scripts.Bundle.CSharp.svg?label=Cake.igloo15.Scripts.Bundle.CSharp)](https://www.nuget.org/packages/Cake.igloo15.Scripts.Bundle.CSharp/)

## Build

```
.\build.ps1
```

## Usage

Easy quick usage of cake scripts allow you to do a ton of stuff with a small footprint. Deep Dive into [API](./docs/api) if you want to see more of the functionality of the Addins. Read the scripts in the [./src/Scripts](./src/Scripts) folder to see what tasks are available for each nuget package.

```csharp
#l 'nuget:?package=Cake.igloo15.Scripts.Bundle.CSharp&version=2.0.0'

var target = Argument<string>("target", "Default");

AddSetup((d) => {
    d.Set("Markdown-Generator-Filter", "./dist/**/publish/Cake.igloo15*.dll");
});

Task("Pack")
    .IsDependentOn("CSharp-Bundle-Pack-All")
    .CompleteTask();

Task("Publish")
    .IsDependentOn("CSharp-Bundle-Publish-All")
    .CompleteTask();

Task("Default")
    .IsDependentOn("Pack")
    .CompleteTask();

RunTarget(target)

```

### Examples

See Api and Scripts

