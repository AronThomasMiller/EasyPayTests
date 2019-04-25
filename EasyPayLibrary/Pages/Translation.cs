using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EasyPayLibrary.Pages
{
    public class Translation
    {
        public Dictionary<string,string> Deserialize()
        {
            //using (StreamWriter file = File.CreateText("dictionary.json"))
            //{
            //    var dict = new Dictionary<string, string>();
            //    dict.Add("Name", "Ім’я");
            //    dict.Add("Surname", "Прізвище");
            //    JsonSerializer formatter = new JsonSerializer();
            //    formatter.Serialize(file, dict);
            //}

            //var dict = new Dictionary<string, string>();
            //dict.Add("Name", "Ім’я");
            //dict.Add("Surname", "Прізвище");
            //string output = Newtonsoft.Json.JsonConvert.SerializeObject(dict, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText("E:\\dict.json", output);

            Dictionary<string,string> dicter;
            using (StreamReader sr = new StreamReader("E:\\dict.json", Encoding.UTF8))
            {
                string json = sr.ReadToEnd();
                dicter = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
            }
            return dicter;

            //using (StreamReader file = File.OpenText("dictionary.json"))
            //{
            //    JsonSerializer formatter = new JsonSerializer();
            //    Dictionary<string, string> dict = (Dictionary<string, string>)formatter.Deserialize(file, typeof(Dictionary<string, string>));
            //    return dict;
            //}
        }

        public bool CheckEN(string attributeToCheck)
        {
            var dict = Deserialize();
            foreach (var k in dict)
            {
                if ((k.Key).ToLower() == attributeToCheck.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckUA(string attributeToCheck)
        {
            var dict = Deserialize();
            foreach (var k in dict)
            {
                if(k.Value.ToLower() == attributeToCheck)
                {
                    return true;
                }                
            }
            return false;
        }
    }
}
