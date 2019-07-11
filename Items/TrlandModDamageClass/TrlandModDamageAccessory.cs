using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrlandMod.Items.TrlandModDamageClass
{
	public class TrlandModDamageAccessory : ModItem
	{
		public override string Texture { get { return "Terraria/Item_" + ItemID.AnglerEarring; } }

		public override void SetStaticDefaults() {
			Tooltip.SetDefault("增加25所有攻击力");
		}

		public override void SetDefaults() {
			item.Size = new Vector2(34);
			item.rare = 10;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual) {
            TrlandModDamagePlayer modPlayer = TrlandModDamagePlayer.ModPlayer(player);
			modPlayer.TrlandModDamage += 0.2f;
			modPlayer.TrlandModCrit += 15;
			modPlayer.TrlandModKnockback += 10;
		}
	}
}
