// -----------------------------------------------------------------------
// <copyright file="IMarshmallowEvent.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.EventArgs.Interfaces
{
    using Atomiled.API.Features.Items;

    /// <summary>
    /// Represents all events related to the marshmallow man.
    /// </summary>
    public interface IMarshmallowEvent : IItemEvent
    {
        /// <summary>
        /// Gets the marshmallow item related to this event.
        /// </summary>
        public Marshmallow Marshmallow { get; }
    }
}
