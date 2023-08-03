using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI;
using PluginAPI.Core.Attributes;
using PluginAPI.Core;
using PluginAPI.Enums;
using PluginAPI.Events;
using PlayerStatsSystem;
using InventorySystem.Items.ThrowableProjectiles;
using Mirror;
using UnityEngine;
using PlayerRoles;
using PluginAPI.Core.Items;
using Footprinting;
using InventorySystem.Items.Pickups;
using InventorySystem.Items;
using InventorySystem;
using Steamworks.Ugc;
using CommandSystem;
using RemoteAdmin;




namespace PeanutGoBoom
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class Disable : ICommand
    {
        public string Command { get; } = "allexplode.disable";

        public string[] Aliases { get; } = { "ae.disable", "PeanutGoBoom.disable", "PGB.disable" };

        public string Description { get; } = "Disables everyone exploding on death.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender)
            {
                Map.Broadcast(5, Plugin.Config.Announcement2);

            }
            response = "Explode all on death succesfully disabled.";
                PeanutGoBoom.Plugin.ChangeAllExplode(false);
                return true;

        }
    }


    /// <summary>
    /// 
    /// </summary>
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class ChangeEvent : ICommand
    {
        public string Command { get; } = "allexplode.enable";

        public string[] Aliases { get; } = {"ae.enable","PeanutGoBoom.enable","PGB.enable"};

        public string Description { get; } = "Enables everyone exploding on death.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (sender is PlayerCommandSender)
            {
                Map.Broadcast(5, Plugin.Config.Announcement1);
               
            }
                    response = "Explode all on death succesfully activated.";
                    PeanutGoBoom.Plugin.ChangeAllExplode(true);
                    return true;

        }
    }
}
