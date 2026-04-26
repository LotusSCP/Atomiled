// -----------------------------------------------------------------------
// <copyright file="IDoorEvent.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.EventArgs.Interfaces
{
    using Atomiled.API.Features.Doors;

    /// <summary>
    /// Event args used for all <see cref="API.Features.Doors.Door" /> related events.
    /// </summary>
    public interface IDoorEvent : IAtomiledEvent
    {
        /// <summary>
        /// Gets the <see cref="API.Features.Doors.Door" /> triggering the event.
        /// </summary>
        public Door Door { get; }
    }
}
