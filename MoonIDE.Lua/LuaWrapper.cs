using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonIDE.Lua
{
    internal class LuaWrapper
    {
        // Debug logging class implementation
        public class LuaDebugWrapper
        {
            public void Log(string message) => Debug.Log(message);
            public void Warning(string message) => Debug.Warning(message);
            public void Error(string message) => Debug.Error(message);

            public void ClearLog() => Debug.ClearLog();
            public List<string> GetLogedMessages() => Debug.GetLogedMessages();

            public string ReadLine() => Read.ReadLine();
            public string ReadKey() => Read.ReadKey();
        }

        public class LuaMathWrapper
        {
            public double Pi => Math.Pi;
            public double E => Math.E;

            public double Add(double value1, double value2)
            {
                return value1 + value2;
            }
            public double Div(double value1, double value2)
            {
                return value1 - value2;
            }
            public double Abs(double value) => Math.Abs(value);
            public double Acos(double value) => Math.Acos(value);
            public double Asin(double value) => Math.Asin(value);
            public double Atan(double value) => Math.Atan(value);
            public double Atan2(double y, double x) => Math.Atan2(y, x);
            public double Ceiling(double value) => Math.Ceiling(value);
            public double Cos(double value) => Math.Cos(value);
            public double Exp(double value) => Math.Exp(value);
            public double Floor(double value) => Math.Floor(value);
            public double Log(double value, double newBase = Math.E) => Math.Log(value, newBase);
            public double Log10(double value) => Math.Log10(value);
            public double Max(params double[] values) => Math.Max(values);
            public double Min(params double[] values) => Math.Min(values);
            public double Pow(double x, double y) => Math.Pow(x, y);
            public double Round(double value, int digits = 0) => Math.Round(value, digits);
            public double Sin(double value) => Math.Sin(value);
            public double Sqrt(double value) => Math.Sqrt(value);
            public double Tan(double value) => Math.Tan(value);
        }

        public class LuaRandomWrapper
        {
            public int Next(int minValue, int maxValue) => Random.Next(minValue, maxValue);
            public int Next(int maxValue) => Random.Next(maxValue);
            public int Next() => Random.Next();
            public void NextBytes(byte[] buffer) => Random.NextBytes(buffer);

        }
    }
}
