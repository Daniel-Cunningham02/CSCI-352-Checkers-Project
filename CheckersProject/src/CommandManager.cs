﻿using System;
using System.Collections.Generic;
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
            None
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

            return CmdType.None;
        }
    }
}
