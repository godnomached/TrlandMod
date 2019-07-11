using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrlandMod;
using TrlandMod.Items.TrlandModDamageClass;

namespace TrlandMod.Items.Accessories
{
	public class 狂徒铠甲 : ModItem
	{


		public override void SetStaticDefaults() {
			Tooltip.SetDefault("+80生命值"+"\n+20%伤害减免");
		}

		public override void SetDefaults() {
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.value = Item.sellPrice(silver: 2850);
			item.rare = ItemRarityID.Red;
		}

        

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //if (player.GetModPlayer<TrlandModPlayer>().狂徒铠甲回血开关 == true)
            //{
            //    player.GetModPlayer<TrlandModPlayer>().狂徒铠甲开关 = true;
            //}
            player.GetModPlayer<TrlandModPlayer>().狂徒铠甲开关 = true;
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
