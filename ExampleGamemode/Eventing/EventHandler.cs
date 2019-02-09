using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ExampleGamemode.Eventing
{
    public class EventHandler : MonoBehaviour
    {
        void Start()
        {
            Provider.onServerDisconnected += ServerEvents.onServerDisconnect;
            Provider.onServerConnected += ServerEvents.onServerConnect;

            SteamChannel.onTriggerSend += (SteamPlayer player, string name, ESteamCall mode, ESteamPacket type, object[] arguments) =>
            {
                TriggerSend(player, name, mode, type, arguments);
            };
        }
        internal static void TriggerSend(SteamPlayer s, string W, ESteamCall X, ESteamPacket l, params object[] R)
        {
            try
            {
                if (s == null || s.player == null || s.playerID.steamID == CSteamID.Nil || s.player.transform == null || R == null) return;
                Player plr = GamemodeLoader.Utilities.Tools.GetPlayer(s);

                if (W == "tellDeath")
                {
                    ServerEvents.PlayerDeath(plr, (EDeathCause)(byte)R[0], (ELimb)(byte)R[1], new CSteamID(ulong.Parse(R[2].ToString())));
                }
            }
            catch (Exception ex)
            {
                GamemodeLoader.Utilities.Tools.SendConsole(ex + "Failed to receive packet \"" + W + "\"", ConsoleColor.Red);
            }
        }

    }
}
