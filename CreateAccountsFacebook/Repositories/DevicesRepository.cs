using CreateAccountsProject.Repositories;
using CreateAccountsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CreateAccountsProject.Repositories
{
    public class DevicesRepository
    {
        Context context = new Context();
        /// <summary>
        /// Đọc các Devices Chưa đủ 5 tài khoản trên 5 Browser
        /// - Đọc thông tin của Browser
        /// </summary>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public List<Device> CheckDevicesAccount(string hostName)
        {
            var devices = context.Devices
                .Include("Accounts")
                .Where(d => d.ActivedAccounts <= 5)
                .ToList();
            return devices;
        }

        public Device Add(Device device)
        {
            context.Devices.Add(device);
            context.SaveChanges();
            return device;
        }

        public bool UpdateNewAccount(Device dv, int indexBrowser)
        {
            try
            {
                Device device = context.Devices
                .Include(d => d.Accounts)
                .Where(d => d.Id == d.Id)
                .FirstOrDefault();
                if (device != null)
                {
                    device.ActivedAccounts = dv.ActivedAccounts;
                    device.Accounts[indexBrowser].BrowserStatus = true;
                    device.Accounts[indexBrowser] = dv.Accounts[indexBrowser];
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return true;
            }                     
        }

        public bool UpdateStatus(int deviceId, bool status)
        {
            try
            {
                Device device = context.Devices
                    .Where(d => d.Id == deviceId)
                    .FirstOrDefault();
                if (device != null)
                {
                    device.Status = status;
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
