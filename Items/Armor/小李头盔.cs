using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TrlandMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class С��ͷ�� : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("С��ϵ��");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 2;
			item.defense = 10;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) {
			return body.type == mod.ItemType("С����") && legs.type == mod.ItemType("С���ȼ�");
		}

		public override void UpdateArmorSet(Player player) {
			player.setBonus = "��ϲ�㼯����С��ϵ�У������˺�+0.5%";
			//player.allDamage -= 0.2f;  //0.11
            player.meleeDamage *= 1.05f;
            player.thrownDamage *= 1.05f;
            player.rangedDamage *= 1.05f;
            player.magicDamage *= 1.05f;
            player.minionDamage *= 1.05f;
            /* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
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