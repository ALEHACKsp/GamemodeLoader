using ExampleGamemode.Commands;
using ExampleGamemode.Configuration;
using GamemodeLoader.Games;
using GamemodeLoader.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExampleGamemode.Eventing;
using UnityEngine;
using EventHandler = ExampleGamemode.Eventing.EventHandler;

namespace ExampleGamemode
{
    public class Loader : Gamemode
    {
        public static readonly string ConfigDir = Tools.GetConfigDir(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        public static GameObject Object;
        public override void Load()
        {
            Register.RegisterCommand(new Test());
            Object = new GameObject("man");
            UnityEngine.Object.DontDestroyOnLoad(Object);
            ////////////////////////////////////
            Object.AddComponent<C>();
            Object.AddComponent<EventHandler>();
        }
    }
}
