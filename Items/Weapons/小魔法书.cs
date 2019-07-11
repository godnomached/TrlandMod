using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrlandMod.Items.Weapons
{
    public class 小魔法书 : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("发出毁灭的激光");
        }

        public override void SetDefaults()
        {
            item.damage = 40;
            item.noMelee = true;
            item.magic = true;
            item.channel = true; //Channel so that you can held the weapon [Important]
            item.mana = 5;
            item.rare = 5;
            item.width = 28;
            item.height = 30;
            item.useTime = 20;
            item.UseSound = SoundID.Item13;
            item.useStyle = 5;
            item.shootSpeed = 14f;
            item.useAnimation = 20;
            item.shoot = mod.ProjectileType("小魔法书弹幕");
            item.value = Item.sellPrice(silver: 3);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            //recipe.AddTile(mod, "ExampleWorkbench");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
