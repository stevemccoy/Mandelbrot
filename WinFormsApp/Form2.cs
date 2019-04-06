using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using csdnfcalclib;

namespace WinFormsApp
{
    public partial class Form2 : Form
    {
        private Bitmap b = new Bitmap(1600, 900);
        MandelEngine engine = new MandelEngine(1000);

        public Form2()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var request = new CalcRequest(
                new Complex(-2.0, -1.25),
                new Complex(0.5, 1.25),
                e.ClipRectangle.Width,
                e.ClipRectangle.Height);

            var result = engine.Render(request);
            e.Graphics.DrawImage(result.Image, new Point(0, 0));
        }
    }
}
