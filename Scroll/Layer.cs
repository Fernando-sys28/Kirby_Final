using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Scroll
{
    public class Layer
    {
        public Sprite sprite;
        public Layer(Size original, Size display, Point starting, int increment, Bitmap right)
        {
            sprite = new Sprite(original, display, starting, increment, right);
        }
        public void Display(Graphics g)
        {
            sprite.Display(g);
        }
    }
}
