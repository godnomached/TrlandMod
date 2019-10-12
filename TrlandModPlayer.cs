//using ExampleMod.Items;
//using ExampleMod.NPCs.PuritySpirit;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TrlandMod
{
    // ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
    // several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
    public class TrlandModPlayer : ModPlayer
    {
        public bool LootChestPet = false;
        public bool 破旧汽车 = false;
        public bool 测试神器开关;
        public bool GodMode;
        public bool 三相之力开关;
        public bool 饮血剑开关;
        public bool 无尽之刃开关;
        public bool 狂徒铠甲开关;
        public bool 狂徒铠甲回血开关;
        public bool GetHurt;
        public int GetHurtTimer = 60;
        public int IncreaseLife = 60;
        public bool llPet;

        public override void ResetEffects()
        {
            LootChestPet = false;
            llPet = false;
            破旧汽车 = false;
            测试神器开关 = false;
            GodMode = false;
            三相之力开关 = false;
            饮血剑开关 = false;
            无尽之刃开关 = false;
            狂徒铠甲开关 = false;
            狂徒铠甲回血开关 = false;
        }

        public override void GetWeaponDamage(Item item, ref int damage)
        {
            if (三相之力开关)
            {
                damage += 25;
            }
            if (无尽之刃开关)
            {
                damage += 80;
            }
            if (饮血剑开关)
            {
                damage += 80;
            }
        }

        public override void GetWeaponCrit(Item item, ref int crit)
        {
            if (无尽之刃开关)
            {
                crit += 25;
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (饮血剑开关)
            {
                if (player.statLife < player.statLifeMax2)
                {
                    player.statLife += damage / 50;
                }
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (饮血剑开关)
            {
                if (player.statLife < player.statLifeMax2)
                {
                    player.statLife += damage / 50;
                }
            }
        }

        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (狂徒铠甲开关)
            {
                if (damage >= 1)
                {
                    player.statLife += damage / 5;
                }
            }
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
          

        }

        public override void PostUpdate()
        {


        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (GodMode)
            {
                return false;
            }
            return true;
        }

        public override void PreUpdate()
        {
            if (GodMode)
            {
                player.statLife = player.statLifeMax2;
                player.statMana = player.statManaMax2;
                player.noKnockback = true;
            }

        }

    }
}
