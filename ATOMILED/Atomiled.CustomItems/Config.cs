// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.CustomItems
{
    using System.ComponentModel;

    using Atomiled.API.Features;
    using Atomiled.API.Interfaces;
    using Atomiled.CustomItems.API.Features;

    /// <summary>
    /// The plugin's config class.
    /// </summary>
    public class Config : IConfig
    {
        /// <inheritdoc/>
        [Description("Indicates whether this plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc/>
        public bool Debug { get; set; } = false;

        /// <summary>
        /// Gets the hint that is shown when someone pickups a <see cref="CustomItem"/>.
        /// </summary>
        [Description("The hint that is shown when someone pickups a custom item.")]
        public Broadcast PickedUpHint { get; private set; } = new("You have picked up a {0}\n{1}");

        /// <summary>
        /// Gets the hint that is shown when someone pickups a <see cref="CustomItem"/>.
        /// </summary>
        [Description("The hint that is shown when someone selects a custom item.")]
        public Broadcast SelectedHint { get; private set; } = new("You have selected a {0}\n{1}", 5);
    }
}
