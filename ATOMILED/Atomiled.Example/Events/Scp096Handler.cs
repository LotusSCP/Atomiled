// -----------------------------------------------------------------------
// <copyright file="Scp096Handler.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Example.Events
{
    using Atomiled.API.Features;
    using Atomiled.Events.EventArgs.Scp096;

    /// <summary>
    /// Handles SCP-096 events.
    /// </summary>
    internal sealed class Scp096Handler
    {
        /// <inheritdoc cref="Atomiled.Events.Handlers.Scp096.OnAddingTarget(AddingTargetEventArgs)"/>
        public void OnAddingTarget(AddingTargetEventArgs ev)
        {
            Log.Info($"{ev.Target.Nickname} is being added to {ev.Player.Nickname} targets!");
        }
    }
}
