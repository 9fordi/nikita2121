using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prs.appdata
{
    internal class Class1
    {
        public static TestEntities c;
        public static TestEntities context
        {
            get
            {
                if (c == null)
                    c = new TestEntities();
                return c;
            }
        }
    }
}
