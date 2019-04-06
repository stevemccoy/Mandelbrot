using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;

namespace csdnfcalclib
{
    public class MandelEngine
    {
        public const int NumColors = 256;

        public MandelEngine(int maxCount)
        {
            MaxCount = maxCount;
            SetupColors();
        }

        public int MaxCount { get; set; }

        private readonly Random myRandom = new Random(DateTime.UtcNow.Millisecond * 1000 + DateTime.UtcNow.Second);
        private Color[] colors;

        public CalcResult Render(CalcRequest request)
        {
            var image = new Bitmap(request.RealSteps, request.ImagSteps, PixelFormat.Format24bppRgb);
            ClearBitmap(image);

            var dx = (request.ToCorner.Real - request.FromCorner.Real) / request.RealSteps;
            var dy = (request.ToCorner.Imaginary - request.FromCorner.Imaginary) / request.ImagSteps;

            double x;
            double y;
            int count;

            for (int gx = 0; gx < request.RealSteps; gx++)
            {
                x = request.FromCorner.Real + gx * dx;
                for (int gy = 0; gy < request.ImagSteps; gy++)
                {
                    y = request.FromCorner.Imaginary + gy * dy;

                    count = ComputeCount(new Complex(x, y));
                    image.SetPixel(gx, gy, colors[count % NumColors]);
                }
            }

            var result = new CalcResult
            {
                Image = image
            };

            return result;
        }

        public int ComputeCount(Complex c)
        {
            var z = new Complex(c.Real, c.Imaginary);
            for (var count = 1; count < MaxCount; count++)
            {
                z = z * z + c;
                if (Divergent(z))
                {
                    return count;
                }

            }

            return MaxCount;
        }

        private bool Divergent(Complex z)
        {
            return (z.Magnitude >= 2.0);
        }

        private void SetupColors()
        {
            var colorMap = new Color[NumColors];
            colorMap[0] = Color.FromArgb(0, 0, 0);
            colorMap[MaxCount % NumColors] = Color.FromArgb(0, 0, 0);
            for (var i = 1; i < NumColors; i++)
            {
                var r = myRandom.Next() % 256;
                var g = myRandom.Next() % 256;
                var b = myRandom.Next() % 256;
                colorMap[i] = Color.FromArgb(r, g, b);
            }
            this.colors = colorMap;
        }

        private void ClearBitmap(Bitmap b)
        {
            for (int i = 0; i < b.Width; i++)
            {
                for (int j = 0; j < b.Height; j++)
                {
                    b.SetPixel(i, j, Color.Black);
                }
            }
        }
    }
}
