using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace PopAppShops.API
{
    public class TextFileManager<T>
    {
        string path;

        public TextFileManager(string path)
        {
            this.path = path;
        }

        public void SaveChanges(T data)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(JsonConvert.SerializeObject(data));
            }
        }

        public T RetreiveFiles()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    T data = JsonConvert.DeserializeObject<T>(line);
                    return data;
                }
            }
            else
            {
                return default(T);
            }
        }
        public string RetreiveFilesAsString()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    String line = sr.ReadToEnd();
                    return line;
                }
            }
            else
            {
                return "";
            }
        }
    }
}
