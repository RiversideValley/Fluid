using System;
using System.IO;

namespace Riverside.Fluid
{
    public class Foundation
    {
        /// <summary>
        /// Foundation.Install()
        /// 
        /// The base of connection with the outside world.
        /// Download packages today from GitHub and alike! You can even download non-Fluid projects. (🤔 Why you would do this we have no idea.)
        /// Coming soon: install Foundation packages from Git repositories not from GitHub!
        /// </summary>
        public static void Install(string applicationPublisher = "", string applicationName = "", string applicationGitIdentifier = "main", bool applicationHasSubmodules = false)
        {
            // Print the variable applicationPublisher

            string gitPublisher = applicationPublisher;
            string gitName = applicationName;
            bool requireDotPostActionHelper = false;
            string splitApplicationName = "";

            string[] specialPublisherList = { "RiversideValley", "Riverside" };

            foreach (string publisher in specialPublisherList)
            {
                if (applicationPublisher == publisher)
                {
                    // Special
                    if (gitPublisher == "RiversideValley")
                    {
                        applicationPublisher = "Riverside";
                    }
                    else if (gitPublisher == "Riverside")
                    {
                        gitPublisher = "RiversideValley";
                        // throw new RuntimeException("Illegal Fluid Foundation publisher; github publisher 43607 ('Riverside') is blocked.");
                    }
                }
            }

            if (gitPublisher.Contains("."))
            {
                // Very problematic.
                throw new Exception("FrameworkArchitectureError: An error occurred due to the way the Python and C-based Fluid backends were built which contradicts the code of the Fluid Runtime.");
            }
            else if (gitName.Contains("."))
            {
                // Very problematic.
                // However, this is very important to make work as most Riverside Valley repos contain dots in them.
                requireDotPostActionHelper = true;
                string[] splitApplicationNameArray = applicationName.Split('.');
                splitApplicationName = splitApplicationNameArray[0];
            }
            else if (gitName.StartsWith("Fluid.") && gitPublisher == "RiversideValley")
            {
                // Special repository.
                bool fluidSpecialRepo = true;
                applicationName = applicationName.Remove(0, "Fluid.".Length);
            }

            // TODO: Implement ability to install non-GitHub sourced Foundation packages.
            string gitRepoUrl = $"https://github.com/{gitPublisher}/{applicationName}.git"; // In order to implement the 'Install from non-GitHub repos' task, this url must be edited.

            try
            {
                string slash = Branding.SlashInPaths ? "/" : "\\";

                string packageLocation = $"{LibLocation}{slash}{applicationPublisher}{slash}{applicationName}";

                if (applicationHasSubmodules)
                {
                    Processing.Execute($"git clone {gitRepoUrl} {packageLocation} --recurse-submodules", "shell");
                }
                else
                {
                    Processing.Execute($"git clone {gitRepoUrl} {packageLocation}", "shell");
                }

                Processing.Execute($"cd {packageLocation}", "shell");
                Processing.Execute($"git checkout -q {applicationGitIdentifier}", "shell");
            }
            catch
            {
                throw new Exception("FoundationCloneError: There was a problem cloning the Foundation package");
            }

            // Post clone actions 🎉

            if (requireDotPostActionHelper)
            {
                // 🤔 How to do this...
                // I've got to thank GitHub Copilot for this one, without it, I might not have fixed this issue.

                Console.WriteLine("\nThe package you are attempting to install appears to contain illegal characters.\nNot to worry, the Fluid Helper will solve the problem for you. We will run some checks and tests on your machine; ignore console output if there is any.\n");

                string helperFile = $"{LibLocation}{slash}{applicationPublisher}{slash}{splitApplicationName}.{Fl}";

                try
                {
                    Explore(helperFile, true).Read();
                }
                catch (FileNotFoundException)
                {
                    // Create the file.
                    Explore(helperFile, true).Create();
                }

                foreach (string part in splitApplicationNameArray)
                {
                    foreach (string line in Explore.Read(helperFile, true))
                    {
                        if (line.StartsWith("class"))
                        {
                            continue;
                        }
                        else if (line.StartsWith("    ") && !line.Contains("class"))
                        {
                            // Fix!
                            Explore(helperFile, true, $"class {splitApplicationNameArray[1]}:\n    ").Append();
                        }
                        else
                        {
                            throw new Exception("FoundationCloneError: There was a problem reading the package's helper contents.");
                        }
                    }
                }
            }
        }
    }
}