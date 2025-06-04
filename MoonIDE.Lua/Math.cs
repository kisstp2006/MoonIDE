using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonIDE.Lua
{
    public static class Math
    {
        public const double Pi = System.Math.PI;
        public const double E = 2.718281828459045;

        public static double Abs(double value) => System.Math.Abs(value);
        public static double Acos(double value) => System.Math.Acos(value);
        public static double Asin(double value) => System.Math.Asin(value);
        public static double Atan(double value) => System.Math.Atan(value);
        public static double Atan2(double y, double x) => System.Math.Atan2(y, x);
        public static double Ceiling(double value) => System.Math.Ceiling(value);
        public static double Cos(double value) => System.Math.Cos(value);
        public static double Exp(double value) => System.Math.Exp(value);
        public static double Floor(double value) => System.Math.Floor(value);

        public static double Log(double value, double newBase = E) =>
            newBase == E ? System.Math.Log(value) : System.Math.Log(value, newBase);

        public static double Log10(double value) => System.Math.Log10(value);

        public static double Max(params double[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentException("At least one value must be provided.", nameof(values));
            return values.Max();
        }

        public static double Min(params double[] values)
        {
            if (values == null || values.Length == 0)
                throw new ArgumentException("At least one value must be provided.", nameof(values));
            return values.Min();
        }

        public static double Pow(double x, double y) => System.Math.Pow(x, y);

        public static double Round(double value, int digits = 0) =>
            digits == 0 ? System.Math.Round(value) : System.Math.Round(value, digits);

        public static double Sin(double value) => System.Math.Sin(value);

        public static double Sqrt(double value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be non-negative.");
            return System.Math.Sqrt(value);
        }

        public static double Tan(double value) => System.Math.Tan(value);
    }
}
