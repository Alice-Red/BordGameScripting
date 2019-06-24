using System;
using System.Reflection;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib.API
{

    public struct LibraryObject
    {
        public string ID { get; }

        public LibraryType LibType { get; }

        private Assembly assembly;

        public Assembly Asm {
            get {
                return assembly;
            }
        }

        public LibraryObject(string path) {
            ID = "";

            assembly = Assembly.LoadFrom(path);
            var types = assembly.GetExportedTypes();
            LibType = LibraryType.None;
            foreach (var item in types) {
                if (item.IsAssignableFrom(typeof(BordGameAttribute))) {
                    LibType = LibraryType.Game;
                    ID = ((BordGameAttribute) Attribute.GetCustomAttribute(item, typeof(BordGameAttribute))).GameID;
                    break;
                }

                if (item.IsAssignableFrom(typeof(InputterAttribute))) {
                    LibType = LibraryType.Game;
                    ID = ((BordGameAttribute) Attribute.GetCustomAttribute(item, typeof(BordGameAttribute))).GameID;
                    break;
                }


            }



        }

        //public MethodInfo Input {
        //    get {
        //        assembly.
        //    }

        //}
    }
}
