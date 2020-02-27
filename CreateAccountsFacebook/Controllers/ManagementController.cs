using CreateAccountsProject.Services;
using CreateAccountsProject.Models;
using CreateAccountsProject.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace CreateAccountsProject.Controllers
{
    public class ManagementController
    {
        // Khai báo biến
        private DevicesRepository devicesRepo = new DevicesRepository();
        private HostRepository hostRepo = new HostRepository();
        private LdPlayerController ldControl = new LdPlayerController();
        public void StartManagement()
        {
            // Đọc thông tin host
            //- Kiểm tra host đã có thông tin chưa
            DeviceVariablesService.MyHost = hostRepo.ReadHost(DeviceVariablesService.MyHostName);
            if (DeviceVariablesService.MyHost == null)
            {
                Host host = new Host(DeviceVariablesService.MyHostName);
                DeviceVariablesService.MyHost = hostRepo.AddHost(host);
            }
            // Đọc các LD chưa đủ 5 tài khoản từ database trên máy này
            List<Device> devices = devicesRepo.CheckDevicesAccount(DeviceVariablesService.MyHostName);
            // TH có thiết bị chưa đủ tài khoản
            if (devices.Count > 0)
            {
                // Cho chạy và tạo tài khoản từng device cho đến khi có thể chạy thêm Thread => thoát ra vòng for
                // Thoát khi threadRunning < maxThread 
                foreach (var device in devices)
                {
                    if (DeviceVariablesService.ThreadRunning < DeviceVariablesService.MaxThread)
                    {
                        RunDeviceThreadCreateAcc(device);
                    }
                    else
                    {
                        while(DeviceVariablesService.ThreadRunning == DeviceVariablesService.MaxThread)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(2));
                        }
                    }
                }
            }
            // Trong điều kiện còn cho phép lập nick mới
            while(DeviceVariablesService.CreateBotLive)
            {
                if (DeviceVariablesService.ThreadRunning < DeviceVariablesService.MaxThread)
                {
                    // Tạo và chạy 1 LD mới
                    Device device = ldControl.CreateDevice();
                    // Tạo Thread mới => chạy LD
                    RunDeviceThreadCreateAcc(device);
                }
                Thread.Sleep(2);
            }      
        }

        /// <summary>
        /// Tạo 1 luồng mới và chạy LD lập tài khoản tự động
        /// </summary>
        /// <param name="device"></param>
        private void RunDeviceThreadCreateAcc(Device device)
        {
            CreateAccountsController createAccoutsLd = new CreateAccountsController(device);
            Thread thread = new Thread(createAccoutsLd.CreateAccountsLD);
            DeviceVariablesService.ThreadRunning += 1;
            thread.Start();
        }
    }
}
