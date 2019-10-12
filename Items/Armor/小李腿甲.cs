using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TrlandMod.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class LiLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("小李系列"
				+ "\n+5%移动速度");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            //recipe.AddTile(mod.TileType("ExampleWorkbench"));
            recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}