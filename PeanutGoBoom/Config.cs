using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeanutGoBoom
{
    public class Config
    {
        [Description("Broadcast when the explode all on death mode is activated.")]
        public string Announcement1 { get; } = "A bomb has been detected in your heart, when you die it will explode.";
        [Description("Broadcast when the explode all on death mode is de-activated.")]
        public string Announcement2 { get; } = "The bomb detected was made by the chinese, and is a complete dud.";
        [Description("Fuse time for the grenade when peanut dies")]
        public float Peanutfuse { get; } = 0f;

        [Description("Fuse time for the grenade when a player dies when AllExplode is enabled.")]
        public float PlayerFuse { get; } = 0f;

        [Description("Hint after Peanut/Player explodes.")]
        public string Hint { get; } = "Boom!!!";

    }
}
