using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountsProject.Services
{
    public class SimVariablesService
    {
        // SIM_THUE
        public static string ApiKeySimThue { get; set; }
        public static Dictionary<string, dynamic> SimThueServices { get; set; }
        public static string SimThueFbServiceName { get; set; }
        public static bool UseSimThue { get; set; }
        // RENTCODE
        public static string ApiKeyRentCode { get; set; }
        public static Dictionary<string, dynamic> ServicesRentCode { get; set; }
        public static string FbServiceNameRentCode { get; set; }
        public static bool UseRentCode { get; set; }

        public static void Initial()
        {
            // SIM_THUE
            ApiKeySimThue = "BTaKJG45nKYfNrYIqYX_MQt6f";
            SimThueServices = null;
            SimThueFbServiceName = "Facebook";
            UseSimThue = false;
            // RENT_CODE
            ApiKeyRentCode = "BSsxUM6WOZzYmt/SwFTfiK6tzYmugeLA7P5y/wrGSX8=";
            ServicesRentCode = null;
            FbServiceNameRentCode = "Facebook";
            UseRentCode = true;
        }
    }
}
