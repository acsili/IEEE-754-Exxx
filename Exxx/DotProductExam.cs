using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exxx
{
    internal class DotProductExam
    {
        public static double NaiveDotProduct(List<double> x, List<double> y)
        {
            double d = 0.0;
            for (var i = 0; i < x.Count; i++)
            {
                d += x[i] * y[i];
            }

            return d;
        }

        public static double NaiveFmaDotProduct(List<double> x, List<double> y)
        {
            double d = 0.0;
            for (var i = 0; i < x.Count; i++)
            {
                d = Math.FusedMultiplyAdd(x[i], y[i], d);
            }

            return d;
        }

        public static double TwoProduct(ref double t, double a, double b)
        {
            double p = a * b;
            t = Math.FusedMultiplyAdd(a, b, -p);  // t = a*b-p
            return p;
        }

        public static double TwoSum(ref double t, double a, double b)
        {
            double s = a + b;
            double bs = s - a;
            double a_s = s - bs;
            t = (b - bs) + (a - a_s);
            return s;
        }

        public static double OgitaRumpOishiDotProduct(List<double> x, List<double> y)
        {
            double s = 0.0, c = 0.0, p, pi = 0.0, t = 0.0;
            for (int i = 0; i < x.Count(); ++i)
            {
                p = TwoProduct(ref pi, x[i], y[i]);  
                s = TwoSum(ref t, s, p);   
                c += pi + t;   
            }
            return s + c;	
        }

        public static double Ulp(double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            var nextValue = BitConverter.Int64BitsToDouble(bits + 1);
            return nextValue - value;
        }

        public static double AbsoluteError(double x, double x_exact)
        {
            return Math.Abs(x - x_exact);
        }

        public static double RelativeError(double x, double x_exact)
        {
            return Math.Abs(x - x_exact) / Math.Abs(x_exact) * 100;
        }

        public static double UlpError(double x, double x_exact)
        {
            return Math.Abs(x - x_exact) / Ulp(x_exact);
        }

        public static string ToBinary(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            string binary = "";
            for (int i = bytes.Length - 1; i >= 0; i--)
            {
                binary += Convert.ToString(bytes[i], 2).PadLeft(8, '0');
            }
            return binary;
        }

        public static float FromBinary(string binaryString)
        {
            var intValue = Convert.ToInt32(binaryString, 2);
            return BitConverter.ToSingle(BitConverter.GetBytes(intValue), 0);
        }

    }
}
