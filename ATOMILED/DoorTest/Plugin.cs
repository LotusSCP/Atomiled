using System;
using Atomiled.API.Features;
using Atomiled.API.Features.Doors;
using MEC;
using Atomiled.API.Enums;
// Note: avoid ambiguous Plugin<> by using Atomiled's Plugin<T> explicitly in the base class.

namespace DoorTest
{
    public class DoorTestPlugin : Atomiled.API.Features.Plugin<Config>
    {
        public static DoorTestPlugin Instance { get; private set; }

        public override string Name => "DoorTest";

        public override void OnEnabled()
        {
            Instance = this;

            // Example subscriptions

            // These are the example of legacy thing meaning of without saying username
            {
                // The Door Trigger (interacted) without saying username -> Door.DoorTriggered += OnDoorTriggeredLegacy; // legacy signature
                // The Door Passed without saying username -> Door.DoorPassed += OnDoorPassedLegacy; // legacy signature
            }
            Door.DoorTriggeredWithPlayer += OnDoorTriggered; // extended with player - fires for all triggers (Locked, Unlocked, Opened, Closed, Exploded, AccessDenied, AccessGranted)
            Door.DoorPassedWithPlayer += OnDoorPassed; // extended with player - fires when someone passes through (Front or Back)

            // Start door monitor which polls door/player state to raise events from in-game activity.
            DoorMonitor.Start();

            // Optionally run an automatic test sequence to exercise door events.

            if (Config.Legacy)
                OnLegacyEnabled();

            if (Config.EnableAutoTest)
                StartAutoTest();

            base.OnEnabled();
        }

        private void OnLegacyEnabled()
        {
            Instance = this;
            // Example subscriptions

            // These are the example of legacy thing meaning of without saying username

            Door.DoorTriggered += OnDoorTriggeredLegacy; // legacy signature
            Door.DoorPassed += OnDoorPassedLegacy; // legacy signature
            // Start door monitor which polls door/player state to raise events from in-game activity.
            // DoorMonitor.Start();
        }

        // Legacy handlers (no player parameter) for backward compatibility
        private void OnDoorTriggeredLegacy(Door door, Door.DoorTrigger trigger)
        {
            if (door is null)
                return;

            Log.Info($"DoorTriggered: {door.Name} -> {trigger}");
        }

        private void OnDoorPassedLegacy(Door door, Door.DoorPass pass)
        {
            if (door is null)
                return;

            Log.Info($"DoorPassed: {door.Name} -> {pass}");
        }

        public override void OnDisabled()
        {
            Door.DoorTriggered -= OnDoorTriggeredLegacy;
            Door.DoorPassed -= OnDoorPassedLegacy;
            Door.DoorTriggeredWithPlayer -= OnDoorTriggered;
            Door.DoorPassedWithPlayer -= OnDoorPassed;

            DoorMonitor.Stop();

            base.OnDisabled();
        }

        // Door screen events removed; no handler.

        private void OnDoorTriggered(Door door, Door.DoorTrigger trigger, Player player)
        {
            if (door is null)
                return;

            // Log door trigger events - the trigger parameter indicates what state changed:
            // DoorTrigger.Locked - Door was locked
            // DoorTrigger.Unlocked - Door was unlocked
            // DoorTrigger.Opened - Door was opened (changed to open state)
            // DoorTrigger.Closed - Door was closed (changed to closed state)
            // DoorTrigger.Exploded - Door was destroyed/exploded (breakable door only)
            // DoorTrigger.AccessGranted - Access attempt was granted (keycard accepted)
            // DoorTrigger.AccessDenied - Access attempt was denied (keycard denied)
            string by = player is null ? "(unknown)" : player.Nickname;
            Log.Info($"DoorTriggered: {door.Name} -> {trigger} by {by}");
        }

        private void OnDoorPassed(Door door, Door.DoorPass pass, Player player)
        {
            if (door is null)
                return;

            // Log when a player passes through a door
            // pass parameter indicates direction: Front or Back
            string by = player is null ? "(unknown)" : player.Nickname;
            Log.Info($"DoorPassed: {door.Name} -> {pass} by {by}");
        }

        // Runs a simple sequence of actions against a door to trigger events for testing.
        private void StartAutoTest()
        {
            try
            {
                Door target = null;
                if (!string.IsNullOrEmpty(Config.TestDoorName))
                    target = Door.Get(Config.TestDoorName);

                // Fallback to a random door only if we actually have any doors available.
                if (target is null)
                {
                    if (Door.List == null || Door.List.Count == 0)
                    {
                        Log.Warn("DoorTest: No door found to run auto-test on (no doors present).");
                        return;
                    }

                    target = Door.Random();
                }

                Log.Info($"DoorTest: Starting auto-test on door '{target.Name}' (id={target.InstanceId}).");

                // Test Door state changes
                // Open after 1s - triggers DoorTrigger.Opened
                Timing.CallDelayed(1f, () => target.IsOpen = true);
                // Close after 3s - triggers DoorTrigger.Closed
                Timing.CallDelayed(3f, () => target.IsOpen = false);
                // Lock after 5s - triggers DoorTrigger.Locked with Regular079 lock type
                Timing.CallDelayed(5f, () => target.Lock(DoorLockType.Regular079));
                // Unlock after 7s - triggers DoorTrigger.Unlocked
                Timing.CallDelayed(7f, () => target.Unlock());
                // Simulate passing through after 9s with Front direction - triggers DoorPass.Front
                Timing.CallDelayed(9f, () => target.RaisePass(Door.DoorPass.Front));
                // Simulate passing through after 11s with Back direction - triggers DoorPass.Back
                Timing.CallDelayed(11f, () => target.RaisePass(Door.DoorPass.Back));
                // Simulate access granted event after 13s - triggers DoorTrigger.AccessGranted
                Timing.CallDelayed(13f, () => target.RaiseTrigger(Door.DoorTrigger.AccessGranted));
                // Simulate access denied event after 15s - triggers DoorTrigger.AccessDenied
                Timing.CallDelayed(15f, () => target.RaiseTrigger(Door.DoorTrigger.AccessDenied));
                // Test explosion after 17s - triggers DoorTrigger.Exploded (only works on breakable doors)
                Timing.CallDelayed(17f, () => target.RaiseTrigger(Door.DoorTrigger.Exploded));
                // Test relock after explosion after 19s with AdminCommand lock type
                Timing.CallDelayed(19f, () => target.Lock(DoorLockType.AdminCommand));
            }
            catch (Exception ex)
            {
                Log.Error($"DoorTest: auto-test failed: {ex}");
            }
        }
    }
}