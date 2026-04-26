// -----------------------------------------------------------------------
// <copyright file="Permissions.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Atomiled.Events.Commands.Reload
{
    using System;

    using CommandSystem;

    using Atomiled.Events.Handlers;
    using Atomiled.Permissions.Extensions;

    /// <summary>
    /// The reload permissions command.
    /// </summary>
    [CommandHandler(typeof(Reload))]
    public class Permissions : ICommand
    {
        /// <summary>
        /// Gets static instance of the <see cref="Permissions"/> command.
        /// </summary>
        public static Permissions Instance { get; } = new();

        /// <inheritdoc/>
        public string Command { get; } = "permissions";

        /// <inheritdoc/>
        public string[] Aliases { get; } = new[] { "perms" };

        /// <inheritdoc/>
        public string Description { get; } = "Reload permissions.";

        /// <inheritdoc/>
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ee.reloadpermissions"))
            {
                response = "You can't reload permissions, you don't have \"ee.reloadpermissions\" permission.";
                return false;
            }

            Atomiled.Permissions.Extensions.Permissions.Reload();
            Server.OnReloadedPermissions();

            response = "Permissions have been reloaded successfully!";
            return true;
        }
    }
}
