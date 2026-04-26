// -----------------------------------------------------------------------
// <copyright file="FixCapturePosition.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.Patches.Fixes
{
    using CustomPlayerEffects;
    using Atomiled.API.Enums;
    using Atomiled.API.Features;
    using HarmonyLib;
    using RelativePositioning;
    using UnityEngine;
#pragma warning disable SA1313 // Parameter names should begin with lower-case letter
    /// <summary>
    /// Patches <see cref="PocketCorroding.CapturePosition" />'s setter.
    /// Fix for those who go to pocket without effect and to get empty or null capture position and fall into the void.
    /// </summary>
    [HarmonyPatch(typeof(PocketCorroding), nameof(PocketCorroding.CapturePosition), MethodType.Getter)]
    internal class FixCapturePosition
    {
        private const RoomType DefaultRoomType = RoomType.Hcz106;

        private static void Postfix(ref RelativePosition __result)
        {
            if (Room.Get(__result.Position) != null)
                return;

            Room room = Room.Get(DefaultRoomType);
            __result = new RelativePosition(room.Position);
        }
    }
}

