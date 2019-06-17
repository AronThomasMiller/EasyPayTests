using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpLibrary.SOM
{
    public class BaseROM
    {
        protected BaseROM(string source)
        {
            this.resource = source;
        }

        protected ClientWrapper client;
        protected string resource;
    }
}
