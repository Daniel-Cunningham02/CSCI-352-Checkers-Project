using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersProject.src
{
    internal class CmdManager
    {
        public enum CmdType
        {
            Move,
            Forfeit,
            Leave,
            Connect,
            None,
            Swap,
            WinBlue,
            WinRed
        }
        public CmdManager()
        {
        
        }

        public CmdType RegisterCommand(ref string command)
        {
            if(command == null)
            {
                return CmdType.None;
            }
            if (command.StartsWith("Move"))
            {
                command = command.Substring(command.IndexOf(" ") + 1);
                return CmdType.Move;
            }
            else if (command.StartsWith("Forfeit"))
            {
                command = command.Substring(command.IndexOf(" ") + 1);
                return CmdType.Forfeit;
            }
            else if (command.StartsWith("Leave"))
            {
                command = command.Substring(command.IndexOf(" ") + 1);
                return CmdType.Leave;
            }
            else if (command.StartsWith("Connect"))
            {
                return CmdType.Connect;
            }
            else if (command.StartsWith("GameStateSwap"))
            {
                command = "Swap";
                return CmdType.Swap;
            }
            else if (command.StartsWith("WinBlue"))
            {
                command = "Blue Win";
                return CmdType.WinBlue;
            }
            else if(command.StartsWith("WinRed"))
            {
                command = "Red win";
                return CmdType.WinRed;
            }

            return CmdType.None;
        }

        public void doCommand(CommandType type)
        {

        }
        
    }
}
