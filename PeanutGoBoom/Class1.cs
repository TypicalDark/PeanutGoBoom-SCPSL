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
//

//
namespace PeanutGoBoom
{
    public class Plugin
    {
        public static Plugin Singleton;

        public bool AllExplode = false;

        [PluginPriority(LoadPriority.Highest)]
        [PluginEntryPoint("Peanut boom ", "version 1.0","Peanut explodes on death. ", " made by Typical")]
        
        void LoadPlugin()
        {
            Singleton = this;
            PluginAPI.Events.EventManager.RegisterEvents(this);
        }




        [PluginEvent(ServerEventType.PlayerChangeRole)]
        public void OnDeath(PlayerChangeRoleEvent ev)
        {
            Log.Debug(ev.Player.Role.ToString());
            if (AllExplode == true)
            {
                if (ev.NewRole == RoleTypeId.Spectator)
                {
                    ev.Player.ReceiveHint("Boom!!!", 5);
                    var item = ev.Player.ReferenceHub.inventory.CreateItemInstance(new ItemIdentifier(ItemType.GrenadeHE, ItemSerialGenerator.GenerateNext()), false) as ThrowableItem;
                    ///
                    TimeGrenade grenadeboom = (TimeGrenade)UnityEngine.Object.Instantiate(item.Projectile, ev.Player.Position, Quaternion.identity);
                    grenadeboom._fuseTime = 0f;
                    grenadeboom.NetworkInfo = new PickupSyncInfo(item.ItemTypeId, item.Weight, item.ItemSerial);
                    grenadeboom.PreviousOwner = new Footprint(ev.Player != null ? ev.Player.ReferenceHub : ReferenceHub.HostHub);
                    NetworkServer.Spawn(grenadeboom.gameObject);
                    grenadeboom.ServerActivate();
                    return;
                }
            }
            if (ev.OldRole.RoleTypeId == RoleTypeId.Scp173)
            {
                ev.Player.ReceiveHint("Boom!!!", 5);
                var item = ev.Player.ReferenceHub.inventory.CreateItemInstance(new ItemIdentifier(ItemType.GrenadeHE, ItemSerialGenerator.GenerateNext()), false) as ThrowableItem;
                ///
                TimeGrenade grenadeboom = (TimeGrenade)UnityEngine.Object.Instantiate(item.Projectile, ev.Player.Position, Quaternion.identity);
                grenadeboom._fuseTime = 0f;
                grenadeboom.NetworkInfo = new PickupSyncInfo(item.ItemTypeId, item.Weight, item.ItemSerial);
                grenadeboom.PreviousOwner = new Footprint(ev.Player != null ? ev.Player.ReferenceHub : ReferenceHub.HostHub);
                NetworkServer.Spawn(grenadeboom.gameObject);
                grenadeboom.ServerActivate();
                ///
            }
        }
    }

}
