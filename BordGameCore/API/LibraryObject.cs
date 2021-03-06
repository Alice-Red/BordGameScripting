﻿using System;
using System.Reflection;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib.Core;
using RUtil;

namespace GameLib.API
{

    public class LibraryObject
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
                if (!item.IsAbstract && item.GetBaseTypes().Contains(typeof(Game))) {
                    LibType = LibraryType.Game;
                    ID = item.GetAttributeValue<GameAddonAttribute>().GameID;
                    //ID = ((GameAddonAttribute) Attribute.GetCustomAttribute(item, typeof(GameAddonAttribute))).GameID;
                    break;
                } else if (item.IsSubclassOf(typeof(IDrawer))) {
                    LibType = LibraryType.Other;
                    ID = item.GetAttributeValue<GameAddonAttribute>().GameID;

                } else if (!item.IsAbstract && item.GetBaseTypes().Contains(typeof(GameInputter))) {
                    LibType = LibraryType.Inputter;
                    ID = item.GetAttributeValue<GameAddonAttribute>().GameID;

                }


            }
        }

    }
}
