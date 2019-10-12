using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TrlandMod.Items
{
    public class llPet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName and Tooltip are automatically set from the .lang files, but below is how it is done normally.
            DisplayName.SetDefault("天依喜欢的包子");
            Tooltip.SetDefault("她要来了！嗯~啊~");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.DD2PetGato);
            item.shoot = mod.ProjectileType("llPet");
            item.buffType = mod.BuffType("llPetBuff");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 1);
            //recipe.AddTile(mod.TileType("ExampleWorkbench"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UseStyle(Player player)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }
    }
}