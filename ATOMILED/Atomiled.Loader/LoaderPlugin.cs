// -----------------------------------------------------------------------
// <copyright file="LoaderPlugin.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Loader
{
    using System;
    using System.IO;
    using System.Reflection;

    using LabApi.Loader.Features.Plugins;
    using LabApi.Loader.Features.Plugins.Enums;
    using MEC;

    using Log = API.Features.Log;
    using Paths = API.Features.Paths;

    /// <summary>
    /// The Northwood LabAPI Plugin class for the ATOMILED Loader.
    /// </summary>
    public class LoaderPlugin : Plugin<Config>
    {
#pragma warning disable SA1401
        /// <summary>
        /// The config for the ATOMILED Loader.
        /// </summary>
        public static new Config Config;

        /// <summary>
        /// The config for the ATOMILED Loader.
        /// </summary>
        public static LoaderPlugin Instance;
#pragma warning restore SA1401

        /// <summary>
        /// Gets the Name of the ATOMILED Loader.
        /// </summary>
        public override string Name => "Atomiled Loader";

        /// <summary>
        /// Gets the Description of the ATOMILED Loader.
        /// </summary>
        public override string Description => "Loads the ATOMILED Plugin Framework.";

        /// <summary>
        /// Gets the Author of the ATOMILED Loader.
        /// </summary>
        public override string Author => "ExMod-Team";

        /// <summary>
        /// Gets the RequiredApiVersion of the ATOMILED Loader.
        /// </summary>
        public override Version RequiredApiVersion => LabApi.Features.LabApiProperties.CurrentVersion;

        /// <summary>
        /// Gets the Atomiled Version.
        /// </summary>
        public override Version Version => Loader.Version;

        /// <summary>
        /// Gets the Atomiled Priority load.
        /// </summary>
        public override LoadPriority Priority { get; } = (LoadPriority)byte.MaxValue;

        /// <summary>
        /// Called by LabAPI when the plugin is enabled.
        /// </summary>
        public override void Enable()
        {
            Instance = this;
            Config = base.Config;

            if (Config == null)
            {
                Log.Error("Detected null config, ATOMILED will not be loaded.");
                return;
            }

            if (!Config.IsEnabled)
            {
                Log.Info("ATOMILED is disabled on this server via config.");
                return;
            }

            Log.Info($"Loading ATOMILED Version: {Assembly.GetExecutingAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}");

            Paths.Reload(Config.AtomiledDirectoryPath);

            Log.Info($"Atomiled root path set to: {Paths.Atomiled}");

            Directory.CreateDirectory(Paths.Atomiled);
            Directory.CreateDirectory(Paths.Configs);
            Directory.CreateDirectory(Paths.Plugins);
            Directory.CreateDirectory(Paths.Dependencies);

            Timing.RunCoroutine(new Loader().Run());
        }

        /// <summary>
        /// Called by LabAPI when the plugin is Disable.
        /// </summary>
        public override void Disable()
        {
            // Plugin will not be disable
        }
    }
}
