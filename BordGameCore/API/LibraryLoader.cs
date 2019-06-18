using System;
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

            }

        }

        public static LibraryObject LoadFile(string file) {

        }

        public static LibraryObject[] LoadFolder(string folder) {

        }

    }
}
