using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace MoonIDE.Lua.Extensions
{
    public class ExtensionLoader
    {
        string path = AppContext.BaseDirectory+"Extensions";
        public ExtensionLoader()
        {
            
        }
        public void LoadExtensions()
        {
            Debug.Log("Lua Interpreter is loading the extensions");
            Debug.Log("Extensions folder: "+path);
            if (!System.IO.Directory.Exists(path))
            {
                Debug.Error("Extensions folder does not exist: " + path);
                return;
            }
        }

    }
}
