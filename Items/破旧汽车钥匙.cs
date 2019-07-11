using Terraria.ID;
using Terraria.ModLoader;

namespace TrlandMod.Items
{
    public class 破旧汽车钥匙 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("破旧汽车坐骑");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 30;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 1;
            item.value = 30000;
            item.rare = 2;
            item.UseSound = SoundID.Item79;
            item.noMelee = true;
            item.mountType = mod.MountType("破旧汽车");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            //recipe.AddTile(mod.TileType("ExampleWorkbench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}