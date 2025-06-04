using MoonIDE.Lua;
using MoonSharp.Interpreter;
using static MoonIDE.Lua.LuaWrapper;

    namespace Program
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Initialize the Lua interpreter
                LuaInterpreter luaInterpreter = new LuaInterpreter();
                luaInterpreter.init();
                luaInterpreter.RegisterDefaultWrappers();
                // Execute a sample script or file
                if (args.Length > 0)
                {
                    luaInterpreter.ExecuteFile(args[0]);
                }
                else
                {
                    Console.WriteLine("No script file provided. Enter Lua code:");
                    string input = Console.ReadLine();
                    luaInterpreter.ExecuteScript(input);
                }
            }
        }
    }

    namespace MoonIDE.Lua
    {
    
        public  class LuaInterpreter
        {
            Script script;
            public LuaInterpreter()
            {
                // Initialize the Lua interpreter
                script = new Script();
            }

            public  void init() 
            { 
                Debug.Log("Lua Interpreter Initialized");
            }

            public void RegisterDefaultWrappers()
            {
                UserData.RegisterType<LuaDebugWrapper>();
                script.Globals["Debug"] = new LuaWrapper.LuaDebugWrapper();
                UserData.RegisterType<LuaMathWrapper>();
                script.Globals["Math"] = new LuaWrapper.LuaMathWrapper();
                UserData.RegisterType<LuaRandomWrapper>();
                script.Globals["Random"] = new LuaWrapper.LuaRandomWrapper();
        }

            public void ExecuteScript(string scriptContent)
            {
                try
                {
                    script.DoString(scriptContent);
                }
                catch (ScriptRuntimeException ex)
                {
                    Debug.Error($"Lua Runtime Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Debug.Error($"Unexpected Error: {ex.Message}");
                }
            }

            public void ExecuteFile(string filePath)
            {
                if (File.Exists(filePath))
                {
                    script.DoFile(filePath);
                }
                else
                {
                    Debug.Error($"File not found: {filePath}");
                }
            }

        }
    }