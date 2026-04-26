// -----------------------------------------------------------------------
// <copyright file="FixNWFlashbangDuration.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.Patches.Fixes
{
    using System.Collections.Generic;
    using System.Reflection.Emit;

    using CustomPlayerEffects;
    using Atomiled.API.Features.Items;
    using Atomiled.Events.EventArgs.Player;
    using HarmonyLib;
    using InventorySystem;

    /// <summary>
    /// Patches <see cref="Flashed.IntensityChanged"/> to fix NW overwritting value multiple time.
    /// </summary>
    [HarmonyPatch(typeof(Flashed), nameof(Flashed.IntensityChanged))]
    internal class FixNWFlashbangDuration
    {
        private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            yield return new CodeInstruction(OpCodes.Ret);
        }
    }
}

