using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary.Containers
{
    public class CommentInfo : CommentBase
    {
        public string Id { get; set; }
        public string CommentedBy { get; set; }
    }
}
