using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarPract6.ViewModel.Helpers
{
    internal class SerDeser
    {
        public static void Serialize<T>(T getdata, string filename)
        {
            string path = Environment.CurrentDirectory;
            string json = JsonConvert.SerializeObject(getdata);

            File.WriteAllText(path.Remove(path.Length - 10) + filename, json);
        }
        public static T Deserialize<T>(string filename)
        {
            string path = Environment.CurrentDirectory;
            string json = File.ReadAllText(path.Remove(path.Length - 10) + filename);

            T getdata = JsonConvert.DeserializeObject<T>(json);
            return getdata;
        }
    }
}
