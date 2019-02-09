using GamemodeLoader.Games;
using GamemodeLoader.Utilities;
using SDG.Framework.Modules;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GamemodeLoader
{
    public class Loader : IModuleNexus
    {
        public GamemodeLoad GamemodeLoad { get; private set; }
        public static GameObject LoadObj;
        public void initialize()
        {
            LoadObj = new GameObject("Manager");
            UnityEngine.Object.DontDestroyOnLoad(LoadObj);
            LoadObj.AddComponent<Manager>();

            //Load Commands
            Register.RegisterCommand(new Commands.Pos());

            Console.Clear();
            Utilities.Tools.SendConsole("Gamemode Loader V.1", ConsoleColor.Blue);
            Console.WriteLine();
            Utilities.Tools.SendConsole("---Loading Gamemodes---", ConsoleColor.Green);
            GamemodeLoad = new GamemodeLoad();
            Utilities.Tools.SendConsole("-----------------------", ConsoleColor.Green);
            Console.WriteLine();
            Utilities.Tools.SendConsole("---Loading Commands---", ConsoleColor.Cyan);
            foreach (Command cmd in Register.commands)
            {
                Utilities.Tools.SendConsole("Registered: " + cmd.command, ConsoleColor.DarkMagenta);
            }
            Utilities.Tools.SendConsole("----------------------", ConsoleColor.Cyan);
            
        }
        public void shutdown()
        {
            GamemodeLoad.UnloadPlugins();
        }
    }
}
