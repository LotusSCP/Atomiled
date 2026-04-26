// -----------------------------------------------------------------------
// <copyright file="IPickupEvent.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.EventArgs.Interfaces
{
    using Atomiled.API.Features.Pickups;

    /// <summary>
    /// Event args used for all <see cref="API.Features.Pickups.Pickup" /> related events.
    /// </summary>
    public interface IPickupEvent : IAtomiledEvent
    {
        /// <summary>
        /// Gets the <see cref="API.Features.Pickups.Pickup" /> triggering the event.
        /// </summary>
        public Pickup Pickup { get; }
    }
}
