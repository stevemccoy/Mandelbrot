using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private const int NumColors = 256;
        private const int MaxCount = 10000;

        private readonly Random _myRandom = new Random(DateTime.UtcNow.Millisecond * 1000 + DateTime.UtcNow.Second);
        private Color[] _colors;
        Bitmap _myBitmap;

        public Form1()
        {
            InitializeComponent();
            SetupColors();
        }

        public void SetMessage(string message) => Text = message;

        private void SetupColors()
        {
            var colors = new Color[NumColors];
            colors[0] = Color.FromArgb(0, 0, 0);
            colors[MaxCount % NumColors] = Color.FromArgb(0, 0, 0);
            for (var i = 1; i < NumColors; i++)
            {
                var r = _myRandom.Next() % 256;
                var g = _myRandom.Next() % 256;
                var b = _myRandom.Next() % 256;
                colors[i] = Color.FromArgb(r, g, b);
            }
            _colors = colors;
        }

        private void SetupImage()
        {
            _myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format24bppRgb);
            ColourImage();
            pictureBox1.Image = _myBitmap;
        }

        private void ColourImage()
        {
            Color c1 = Color.Green;
            for (int gx = 0; gx < _myBitmap.Width; gx++)
            {
                for (int gy = 0; gy < _myBitmap.Height; gy++)
                {
                    _myBitmap.SetPixel(gx, gy, c1);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupImage();
        }
    }
}
