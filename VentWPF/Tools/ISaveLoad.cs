using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace VentWPF.Tools
{
    
    interface ISaveLoad
    {

        void Save(string Path) 
            => File.WriteAllText(Path, JsonSerializer.Serialize(this));

        void Load(string Path) 
            => JsonSerializer.Deserialize(File.ReadAllText(Path), this.GetType());
    }
}
