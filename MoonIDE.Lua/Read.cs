using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonIDE.Lua
{
    public static class Read
    {
        public static string ReadLine()
        {
            string input = Console.ReadLine();
            return input ?? string.Empty;
        }
        public static string ReadKey()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            return keyInfo.KeyChar.ToString();
        }
    }
}
