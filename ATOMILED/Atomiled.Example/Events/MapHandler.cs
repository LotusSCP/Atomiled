// -----------------------------------------------------------------------
// <copyright file="MapHandler.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Example.Events
{
    using System.Linq;

    using Atomiled.API.Features;
    using Atomiled.Events.EventArgs.Map;

    /// <summary>
    /// Handles Map events.
    /// </summary>
    internal sealed class MapHandler
    {
        /// <inheritdoc cref="Atomiled.Events.Handlers.Map.OnExplodingGrenade(ExplodingGrenadeEventArgs)"/>
        public void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {
            Log.Info($"A grenade thrown by {ev.Player.Nickname} is exploding: {ev.Projectile.Type}\n[Targets]\n\n{string.Join("\n", ev.TargetsToAffect.Select(player => $"[{player.Nickname}]"))}");
        }

        /// <inheritdoc cref="Atomiled.Events.Handlers.Map.OnGeneratorActivating"/>
        public void OnGeneratorActivated(GeneratorActivatingEventArgs ev)
        {
            Log.Info($"A generator has been activated in {ev.Generator.Room.Type}!");
        }
    }
}
