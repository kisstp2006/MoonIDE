using System.IO;


namespace MoonIDE.Lua
{
    public static class IO
    {
        public static class JSON
        {
            public static string Serialize(object obj)
            {
                return System.Text.Json.JsonSerializer.Serialize(obj);
            }

            public static T Deserialize<T>(string json)
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
        }
        public static class File 
        { 
        
        
        }

    }
}
