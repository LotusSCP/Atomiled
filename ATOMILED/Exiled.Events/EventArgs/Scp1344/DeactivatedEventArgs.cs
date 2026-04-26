// -----------------------------------------------------------------------
// <copyright file="DeactivatedEventArgs.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.EventArgs.Scp1344
{
    using Atomiled.API.Features.Items;
    using Atomiled.Events.EventArgs.Interfaces;

    /// <summary>
    /// Contains all information after deactivating.
    /// </summary>
    public class DeactivatedEventArgs : IPlayerEvent, IScp1344Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeactivatedEventArgs" /> class.
        /// </summary>
        /// <param name="item"><inheritdoc cref="Item"/></param>
        public DeactivatedEventArgs(Item item)
        {
            Item = item;
            Scp1344 = item as Scp1344;
            Player = item.Owner;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        public Item Item { get; }

        /// <summary>
        /// Gets the player in owner of the item.
        /// </summary>
        public Atomiled.API.Features.Player Player { get; }

        /// <summary>
        /// Gets Scp1344 item.
        /// </summary>
        public Scp1344 Scp1344 { get; }
    }
}

