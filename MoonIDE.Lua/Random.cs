using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonIDE.Lua
{
    public static class Random
    {
        static public double NextDouble()
        {
            return new System.Random().NextDouble();
        }
        static public int Next(int minValue, int maxValue)
        {
            if (minValue == maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue should not be equal maxValue.");
                return 0;
            }

            if (minValue >= maxValue)
            {
                throw new ArgumentOutOfRangeException("minValue must be less than maxValue.");
                return 0;
            }
            return new System.Random().Next(minValue, maxValue);
        }
        static public int Next(int maxValue)
        {
            if (maxValue <= 0)
            {
                throw new ArgumentOutOfRangeException("maxValue must be greater than 0.");
                return 0;
            }
            return new System.Random().Next(maxValue);
        }
        static public int Next()
        {
            return new System.Random().Next();
        }
        static public void NextBytes(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer), "Buffer cannot be null.");
            if (buffer.Length == 0)
                throw new ArgumentException("Buffer must have a length greater than 0.", nameof(buffer));
            
            new System.Random().NextBytes(buffer);
        }
    }
}
