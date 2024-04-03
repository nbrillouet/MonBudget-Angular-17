using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Budget.SERVICE
{
    public static class JsonReader
    {
        public static List<T> Read<T>(string jsonFilename)
        {
            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "datas", "Json", $"{jsonFilename}.json");
            var file = File.ReadAllText(filepath);

            JArray jArray = JArray.Parse(file);
            var result = jArray.ToObject<List<T>>();

            return result;
        }
    }
}
