using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Threading;
using Scroll.Properties;

namespace Scroll
{
    public class Map
    {
        int divs = 3;
        public int nTileWidth = 20;
        public int nTileHeight = 20;
        int nLevelWidth, nLevelHeight;
        private string sLevel;
        public Bitmap bmp;
        public Graphics g;
        Player dedede;
        Player weedle;
        Player fla;
        SoundPlayer soundPlayer;
        int score;
        int vidas=0;
        bool isP1 = true;
        Thread thread, threadStop;
        Bitmap tilesLevel = new Bitmap(Resource1.escenarioFF);
        Bitmap tilesLevel2 = new Bitmap(Resource1.escenarioinverso);
        public Map(Size size)
        {
            
            soundPlayer = new SoundPlayer(Resource1.coimp);
            Play();
            score = 0;
            dedede = new Player();
            weedle = new Player();
            fla= new Player();
            dedede.enemigo.Position(0, 390);
            weedle.weedle.Position(0, 410);
            fla.flamer.Position(0,240);

            sLevel = "";
            sLevel += "*******************************************************************************************************************************************************************.8888888888";
            sLevel += "************************************************************************************************************<******************************************************.8888888888";
            sLevel += "***********************************************************************************************************AAAAA***************************************************.8888888888";
            sLevel += "*********************]*******************************]*****************************************************.....***************************************************.8888888888";
            sLevel += "*******************************************************************************************]*******************.***************************************************.8888888888";
            sLevel += "jm************************************************dhjjjjm******************************************************.*******************************************]*******.8888888888";
            sLevel += "knp**<********************************************eikkkkn******************************************************.****************<*******************************:**.8888888888";
            sLevel += "loqAAAAAE**************************IA***************aaa***************************************************IF***.**************IAAAA****************AAAAAAAAAAAAAAAA.8888888888";
            sLevel += "........BCDE*******************AAFGH.***************aaa**************<***************************uy******GH.***.***********IFGH....****************.................8888888888";
            sLevel += "...........BCDE****************......jm*************aaa*****AAA******AA*******<******AAE*********vz******...***.uy******IFGH.......********************************.8888888888";
            sLevel += "......f.......BCDE*************......knp*******AAAAA>>>AAAAA...******..*****IAAAjm***..BCDE*****swSU**IAA...****vz***IFGH.f........********************************.8888888888";
            sLevel += ".................BCD**<********......loqDE***:*....ffff........******..AAAFGH...knp**.....BCDAAAtxTVFGH.....***swSUFGH.............********************************.8888888888";
            sLevel += "....................AAAAAAAAAAA...f......BCDAAA................AAAAAA....f......loqAA.......................AAAtxTV.....f..........*********************40^*AAAAAAA.8888888888";
            sLevel += "...................................................................................................................................********************P39&+........8888888888";
            sLevel += "**********************************************************************************************************************.********************************O28(!........8888888888";
            sLevel += "**********************************************************************************************************************.********************************N17)@........8888888888";
            sLevel += "**********************************************************************************************************************.****************************R***M;6-$........8888888888";
            sLevel += "**********************************************************************************************************************.**:**AAAAAAAAAAAAAAAAAAAAAAAAAAALQ5=%........8888888888";
            sLevel += "**********************************************************************************************************************.AAAAA........................................8888888888";
            sLevel += "**********************************************************************************************************************..............................................8888888888";

            nLevelWidth = 174;
            nLevelHeight = 20;

            bmp = new Bitmap(size.Width / divs, size.Height / divs);

            g = Graphics.FromImage(bmp);
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;

        }

