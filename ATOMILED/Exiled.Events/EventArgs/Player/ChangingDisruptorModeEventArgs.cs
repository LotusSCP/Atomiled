// -----------------------------------------------------------------------
// <copyright file="ChangingDisruptorModeEventArgs.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.EventArgs.Player
{
    using Atomiled.API.Enums;
    using Atomiled.API.Features;
    using Atomiled.API.Features.Items;
    using Atomiled.Events.EventArgs.Interfaces;
    using InventorySystem.Items;

    /// <summary>
    /// Contains all information before disruptor's mode is changed.
    /// </summary>
    public class ChangingDisruptorModeEventArgs : IFirearmEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangingDisruptorModeEventArgs"/> class.
        /// </summary>
        /// <param name="firearm"><inheritdoc cref="Firearm"/></param>
        /// <param name="mode"><inheritdoc cref="NewMode"/></param>
        public ChangingDisruptorModeEventArgs(ItemBase firearm, bool mode)
        {
            Firearm = Item.Get(firearm).As<Firearm>();
            NewMode = mode ? DisruptorMode.Disintegrator : DisruptorMode.BurstFire;
        }

        /// <inheritdoc/>
        public Item Item => Firearm;

        /// <inheritdoc/>
        public Firearm Firearm { get; }

        /// <summary>
        /// Gets a new disruptor's fire mode.
        /// </summary>
        public DisruptorMode NewMode { get; }

        /// <inheritdoc />
        public Player Player => Item.Owner;
    }
}

