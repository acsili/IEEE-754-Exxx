using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exxx
{
    internal class HornerAlgorithmExam
    {
        public static (double, double) HornerAlgorithm(double[] a, double x)
        {
            var n = a.Length - 1;
            var r = a[n];
            var s = Math.Abs(a[n - 1]) / 2;
            for (int i = n - 1; i > 0; i--)
            {
                r = r * x + a[i];
                s = s * Math.Abs(x) + Math.Abs(r);
            }
            r = r * x + a[0];
            var b = 2 * (s * Math.Abs(x) + Math.Abs(r));
            b = U * b / (1 - (2 * (n - 1) - 1) * U);
            return (r, b);
        }

        public static double PolynomialValue(double[] a, double x)
        {
            var n = a.Length - 1;
            double result = a[n];
            for (int i = n; i > 0; i--)
            {
                result = result * x + a[i - 1];
            }
            return result;
        }

        public static double Ulp(double value)
        {
            var bits = BitConverter.DoubleToInt64Bits(value);
            var nextValue = BitConverter.Int64BitsToDouble(bits + 1);
            return nextValue - value;
        }

        public static double U = Ulp(1.0) / 2.0;

        public static byte[] Bytes(string path) => File.ReadAllBytes(path);

        public static double[] ToArrayOfDouble(byte[] buffer)
        {
            var arr = Enumerable.Range(0, buffer.Length / 8).ToArray();
            var list = new List<double>();
            foreach (var a in arr)
            {
                list.Add(BitConverter.ToDouble(buffer, a * 8));
            }
            return list.ToArray();
        }

        public static (double[], double[]) CoefficientsAndArgsLittleEnding(double[] arr)
        {
            var n = arr.Length;
            var arguments = new List<double>();
            var coefficients = new List<double>();
            for (int i = 0; i < n; i++)
            {
                if (i <= n - 4)
                {
                    coefficients.Add(arr[i]);
                }
                else
                {
                    arguments.Add(arr[i]);
                }
            }
            return (arguments.ToArray(), coefficients.ToArray());
        }


        public static (double[], double[]) CoefficientsAndArgsBigEnding(double[] arr)
        {
            var n = arr.Length;
            var arguments = new List<double>();
            var coefficients = new List<double>();
            Array.Reverse(arr);
            for (int i = 0; i < n; i++)
            {
                if (i <= n - 2)
                {
                    coefficients.Add(arr[i]);
                }
                else
                {
                    arguments.Add(arr[i]);
                }
            }
            return (arguments.ToArray(), coefficients.ToArray());
        }
        public static double AprioriError(double[] a, double x)
        {
            double w = 2.0;  
            double b = 10.0;
            double u = Ulp(1.0);

            double bound = 1.0 / 2.0 * (Math.Sqrt(w / b) * Math.Pow(u, -0.5) - 1);

            int n = a.Length;
            double e = a[n - 1];
            if (n < bound)
            {
                for (int i = 1; i < n; i++)
                {
                    e = e * Math.Abs(x) + Math.Abs(a[i]);
                }
                e = 2 * (n - 1) * U * e;
            }
            else
            {
                for (int i = 1; i < n; i++)
                {
                    e = e * Math.Abs(x) + Math.Abs(a[i]);
                }
                e = 2 * (n - 1) * U / (1 - 2 * (n - 1) * U) * e;
            }
            return e;
        }

        /*public static double AprioriError(double[] a, double x)
        {
            int n = a.Length;
            double e = a[n - 1];
            for (int i = 1; i < n; i++)
            {
                e = e * Math.Abs(x) + Math.Abs(a[i]);
            }
            e = 2 * (n - 1) * U / (1 - 2 * (n - 1) * U) * e;
            return e;
        }*/

        public static double PosterioriError(double[] a, double x)
        {
            var n = a.Length - 1;
            double r = a[n];
            double s = Math.Abs(a[n] / 2);

            for (int i = n; i > 1; i--)
            {
                r = r * x + a[i - 1];
                s = s * Math.Abs(x) + Math.Abs(r);
            }
            r = r * x + a[0];
            double p = 2 * (s * Math.Abs(x)) + Math.Abs(r);
            p = U * (p / (1 - (2 * n) * U));
            return p;
        }


        /*public static double PosterioriError(double[] a, double x)
        {
            var n = a.Length - 1;
            var p = a[n - 1];
            var m = Math.Abs(a[n - 1]) / 2.0;
            for (int i = 0; i < n; i++)
            {
                p = p * x + a[i];
                m = m * Math.Abs(x) + Math.Abs(p);
            }
            m = Ulp(2.0 * m - Math.Abs(p));
            return m;
        }*/
    }
}
