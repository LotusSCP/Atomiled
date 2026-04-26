// -----------------------------------------------------------------------
// <copyright file="InspectedItemEventArgs.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.EventArgs.Item
{
    using Atomiled.API.Features;
    using Atomiled.API.Features.Items;
    using Atomiled.Events.EventArgs.Interfaces;
    using InventorySystem.Items;

    /// <summary>
    /// Contains all information before weapon is inspected.
    /// </summary>
    public class InspectedItemEventArgs : IItemEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InspectedItemEventArgs"/> class.
        /// </summary>
        /// <param name="item"><inheritdoc cref="Item"/></param>
        public InspectedItemEventArgs(ItemBase item)
        {
            Item = Item.Get(item);
        }

        /// <inheritdoc/>
        public Player Player => Item.Owner;

        /// <inheritdoc/>
        public Item Item { get; }
    }
}
