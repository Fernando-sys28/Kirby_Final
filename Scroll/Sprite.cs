using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Scroll
{
    public class Sprite
    {
        int increment;
        RectangleF size, display;
        Bitmap imgDisplay, imgL, imgR;
        public int counter;
        Point pos;
        public int imagen { get; set; }

        public float posX
        {
            get { return display.X; }
            set { display.X = value; }
        }

        public float posY
        {
            get { return display.Y; }
            set { display.Y = value; }
        }

        public Bitmap ImgDisplay
        {
            get { return imgDisplay; }
            set { imgDisplay = value; }
        }
        public Sprite(Size original, Size display, Point starting, int increment, Bitmap right)
        {
            counter = 0;
            pos = starting;
            this.increment = increment;
            this.display = new Rectangle(starting.X, starting.Y, display.Width, display.Height);
            this.size = new Rectangle(0, 0, original.Width, original.Height);
            this.imgR = right;
            this.imgDisplay = right;
            imagen = 0;
        }
        public Sprite(Size original, Size display, Point starting, Bitmap right, Bitmap left)
        {
            counter = 0;
            this.increment = original.Width;
            this.display = new RectangleF(starting.X, starting.Y, display.Width, display.Height);
            this.size = new RectangleF(0, 0, original.Width, original.Height);
            this.imgR = right;
            this.imgL = left;
            this.imgDisplay = right;
        }

        public Sprite(Size original, Size display, Point starting, Bitmap right)
        {
            counter = 0;
            pos = starting;
            this.increment = original.Width;
            this.display = new Rectangle(starting.X, starting.Y, display.Width, display.Height);
            this.size = new Rectangle(0, 0, original.Width, original.Height);
            this.imgR = right;
            this.imgDisplay = right;

        }
        public void Position(int x, int y)
        {
            size.X = x;
            size.Y = y;
        }

        public void Frame(int x)
        {
            size.X = (x * size.Width) % (-imagen + imgDisplay.Width);
        }

        public void MoveLeft()
        {
            imgDisplay = imgL;
            size.X = (increment + size.X) % (-imagen + imgDisplay.Width);
        }
        public void MoveLeftE()
        {
            imgDisplay = imgR;
            size.X = (increment + size.X) % (-imagen + imgDisplay.Width);
        }
        public void MoveRight()
        {
            imgDisplay = imgR;
            size.X = (increment + size.X) % (-imagen + imgDisplay.Width);
        }
        public void MoveSlow(int value)
        {
            if (counter % value == 0)
                size.X = (increment + size.X) % (-imagen + imgDisplay.Width);

            counter++;
        }

        public void Display(Graphics g)//
        {
            if (display.Y < pos.Y)
                display.Y += 10;

            g.DrawImage(imgDisplay, display, size, GraphicsUnit.Pixel);
        }
    }
}
