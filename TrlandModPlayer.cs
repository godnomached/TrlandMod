//using ExampleMod.Items;
//using ExampleMod.NPCs.PuritySpirit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

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


        public override void ResetEffects()
        {
            LootChestPet = false;
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
                crit +=25;
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
            //if (狂徒铠甲开关)
            //{
            //    GetHurtTimer--;
            //    if (GetHurtTimer == 0 && damage < 1)
            //    {
            //       IncreaseLife--;
            //       if (IncreaseLife == 0)
            //       {
            //          IncreaseLife = 60;
            //          player.statLife += player.statLifeMax2 / 30;
            //       }
            //    }
            //   else if (damage >= 1)
            //    {
            //        IncreaseLife = 0;
            //        player.statLife = player.statLife;
            //    }
            //}

            //GetHurtTimer--;
            //if (GetHurtTimer == 0)
            //{
            //    狂徒铠甲回血开关 = true;
            //}

            //狂徒铠甲回血开关 = true;

            //if (!GetHurt)
            //{
            //    狂徒铠甲回血开关 = true;
            //    player.statLife += 50;
            //}
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (狂徒铠甲开关)
            {
                if (damage >= 1)
                {
                   player.statLife += damage /5;
                }
            }
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            //if (狂徒铠甲开关)
            //{
            //    if (damage>=1)
            //    {
            //        player.statLife += 30;
            //    }
            //}
            
        }

        public override void PostUpdate()
        {
            
            //if (GetHurt && 狂徒铠甲开关)
            //{
               
            //    player.statLife += 100;
            //}

            //if (狂徒铠甲开关)
            //{
            //    player.statLife += 50;
            //}

            //if (魔法星开关 == true)
            //{

            //    if (player.statMana == player.statManaMax2)
            //    {
            //        ManaAccessoryTimer = 60;

            //    }
            //    else
            //    {
            //        ManaAccessoryTimer--;
            //        if (ManaAccessoryTimer == 0)
            //        {
            //            ManaAccessoryTimer = 60;
            //            player.statMana += 5;

            //        }
            //    }
            //    player.statManaMax2 += 5;
            //    if (player.statMana == player.statManaMax)
            //    {
            //        player.statMana += 5;
            //    }
            //}

            //if (生命心开关 == true)
            //{

            //    if (player.statLife == player.statLifeMax2)
            //    {
            //        LifeAccessoryTimer = 60;
            //    }
            //    else
            //    {
            //        LifeAccessoryTimer--;
            //        if (LifeAccessoryTimer == 0)
            //        {
            //            LifeAccessoryTimer = 60;
            //            player.statLife += 5;
            //        }
            //    }
            //    player.statLifeMax2 += 5;
            //    if (player.statLife == player.statLifeMax)
            //    {
            //        player.statLife+=player.statLifeMax2-player.statLifeMax;
            //    }
            //}

            //if (混乱果开关 == true)
            //{
            //    player.statLifeMax2 = 1;
            //    player.statLife = 1;
            //    player.statManaMax2 = 1;
            //    player.statMana = 1;
            //    player.moveSpeed = 0.1f;
            //}

            //if (测试神器开关 == true)
            //{
            //    player.statLifeMax2 = 10000;
            //    player.statLife = 10000;
            //    player.statMana = 10000;
            //    player.moveSpeed = 100f;
            //}

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
