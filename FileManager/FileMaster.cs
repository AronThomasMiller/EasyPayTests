using System.IO;

namespace FileManager
{
    public class FileMaster
    {
        public static string GetAllTextFromFile(string pathToFile)
        {
            string data;
            var sr = new StreamReader(pathToFile);//using(StreamReader sr = new StreamReader(pathToFile))

            try
            {//{
                data = sr.ReadToEnd();
            }//}
            finally
            {
                sr.Dispose();
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
