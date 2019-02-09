using GamemodeLoader.Games;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GamemodeLoader.Commands
{
    public class Pos : Command
    {
        public Pos()
        {
            localization = new Local();
            _command = "Pos";
            _info = _command;
            _help = "Provides Position";
        }

        protected override void execute(Steamworks.CSteamID executorID, string parameter)
        {
            Utilities.Tools.SendChat("Position: " + Utilities.Tools.GetPlayer(executorID).transform.position.ToString(), Utilities.Tools.GetPlayer(executorID));
        }
    }
}
