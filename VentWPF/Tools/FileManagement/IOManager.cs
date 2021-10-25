using Newtonsoft.Json;
using System.IO;

namespace VentWPF.Tools
{
    /// <summary>
    /// Класс отвечающий за работу с файлами приложения
    /// </summary>
    public static class IOManager
    {

        private static JsonSerializerSettings jsonS = new()
        {
            ContractResolver = new WritablePropertiesOnlyResolver(),
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented,
        };

        public static void SaveAsJson<T>(T o, string path)
        {
            _ = File.WriteAllTextAsync(path, JsonConvert.SerializeObject(o, typeof(T), jsonS));
        }

        public static T LoadAsJson<T>(string path) where T : new()
        {
            try
            {
                return (T)JsonConvert.DeserializeObject(File.ReadAllText(path), jsonS);
            }
            catch
            {
                return new T();
            }
        }

    }
}