using Terraria;
using Terraria.ModLoader;

namespace TrlandMod.Items.TrlandModDamageClass
{
	// This class stores necessary player info for our custom damage class, such as damage multipliers and additions to knockback and crit.
	public class TrlandModDamagePlayer : ModPlayer
	{
		public static TrlandModDamagePlayer ModPlayer(Player player) {
			return player.GetModPlayer<TrlandModDamagePlayer>();
		}

		// Vanilla only really has damage multipliers in code
		// And crit and knockback is usually just added to
		// As a modder, you could make separate variables for multipliers and simple addition bonuses
		public float TrlandModDamage = 1f;
		public float TrlandModKnockback;
		public int TrlandModCrit;

		public override void ResetEffects() {
			ResetVariables();
		}

		public override void UpdateDead() {
			ResetVariables();
		}

		private void ResetVariables() {
            TrlandModDamage = 1f;
            TrlandModKnockback = 0f;
            TrlandModCrit = 0;
		}
	}
}
