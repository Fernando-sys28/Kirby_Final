using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using System.Reflection.Emit;

namespace Scroll
{
    public partial class MAIN : Form
    {
        Map map;
        Map map2;
        Player player;

        float fElapsedTime;

        SoundPlayer sPlayer;
        SoundPlayer Ataque;
        SoundPlayer Suspirar;
        Thread thread, thread2, threadStop;
        bool isP1 = true;

        // Camera properties
        float fCameraPosX = 0.0f;
        float fCameraPosY = 0.0f;
        bool left, right, downbutton, kirbyjump, kirbyjumpleft, kirbyHit, succionar;
        Layer nubes;
        Layer nubes2;
        Layer background;
        Layer arbustos;
        bool verificar=false;
        public MAIN()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            
            player = new Player();
            map = new Map(PCT_CANVAS.Size);
            
            PCT_CANVAS.Image = map.bmp;
            fElapsedTime = 0.04f;
            left = false;
            right = false;
            sPlayer = new SoundPlayer(Resource1.kirby_dreamland);
            Ataque = new SoundPlayer(Resource1.golpe__1_);
            Suspirar = new SoundPlayer(Resource1.succionar);


            //--------------------------------------------------
            Size sizeSky = new Size(500, 270);
            Size vizSky = new Size(180, 90);

            nubes = new Layer(sizeSky, vizSky, new Point(),0, Resource1.nubes_1);

            //--------------------------------------------------
            Size sizeSky2 = new Size(500, 270);
            Size vizSky2 = new Size(180, 90);

            nubes2 = new Layer(sizeSky2, vizSky2, new Point(200, 0),0, Resource1.nubes2);

            //--------------------------------------------------
            Size sizefondo = new Size(672, 216);
            Size vizfondo = new Size(600, 400);

            background = new Layer(sizefondo, vizfondo, new Point(), 0, Resource1.Green_Greens);

            //--------------------------------------------------
            Size sizearbusto = new Size(825, 100);
            Size vizarbusto = new Size(600, 100);

            //arbustos = new Layer(sizearbusto, vizarbusto, new Point(0, 120), Resource1.layer_arbustos);
             Play();
        }

        public void Play()
        {
            thread = new Thread(PlayThread);
            thread.Start();
        }

        private void PlayThread()
        {
            while (true)
            {
                sPlayer.PlaySync();
            }
        }

        private void MAIN_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (!left)
                    {
                        left = true;
                        
                    }
                    break;
                case Keys.Right:
                    if (!right)
                    {
                        player.MainSprite.Position(0, 0);
                        
                        right = true;
                    }
                    
                    break;
                case Keys.Down:
                    if (!downbutton)
                    {
                        player.MainSprite.Position(0, 2120);
                        player.MainSprite.imagen = 2400;
                        downbutton = true;
                    }
                    break;
                
                case Keys.A:
                    if (!kirbyHit)
                    {
                        player.MainSprite.Position(0, 1060);
                        player.MainSprite.imagen = 480;
                        kirbyHit = true;
                        
                        //PlayAtaques();
                    }
                    break;
                case Keys.Space:

                    player.FPlayerVelY = -6f;
                    player.MainSprite.Position(0, 530);
                    player.MainSprite.imagen = 2400;
                    kirbyjump = true;
                    break;

                case Keys.Up:
                    if (player.FPlayerVelY == 0)// sin brincar o cayendo
                    {
                        player.FPlayerVelY = -10.0f;
                        player.MainSprite.Position(480, 0);
                        player.Frame(2);
                        player.bPlayerOnGround = false;
                        kirbyjump = true;
                    }
                    break;

                case Keys.S:
                    if (!succionar)
                    {
                        player.MainSprite.Position(480, 1590);
                        player.MainSprite.imagen = 1920;
                        player.bPlayerOnGround = false;
                        succionar = true;
                       // PlaySuspirar();
                    }
                    
                    break;

            }

            UpdateEnv();
        }

        private void MAIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void MAIN_KeyUp(object sender, KeyEventArgs e)
        {
       

            if (e.KeyCode == Keys.Right)
                right = false;

            if (e.KeyCode == Keys.Left)
            {
                left = false;
              
            }
            if (e.KeyCode == Keys.Down)
            {
                player.MainSprite.Position(0, 0);
                downbutton = false;
            }
            if (e.KeyCode == Keys.Space)
                return;
            if (e.KeyCode == Keys.Up)
                kirbyjump=false;
            if (e.KeyCode == Keys.A)
            {
                kirbyHit = false;
            }
                
            if (e.KeyCode == Keys.S)
            {
                player.MainSprite.Position(0, 0);
                succionar = false;
            }

            player.Stop();


        }

        private void MAIN_Load(object sender, EventArgs e)
        {

        }

        private void TIMER_Tick(object sender, EventArgs e)
        {
            UpdateEnv();
        }

        private void UpdateEnv()
        {
            if (left)
            {
                player.Left(fElapsedTime);
                //background.sprite.MoveLeft();
            }
                
            if (right)
            {
                player.Right(fElapsedTime);
               
            }
            if (downbutton || kirbyHit ||succionar)
            {
                
                player.Right(0);
                if (left)
                {
                    player.Left(0);
                }
            }
            fCameraPosX = player.fPlayerPosX;
            fCameraPosY = player.fPlayerPosY;

            background.Display(map.g);
            nubes.Display(map.g);
            nubes2.Display(map.g);
           
            map.Draw(new PointF(fCameraPosX, fCameraPosY), player.fPlayerPosX.ToString(), player);

            player.Update(fElapsedTime, map,kirbyHit,succionar);
            
            PCT_CANVAS.Invalidate();
        }

        public void PlayAtaques()
        {
            thread = new Thread(PlayThreadAtaques);
            thread.Start();
        }
        private void PlayThreadAtaques()
        {
            
            Ataque.PlaySync();
         
        }

        public void PlaySuspirar()
        {
            thread = new Thread(PlayThreadSus);
            thread.Start();
        }
        private void PlayThreadSus()
        {
            
            Suspirar.PlaySync();

        }
    }
}
