using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TrlandMod.Projectiles.Pets
{
    public class LootChestPet : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("战利品宝箱宠物");
        }

        public override void SetDefaults()
        {
            projectile.width = 32;//24;
            projectile.height = 44;// 24;
                                   //   projectile.aiStyle = 26; // ???
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft *= 5;
            projectile.light = 0.5f;

            Main.projFrames[projectile.type] = 24;

            Main.projPet[projectile.type] = true;

            projectile.tileCollide = true;
            projectile.ignoreWater = true;
        }

        private int targetLoot()
        {
            int target = -1;
            float range = 400f;
            float playerRange = 700f;
            float targetDistance = float.MaxValue;

            for (int j = 0; j < 400; j++)
            {
                if (Main.item[j].active && Main.item[j].noGrabDelay == 0 && Main.item[j].owner == projectile.owner && ItemLoader.CanPickup(Main.item[j], Main.player[Main.item[j].owner]) && Main.player[Main.item[j].owner].ItemSpace(Main.item[j]))
                {
                    if (ItemID.Sets.NebulaPickup[Main.item[j].type])
                    {
                        continue;
                    }
                    if (Main.item[j].type == 58 || Main.item[j].type == 1734 || Main.item[j].type == 1867)
                    {
                        continue;
                    }
                    else if (Main.item[j].type == 184 || Main.item[j].type == 1735 || Main.item[j].type == 1868)
                    {
                        continue;
                    }


                    float distanceToPotential = projectile.Distance(Main.item[j].Center);
                    float playerDistanceToPotential = Main.player[projectile.owner].Distance(Main.item[j].Center);
                    if (playerDistanceToPotential < playerRange && distanceToPotential < targetDistance && distanceToPotential < range)
                    {
                        target = j;
                        targetDistance = distanceToPotential;
                    }
                }
            }

            return target;
        }

        private void pickup()
        {
            int defaultItemGrabRange = 38;
            Player thisPlayer = Main.player[projectile.owner];

            for (int j = 0; j < 400; j++)
            {
                if (Main.item[j].active && Main.item[j].noGrabDelay == 0 && Main.item[j].owner == projectile.owner && ItemLoader.CanPickup(Main.item[j], thisPlayer))
                {
                    int num = defaultItemGrabRange;//Player.defaultItemGrabRange;

                    if (new Rectangle((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height).Intersects(new Rectangle((int)Main.item[j].position.X, (int)Main.item[j].position.Y, Main.item[j].width, Main.item[j].height)))
                    {
                        if (projectile.owner == Main.myPlayer && (thisPlayer.inventory[thisPlayer.selectedItem].type != 0 || thisPlayer.itemAnimation <= 0))
                        {
                            // TODO, fix this maybe?
                            if (!ItemLoader.OnPickup(Main.item[j], thisPlayer))
                            {
                                Main.item[j] = new Item();
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendData(21, -1, -1, null, j, 0f, 0f, 0f, 0, 0, 0);
                                }
                                continue;
                            }

                            if (ItemID.Sets.NebulaPickup[Main.item[j].type])
                            {
                                continue;
                                //Main.PlaySound(7, (int)thisPlayer.position.X, (int)thisPlayer.position.Y, 1);
                                //int num2 = Main.item[j].buffType;
                                //Main.item[j] = new Item();
                                //if (Main.netMode == 1)
                                //{
                                //    NetMessage.SendData(102, -1, -1, "", projectile.owner, (float)num2, thisPlayer.Center.X, thisPlayer.Center.Y, 0, 0, 0);
                                //    NetMessage.SendData(21, -1, -1, "", j, 0f, 0f, 0f, 0, 0, 0);
                                //}
                                //else
                                //{
                                //    thisPlayer.NebulaLevelup(num2);
                                //}
                            }
                            if (Main.item[j].type == 58 || Main.item[j].type == 1734 || Main.item[j].type == 1867)
                            {
                                continue;
                                //Main.PlaySound(7, (int)thisPlayer.position.X, (int)thisPlayer.position.Y, 1);
                                //thisPlayer.statLife += 20;
                                //if (Main.myPlayer == thisPlayer.whoAmI)
                                //{
                                //    thisPlayer.HealEffect(20, true);
                                //}
                                //if (thisPlayer.statLife > thisPlayer.statLifeMax2)
                                //{
                                //    thisPlayer.statLife = thisPlayer.statLifeMax2;
                                //}
                                //Main.item[j] = new Item();
                                //if (Main.netMode == 1)
                                //{
                                //    NetMessage.SendData(21, -1, -1, "", j, 0f, 0f, 0f, 0, 0, 0);
                                //}
                            }
                            else if (Main.item[j].type == 184 || Main.item[j].type == 1735 || Main.item[j].type == 1868)
                            {
                                continue;
                                //Main.PlaySound(7, (int)thisPlayer.position.X, (int)thisPlayer.position.Y, 1);
                                //thisPlayer.statMana += 100;
                                //if (Main.myPlayer == thisPlayer.whoAmI)
                                //{
                                //    thisPlayer.ManaEffect(100);
                                //}
                                //if (thisPlayer.statMana > thisPlayer.statManaMax2)
                                //{
                                //    thisPlayer.statMana = thisPlayer.statManaMax2;
                                //}
                                //Main.item[j] = new Item();
                                //if (Main.netMode == 1)
                                //{
                                //    NetMessage.SendData(21, -1, -1, "", j, 0f, 0f, 0f, 0, 0, 0);
                                //}
                            }
                            else
                            {
                                Main.item[j] = thisPlayer.GetItem(projectile.owner, Main.item[j], false, false);
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendData(21, -1, -1, null, j, 0f, 0f, 0f, 0, 0, 0);
                                }
                            }

                            //  Main.item[j] = thisPlayer.GetItem(projectile.owner, Main.item[j], false, false);
                            //   ErrorLogger.Log("whoa");
                        }
                    }
                }
            }
        }


        public override void AI()
        {
            Entity target = Main.player[projectile.owner];

            if (!Main.player[projectile.owner].active)
            {
                projectile.active = false;
                return;
            }

            pickup();

            int num = 85;

            // Change "target" to player OR items.  No teleporting to items....?
            int lootTarget = targetLoot();

            if (lootTarget != -1)
            {
                //Item targetedLootItem = Main.item[lootTarget];
                target = Main.item[lootTarget];
                num = 0;
                //Vector2 vector132 = targetedLootItem.Center - projectile.Center;
            }


            bool playerOutOfRangeLeftSide = false;
            bool playerOutOfRangeRightSide = false;
            bool playerBelowPet = false;
            bool flag4 = false;



            //if (projectile.type == 209)
            //{
            Player player = Main.player[projectile.owner];
            TrlandModPlayer modPlayer = player.GetModPlayer<TrlandModPlayer>(mod);

            if (Main.player[projectile.owner].dead)
            {
                modPlayer.LootChestPet = false;
                //   Main.player[projectile.owner].truffle = false;
            }
            if (modPlayer.LootChestPet)
            {
                projectile.timeLeft = 2;
            }
            //}


            //if (Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) < projectile.position.X + (float)(projectile.width / 2) - (float)num)
            //{
            //    playerOutOfRangeLeftSide = true;
            //}
            //else if (Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) > projectile.position.X + (float)(projectile.width / 2) + (float)num)
            //{
            //    playerOutOfRangeRightSide = true;
            //}

            if (target.position.X + (float)(target.width / 2) < projectile.position.X + (float)(projectile.width / 2) - (float)num)
            {
                playerOutOfRangeLeftSide = true;
            }
            else if (target.position.X + (float)(target.width / 2) > projectile.position.X + (float)(projectile.width / 2) + (float)num)
            {
                playerOutOfRangeRightSide = true;
            }




            {
                if (projectile.ai[1] == 0f)
                {
                    int num36 = 1000;

                    if (Main.player[projectile.owner].rocketDelay2 > 0)
                    {
                        projectile.ai[0] = 1f;
                    }
                    Vector2 petCenter = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    float distanceXToPlayer = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - petCenter.X;

                    float distanceYToPlayer = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - petCenter.Y;
                    float distanceToPlayer = (float)Math.Sqrt((double)(distanceXToPlayer * distanceXToPlayer + distanceYToPlayer * distanceYToPlayer));
                    if (distanceToPlayer > 2000f)
                    {
                        // teleport now!
                        projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
                        projectile.position.Y = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - (float)(projectile.height / 2);
                    }
                    else if (distanceToPlayer > (float)num36 || (Math.Abs(distanceYToPlayer) > 800f && (true || projectile.localAI[0] <= 0f)))
                    {
                        projectile.ai[0] = 1f;
                    }
                }
                // if teleporting.
                if (/*projectile.type == 209 && */projectile.ai[0] != 0f)
                {
                    if (Main.player[projectile.owner].velocity.Y == 0f && projectile.alpha >= 100)
                    {
                        // Teleport Directly to player
                        projectile.position.X = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - (float)(projectile.width / 2);
                        projectile.position.Y = Main.player[projectile.owner].position.Y + (float)Main.player[projectile.owner].height - (float)projectile.height;
                        projectile.ai[0] = 0f;
                        return;
                    }
                    projectile.velocity.X = 0f;
                    projectile.velocity.Y = 0f;
                    projectile.alpha += 5;
                    if (projectile.alpha > 255)
                    {
                        projectile.alpha = 255;
                        return;
                    }
                }
                //else if (projectile.ai[0] != 0f)
                //{
                //    float num40 = 0.2f;
                //    int num41 = 200;


                //    projectile.tileCollide = false;
                //    Vector2 vector7 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                //    float num42 = Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2) - vector7.X;

                //    float num48 = Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2) - vector7.Y;

                //    float num49 = (float)Math.Sqrt((double)(num42 * num42 + num48 * num48));
                //    float num50 = 10f;
                //    float num51 = num49;


                //    if (num49 < (float)num41 && Main.player[projectile.owner].velocity.Y == 0f && projectile.position.Y + (float)projectile.height <= Main.player[projectile.owner].position.Y + (float)Main.player[projectile.owner].height && !Collision.SolidCollision(projectile.position, projectile.width, projectile.height))
                //    {
                //        projectile.ai[0] = 0f;
                //        if (projectile.velocity.Y < -6f)
                //        {
                //            projectile.velocity.Y = -6f;
                //        }
                //    }
                //    if (num49 < 60f)
                //    {
                //        num42 = projectile.velocity.X;
                //        num48 = projectile.velocity.Y;
                //    }
                //    else
                //    {
                //        num49 = num50 / num49;
                //        num42 *= num49;
                //        num48 *= num49;
                //    }

                //    {
                //        if (projectile.velocity.X < num42)
                //        {
                //            projectile.velocity.X = projectile.velocity.X + num40;
                //            if (projectile.velocity.X < 0f)
                //            {
                //                projectile.velocity.X = projectile.velocity.X + num40 * 1.5f;
                //            }
                //        }
                //        if (projectile.velocity.X > num42)
                //        {
                //            projectile.velocity.X = projectile.velocity.X - num40;
                //            if (projectile.velocity.X > 0f)
                //            {
                //                projectile.velocity.X = projectile.velocity.X - num40 * 1.5f;
                //            }
                //        }
                //        if (projectile.velocity.Y < num48)
                //        {
                //            projectile.velocity.Y = projectile.velocity.Y + num40;
                //            if (projectile.velocity.Y < 0f)
                //            {
                //                projectile.velocity.Y = projectile.velocity.Y + num40 * 1.5f;
                //            }
                //        }
                //        if (projectile.velocity.Y > num48)
                //        {
                //            projectile.velocity.Y = projectile.velocity.Y - num40;
                //            if (projectile.velocity.Y > 0f)
                //            {
                //                projectile.velocity.Y = projectile.velocity.Y - num40 * 1.5f;
                //            }
                //        }
                //    }

                //    if ((double)projectile.velocity.X > 0.5)
                //    {
                //        projectile.spriteDirection = -1;
                //    }
                //    else if ((double)projectile.velocity.X < -0.5)
                //    {
                //        projectile.spriteDirection = 1;
                //    }





                //    else if (projectile.spriteDirection == -1)
                //    {
                //        projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X);
                //    }
                //    else
                //    {
                //        projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 3.14f;
                //    }


                //    //if (projectile.type != 398 && projectile.type != 390 && projectile.type != 391 && projectile.type != 392 && projectile.type != 127 && projectile.type != 200 && projectile.type != 208 && projectile.type != 210 && projectile.type != 236 && projectile.type != 266 && projectile.type != 268 && projectile.type != 269 && projectile.type != 313 && projectile.type != 314 && projectile.type != 319 && projectile.type != 324 && projectile.type != 334 && projectile.type != 353)
                //    //{
                //    //    int num56 = Dust.NewDust(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 4f, projectile.position.Y + (float)(projectile.height / 2) - 4f) - projectile.velocity, 8, 8, 16, -projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 50, default(Color), 1.7f);
                //    //    Main.dust[num56].velocity.X = Main.dust[num56].velocity.X * 0.2f;
                //    //    Main.dust[num56].velocity.Y = Main.dust[num56].velocity.Y * 0.2f;
                //    //    Main.dust[num56].noGravity = true;
                //    //    return;
                //    //}
                //}
                else
                {
                    //bool flag6 = false;
                    Vector2 vector9 = Vector2.Zero;
                    //bool flag7 = false;
                    // ?? does nothing.
                    if (projectile.ai[1] != 0f)
                    {
                        playerOutOfRangeLeftSide = false;
                        playerOutOfRangeRightSide = false;
                    }
                    float xAccelerationValue = 0.08f;
                    float xVelocityLimit = 6.5f;
                    if (playerOutOfRangeLeftSide)
                    {
                        if ((double)projectile.velocity.X > -3.5)
                        {
                            projectile.velocity.X = projectile.velocity.X - xAccelerationValue;
                        }
                        else
                        {
                            projectile.velocity.X = projectile.velocity.X - xAccelerationValue * 0.25f;
                        }
                    }
                    else if (playerOutOfRangeRightSide)
                    {
                        if ((double)projectile.velocity.X < 3.5)
                        {
                            projectile.velocity.X = projectile.velocity.X + xAccelerationValue;
                        }
                        else
                        {
                            projectile.velocity.X = projectile.velocity.X + xAccelerationValue * 0.25f;
                        }
                    }
                    else
                    {
                        projectile.velocity.X = projectile.velocity.X * 0.9f;
                        if (projectile.velocity.X >= -xAccelerationValue && projectile.velocity.X <= xAccelerationValue)
                        {
                            projectile.velocity.X = 0f;
                        }
                    }
                    if (playerOutOfRangeLeftSide || playerOutOfRangeRightSide)
                    {
                        int petPositionTileX = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                        int petPositionTileY = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16;

                        if (playerOutOfRangeLeftSide)
                        {
                            petPositionTileX--;
                        }
                        if (playerOutOfRangeRightSide)
                        {
                            petPositionTileX++;
                        }
                        petPositionTileX += (int)projectile.velocity.X;
                        if (WorldGen.SolidTile(petPositionTileX, petPositionTileY))
                        {
                            flag4 = true;
                        }
                    }
                    if (Main.player[projectile.owner].position.Y + (float)Main.player[projectile.owner].height - 8f > projectile.position.Y + (float)projectile.height)
                    {
                        playerBelowPet = true;
                    }
                    Collision.StepUp(ref projectile.position, ref projectile.velocity, projectile.width, projectile.height, ref projectile.stepSpeed, ref projectile.gfxOffY, 1, false, 0);
                    if (projectile.velocity.Y == 0f)
                    {
                        if (!playerBelowPet && (projectile.velocity.X < 0f || projectile.velocity.X > 0f))
                        {
                            int num102 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                            int j3 = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16 + 1;
                            if (playerOutOfRangeLeftSide)
                            {
                                num102--;
                            }
                            if (playerOutOfRangeRightSide)
                            {
                                num102++;
                            }
                            WorldGen.SolidTile(num102, j3);
                        }
                        if (flag4)
                        {
                            int num103 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                            int num104 = (int)(projectile.position.Y + (float)projectile.height) / 16 + 1;
                            if (WorldGen.SolidTile(num103, num104) || Main.tile[num103, num104].halfBrick() || Main.tile[num103, num104].slope() > 0 /*|| projectile.type == 200*/)
                            {

                                {
                                    try
                                    {
                                        num103 = (int)(projectile.position.X + (float)(projectile.width / 2)) / 16;
                                        num104 = (int)(projectile.position.Y + (float)(projectile.height / 2)) / 16;
                                        if (playerOutOfRangeLeftSide)
                                        {
                                            num103--;
                                        }
                                        if (playerOutOfRangeRightSide)
                                        {
                                            num103++;
                                        }
                                        num103 += (int)projectile.velocity.X;
                                        if (!WorldGen.SolidTile(num103, num104 - 1) && !WorldGen.SolidTile(num103, num104 - 2))
                                        {
                                            projectile.velocity.Y = -5.1f;
                                        }
                                        else if (!WorldGen.SolidTile(num103, num104 - 2))
                                        {
                                            projectile.velocity.Y = -7.1f;
                                        }
                                        else if (WorldGen.SolidTile(num103, num104 - 5))
                                        {
                                            projectile.velocity.Y = -11.1f;
                                        }
                                        else if (WorldGen.SolidTile(num103, num104 - 4))
                                        {
                                            projectile.velocity.Y = -10.1f;
                                        }
                                        else
                                        {
                                            projectile.velocity.Y = -9.1f;
                                        }
                                    }
                                    catch
                                    {
                                        projectile.velocity.Y = -9.1f;
                                    }
                                }

                            }
                        }

                    }
                    if (projectile.velocity.X > xVelocityLimit)
                    {
                        projectile.velocity.X = xVelocityLimit;
                    }
                    if (projectile.velocity.X < -xVelocityLimit)
                    {
                        projectile.velocity.X = -xVelocityLimit;
                    }
                    if (projectile.velocity.X < 0f)
                    {
                        projectile.direction = -1;
                    }
                    if (projectile.velocity.X > 0f)
                    {
                        projectile.direction = 1;
                    }
                    if (projectile.velocity.X > xAccelerationValue && playerOutOfRangeRightSide)
                    {
                        projectile.direction = 1;
                    }
                    if (projectile.velocity.X < -xAccelerationValue && playerOutOfRangeLeftSide)
                    {
                        projectile.direction = -1;
                    }

                    if ((double)projectile.velocity.X > 0.5)
                    {
                        projectile.spriteDirection = -1;
                    }
                    else if ((double)projectile.velocity.X < -0.5)
                    {
                        projectile.spriteDirection = 1;
                    }


                    //else if (projectile.type == 209)
                    {
                        if (projectile.alpha > 0)
                        {
                            projectile.alpha -= 5;
                            if (projectile.alpha < 0)
                            {
                                projectile.alpha = 0;
                            }
                        }
                        if (projectile.velocity.Y == 0f)
                        {
                            if (projectile.velocity.X == 0f)
                            {
                                projectile.frame = 0;
                                projectile.frameCounter = 0;
                            }
                            else if ((double)projectile.velocity.X < -0.1 || (double)projectile.velocity.X > 0.1)
                            {
                                projectile.frameCounter += (int)Math.Abs(projectile.velocity.X);
                                projectile.frameCounter++;
                                if (projectile.frameCounter > 6)
                                {
                                    projectile.frame++;
                                    projectile.frameCounter = 0;
                                }
                                if (projectile.frame > 4)
                                {
                                    projectile.frame = 2;
                                }
                                if (projectile.frame < 2)
                                {
                                    projectile.frame = 2;
                                }
                            }
                            else
                            {
                                projectile.frame = 0;
                                projectile.frameCounter = 0;
                            }
                        }
                        else
                        {
                            projectile.frame = 1;
                            projectile.frameCounter = 0;
                            projectile.rotation = 0f;
                        }
                        projectile.velocity.Y = projectile.velocity.Y + 0.4f;
                        if (projectile.velocity.Y > 10f)
                        {
                            projectile.velocity.Y = 10f;
                            return;
                        }
                    }
                }
            }
        }
    }
}
