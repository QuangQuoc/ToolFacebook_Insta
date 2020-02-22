using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlLdPlayer.Services
{
    public class SimVariablesService
    {
        public static string ApiKeySimThue { get; set; }
        public static Dictionary<string, dynamic> SimThueServices { get; set; }
        public static string SimThueFbServiceName { get; set; }

        public static void Initial()
        {
            ApiKeySimThue = "BTaKJG45nKYfNrYIqYX_MQt6f";
            SimThueServices = null;
            SimThueFbServiceName = "Facebook";
        }
    }
}
