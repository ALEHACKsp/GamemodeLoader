using ExampleGamemode.Configuration;
using SDG.Unturned;
using Tools = GamemodeLoader.Utilities.Tools;

namespace ExampleGamemode.Commands
{
    public class Test : Command
    {
        public Test()
        {
            _command = "test";
            _help = "yes";
        }

        protected override void execute(Steamworks.CSteamID executorID, string parameter)
        {
            string[] Params = Parser.getComponentsFromSerial(parameter, '/');
            Player caller = GamemodeLoader.Utilities.Tools.GetPlayer(executorID);
            Tools.SendChat(C.Configuration.SpicyString, caller);
        }
    }
}
