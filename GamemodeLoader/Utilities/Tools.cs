using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Timers;
using UnityEngine;

namespace GamemodeLoader.Utilities
{
    public class Tools
    {
        private static Color grey = Color.grey;
        public static string GetIP(Player plr)
        {
            P2PSessionState_t State;
            SteamGameServerNetworking.GetP2PSessionState(GetSteamPlayer(plr).playerID.steamID, out State);
            return Parser.getIPFromUInt32(State.m_nRemoteIP);
        }
        public static void SendConsole(string content, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ResetColor();
        }
        public static void SendConsole(string content, ConsoleColor color = ConsoleColor.White, ConsoleColor bgcolor = ConsoleColor.Black)
        {
            Console.BackgroundColor = bgcolor;
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ResetColor();
        }
        public static void SendChat(string content, Color color)
        {
            ChatManager.say("[" + DateTime.Now.ToString("h:mm tt") + "] [GLOBAL] " + content, color);
        }
        public static void SendChat(string content)
        {
            ChatManager.say("[" + DateTime.Now.ToString("h:mm tt") + "] [GLOBAL] " + content, Color.white);
        }
        public static void SendChat(string content, Player player, Color color)
        {
            ChatManager.serverSendMessage("[" + DateTime.Now.ToString("h:mm tt") + "] [MESSAGE] " + content, color, null, GetSteamPlayer(player));
        }
        public static void SendChat(string content, Player player)
        {
            ChatManager.serverSendMessage("[" + DateTime.Now.ToString("h:mm tt") + "] [MESSAGE] " + content, Color.white, null, GetSteamPlayer(player));
        }
        public static void OpenWebRequest(string description, string url, Player player)
        {
            player.sendBrowserRequest(description, url);
        }
        public static SteamPlayer GetSteamPlayer(CSteamID iD)
        {
            foreach (var user in Provider.clients)
            {
                if (user.playerID.steamID == iD)
                    return user;
            }

            return null;
        }
        public static SteamPlayer GetSteamPlayer(Player player)
        {
            foreach (var user in Provider.clients)
            {
                if (user.player == player)
                    return user;
            }

            return null;
        }
        public static Player GetPlayer(CSteamID id)
        {
            foreach (var user in Provider.clients)
            {
                if (user.playerID.steamID == id)
                    return user.player;
            }

            return null;
        }

        public static Player GetPlayer(SteamPlayer steamplayer)
        {
            return GetPlayer(steamplayer.playerID.steamID);
        }
        public static string GetName(Player player)
        {
            return GetSteamPlayer(player).playerID.characterName;
        }
        public static string GetConfigDir(string gamename)
        {
            Directory.SetCurrentDirectory(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\"));
            return string.Format("Servers/{0}/Gamemodes/{1}.config.json", Dedicator.serverID, gamename);
        }
    }
}
