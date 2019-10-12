using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrlandMod.Items.Accessories
{
    public class 三相之力 : ModItem
	{


		public override void SetStaticDefaults() {
			Tooltip.SetDefault("+25生命值"+"\n+25魔法值"+"\n+25攻击力"+"\n+40攻击速度"+"\n-20使用时间"+"\n+50%移动速度");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 3733);
			item.rare = ItemRarityID.Red;
		}

        

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeSpeed += 0.12f;
            player.moveSpeed *= 1.5f;
            player.statLifeMax2 += 25;
            player.statManaMax2 += 25;
            player.GetModPlayer<TrlandModPlayer>().三相之力开关 = true;
        }

        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.LifeCrystal, 2);
			recipe.AddIngredient(ItemID.Wood, 1);
			//recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

        


    }
}
