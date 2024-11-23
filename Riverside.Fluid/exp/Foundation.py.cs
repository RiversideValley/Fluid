// Foundation
// 
// A fast, fully-fledged package manager for the Fluid framework.
// 

using Processing = System.Processing;

using Branding = System.Branding;

using Explore = System.Explore;

using Console = System.Console;

using Legacy = System.Legacy;

using Null = System.Null;

using LibLocation = Fluid.Location;

using Fl = Fluid.Extension;

using Exception = Fluid.Exception;

using System.Collections.Generic;

public static class Foundation {
    
    // Foundation.Install()
    //     
    //     The base of connection with the outside world.
    //     Download packages today from GitHub and alike! You can even download non-Fluid projects. (🤔 Why you would do this we have no idea.)
    //     Coming soon: install Foundation packages from Git repositories not from GitHub!
    //     
    public static object Install(string ApplicationPublisher = "", string ApplicationName = "", string ApplicationGitIdentifier = "main", bool ApplicationHasSubmodules = false) {
        object Slash;
        // Print the variable ApplicationPublisher
        var GitPublisher = ApplicationPublisher;
        var GitName = ApplicationName;
        var RequireDotPostActionHelper = false;
        var SplitApplicationName = "";
        var SpecialPublisherList = new List<string> {
            "RiversideValley",
            "Riverside"
        };
        foreach (var str in SpecialPublisherList) {
            if (object.ReferenceEquals(ApplicationPublisher, str)) {
                // Special
                if (GitPublisher == "RiversideValley") {
                    ApplicationPublisher = "Riverside";
                } else if (GitPublisher == "Riverside") {
                    GitPublisher = "RiversideValley";
                    // raise RuntimeError("Illegal Fluid Foundation publisher; github publisher 43607 ('Riverside') is blocked.")
                }
            }
        }
        if (GitPublisher.Contains(".")) {
            // Very problematic.
            throw Exception.FrameworkArchitectureError("An error occured due to the way the Python and C-based Fluid backends were built which contradicts the code of the Fluid Runtime.");
        } else if (GitName.Contains(".")) {
            // Very problematic.
            // However, this is very important to make work as most Riverside Valley repos contain dots in them.
            RequireDotPostActionHelper = true;
            SplitApplicationName = ApplicationName.split(".");
        } else if (GitName.Contains("Fluid.") && object.ReferenceEquals("RiversideValley", GitPublisher)) {
            // Special repository.
            var FluidSpecialRepo = true;
            ApplicationName = ApplicationName.removeprefix("Fluid.");
        }
        // TODO: Implement ability to install non-GitHub sourced Foundation packages.
        var GitRepoUrl = $"https://github.com/{GitPublisher}/{ApplicationName}.git";
        try {
            if (Branding.SlashInPaths != true) {
                Slash = "\\";
            } else {
                Slash = "/";
            }
            var PackageLocation = $"{LibLocation}{Slash}{ApplicationPublisher}{Slash}{ApplicationName}";
            if (ApplicationHasSubmodules) {
                Processing.Execute($"git clone {GitRepoUrl} {PackageLocation} --recurse-submodules", Language: "shell");
            } else if (ApplicationHasSubmodules != true) {
                Processing.Execute($"git clone {GitRepoUrl} {PackageLocation}", Language: "shell");
            } else {
                throw Exception.FoundationCloneError("Error with submodules");
            }
            Processing.Execute($"cd {PackageLocation}", Language: "shell");
            Processing.Execute($"git checkout -q {ApplicationGitIdentifier}", Language: "shell");
        } catch {
            throw Exception.FoundationCloneError("There was a problem cloning the Foundation package");
        }
        if (object.ReferenceEquals(RequireDotPostActionHelper, true)) {
            // 🤔 How to do this...
            // I've got to thank GitHub Copilot for this one, without it, I might not have fixed this issue.
            // if GitPublisher is SpecialPublisherList[1]:
            // Fix only if the provider is Riverside Valley Corporation.
            //     raise NotImplementedError
            // else:
            //     raise NotImplementedError("\nThe package you are attempting to install appears to contain illegal characters, and is not yet supported by the Fluid Runtime. Try renaming your Git repository.\nOtherwise, there is a temporary fix: https://github.com/RiversideValley/Fluid.Runtime/wiki/Classes.Foundation#-if-you-have-a-package-with-a-dot--in-its-name-the-foundation-will-fail-to-install-the-package-this-is-due-to-the-nature-of-the-python-and-c-based-libraries-the-fluid-runtime-depends-on-which-contain-a-restriction-causing-the-code-to-fail-we-are-still-locating-the-root-of-this-restriction-but-it-will-be-fixed-at-some-point-meanwhile-you-can-create-an-issue-and-we-will-implement-the-workaround-for-your-package")
            Console.WriteLine("\nThe package you are attempting to install appears to contain illegal characters.\nNot to worry, the Fluid Helper will solve the problem for you. We will run some checks and tests on your machine; ignore console output if there is any.\n");
            var HelperFile = $"{LibLocation}{Slash}{ApplicationPublisher}{Slash}{SplitApplicationName[0]}.{Fl}";
            try {
                Explore(HelperFile, true).Read();
            } catch (FileNotFoundError) {
                // Create the file.
                Explore(HelperFile, true).Create();
            }
            foreach (var str in SplitApplicationName) {
                foreach (var line in Explore.Read(HelperFile, Auto: true)) {
                    if (line.startswith("class")) {
                    } else if (line.startswith("    ") && !line.Contains("class")) {
                        // Fix!
                        Explore(HelperFile, true, $"class {SplitApplicationName[1]}:\n    ").Append();
                    } else {
                        throw Exception.FoundationCloneError("There was a problem reading the package's helper contents.");
                        //try:
                        //    Explore.Append(f"{LibLocation}{Slash}{ApplicationPublisher}{Slash}{SplitApplicationName[0]}.{Fl}", Auto=True, AutoValue=f"class {SplitApplicationName[1]}:\n    ")
                        //except:
                    }
                }
            }
        }
    }
}
