using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;

namespace FLAHSHSHSH_AAAAA
{
    public partial class Form1 : Form
    {
        private bool _init;

        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
            serialPort1.Write("b");
            init();
            

            Thread t = new Thread(init);
            _init = true;
            t.Start();
        }

        static Color GetColor(int x, int y)
        {
            Bitmap bmp = new Bitmap(1, 1);
            Rectangle bounds = new Rectangle(x, y, 1, 1);
            using (Graphics g = Graphics.FromImage(bmp))
                g.CopyFromScreen(bounds.Location, System.Drawing.Point.Empty, bounds.Size);
            var color = bmp.GetPixel(0, 0);
            return color;

        }

        public void init()
        {
            while (_init)
            {
                Point p = Cursor.Position;
                Color pixel = GetColor(p.X, p.Y);
                if (pixel.GetBrightness() >= 0.98)
                {
                    serialPort1.Write("a");
                    Console.WriteLine("ON");
                }
                else
                {
                    serialPort1.Write("b");
                    Console.WriteLine("OFF");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
