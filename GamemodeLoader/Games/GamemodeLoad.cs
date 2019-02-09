using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GamemodeLoader.Utilities;
using System.Reflection;
using UnityEngine;

namespace GamemodeLoader.Games
{
    public class GamemodeLoad : MonoBehaviour
    {
        private List<Gamemode> loadedGames;

        public GamemodeLoad()
        {
            loadedGames = new List<Gamemode>();
            LoadPlugins();
        }

        internal void LoadPlugins()
        {
            foreach (string s in Directory.GetFiles(string.Format("Servers/{0}/Gamemodes/", Dedicator.serverID), "*.dll"))
                LoadPlugin(Path.GetFileNameWithoutExtension(s));
        }

        internal void UnloadPlugins()
        {
            foreach (Gamemode game in loadedGames.Reverse<Gamemode>())
                UnloadPlugin(game);
        }

        internal void UnloadPlugin(Gamemode game)
        {
            game.Unload();
            loadedGames.Remove(game);
        }

        internal void LoadPlugin(string name)
        {
            Utilities.Tools.SendConsole($"Loaded: {name}", ConsoleColor.Yellow);
            var a = Assembly.LoadFrom(string.Format("Servers/{0}/Gamemodes/", Dedicator.serverID) + name + ".dll");
            Type p = a.GetTypes().FirstOrDefault(x => x.IsSubclassOf(typeof(Gamemode)));
            if (p != null)
            {
                var plugin = (Gamemode)Activator.CreateInstance(p);
                plugin.Load();
                loadedGames.Add(plugin);
                string plugindir = string.Format("Servers/{0}/Gamemodes/", Dedicator.serverID);
                if (!Directory.Exists(plugindir))
                {
                    Directory.CreateDirectory(plugindir);
                }
            }
            else
            {
                Utilities.Tools.SendConsole($"Error loading {name}.");
            }
        }
    }
}
