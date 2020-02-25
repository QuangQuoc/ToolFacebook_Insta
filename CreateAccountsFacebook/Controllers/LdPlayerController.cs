using ControlLdPlayer.Models;
using ControlLdPlayer.Services;
using CreateAccountsProject.Models;
using CreateAccountsProject.Repositories;
using CreateAccountsProject.Services;
using CreateAccountsProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreateAccountsProject.Controllers
{
    public class LdPlayerController
    {
        private Random random = new Random();
        private DevicesRepository devicesRepo = new DevicesRepository();

        public LdPlayerController()
        {
        }
      
        public Device CreateDevice()
        {
            Device device = new Device();
            // Tạo tên cho device
            string name = $"Device_{random.Next(1000, 10000).ToString()}_{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
            device.Name = name;
            // Thêm thông tin host
            device.HostId = DeviceVariablesService.MyHost.Id;
            // Tạo Ld mới
            LdPlayerService.Create(device.Name);
            Thread.Sleep(TimeSpan.FromSeconds(DeviceVariablesService.TimeCreateDevice));
            // Config device
            LdPlayerService.PropertySetting(device.Name, DeviceVariablesService.ConfigDevice);
            Thread.Sleep(TimeSpan.FromSeconds(DeviceVariablesService.TimeCreateDevice));
            // Rundevice
            LdPlayerService.Run(device.Name);
            Thread.Sleep(TimeSpan.FromSeconds(DeviceVariablesService.TimeRunDevice));
            // Đọc ip tất cả device
            List<String> deviceIps = KAutoHelper.ADBHelper.GetDevices();
            foreach (var dvIp in deviceIps)
            {
                int index = DeviceVariablesService.DeviceIpsRunning.FindIndex(drning => drning == dvIp);
                if (index == -1)
                {
                    device.DeviceIp = dvIp;                            
                }
            }
            // Thêm thông tin deviceIp đang chạy
            DeviceVariablesService.DeviceIpsRunning.Add(device.DeviceIp);
            // Cài phần mềm
            for (int i = 0; i < 5; i++)
            {
                string apkBrowser = $"{DeviceVariablesService.ApkPath}{DeviceVariablesService.ApkBrowserName}{i + 1}.apk";
                LdPlayerService.InstallApp(device.Name, apkBrowser);

                Thread.Sleep(TimeSpan.FromSeconds(DeviceVariablesService.TimeInstallApp));
                // Thêm thông tin Browser đã cài vào Device
                Browser br = new Browser($"{DeviceVariablesService.BrowserName}{i + 1}", apkBrowser);
                device.Browsers.Add(br);
            }
            string apkFbName = $@"{DeviceVariablesService.ApkPath}{DeviceVariablesService.ApkFacebookName}";
            LdPlayerService.InstallApp(device.Name, apkFbName);
            Thread.Sleep(TimeSpan.FromSeconds(DeviceVariablesService.TimeInstallApp));
            
            // Lấy ra device mới chạy
            device.Status = true;
            // Lưu thông tin device vào Db
            device = devicesRepo.Add(device);
            return device;
        }
    }
}
