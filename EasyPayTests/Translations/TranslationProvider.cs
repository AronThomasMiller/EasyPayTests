using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary.Translations
{
    class TranslationProvider
    {
        public static TranslationValues GetTranslation(string langCode)
        {
            var x = Assembly.GetExecutingAssembly().Location;
            var info = new FileInfo(x);         
            var dir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            var dictionaryFile = new FileInfo(dir + $"\\Translations\\dictionaries\\dict.{langCode}.json");

            if (dictionaryFile.Exists)
            {               
                Dictionary<string, string> text;

                using (StreamReader sr = new StreamReader(Convert.ToString(dictionaryFile), Encoding.UTF8))
                {
                    string json = sr.ReadToEnd();
                    text = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                }

                var t = new TranslationValues();
                Type myType = t.GetType();
                var props = myType.GetFields();

                foreach (var prop in props)
                {
                    foreach (var k in text)
                    {
                        if (prop.Name == k.Key)
                        {
                            prop.SetValue(t, k.Value);
                        }
                    }
                }
                return t;
            }
            else
            {
                throw new FileNotFoundException(dictionaryFile.FullName);
            }
            
        }
    }
}
