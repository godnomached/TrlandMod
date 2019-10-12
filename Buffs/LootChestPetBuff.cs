using Terraria;
using Terraria.ModLoader;

namespace TrlandMod.Buffs
{
    public class LootChestPetBuff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffNoTimeDisplay[Type] = true;
            DisplayName.SetDefault("战利品宝箱宠物");
            Description.SetDefault("一半箱子，一半宠物");
            Main.vanityPet[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            TrlandModPlayer modPlayer = player.GetModPlayer<TrlandModPlayer>();
            modPlayer.LootChestPet = true;
            //player.truffle = true;
            bool theLuggageNotSpawned = true;

            if (player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.LootChestPet>()] > 0)
            {
                theLuggageNotSpawned = false;
            }
            if (theLuggageNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2) * 2, player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.LootChestPet>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}
