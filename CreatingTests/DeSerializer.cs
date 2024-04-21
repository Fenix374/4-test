using Newtonsoft.Json;
using System;
using System.IO;

namespace CreatingTests
{
    public class DeSerializer
    {
        public static void Serialize<T>(T obj, string filePath)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(filePath, json);
        }

        public T Deserialize<T>(string filePath)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (File.Exists("tests.json"))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            else return default;
            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                    string json = File.ReadAllText(filePath);
                object obj = JsonConvert.DeserializeObject<T>(json + "\\" + "tests.json");
                return (T)obj;
            }
            else
            {
                return default;
            }

        }
    }

}