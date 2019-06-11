using HttpLibrary.Containers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary.Containers
{
    public class Post: BasePost
    {
        public string Id { get; set; }
        public float Rate { get; set; }

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
