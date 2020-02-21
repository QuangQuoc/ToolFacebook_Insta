using ControlLdPlayer.Models;
using ControlLdPlayer.Repositories;
using ControlLdPlayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlLdPlayer.Controllers
{
    public class ManagementController
    {
        // Khai báo biến
        private DevicesRepository devicesRepo = new DevicesRepository();
        private HostRepository hostRepo = new HostRepository();
        private LdPlayerController ldControl = new LdPlayerController();
        public void ManagementTool()
        {
            // Đọc thông tin host
            //- Kiểm tra host đã có thông tin chưa
            VariablesService.myHost = hostRepo.ReadHost(VariablesService.myHostName);
            if (VariablesService.myHost == null)
            {
                VariablesService.myHost = hostRepo.AddHost(VariablesService.myHostName);
            }
            // Đọc các LD chưa đủ 5 tài khoản từ database trên máy này
            List<Device> devices = devicesRepo.CheckDevicesAccount(VariablesService.myHostName);
            // TH có thiết bị chưa đủ tài khoản
            if (devices.Count > 0)
            {
                // Cho chạy và tạo tài khoản từng device cho đến khi có thể chạy thêm Thread => thoát ra vòng for
                // Thoát khi threadRunning < maxThread 
                foreach (var device in devices)
                {
                    if (VariablesService.threadRunning < VariablesService.maxThread)
                    {
                        RunDeviceThreadCreateAcc(device);
                    }
                    else
                    {
                        while(VariablesService.threadRunning == VariablesService.maxThread)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(2));
                        }
                    }
                }
            }
            // Trong điều kiện còn cho phép lập nick mới
            while(VariablesService.createBotLive)
            {
                if (VariablesService.threadRunning < VariablesService.maxThread)
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
            VariablesService.threadRunning += 1;
            thread.Start();
        }

    }
}
