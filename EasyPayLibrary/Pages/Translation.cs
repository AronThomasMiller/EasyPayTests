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
            Dictionary<string,string> dicter;
            using (StreamReader sr = new StreamReader("E:\\dict.json", Encoding.UTF8))
            {
                string json = sr.ReadToEnd();
                dicter = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
            }
            return dicter;          
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
                if(k.Value.ToLower() == attributeToCheck.ToLower())
                {
                    return true;
                }                
            }
            return false;
        }
    }
}
