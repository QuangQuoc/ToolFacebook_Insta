using ControlLdPlayer.Models;
using ControlLdPlayer.Repositories;
using ControlLdPlayer.Services;
using ControlLdPlayer.ViewModels;
using ControlLdPlayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlLdPlayer.Controllers
{
    public class LdPlayerController
    {
        private LdPlayer form;
        private LdPlayerViewModel view;
        private Random random = new Random();
        private DevicesRepository devicesRepo = new DevicesRepository();

        public LdPlayerController()
        {
        }

        public void Create(string ldName)
        {
            string command = $"add --name \"{ldName}\"";
            CmdService.RunLdConsole(command);
        }
        /// <summary>
        /// Chạy LD - sử dụng tên LD
        /// </summary>
        /// <param name="ldName"></param>
        public void Run(string ldName)
        {
            string command = $"launch --name \"{ldName}\"";
            CmdService.RunLdConsole(command);
        }

        public void Quit(string ldName)
        {
            string command = $"quit --name \"{ldName}\"";
            CmdService.RunLdConsole(command);
        }

        public void QuitAll()
        {
            string command = $"quitall";
            CmdService.RunLdConsole(command);
        }

        public void PropertySetting(string ldName, LDProperty property)
        {
            string command = $"modify --name \"{ldName}\" --resolution \"{property.Resolution}\" --cpu \"{property.Resolution}\" --memory \"{property.Memory}\" --imei \"{property.Imei}\"";
            CmdService.RunLdConsole(command);
        }

        public void InstallApp(string ldName, string fileName)
        {
            string command = $"installapp --name \"{ldName}\" --filename \"{fileName}\"";
            CmdService.RunLdConsole(command);
        }

        public void UnInstallApp(string ldName, string packageName)
        {
            string command = $"uninstallapp --name \"{ldName}\" --packagename \"{packageName}\"";
            CmdService.RunLdConsole(command);
        }

        public void RunApp(string ldName, string packageName)
        {
            string command = $"runapp --name \"{ldName}\" --packagename \"{packageName}\"";
            CmdService.RunLdConsole(command);
        }

        public void KillApp(string ldName, string packageName)
        {
            view.ReadName();
            string command = $"killapp --name \"{ldName}\" --packagename \"{packageName}\"";
            CmdService.RunLdConsole(command);
        }

        public Device CreateDevice()
        {
            Device device = new Device();
            // Tạo tên cho device
            string name = $"Device_{random.Next(1000, 10000).ToString()}_{DateTime.Now.ToString()}";
            device.Name = name;
            // Thêm thông tin host
            device.HostId = VariablesService.myHost.Id;
            // Tạo Ld mới
            Create(device.Name);
            Thread.Sleep(TimeSpan.FromSeconds(VariablesService.timeCreateDevice));
            // Config device
            PropertySetting(device.Name, VariablesService.configDevice);
            // Rundevice
            Run(device.Name);
            Thread.Sleep(TimeSpan.FromSeconds(VariablesService.timeRunDevice));
            // Đọc ip tất cả device
            List<String> deviceIps = KAutoHelper.ADBHelper.GetDevices();
            foreach (var dvIp in deviceIps)
            {
                int index = VariablesService.deviceIpsRunning.FindIndex(drning => drning == dvIp);
                if (index == -1)
                {
                    device.DeviceIp = dvIp;
                }
            }
            // Thêm thông tin deviceIp đang chạy
            VariablesService.deviceIpsRunning.Add(device.DeviceIp);
            // Cài phần mềm
            for (int i = 0; i < 5; i++)
            {
                InstallApp(device.Name, $"{VariablesService.apkBrowserPath}\\{VariablesService.apkBrowserName}{i}.apk");
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            InstallApp(device.Name, $"{VariablesService.apkBrowserPath}\\{VariablesService.apkFacebookName}");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            // Lấy ra device mới chạy
            device.Status = true;
            // Lưu thông tin device vào Db
            device = devicesRepo.Add(device);
            return device;
        }
    }
}
