using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TrlandMod.Items
{
    public class OldKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("一把冰冻的古老钥匙");
            Tooltip.SetDefault("召唤战利品宝箱宠物");
        }

        public override void SetDefaults()
        {
            item.damage = 0;
            item.useStyle = 1;
            item.shoot = ModContent.ProjectileType<Projectiles.Pets.LootChestPet>();
            item.width = 16;
            item.height = 30;
            item.UseSound = SoundID.Item2;
            item.useAnimation = 20;
            item.useTime = 20;
            item.rare = 3;
            item.noMelee = true;
            item.value = Item.buyPrice(0, 3, 0, 0);
            item.buffType = ModContent.BuffType<Buffs.LootChestPetBuff>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(ItemID.Chest);
            recipe.AddIngredient(ItemID.Wood, 1);
            //recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
