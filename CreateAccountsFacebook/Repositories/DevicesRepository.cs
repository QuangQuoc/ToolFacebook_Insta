using ControlLdPlayer.Repositories;
using CreateAccountsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountsProject.Repositories
{
    public class DevicesRepository
    {
        /// <summary>
        /// Đọc các Devices Chưa đủ 5 tài khoản trên 5 Browser
        /// - Đọc thông tin của Browser
        /// </summary>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public List<Device> CheckDevicesAccount(string hostName)
        {
            List<Device> dv = new List<Device>();
            return dv;
        }

        public Device Add(Device device)
        {
            int id = TestDb.Devices.Count;
            device.Id = id;
            TestDb.Devices.Add(device);
            return device;
        }

    }
}
