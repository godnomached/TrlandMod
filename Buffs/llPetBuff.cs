using Terraria;
using Terraria.ModLoader;

namespace TrlandMod.Buffs
{
    public class llPetBuff : ModBuff
    {
        public override void SetDefaults()
        {
            // DisplayName and Description are automatically set from the .lang files, but below is how it is done normally.
            DisplayName.SetDefault("洛天依爱着你");
            Description.SetDefault("\"据说洛天依的身心被魔法变小了\"");
            Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<TrlandModPlayer>().llPet = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("llPet")] <= 0;
            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("llPet"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}