using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TrlandMod;

namespace TrlandMod.Projectiles.Pets
{
    public class llPet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Paper Airplane"); // Automatic from .lang files
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
        }

        public override void SetDefaults()
        {
            projectile.width = 20;
            projectile.height = 20;
            projectile.aiStyle = 144;
            projectile.penetrate = -1;
            projectile.netImportant = true;
            projectile.timeLeft *= 5;
            projectile.scale = 0.6f;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.manualDirectionChange = true;

            aiType = ProjectileID.DD2PetGato;
        }

        public override bool PreAI()
        {
            Player player = Main.player[projectile.owner];
            player.petFlagDD2Gato = false; // Relic from aiType
            return true;
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            TrlandModPlayer modPlayer = player.GetModPlayer<TrlandModPlayer>();
            if (player.dead)
            {
                modPlayer.llPet = false;
            }
            if (modPlayer.llPet)
            {
                projectile.timeLeft = 2;
            }
        }
    }
}