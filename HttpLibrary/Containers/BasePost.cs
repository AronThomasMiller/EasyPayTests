using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary.Containers
{
    public class BasePost
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is BasePost cast)
            {
                return (cast.Text == Text) && (cast.Title == Title);
            }
            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = 1475640943;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
            return hashCode;
        }
    }
}
