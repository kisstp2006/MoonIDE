using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoonIDE.Lua
{
    public static class Debug
    {
        public static List<string> LogedMessages { get; private set; } = new List<string>();
        public static void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}][LOG] {message}");
            LogedMessages.Add($"[{DateTime.Now:HH:mm:ss}][LOG] {message}");
            Console.ResetColor();
        }

        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}][WARNING] {message}");
            LogedMessages.Add($"[{DateTime.Now:HH:mm:ss}][WARNING] {message}");
            Console.ResetColor();
        }

        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}][ERROR] {message}");
            LogedMessages.Add($"[{DateTime.Now:HH:mm:ss}][ERROR] {message}");
            Console.ResetColor();
        }
        public static void ClearLog()
        {
            LogedMessages.Clear();
            Console.Clear();
            Console.WriteLine("Console log cleared.");
        }
        public static List<string> GetLogedMessages()
        {
            return new List<string>(LogedMessages);
        }
    }
}
