using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GamemodeLoader.Utilities
{
    public class Register
    {
        public static List<Command> commands = new List<Command>();
        public static void RegisterCommand(Command cmd)
        {
            commands.Add(cmd);
            Commander.register(cmd);
        }
    }
}
