using FileManager;
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
        public readonly string DataPlace;
        public readonly string Url;

        public Api(string url, string path)
        {
            location = path;
            DataPlace = $"{location}\\Data";
            Url = url;
        }

        public List<T> GetFileDataFromAPI<T>(string name) where T : class
        {
            var jsonString = FileMaster.GetAllTextFromFile($"{DataPlace}\\{name}");
            return JsonConvert.DeserializeObject<List<T>>(jsonString);
        }

        public void WriteToApiDataFile(string pathToFile, string name, string format)
        {
            var pathOfInput = $"{pathToFile}\\{name}.{format}";
            var pathOfOutput = $"{DataPlace}\\{name}.{format}";
            DeleteDataFile($"{name}.{ format}");
            File.Copy(pathOfInput, pathOfOutput);
        }

        public void DeleteDataFile(string name)
        {
            var pathToFile = $"{DataPlace}\\{name}";
            FileMaster.DeleteFile(pathToFile);
        }
    }
}
