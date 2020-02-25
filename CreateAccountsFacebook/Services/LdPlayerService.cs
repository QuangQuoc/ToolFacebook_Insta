using CreateAccountsProject.Models;
using CreateAccountsProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLdPlayer.Services
{
    public static class LdPlayerService
    {
        public static void Create(string ldName)
        {
            string command = $"add --name \"{ldName}\"";
            CmdService.RunLdConsole(command);
        }
        /// <summary>
        /// Chạy LD - sử dụng tên LD
        /// </summary>
        /// <param name="ldName"></param>
        public static void Run(string ldName)
        {
            string command = $"launch --name \"{ldName}\"";
            CmdService.RunLdConsole(command);
        }

        public static void Quit(string ldName)
        {
            string command = $"quit --name \"{ldName}\"";
            CmdService.RunLdConsole(command);
        }

        public static void QuitAll()
        {
            string command = $"quitall";
            CmdService.RunLdConsole(command);
        }

        public static void PropertySetting(string ldName, LDProperty property)
        {
            string command = $"modify --name \"{ldName}\" --resolution \"{property.Resolution}\" --cpu \"{property.Resolution}\" --memory \"{property.Memory}\" --imei \"{property.Imei}\"";
            CmdService.RunLdConsole(command);
        }

        public static void InstallApp(string ldName, string fileName)
        {
            string command = $"installapp --name \"{ldName}\" --filename \"{fileName}\"";
            CmdService.RunLdConsole(command);
        }

        public static void UnInstallApp(string ldName, string packageName)
        {
            string command = $"uninstallapp --name \"{ldName}\" --packagename \"{packageName}\"";
            CmdService.RunLdConsole(command);
        }

        public static void RunApp(string ldName, string packageName)
        {
            string command = $"runapp --name \"{ldName}\" --packagename \"{packageName}\"";
            CmdService.RunLdConsole(command);
        }

        public static void KillApp(string ldName, string packageName)
        {
            string command = $"killapp --name \"{ldName}\" --packagename \"{packageName}\"";
            CmdService.RunLdConsole(command);
        }
    }
}
