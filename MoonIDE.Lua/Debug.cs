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
        public static event Action? LogUpdated;

        private static void LogMessage(string message, ConsoleColor color, string prefix)
        {
            string formattedMessage = $"[{DateTime.Now:HH:mm:ss}][{prefix}] {message}";
            Console.ForegroundColor = color;
            Console.WriteLine(formattedMessage);
            LogedMessages.Add(formattedMessage);
            Console.ResetColor();
            LogUpdated?.Invoke();
        }

        public static void Log(string message)
        {
            LogMessage(message, ConsoleColor.White, "LOG");
        }

        public static void Warning(string message)
        {
            LogMessage(message, ConsoleColor.Yellow, "WARNING");
        }

        public static void Error(string message)
        {
            LogMessage(message, ConsoleColor.Red, "ERROR");
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
