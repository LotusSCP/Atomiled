// -----------------------------------------------------------------------
// <copyright file="IHazardEvent.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.EventArgs.Interfaces
{
    using Atomiled.API.Features.Hazards;

    /// <summary>
    /// Event args for all <see cref="API.Features.Hazards.Hazard"/> related events.
    /// </summary>
    public interface IHazardEvent : IAtomiledEvent
    {
        /// <summary>
        /// Gets the environmental hazard that the player is interacting with.
        /// </summary>
        public Hazard Hazard { get; }
    }
}
