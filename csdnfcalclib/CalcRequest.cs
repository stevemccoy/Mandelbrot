using System.Numerics;

namespace csdnfcalclib
{
    public class CalcRequest
    {
        public CalcRequest(Complex fromCorner, Complex toCorner, int realSteps, int imagSteps)
        {
            FromCorner = fromCorner;
            ToCorner = toCorner;
            RealSteps = realSteps;
            ImagSteps = imagSteps;
        }

        public Complex FromCorner { get; set; }

        public Complex ToCorner { get; set; }

        public int RealSteps { get; set; }

        public int ImagSteps { get; set; }
    }
}
