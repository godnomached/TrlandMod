using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrlandMod.Items.Accessories
{
    class 无尽之刃 : ModItem
    {

        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("+80攻击，+25%暴击几率");
        }

        public override void SetDefaults()
        {
            item.width = 60;
            item.height = 60;
            item.accessory = true;
            item.value = Item.sellPrice(silver: 3400);
            item.rare = ItemRarityID.Red;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<TrlandModPlayer>().无尽之刃开关 = true;
        }


        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            //recipe.AddIngredient(ItemID.LifeCrystal, 2);
            recipe.AddIngredient(ItemID.Wood, 1);
            //recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
