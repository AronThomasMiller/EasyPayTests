using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary
{
    public class Post
    {
        public string Id { get; set; }
        public float Rate { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Post cast)
            {
                return (cast.Id == Id);
            }
            else
            {
                return false;
            }
        }

        public static string FromJsonFile(string pathToFile)
        {
            string data;
            using (StreamReader sr = new StreamReader(pathToFile))
            {
                data = sr.ReadToEnd();
            }
            return data;
        }

        public override int GetHashCode()
        {
            var hashCode = -66575386;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + Rate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            return hashCode;
        }
    }
}
