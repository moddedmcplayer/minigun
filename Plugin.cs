using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.CustomItems.API;
using MEC;

namespace minigun
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "moddedmcplayer";
        public override string Name { get; } = "minigun";
        public override Version Version { get; } = new Version(0, 0, 1);
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        public static Plugin Instance { get; private set; }
        
        public override void OnEnabled()
        {
            Instance = this;
            Config.Minigun.Register();
            Config.sniper.Register();
            base.OnEnabled();
        }
        
        public override void OnDisabled()
        {
            Config.Minigun.Unregister();
            Config.sniper.Unregister();
            Instance = null;
            base.OnDisabled();
        }
    }
}