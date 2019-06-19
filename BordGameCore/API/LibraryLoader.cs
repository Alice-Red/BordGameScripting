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

        public Assembly[] Games => Libs.Where(s=>s.LibType == LibraryType.Game).Select(s=>s.Get)

        public static LibraryObject LoadFile(string file) {
            if (!File.Exists(file))
                throw new System.IO.FileNotFoundException();



        }

        public static LibraryObject[] LoadFolder(string folder) {
            if (!Directory.Exists(folder))
                throw new System.IO.DirectoryNotFoundException();



        }

    }
}
