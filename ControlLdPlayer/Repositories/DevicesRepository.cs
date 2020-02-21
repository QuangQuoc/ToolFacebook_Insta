using ControlLdPlayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLdPlayer.Repositories
{
    public class DevicesRepository
    {
        public List<Device> CheckDevicesAccount(string hostName)
        {
            List<Device> dv = new List<Device>();
            return dv;
        }

        public Device Add(Device device)
        {
            return new Device();
        }

    }
}
