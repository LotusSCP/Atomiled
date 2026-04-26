// -----------------------------------------------------------------------
// <copyright file="AutoUpdateFiles.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Loader
{
    using System;

    /// <summary>
    /// Automatically updates with Reference used to generate Atomiled.
    /// </summary>
    public static class AutoUpdateFiles
    {
        /// <summary>
        /// Gets which SCP: SL version generated Atomiled.
        /// </summary>
        public static readonly Version RequiredSCPSLVersion = new(0, 0, 0, 0);
    }
}
