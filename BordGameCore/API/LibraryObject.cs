using System;
using System.Reflection;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Core;

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
                if (item.IsSubclassOf(typeof(Game))) {
                    LibType = LibraryType.Game;
                    ID = ((BordGameAttribute) Attribute.GetCustomAttribute(item, typeof(BordGameAttribute))).GameID;
                    break;
                }


            }



        }

    }
}
