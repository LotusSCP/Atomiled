// -----------------------------------------------------------------------
// <copyright file="Example.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Example
{
    using Atomiled.API.Enums;
    using Atomiled.API.Features;
    using Atomiled.Example.Events;

    /// <summary>
    /// The example plugin.
    /// </summary>
    public class Example : Plugin<Config>
    {
        private static readonly Example Singleton = new();

        private ServerHandler serverHandler;
        private PlayerHandler playerHandler;
        private WarheadHandler warheadHandler;
        private MapHandler mapHandler;
        private ItemHandler itemHandler;
        private Scp914Handler scp914Handler;
        private Scp096Handler scp096Handler;

        private Example()
        {
        }

        /// <summary>
        /// Gets the only existing instance of this plugin.
        /// </summary>
        public static Example Instance => Singleton;

        /// <inheritdoc/>
        public override PluginPriority Priority { get; } = PluginPriority.Last;

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            RegisterEvents();

            Log.Warn($"I correctly read the string config, its value is: {Config.String}");
            Log.Warn($"I correctly read the int config, its value is: {Config.Int}");
            Log.Warn($"I correctly read the float config, its value is: {Config.Float}");

            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        /// <summary>
        /// Registers the plugin events.
        /// </summary>
        private void RegisterEvents()
        {
            serverHandler = new ServerHandler();
            playerHandler = new PlayerHandler();
            warheadHandler = new WarheadHandler();
            mapHandler = new MapHandler();
            itemHandler = new ItemHandler();
            scp914Handler = new Scp914Handler();
            scp096Handler = new Scp096Handler();

            Atomiled.Events.Handlers.Server.WaitingForPlayers += serverHandler.OnWaitingForPlayers;
            Atomiled.Events.Handlers.Server.RoundStarted += serverHandler.OnRoundStarted;

            Atomiled.Events.Handlers.Player.Destroying += playerHandler.OnDestroying;
            Atomiled.Events.Handlers.Player.Spawned += playerHandler.OnSpawned;
            Atomiled.Events.Handlers.Player.Escaping += playerHandler.OnEscaping;
            Atomiled.Events.Handlers.Player.Hurting += playerHandler.OnHurting;
            Atomiled.Events.Handlers.Player.Dying += playerHandler.OnDying;
            Atomiled.Events.Handlers.Player.Died += playerHandler.OnDied;
            Atomiled.Events.Handlers.Player.ChangingRole += playerHandler.OnChangingRole;
            Atomiled.Events.Handlers.Player.ChangingItem += playerHandler.OnChangingItem;
            Atomiled.Events.Handlers.Player.UsingItem += playerHandler.OnUsingItem;
            Atomiled.Events.Handlers.Player.PickingUpItem += playerHandler.OnPickingUpItem;
            Atomiled.Events.Handlers.Player.DroppingItem += playerHandler.OnDroppingItem;
            Atomiled.Events.Handlers.Player.Verified += playerHandler.OnVerified;
            Atomiled.Events.Handlers.Player.FailingEscapePocketDimension += playerHandler.OnFailingEscapePocketDimension;
            Atomiled.Events.Handlers.Player.EscapingPocketDimension += playerHandler.OnEscapingPocketDimension;
            Atomiled.Events.Handlers.Player.UnlockingGenerator += playerHandler.OnUnlockingGenerator;
            Atomiled.Events.Handlers.Player.PreAuthenticating += playerHandler.OnPreAuthenticating;
            Atomiled.Events.Handlers.Player.Shooting += playerHandler.OnShooting;
            Atomiled.Events.Handlers.Player.ReloadingWeapon += playerHandler.OnReloading;
            Atomiled.Events.Handlers.Player.ReceivingEffect += playerHandler.OnReceivingEffect;

            Atomiled.Events.Handlers.Warhead.Stopping += warheadHandler.OnStopping;
            Atomiled.Events.Handlers.Warhead.Starting += warheadHandler.OnStarting;

            Atomiled.Events.Handlers.Scp106.Teleporting += playerHandler.OnTeleporting;

            Atomiled.Events.Handlers.Scp914.Activating += playerHandler.OnActivating;
            Atomiled.Events.Handlers.Scp914.ChangingKnobSetting += playerHandler.OnChangingKnobSetting;
            Atomiled.Events.Handlers.Scp914.UpgradingPlayer += playerHandler.OnUpgradingPlayer;

            Atomiled.Events.Handlers.Map.ExplodingGrenade += mapHandler.OnExplodingGrenade;
            Atomiled.Events.Handlers.Map.GeneratorActivating += mapHandler.OnGeneratorActivated;

            Atomiled.Events.Handlers.Item.ChangingAmmo += itemHandler.OnChangingAmmo;
            Atomiled.Events.Handlers.Item.ChangingAttachments += itemHandler.OnChangingAttachments;
            Atomiled.Events.Handlers.Item.ReceivingPreference += itemHandler.OnReceivingPreference;

            Atomiled.Events.Handlers.Scp914.UpgradingPickup += scp914Handler.OnUpgradingItem;

            Atomiled.Events.Handlers.Scp096.AddingTarget += scp096Handler.OnAddingTarget;
        }

        /// <summary>
        /// Unregisters the plugin events.
        /// </summary>
        private void UnregisterEvents()
        {
            Atomiled.Events.Handlers.Server.WaitingForPlayers -= serverHandler.OnWaitingForPlayers;
            Atomiled.Events.Handlers.Server.RoundStarted -= serverHandler.OnRoundStarted;

            Atomiled.Events.Handlers.Player.Destroying -= playerHandler.OnDestroying;
            Atomiled.Events.Handlers.Player.Dying -= playerHandler.OnDying;
            Atomiled.Events.Handlers.Player.Died -= playerHandler.OnDied;
            Atomiled.Events.Handlers.Player.ChangingRole -= playerHandler.OnChangingRole;
            Atomiled.Events.Handlers.Player.ChangingItem -= playerHandler.OnChangingItem;
            Atomiled.Events.Handlers.Player.PickingUpItem += playerHandler.OnPickingUpItem;
            Atomiled.Events.Handlers.Player.Verified -= playerHandler.OnVerified;
            Atomiled.Events.Handlers.Player.FailingEscapePocketDimension -= playerHandler.OnFailingEscapePocketDimension;
            Atomiled.Events.Handlers.Player.EscapingPocketDimension -= playerHandler.OnEscapingPocketDimension;
            Atomiled.Events.Handlers.Player.UnlockingGenerator -= playerHandler.OnUnlockingGenerator;
            Atomiled.Events.Handlers.Player.PreAuthenticating -= playerHandler.OnPreAuthenticating;

            Atomiled.Events.Handlers.Warhead.Stopping -= warheadHandler.OnStopping;
            Atomiled.Events.Handlers.Warhead.Starting -= warheadHandler.OnStarting;

            Atomiled.Events.Handlers.Scp106.Teleporting -= playerHandler.OnTeleporting;

            Atomiled.Events.Handlers.Scp914.Activating -= playerHandler.OnActivating;
            Atomiled.Events.Handlers.Scp914.ChangingKnobSetting -= playerHandler.OnChangingKnobSetting;

            Atomiled.Events.Handlers.Map.ExplodingGrenade -= mapHandler.OnExplodingGrenade;
            Atomiled.Events.Handlers.Map.GeneratorActivating -= mapHandler.OnGeneratorActivated;

            Atomiled.Events.Handlers.Item.ChangingAmmo -= itemHandler.OnChangingAmmo;
            Atomiled.Events.Handlers.Item.ChangingAttachments -= itemHandler.OnChangingAttachments;
            Atomiled.Events.Handlers.Item.ReceivingPreference -= itemHandler.OnReceivingPreference;

            Atomiled.Events.Handlers.Scp914.UpgradingPickup -= scp914Handler.OnUpgradingItem;

            Atomiled.Events.Handlers.Scp096.AddingTarget -= scp096Handler.OnAddingTarget;

            serverHandler = null;
            playerHandler = null;
            warheadHandler = null;
            mapHandler = null;
            itemHandler = null;
            scp914Handler = null;
            scp096Handler = null;
        }
    }
}
