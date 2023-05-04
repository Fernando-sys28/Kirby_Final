using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Scroll
{
    public class Player
    {

        Sprite mainSprite;
        public Sprite enemigo;
        public Sprite weedle;
        public Sprite flamer;

        public float fPlayerPosX = 1.0f;
        public float fPlayerPosY = 1.0f;

        public float fPlayerVelX = 0.0f;
        private float fPlayerVelY = 0.0f;
        public int x, y;
        bool verificar = false;
        public int vidas=3;

        List<char> enemigos = new List<char> { '<', ']', 'R' };
        public Sprite MainSprite
        {
            get { return mainSprite; }
            set { mainSprite = value; }
        }

        public float FPlayerVelX
        {
            get { return fPlayerVelX; }
            set { fPlayerVelX = value; }
        }

        public float FPlayerVelY
        {
            get { return fPlayerVelY; }
            set { fPlayerVelY = value; }
        }

        public Player()
        {
            Point posKirby = new Point(0, 0); 
            Size sizeKirby = new Size(480, 550); 
            Size vizKirby = new Size(40, 40);
            mainSprite = new Sprite(sizeKirby, vizKirby, posKirby, Resource1.kirbyderecha2, Resource1.kirbyizquierda1);

            Point enemigo1 = new Point(0, 0); 
            Size sizeenemigo1 = new Size(114, 150);  
            Size vizenemigo1 = new Size(70, 65);     
            enemigo = new Sprite(sizeenemigo1, vizenemigo1, enemigo1, Resource1.KINDEDEDE);

            Point enemigo2 = new Point(0, 0); 
            Size sizeenemigo2 = new Size(113, 130);  
            Size vizenemigo2 = new Size(80, 80);    
            weedle = new Sprite(sizeenemigo2, vizenemigo2, enemigo2, Resource1.waddle_lanza);

            Point enemigo3 = new Point(0, 0); 
            Size sizeenemigo3 = new Size(119, 120);  
            Size vizenemigo3 = new Size(50, 45);     
            flamer = new Sprite(sizeenemigo3, vizenemigo3, enemigo3, Resource1.flammer);

            
        }


        public void Right(float fElapsedTime)
        {
            FPlayerVelX += (bPlayerOnGround ? 15.0f : 5.0f) * fElapsedTime;
            if (bPlayerOnGround)
            {
                mainSprite.MoveRight();
                
            }

        }

        public void Left(float fElapsedTime)
        {
            FPlayerVelX += (bPlayerOnGround ? -15.0f : -5.0f) * fElapsedTime;
            if (bPlayerOnGround)
            {
                mainSprite.MoveLeft();      
            }

        }
        public void Frame(int x)
        {
            mainSprite.Frame(x);
        }
        public void Stop()
        {
            mainSprite.Frame(0);
        }

        public bool bPlayerOnGround = false;

        public bool Update(float fElapsedTime, Map map, bool golpes, bool succionar)
        {


            //Gravity
            fPlayerVelY += 20.0f * fElapsedTime;//---------------

            // Drag
            if (bPlayerOnGround)
            {
                fPlayerVelX += -3.0f * fPlayerVelX * fElapsedTime;
                if (Math.Abs(fPlayerVelX) < 0.01f)
                    fPlayerVelX = 0.0f;
            }

            // Clamp velocities
            if (fPlayerVelX > 10.0f)
                fPlayerVelX = 10.0f;

            if (fPlayerVelX < -10.0f)
                fPlayerVelX = -10.0f;

            if (fPlayerVelY > 100.0f)
                fPlayerVelY = 100.0f;

            if (fPlayerVelY < -100.0f)
                fPlayerVelY = -100.0f;

            float fNewPlayerPosX = fPlayerPosX + fPlayerVelX * fElapsedTime;
            float fNewPlayerPosY = fPlayerPosY + fPlayerVelY * fElapsedTime;
            // Check for spikes!
            if (enemigos.Contains(map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f)))
            {
                if (fPlayerVelX == 0)
                {

                    if (vidas > 0)
                    {
                        fNewPlayerPosX = 0f;
                        fNewPlayerPosY = 0f;
                        Reset();
                        Console.WriteLine(vidas);
                        vidas--;
                    }
                    else
                    {
                        MessageBox.Show("You defeat", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        Environment.Exit(0);
                    }
                }
                
            }
            if (enemigos.Contains(map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.0f)))
            {
                if (fPlayerVelX == 0)
                {
                    if (vidas > 0)
                    {
                        fNewPlayerPosX = 0f;
                        fNewPlayerPosY = 0f;
                        Reset();
                        Console.WriteLine(vidas);
                        vidas--;
                    }
                    else
                    {
                        MessageBox.Show("You defeat", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        Environment.Exit(0);
                    }
                }
            }

            if (enemigos.Contains(map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f)))
            {
                if (fPlayerVelX == 0)
                {
                    if (vidas > 0)
                    {
                        fNewPlayerPosX = 0f;
                        fNewPlayerPosY = 0f;
                        Reset();
                        Console.WriteLine(vidas);
                        vidas--;
                    }
                    else
                    {
                        MessageBox.Show("You defeat", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        Environment.Exit(0);
                    }

                }
            }

            if (enemigos.Contains(map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 1.0f)))
            {
                if (fPlayerVelX == 0)
                {
                    if (vidas > 0)
                    {
                        fNewPlayerPosX = 0f;
                        fNewPlayerPosY = 0f;
                        Reset();
                        Console.WriteLine(vidas);
                        vidas--;
                    }
                    else
                    {
                        MessageBox.Show("You defeat", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        Environment.Exit(0);
                    }

                }
            }
            CheckFinish(map, fNewPlayerPosX, fNewPlayerPosY);
            if (golpes)
            {
                CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, '<', '*');
                CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, ']', '*');
                CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, 'R', '*');
               
            }  

            if (succionar)
            {
                CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, '<', '*');
                CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, ']', '*');
                CheckPicks(map, fNewPlayerPosX, fNewPlayerPosY, 'R', '*');
            }
           
            CheckManzana(map, fNewPlayerPosX, fNewPlayerPosY, ':', '*');

            List<char> avoidChars = new List<char> { '*', 'j', 'm', 'k', 'n', 'p', 'a', 'd','h','e', 'i', 'u','y', 'v', 'z', 's', 'w', 'S','U','M', ';', '-', '$', 'N', '1', '7', ')', '@', 'O', '2','8', '(', '!', 'P','3','9', '&', '+', '4','0', '^' }; // add all the characters you want to avoid collision with
            
            // COLLISION
            if (fPlayerVelX <= 0)//left
            {
                if (!avoidChars.Contains(map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.0f))) || !avoidChars.Contains(map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fPlayerPosY + 0.9f))))
                {
                    if (fPlayerVelX != 0)
                        fNewPlayerPosX = (int)fNewPlayerPosX + 1;
                    fPlayerVelX = 0;

                }
            }
            else//right
            {
                if (!avoidChars.Contains(map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.0f))) || !avoidChars.Contains(map.GetTile((int)(fNewPlayerPosX + 1.0f), (int)(fPlayerPosY + 0.9f))))
                {
                    if (fPlayerVelX != 0)
                    {
                        fNewPlayerPosX = (int)fNewPlayerPosX;
                        
                    }
                    fPlayerVelX = 0;
                }
            }

            //bPlayerOnGround = false;
            if (fPlayerVelY <= 0)// up
            {
                if (!avoidChars.Contains(map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fNewPlayerPosY - 1f))) || !avoidChars.Contains(map.GetTile((int)(fNewPlayerPosX + 0.9f), (int)(fNewPlayerPosY - 1f))))
                {
                    fNewPlayerPosY = (int)fNewPlayerPosY+1;
                    fPlayerVelY = 0;                   
                }
            }
            else
            {
                if (!avoidChars.Contains(map.GetTile((int)(fNewPlayerPosX + 0.0f), (int)(fNewPlayerPosY + 1f)))  || !avoidChars.Contains(map.GetTile((int)(fNewPlayerPosX + 0.9f), (int)(fNewPlayerPosY - 1f))))
                {
                    fNewPlayerPosY = (int)fNewPlayerPosY;
                    fPlayerVelY = 0;
                    if(!bPlayerOnGround)
                        Frame(0);
                    
                    bPlayerOnGround = true;                    
                }
            }
            
            fPlayerPosX = fNewPlayerPosX;
            fPlayerPosY = fNewPlayerPosY;

            mainSprite.Display(map.g);
            return verificar;
        }

        private void CheckPicks(Map map, float fNewPlayerPosX, float fNewPlayerPosY,char c, char c2)
        {
            // Check for pickups!
            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f) == c)
                map.SetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.0f) == c)
                map.SetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f) == c)
                map.SetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f, c2);

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 1.0f) == c)
                map.SetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 1.0f, c2);
           
        }
        private static void CheckFinish(Map map, float fNewPlayerPosX, float fNewPlayerPosY)
        {
            // Check for finish line
            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f) == '6')
            {
                MessageBox.Show("Ganaste", "Finish the game", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                Environment.Exit(0);
            }
            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.0f) == '6')
            {
                MessageBox.Show("Ganaste", "Finish the game", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                Environment.Exit(0);
            }

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f) == '6')
            {
                MessageBox.Show("Ganaste", "Finish the game", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                Environment.Exit(0);
            }

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 1.0f) == '6')
            {
                MessageBox.Show("Ganaste", "Finish the game", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                Environment.Exit(0);
            }

        }
        private void CheckManzana(Map map, float fNewPlayerPosX, float fNewPlayerPosY, char c, char c2)
        {
            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f) == c)
            {
                if(vidas < 3)
                    vidas++;
                map.SetTileM(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 0.0f, c2);
            }
                

            if (map.GetTile(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.0f) == c)
            {
                if (vidas < 3)
                    vidas++;
                map.SetTileM(fNewPlayerPosX + 0.0f, fNewPlayerPosY + 1.0f, c2);
            }
                

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f) == c)
            {
                if (vidas < 3)
                    vidas++;
                map.SetTileM(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 0.0f, c2);
            }
                

            if (map.GetTile(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 1.0f) == c)
            {
                if (vidas < 3)
                    vidas++;
                map.SetTileM(fNewPlayerPosX + 1.0f, fNewPlayerPosY + 1.0f, c2);
            }
                           
        }
        public void Reset()
        {      
            fPlayerPosX = 0.0f;
            fPlayerPosY = 0.0f;
            fPlayerVelX = 0.0f;
            fPlayerVelY = 0.0f;
        }
    }
}
