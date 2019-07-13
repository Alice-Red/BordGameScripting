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
            var libs = new List<LibraryObject>();
            if (File.Exists(fullPath)) {
                libs.Add(LoadFile(fullPath));
            } else if (Directory.Exists(fullPath)) {
                libs = libs.Concat(LoadFolder(fullPath)).ToList();
            } else {
                throw new System.IO.DirectoryNotFoundException();
            }
            Libs = libs.ToArray();

        }

        public Assembly[] Games => Libs.Where(s => s.LibType == LibraryType.Game).Select(s => s.Asm).ToArray();

        public Assembly[] Inputters => Libs.Where(s => s.LibType == LibraryType.Inputter).Select(s => s.Asm).ToArray();

        public Assembly[] Inpuuters(string id) => Libs.Where(s => s.LibType == LibraryType.Inputter).Where(s => s.ID == id).Select(s => s.Asm).ToArray();

        public static LibraryObject LoadFile(string file) {
            if (!File.Exists(file))
                throw new System.IO.FileNotFoundException();

            return new LibraryObject(file);
        }

        public static LibraryObject[] LoadFolder(string folder) {
            if (!Directory.Exists(folder))
                throw new System.IO.DirectoryNotFoundException();
            var libs = System.IO.Directory.GetFiles(folder, "*.dll", System.IO.SearchOption.AllDirectories);
            List<LibraryObject> tmp = new List<LibraryObject>();
            foreach (var item in libs) {
                tmp.Add(LoadFile(item));
            }
            return tmp.ToArray();
        }

    }
}
