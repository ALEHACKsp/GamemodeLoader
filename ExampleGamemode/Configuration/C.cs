using GamemodeLoader.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ExampleGamemode.Configuration
{
    public class C : MonoBehaviour
    {
        public static ConfigFields Configuration;

        void Start()
        {
            WriteFiles();
        }

        public static void WriteFiles()
        {
            if (!File.Exists(Loader.ConfigDir))
            {
                ConfigFields cfg = new ConfigFields();
                string json = JsonConvert.SerializeObject(cfg, Formatting.Indented);
                File.WriteAllText(Loader.ConfigDir, json);
            }
        }

        public static void UpdateFiles()
        {
            ConfigFields cfg = new ConfigFields();
            cfg = Configuration;
            string json = JsonConvert.SerializeObject(cfg, Formatting.Indented);
            File.WriteAllText(Loader.ConfigDir, json);
            GetFiles();
        }

        public static void GetFiles()
        {
            if (File.Exists(Loader.ConfigDir))
            {
                string text = File.ReadAllText(Loader.ConfigDir);
                ConfigFields g = JsonConvert.DeserializeObject<ConfigFields>(text);
                Configuration = g;
            }
        }
    }
}