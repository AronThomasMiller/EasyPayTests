using System.IO;

namespace FileManager
{
    public class FileMaster
    {
        public static string GetAllTextFromFile(string pathToFile)
        {
            string data;
            using (StreamReader sr = new StreamReader(pathToFile))
            {
                data = sr.ReadToEnd();
            }
            return data;
        }

        public static void DeleteFile(string pathToFile)
        {
            if (File.Exists(pathToFile))
            {
                File.Delete(pathToFile);
            }
        }
    }
}
