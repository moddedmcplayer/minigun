using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs;
using InventorySystem.Items.Firearms.Attachments;
using InventorySystem.Items.Firearms.BasicMessages;
using MEC;
using UnityEngine;

namespace minigun.Items
{
    public class minigun: CustomWeapon
    {
        public override uint Id { get; set; } = 300;
        
        public override string Name { get; set; } = "minigun";
        
        public override string Description { get; set; } =
            "A fucking minigun.";
        
        public override float Weight { get; set; } = 3f;
        
        public override SpawnProperties SpawnProperties { get; set; }

        public override float Damage { get; set; } = 25f;

        public override byte ClipSize { get; set; } = 250;

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Shooting += OnShot;
            Exiled.Events.Handlers.Player.ChangingItem += OnChangingItem;
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.ChangingItem -= OnChangingItem;
            Exiled.Events.Handlers.Player.Shooting -= OnShot;
            base.UnsubscribeEvents();
        }

        private void OnChangingItem(ChangingItemEventArgs ev)
        {
            if(Check(ev.NewItem))
            {
                if (ev.NewItem is Exiled.API.Features.Items.Firearm firearm)
                {
                    firearm.Ammo = 250;
                    firearm.ClearAttachments();
                    firearm.AddAttachment(AttachmentName.Foregrip);
                    firearm.AddAttachment(AttachmentName.MuzzleBrake);
                }
            }
        }
        
        private void OnShot(ShootingEventArgs ev)
        {
            if (ev.Shooter.CurrentItem is Firearm firearm && Check(ev.Shooter.CurrentItem))
            {
                firearm.Ammo = 250;
                for(int i = 0; i <= Plugin.Instance.Config.bullets; i++)
                {
                    if (!firearm.Base.ActionModule.IsTriggerHeld)
                        break;
                    Timing.WaitForSeconds(Plugin.Instance.Config.delay);
                    firearm.Base.HitregModule.ClientCalculateHit(out var msg);
                    firearm.Base.HitregModule.ServerProcessShot(msg);
                }
            }
        }
    }
}