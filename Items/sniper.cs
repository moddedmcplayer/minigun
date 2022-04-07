using Exiled.API.Features;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Firearms.Attachments;
using InventorySystem.Items.Firearms.BasicMessages;
using InventorySystem.Items.Firearms.Modules;
using MEC;
using UnityEngine;

namespace minigun.Items
{
    public class sniper: CustomWeapon
    {
        public override uint Id { get; set; } = 301;
        
        public override string Name { get; set; } = "sniper";
        
        public override string Description { get; set; } =
            "funny one shot pistol.";
        
        public override float Weight { get; set; } = 1f;
        
        public override SpawnProperties SpawnProperties { get; set; }

        public override float Damage { get; set; } = 99999999999999f;

        public override byte ClipSize { get; set; } = 69;
    }
}