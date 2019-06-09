using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary
{
    public class Api
    {
        private readonly string location;
        private readonly string dataPlace;
        public string Url { get; }

        public Api(string url, string path)
        {
            location = path;
            dataPlace = $"{location}\\Data\\";
            Url = url;
        }

        public List<T> GetFileDataFromAPI<T>(string name) where T : Post
        {
            var jsonString = Post.FromJsonFile(dataPlace + name);
            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }

        public void WriteToApiDataFile(string pathToFile, string nameOfFile, string format)
        {
            var pathOfInput = $"{pathToFile}{nameOfFile}.{format}";
            string data;
            using (StreamReader sw = new StreamReader(pathOfInput, true))
            {
                data = sw.ReadToEnd();
            }

            var pathOfOutput = $"{dataPlace}{nameOfFile}.{format}";
            using (var fileStream = File.Open(pathOfOutput, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(pathOfOutput, true))
                {
                    sw.Write(data);
                }
            }
        }
    }
}
