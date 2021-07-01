﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VentWPF.Tools
{
    public static class IOManager
    {
        public static T LoadAsJson<T>(T o, string path)
        {
            return o = (T)JsonConvert.DeserializeObject(File.ReadAllText(path), jsonS);
        }

        private static JsonSerializerSettings jsonS = new()
        {
            ContractResolver = new WritablePropertiesOnlyResolver(),
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented,
        };

        public static void SaveAsJson<T>(T o, string path)
        {
            File.WriteAllTextAsync(path, JsonConvert.SerializeObject(o, typeof(T), jsonS));
        }

        public static T LoadAsJson<T>(string path) where T : new()
        {
            return (T)JsonConvert.DeserializeObject(File.ReadAllText(path), jsonS);
        }
    }

    internal class WritablePropertiesOnlyResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            return props.Where(p => p.Writable).ToList();
        }
    }
}