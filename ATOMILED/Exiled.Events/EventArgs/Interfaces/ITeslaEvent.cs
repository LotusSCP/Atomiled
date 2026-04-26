// -----------------------------------------------------------------------
// <copyright file="ITeslaEvent.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.EventArgs.Interfaces
{
    using API.Features;

    /// <summary>
    /// Event args used for all <see cref="TeslaGate" /> related events.
    /// </summary>
    public interface ITeslaEvent : IAtomiledEvent
    {
        /// <summary>
        /// Gets the <see cref="TeslaGate" /> triggering the event.
        /// </summary>
        public TeslaGate Tesla { get; }
    }
}
