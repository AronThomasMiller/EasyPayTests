using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPayLibrary
{
    public abstract class BaseTable<T>:BasePageObject where T:BaseRow
    {
        public List<T> Rows { get; set; }

        public T FirstRow => Rows.First();
        public T LastRow => Rows.Last();

        public T this[int index]
        {
            get
            {
                return Rows[index];
            }
        }
    }
}
