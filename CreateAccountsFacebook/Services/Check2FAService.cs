using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountsProject.Services
{
    public class Check2FAService
    {
        public static Dictionary<string, dynamic> GetCode(string code2Fa)
        {
            string url = $"http://quocsang.ddns.net:3000/key?secret={code2Fa}";
            var data = HttpRequestService.RequestDicData(url);
            return data;
        }
    }
}
