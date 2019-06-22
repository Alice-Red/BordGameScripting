using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RUtil;

namespace GameLib.API
{
    public class LibraryLoader
    {
        public LibraryObject[] Libs { get; }

        public LibraryLoader(string path) {
            var fullPath = Path.GetFullPath(path);
            if (File.Exists(fullPath)) {
                Libs.Add(LoadFile(fullPath));
            } else if (Directory.Exists(fullPath)) {
                Libs.Concat(LoadFolder(fullPath));
            } else {
                throw new System.IO.DirectoryNotFoundException();
            }

        }

        public Assembly[] Games => Libs.Where(s=>s.LibType == LibraryType.Game).Select(s=>s)

        public static LibraryObject LoadFile(string file) {
            if (!File.Exists(file))
                throw new System.IO.FileNotFoundException();

            var t = new LibraryObject(file);



            //assembly = Assembly.LoadFrom(path);
            //var types = assembly.GetExportedTypes();

            //staticMethods = new Dictionary<string, MethodInfo>[types.Length];

            //for (int i = 0; i < types.Length; i++) {

            //    //Console.WriteLine(types[i].Name + ":" + types[i].IsAbstract);

            //    staticMethods[i] = new Dictionary<string, MethodInfo>();
            //    foreach (var method in types[i].GetMethods()) {
            //        // static関数回収
            //        if (method.IsStatic) {
            //            string tmpKey = types[i].ToString() + "." + method.Name;
            //            if (!staticMethods[i].ContainsKey(tmpKey)) {
            //                staticMethods[i].Add(tmpKey, method);
            //            }
            //        }
            //    }
            //}



        }

        public static LibraryObject[] LoadFolder(string folder) {
            if (!Directory.Exists(folder))
                throw new System.IO.DirectoryNotFoundException();



        }

    }
}