        public void Draw(PointF cameraPos, string message, Player player)
        {

            
            //.
            Rectangle blackCube = new Rectangle(56, 184, 36, 32);
            //f
            Rectangle florVerde = new Rectangle(138, 86, 37, 37);
            //j
            Rectangle arbusto43 = new Rectangle(669, 173, 37, 34);
            //k
            Rectangle arbusto42 = new Rectangle(670, 210, 38, 38);
            //l
            Rectangle arbusto41 = new Rectangle(670, 251, 37, 34);
            //m
            Rectangle arbusto53 = new Rectangle(711, 174, 37, 36);
            //n
            Rectangle arbusto52 = new Rectangle(711, 213, 35, 34);
            //o
            Rectangle arbusto51 = new Rectangle(710, 251, 37, 34);
            //p
            Rectangle arbusto62 = new Rectangle(751, 212, 37, 34);
            //q
            Rectangle arbusto61 = new Rectangle(751, 252, 37, 33);
            //a
            Rectangle arboltronco = new Rectangle(873, 120, 38, 38);
            //>
            Rectangle arboltronco2 = new Rectangle(873, 161, 38, 38);
            //b
            Rectangle arbusto12 = new Rectangle(546, 209, 38, 38);
            //c
            Rectangle arbusto11 = new Rectangle(546, 250, 38, 38);
            //d
            Rectangle arbusto23 = new Rectangle(588, 174, 38, 34);
            //e
            Rectangle arbusto22 = new Rectangle(587, 209, 38, 38);
            //g
            Rectangle arbusto21 = new Rectangle(587, 250, 38, 38);
            //h
            Rectangle arbusto33 = new Rectangle(628, 173, 38, 38);
            //i
            Rectangle arbusto32 = new Rectangle(628, 209, 38, 38);
            //r
            Rectangle arbusto31 = new Rectangle(628, 250, 38, 38);

            //s
            Rectangle arbolitoNavida12 = new Rectangle(587, 92, 38, 38);
            //t
            Rectangle arbolitoNavida11 = new Rectangle(587, 132, 38, 38);
            //u
            Rectangle arbolitoNavida24 = new Rectangle(628, 9, 38, 38);
            //v
            Rectangle arbolitoNavida23 = new Rectangle(628, 51, 35, 35);
            //w
            Rectangle arbolitoNavida22 = new Rectangle(628, 92, 38, 38);
            //x
            Rectangle arbolitoNavida21 = new Rectangle(628, 132, 38, 38);
            //y
            Rectangle arbolitoNavida34 = new Rectangle(669, 9, 38, 38);
            //z
            Rectangle arbolitoNavida33 = new Rectangle(669, 51, 35, 35);
            //S
            Rectangle arbolitoNavida32 = new Rectangle(669, 92, 38, 38);
            //T
            Rectangle arbolitoNavida31 = new Rectangle(669, 133, 38, 38);
            //U
            Rectangle arbolitoNavida42 = new Rectangle(710, 90, 38, 38);
            //V
            Rectangle arbolitoNavida41 = new Rectangle(710, 133, 38, 38);
            //A
            Rectangle pasto = new Rectangle(179, 17, 36, 20);
            //B
            Rectangle arbustoBajada = new Rectangle(464, 44, 38, 38);
            //C
            Rectangle arbustoBajada2 = new Rectangle(505, 44, 38, 38);
            //D
            Rectangle arbustoBajada3 = new Rectangle(546, 44, 38, 38);
            //E
            Rectangle arbustoBajada4 = new Rectangle(464, 1, 38, 41);
            //F
            Rectangle arbustoBajadA1 = new Rectangle(342, 44, 34, 38);
            //G
            Rectangle arbustoBajadA2 = new Rectangle(384, 44, 36, 36);
            //H
            Rectangle arbustoBajadA3 = new Rectangle(424, 44, 36, 36);
            //I
            Rectangle arbustoBajadA4 = new Rectangle(422, 1, 38, 41);

            //L
            Rectangle arbolCasa11 = new Rectangle(954, 250, 38, 38);
            //M
            Rectangle arbolCasa12 = new Rectangle(954, 209, 38, 38);
            //N
            Rectangle arbolCasa13 = new Rectangle(954, 168, 38, 38);
            //O
            Rectangle arbolCasa14 = new Rectangle(954, 128, 38, 38);
            //P
            Rectangle arbolCasa15 = new Rectangle(954, 87, 38, 38);
            //Q
            Rectangle arbolCasa21 = new Rectangle(995, 250, 38, 38);
            //;
            Rectangle arbolCasa22 = new Rectangle(995, 209, 38, 38);
            //1
            Rectangle arbolCasa23 = new Rectangle(995, 168, 38, 38);
            //2
            Rectangle arbolCasa24 = new Rectangle(995, 128, 38, 38);
            //3
            Rectangle arbolCasa25 = new Rectangle(995, 87, 38, 38);
            //4
            Rectangle arbolCasa26 = new Rectangle(995, 43, 38, 38);
            //5
            Rectangle arbolCasa31 = new Rectangle(1036, 250, 38, 38);
            //6
            Rectangle arbolCasa32 = new Rectangle(1036, 209, 38, 38);
            //7
            Rectangle arbolCasa33 = new Rectangle(1036, 168, 38, 38);
            //8
            Rectangle arbolCasa34 = new Rectangle(1036, 128, 38, 38);
            //9
            Rectangle arbolCasa35 = new Rectangle(1036, 87, 38, 38);
            //0
            Rectangle arbolCasa36 = new Rectangle(1036, 43, 38, 38);
            //=
            Rectangle arbolCasa41 = new Rectangle(1077, 250, 38, 38);
            //-
            Rectangle arbolCasa42 = new Rectangle(1077, 209, 38, 38);
            //)
            Rectangle arbolCasa43 = new Rectangle(1077, 168, 38, 38);
            //(
            Rectangle arbolCasa44 = new Rectangle(1077, 128, 38, 38);
            //&
            Rectangle arbolCasa45 = new Rectangle(1077, 87, 38, 38);
            //^
            Rectangle arbolCasa46 = new Rectangle(1077, 43, 38, 38);
            //%
            Rectangle arbolCasa51 = new Rectangle(1118, 250, 38, 38);
            //$
            Rectangle arbolCasa52 = new Rectangle(1118, 209, 38, 38);
            //@
            Rectangle arbolCasa53 = new Rectangle(1118, 168, 38, 38);
            //!
            Rectangle arbolCasa54 = new Rectangle(1118, 128, 38, 38);
            //+
            Rectangle arbolCasa55 = new Rectangle(1118, 87, 38, 38);



            // Draw Level based on the visible tiles on our picturebox (canvas)
            int nVisibleTilesX = bmp.Width / nTileWidth;
            int nVisibleTilesY = bmp.Height / nTileHeight;

            // Calculate Top-Leftmost visible tile
            float fOffsetX = cameraPos.X - (float)nVisibleTilesX / 2.0f;
            float fOffsetY = cameraPos.Y - (float)nVisibleTilesY / 1.25f;

            // Clamp camera to game boundaries
            if (fOffsetX < 0) fOffsetX = 0;
            if (fOffsetY < 0) fOffsetY = 0;
            if (fOffsetX > nLevelWidth - nVisibleTilesX) fOffsetX = nLevelWidth - nVisibleTilesX;
            if (fOffsetY > nLevelHeight - nVisibleTilesY) fOffsetY = nLevelHeight - nVisibleTilesY;

            float fTileOffsetX = (fOffsetX - (int)fOffsetX) * nTileWidth;
            float fTileOffsetY = (fOffsetY - (int)fOffsetY) * nTileHeight;
            GC.Collect();
            //Draw visible tile map//*--------------------DRAW------------------------------
            char c;
            float stepX, stepY;
            for (int x = -1; x < nVisibleTilesX + 2; x++)
            {
                for (int y = -1; y < nVisibleTilesY + 2; y++)
                {
                    c = GetTile(x + (int)fOffsetX, y + (int)fOffsetY);
                    stepX = x * nTileWidth - fTileOffsetX;
                    stepY = y * nTileHeight - fTileOffsetY;
                    Rectangle destRect = new Rectangle((int)stepX, (int)stepY, nTileWidth, nTileWidth);

                    g.FillRectangle(Brushes.Transparent, stepX, stepY, nTileWidth, nTileHeight);             
                    switch (c)
                    {
                        case '#':
                            g.FillRectangle(Brushes.Cyan, stepX, stepY, nTileWidth, nTileHeight);
                            break;

                        case '.':
                            g.DrawImage(tilesLevel, destRect, blackCube, GraphicsUnit.Pixel);
                            break;
                        case 'f':
                            g.DrawImage(tilesLevel, destRect, florVerde, GraphicsUnit.Pixel);
                            break;

                        case 'j':
                            g.DrawImage(tilesLevel, destRect, arbusto43, GraphicsUnit.Pixel);
                            
                            break;
                        case 'k':
                            g.DrawImage(tilesLevel, destRect, arbusto42, GraphicsUnit.Pixel);
                            break;
                        case 'l':
                            g.DrawImage(tilesLevel, destRect, arbusto41, GraphicsUnit.Pixel);
                            break;
                        case 'm':
                            g.DrawImage(tilesLevel, destRect, arbusto53, GraphicsUnit.Pixel);
                            
                            break;
                        case 'n':
                            g.DrawImage(tilesLevel, destRect, arbusto52, GraphicsUnit.Pixel);
                            break;
                        case 'o':
                            g.DrawImage(tilesLevel, destRect, arbusto51, GraphicsUnit.Pixel);
                            break;
                        case 'p':
                            g.DrawImage(tilesLevel, destRect, arbusto62, GraphicsUnit.Pixel);
                            break;
                        case 'q':
                            g.DrawImage(tilesLevel, destRect, arbusto61, GraphicsUnit.Pixel);
                            break;
                        case 'a':
                            g.DrawImage(tilesLevel, destRect, arboltronco, GraphicsUnit.Pixel);
                            break;
                        case '>':
                            g.DrawImage(tilesLevel, destRect, arboltronco2, GraphicsUnit.Pixel);
                            break;
                        case 'b':
                            g.DrawImage(tilesLevel, destRect, arbusto12, GraphicsUnit.Pixel);
                            break;
                        case 'c':
                            g.DrawImage(tilesLevel, destRect, arbusto11, GraphicsUnit.Pixel);
                            break;
                        case 'd':
                            g.DrawImage(tilesLevel, destRect, arbusto23, GraphicsUnit.Pixel);
                            break;
                        case 'e':
                            g.DrawImage(tilesLevel, destRect, arbusto22, GraphicsUnit.Pixel);
                            break;
                        case 'g':
                            g.DrawImage(tilesLevel, destRect, arbusto21, GraphicsUnit.Pixel);
                            break;
                        case 'h':
                            g.DrawImage(tilesLevel, destRect, arbusto33, GraphicsUnit.Pixel);
                            break;
                        case 'i':
                            g.DrawImage(tilesLevel, destRect, arbusto32, GraphicsUnit.Pixel);
                            break;
                        case 'r':
                            g.DrawImage(tilesLevel, destRect, arbusto31, GraphicsUnit.Pixel);
                            break;
                        case 's':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida12, GraphicsUnit.Pixel);
                            break;
                        case 't':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida11, GraphicsUnit.Pixel);
                            break;
                        case 'u':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida24, GraphicsUnit.Pixel);
                            break;
                        case 'v':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida23, GraphicsUnit.Pixel);
                            break;
                        case 'w':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida22, GraphicsUnit.Pixel);
                            break;
                        case 'x':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida21, GraphicsUnit.Pixel);
                            break;
                        case 'y':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida34, GraphicsUnit.Pixel);
                            break;
                        case 'z':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida33, GraphicsUnit.Pixel);
                            break;
                        case 'S':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida32, GraphicsUnit.Pixel);
                            break;
                        case 'T':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida31, GraphicsUnit.Pixel);
                            break;
                        case 'U':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida42, GraphicsUnit.Pixel);
                            break;
                        case 'V':
                            g.DrawImage(tilesLevel, destRect, arbolitoNavida41, GraphicsUnit.Pixel);
                            break;
                        case 'A':
                            g.DrawImage(tilesLevel, destRect, pasto, GraphicsUnit.Pixel);
                            break;
                        case 'B':
                            g.DrawImage(tilesLevel, destRect, arbustoBajada, GraphicsUnit.Pixel);
                            break;
                        case 'C':
                            g.DrawImage(tilesLevel, destRect, arbustoBajada2, GraphicsUnit.Pixel);
                            break;
                        case 'D':
                            g.DrawImage(tilesLevel, destRect, arbustoBajada3, GraphicsUnit.Pixel);
                            break;
                        case 'E':
                            g.DrawImage(tilesLevel, destRect, arbustoBajada4, GraphicsUnit.Pixel);
                            break;
                        case 'F':
                            g.DrawImage(tilesLevel, destRect, arbustoBajadA1, GraphicsUnit.Pixel);
                            break;
                        case 'G':
                            g.DrawImage(tilesLevel, destRect, arbustoBajadA2, GraphicsUnit.Pixel);
                            break;
                        case 'H':
                            g.DrawImage(tilesLevel, destRect, arbustoBajadA3, GraphicsUnit.Pixel);
                            break;
                        case 'I':
                            g.DrawImage(tilesLevel, destRect, arbustoBajadA4, GraphicsUnit.Pixel);
                            break;
                        case 'R':
                            dedede.enemigo.posX = stepX;
                            dedede.enemigo.posY = stepY-15;
                            
                            dedede.enemigo.MoveSlow(5);
                            dedede.enemigo.Display(g);
                            break;
                        case '<':
                            weedle.weedle.posX = stepX-10;
                            weedle.weedle.posY = stepY;

                            weedle.weedle.MoveSlow(5);
                            weedle.weedle.Display(g);
                            break;
                        case ']':
                            fla.flamer.posX = stepX - 10;
                            fla.flamer.posY = stepY;

                            fla.flamer.MoveSlow(5);
                            fla.flamer.Display(g);
                            break;
                        case ':':
                            g.DrawImage(Resource1.MANZANA, stepX, stepY, nTileWidth+10, nTileHeight+10);
                            break;
                        case 'L':
                            g.DrawImage(tilesLevel, destRect, arbolCasa11, GraphicsUnit.Pixel);
                            break;
                        case 'M':
                            g.DrawImage(tilesLevel, destRect, arbolCasa12, GraphicsUnit.Pixel);
                            break;
                        case 'N':
                            g.DrawImage(tilesLevel, destRect, arbolCasa13, GraphicsUnit.Pixel);
                            break;
                        case 'O':
                            g.DrawImage(tilesLevel, destRect, arbolCasa14, GraphicsUnit.Pixel);
                            break;
                        case 'P':
                            g.DrawImage(tilesLevel, destRect, arbolCasa15, GraphicsUnit.Pixel);
                            break;
                        case 'Q':
                            g.DrawImage(tilesLevel, destRect, arbolCasa21, GraphicsUnit.Pixel);
                            break;
                        case ';':
                            g.DrawImage(tilesLevel, destRect, arbolCasa22, GraphicsUnit.Pixel);
                            break;
                        case '1':
                            g.DrawImage(tilesLevel, destRect, arbolCasa23, GraphicsUnit.Pixel);
                            break;
                        case '2':
                            g.DrawImage(tilesLevel, destRect, arbolCasa24, GraphicsUnit.Pixel);
                            break;
                        case '3':
                            g.DrawImage(tilesLevel, destRect, arbolCasa25, GraphicsUnit.Pixel);
                            break;
                        case '4':
                            g.DrawImage(tilesLevel, destRect, arbolCasa26, GraphicsUnit.Pixel);
                            break;
                        case '5':
                            g.DrawImage(tilesLevel, destRect, arbolCasa31, GraphicsUnit.Pixel);
                            break;
                        case '6':
                            g.DrawImage(tilesLevel, destRect, arbolCasa32, GraphicsUnit.Pixel);
                            break;
                        case '7':
                            g.DrawImage(tilesLevel, destRect, arbolCasa33, GraphicsUnit.Pixel);
                            break;
                        case '8':
                            g.DrawImage(tilesLevel, destRect, arbolCasa34, GraphicsUnit.Pixel);
                            break;
                        case '9':
                            g.DrawImage(tilesLevel, destRect, arbolCasa35, GraphicsUnit.Pixel);
                            break;
                        case '0':
                            g.DrawImage(tilesLevel, destRect, arbolCasa36, GraphicsUnit.Pixel);
                            break;
                        case '=':
                            g.DrawImage(tilesLevel, destRect, arbolCasa41, GraphicsUnit.Pixel);
                            break;
                        case '-':
                            g.DrawImage(tilesLevel, destRect, arbolCasa42, GraphicsUnit.Pixel);
                            break;
                        case ')':
                            g.DrawImage(tilesLevel, destRect, arbolCasa43, GraphicsUnit.Pixel);
                            break;
                        case '(':
                            g.DrawImage(tilesLevel, destRect, arbolCasa44, GraphicsUnit.Pixel);
                            break;
                        case '&':
                            g.DrawImage(tilesLevel, destRect, arbolCasa45, GraphicsUnit.Pixel);
                            break;
                        case '^':
                            g.DrawImage(tilesLevel, destRect, arbolCasa46, GraphicsUnit.Pixel);
                            break;
                        case '%':
                            g.DrawImage(tilesLevel, destRect, arbolCasa51, GraphicsUnit.Pixel);
                            break;
                        case '$':
                            g.DrawImage(tilesLevel, destRect, arbolCasa52, GraphicsUnit.Pixel);
                            break;
                        case '@':
                            g.DrawImage(tilesLevel, destRect, arbolCasa53, GraphicsUnit.Pixel);
                            break;
                        case '!':
                            g.DrawImage(tilesLevel, destRect, arbolCasa54, GraphicsUnit.Pixel);
                            break;
                        case '+':
                            g.DrawImage(tilesLevel, destRect, arbolCasa55, GraphicsUnit.Pixel);
                            break;


                    }
                    //g.DrawRectangle(Pens.Gray, stepX, stepY, nTileWidth, nTileHeight);
                }
            }

            g.DrawString("SCORE:: " + score, new Font("Consolas", 10, FontStyle.Italic), Brushes.White, 5, 5);


            if (player.vidas == 3)
            {
                g.DrawImage(Resource1.kirby_vida, 5, 180, 40, 40);
                g.DrawImage(Resource1.kirby_vida, 35, 180, 40, 40);
                g.DrawImage(Resource1.kirby_vida, 65, 180, 40, 40);
            }
            if (player.vidas == 2)
            {
                g.DrawImage(Resource1.kirby_vida, 5, 180, 40, 40);
                g.DrawImage(Resource1.kirby_vida, 35, 180, 40, 40);

            }
            if (player.vidas == 1)
            {
                g.DrawImage(Resource1.kirby_vida, 5, 180, 40, 40);
               
            }

            player.MainSprite.posX = (player.fPlayerPosX - fOffsetX) * nTileWidth;
            player.MainSprite.posY = (player.fPlayerPosY - fOffsetY) * nTileHeight;
          
        }

        public void SetTile(float x, float y, char c)//changes the tile
        {
            if (x >= 0 && x < nLevelWidth && y >= 0 && y < nLevelHeight)
            {
                int index = (int)y * nLevelWidth + (int)x;
                sLevel = sLevel.Remove(index, 1).Insert(index, c.ToString());
                // Play();
                score += 100;
            }
        }

        public char GetTile(float x, float y)
        {
            if (x >= 0 && x < nLevelWidth && y >= 0 && y < nLevelHeight)
                return sLevel[(int)y * nLevelWidth + (int)x];
            else
                return ' ';
        }

        public void SetTileM(float x, float y, char c)//changes the tile
        {
            if (x >= 0 && x < nLevelWidth && y >= 0 && y < nLevelHeight)
            {
                int index = (int)y * nLevelWidth + (int)x;
                sLevel = sLevel.Remove(index, 1).Insert(index, c.ToString());;
            }
        }

        public void Play()
        {
            if (isP1)
            {
                thread = new Thread(PlayThread);
                thread.Start();
            }
            threadStop = new Thread(PlayStop);
            threadStop.Start();
        }
        private void PlayThread()
        {
            isP1 = false;
            soundPlayer.PlaySync();
            isP1 = true;
        }

        private void PlayStop()
        {
            soundPlayer.Stop();
        }

    }
}
