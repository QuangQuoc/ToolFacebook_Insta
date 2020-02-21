using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLdPlayer.Services
{
    public static class CmdService
    {
        public static void Run(string dir, string arg)
        {
            ProcessStartInfo proStart = new ProcessStartInfo();
            Process pro = new Process();
            proStart.FileName = "cmd.exe";
            proStart.WorkingDirectory = dir;
            proStart.Arguments = $"/c {arg}";
            proStart.WindowStyle = ProcessWindowStyle.Hidden;
            pro.StartInfo = proStart;
            pro.Start();
        }

        public static void RunLdConsole(string command)
        {
            string arg = $"ldconsole.exe {command}";
            CmdService.Run(VariablesServiceService.dirLd, arg);
        }
    }
}
