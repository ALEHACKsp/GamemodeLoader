using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ExampleGamemode.Eventing
{
    public class ServerEvents
    {
        #region PlayerDisconnect
        public static void onServerDisconnect(CSteamID steamID)
        {
            GamemodeLoader.Utilities.Tools.SendChat(GamemodeLoader.Utilities.Tools.GetName(GamemodeLoader.Utilities.Tools.GetPlayer(steamID)) + " has left the server");
        }
        #endregion
        #region PlayerConnect
        public static void onServerConnect(CSteamID steamID)
        {
            GamemodeLoader.Utilities.Tools.SendChat(GamemodeLoader.Utilities.Tools.GetName(GamemodeLoader.Utilities.Tools.GetPlayer(steamID)) + " has joined the server");
        }
        #endregion
        #region PlayerDeath
        public static void PlayerDeath(Player player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            GamemodeLoader.Utilities.Tools.SendChat(string.Format("{0} died", GamemodeLoader.Utilities.Tools.GetPlayer(murderer)), Color.magenta);
        }
        #endregion
    }
}
