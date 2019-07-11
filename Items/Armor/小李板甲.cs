using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrlandMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class С���� : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("С����");
			Tooltip.SetDefault("С��ϵ��"
				+ "\n�����Ż�"
				+ "\n+5�������ֵ��+1����ٻ�����");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 15;
		}

		public override void UpdateEquip(Player player) {
			player.buffImmune[BuffID.OnFire] = true;
			player.statLifeMax2 += 5;
            player.maxMinions++;
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