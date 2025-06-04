using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoonIDE.Lua;

namespace MoonIDE.Console
{
    internal class IDEConsoleHistory
    {
        List<string> history = new List<string>();

        void getHistory()
        {
            history = Debug.GetLogedMessages();
        }
    }
}
