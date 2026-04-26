// -----------------------------------------------------------------------
// <copyright file="CommandSettings.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Installer
{
    using System;
    using System.CommandLine;
    using System.CommandLine.Invocation;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class CommandSettings
    {
        /// <summary>
        /// The RootCommand to the Atomiled Installer
        /// </summary>
        public static readonly RootCommand RootCommand = new()
        {
            new Option<DirectoryInfo?>(
                new[] { "-p", "--path" },
                (parsed) =>
                {
                    string path = parsed.Tokens.SingleOrDefault()?.Value ?? Directory.GetCurrentDirectory();

                    if (string.IsNullOrEmpty(path))
                    {
                        parsed.ErrorMessage = "--path is null or empty";
                        return null;
                    }

                    if (File.Exists(path))
                        parsed.ErrorMessage = "Can't be a file!";
                    else if (!Directory.Exists(path))
                        parsed.ErrorMessage = "Directory doesn't exist!";

                    return new DirectoryInfo(path); // return for default value
                },
                true,
                "Path to the folder with the SL server")
                { IsRequired = true },

            new Option<DirectoryInfo?>(
                "--appdata",
                (parsed) =>
                {
                    string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                    if (string.IsNullOrEmpty(appdataPath))
                        Console.Error.WriteLine("AppData path is null, make sure it exists");

                    string path = parsed.Tokens.SingleOrDefault()?.Value ?? appdataPath;

                    if (string.IsNullOrEmpty(path))
                    {
                        parsed.ErrorMessage = "--AppData is null or empty, make sure the AppData folder exists";
                        return null;
                    }

                    return new DirectoryInfo(path);
                },
                true,
                "Forces the folder to be the AppData folder (useful for containers when pterodactyl runs as root)")
                { IsRequired = true },

             new Option<DirectoryInfo?>(
                "--Atomiled",
                (parsed) =>
                {
                    string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                    if (string.IsNullOrEmpty(appdataPath))
                        Console.Error.WriteLine("Your Atomiled path is null, make sure it exists");

                    string path = parsed.Tokens.SingleOrDefault()?.Value ?? appdataPath;

                    if (string.IsNullOrEmpty(path))
                    {
                        parsed.ErrorMessage = "--Atomiled is null or empty, make sure your Atomiled folder exists";
                        return null;
                    }

                    return new DirectoryInfo(path);
                },
                true,
                "Indicates the root path of Atomiled")
                { IsRequired = true },

            new Option<bool>(
                "--pre-releases",
                () => false,
                "Includes pre-releases")
                { IsRequired = false },

            new Option<string?>(
                "--target-port",
                "Target port for AtomiledLoader installation")
                { IsRequired = false },

            new Option<string?>(
                "--target-version",
                "Target version for installation")
                { IsRequired = false },

            new Option<string?>(
                "--github-token",
                "Uses a token for auth in case the rate limit is exceeded (no permissions required)")
                { IsRequired = false },

            new Option<bool>(
                "--exit",
                "Automatically exits the application anyway")
                { IsRequired = false },

            new Option<bool>(
                "--get-versions",
                "Gets all possible versions for installation")
                { IsRequired = false },

            new Option<bool>(
                "--skip-version-select",
                "Skips version selecting")
                { IsRequired = false },
        };

#nullable disable
        /// <summary>
        /// Gets or sets the directory path.
        /// </summary>
        public DirectoryInfo Path { get; set; }

        /// <summary>
        /// Gets or sets the AppData directory path.
        /// </summary>
        public DirectoryInfo AppData { get; set; }

        /// <summary>
        /// Gets or sets the Atomiled directory path.
        /// </summary>
        public DirectoryInfo Atomiled { get; set; }
#nullable restore
        /// <summary>
        /// Gets or sets if it is a prerelease.
        /// </summary>
        public bool PreReleases { get; set; }

        /// <summary>
        /// Gets or sets the target port.
        /// </summary>
        public string? TargetPort { get; set; }

        /// <summary>
        /// Gets or sets the target version.
        /// </summary>
        public string? TargetVersion { get; set; }

        /// <summary>
        /// Gets or sets the GitHub token.
        /// </summary>
        public string? GitHubToken { get; set; }

        /// <summary>
        /// Gets or sets the version of Atomiled available.
        /// </summary>
        public bool GetVersions { get; set; }

        /// <summary>
        /// Gets or sets the boolean for exiting.
        /// </summary>
        public bool Exit { get; set; }

        /// <summary>
        /// Gets or sets the value indicating whether the version select should be skipped.
        /// </summary>
        public bool SkipVersionSelect { get; set; }

        public static async Task Parse(string[] args)
        {
            RootCommand.Handler = CommandHandler.Create<CommandSettings>(async args => await Program.MainSafe(args).ConfigureAwait(false));
            RootCommand.TreatUnmatchedTokensAsErrors = false;

            await RootCommand.InvokeAsync(args).ConfigureAwait(false);
        }
    }
}
