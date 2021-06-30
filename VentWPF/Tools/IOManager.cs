using System.IO;
using System.Text.Json;

namespace VentWPF.Tools
{
    public static class IOManager
    {
        public static T LoadAsJson<T>(T o,string path)
                    => o=(T)JsonSerializer.Deserialize(File.ReadAllText(path), typeof(T));

        public static  void SaveAsJson<T>(T o,string path)
                    => File.WriteAllText(path, JsonSerializer.Serialize(o));

        public static T LoadAsJson<T>(string path) where T : new()
        {
            T o = new T();
            return o=(T)JsonSerializer.Deserialize(File.ReadAllText(path), typeof(T));
        }
    }
}