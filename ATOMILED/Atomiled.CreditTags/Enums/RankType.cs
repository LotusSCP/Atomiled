// -----------------------------------------------------------------------
// <copyright file="RankType.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.CreditTags.Enums
{
    /// <summary>
    /// Represents all existing ranks.
    /// </summary>
    public enum RankType
    {
        /// <summary>
        /// No ATOMILED roles.
        /// </summary>
        None,

        /// <summary>
        /// Atomiled Developer.
        /// </summary>
        Dev = 1,

        /// <summary>
        /// Atomiled Contributor.
        /// </summary>
        Contributor = 2,

        /// <summary>
        /// Atomiled Plugin Developer.
        /// </summary>
        PluginDev = 3,

        /// <summary>
        /// ATOMILED Tournament Participant.
        /// </summary>
        TournamentParticipant = 4,

        /// <summary>
        /// ATOMILED Tournament Champion.
        /// </summary>
        TournamentChampion = 5,

        /// <summary>
        /// ATOMILED Donator.
        /// </summary>
        Donator = 6,
    }
}
