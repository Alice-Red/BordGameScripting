using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BordGameCore.API
{

    [AttributeUsage(AttributeTargets.Class)]
    public class BordGameAttribute : Attribute
    {
        public string ModID { get; set; }

        public BordGameAttribute(string modid) {
            ModID = modid;
        }
    }
}
