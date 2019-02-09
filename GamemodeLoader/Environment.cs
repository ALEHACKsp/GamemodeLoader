using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GamemodeLoader
{
    public class Environment : MonoBehaviour
    {
        public static string GameDir;
        void Start()
        {
            GameDir = string.Format("Servers/{0}/Gamemodes/", Dedicator.serverID);
            if (!Directory.Exists(GameDir))
            {
                Directory.CreateDirectory(GameDir);
            }
        }
    }
}
