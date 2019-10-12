using Terraria;
using Terraria.ModLoader;

namespace TrlandMod.Buffs
{
    public class 破旧汽车Buff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("破旧汽车");
            Description.SetDefault("真皮座椅，4个杯托");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.mount.SetMount(ModContent.MountType<Mounts.破旧汽车>(), player);
            player.buffTime[buffIndex] = 10;
        }
    }
}
