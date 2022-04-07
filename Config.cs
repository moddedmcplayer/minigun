using System.ComponentModel;
using Exiled.API.Interfaces;
using minigun.Items;

namespace minigun
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("The amount of bullets to spawn per shot")]
        public int bullets { get; set; } = 5;

        [Description("The delay between bullets")]
        public float delay { get; set; } = 0.1f;

        [Description("The damage of a single bullet")]
        public float damage = 10f;
        
        public Items.minigun Minigun { get; set; } = new Items.minigun { Type = ItemType.GunLogicer };

        public Items.sniper sniper { get; set; } = new sniper {Type = ItemType.GunRevolver };
    }
}