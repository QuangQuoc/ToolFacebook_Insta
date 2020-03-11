using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateAccountsProject.Services
{
    public class RentCodeService
    {
        public string requestId = "";
        /// <summary>
        /// Đọc số tiền còn lại của tài khoản
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, dynamic> Balance()
        {
            string url = $"https://api.rentcode.net/api/v2/balance?apiKey={SimVariablesService.ApiKeyRentCode}";
            var data = HttpRequestService.RequestDicData(url);
            return data;
        }
        /// <summary>
        /// Đọc tất cả service của Rentcode
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, dynamic> Services()
        {
            string url = $"https://api.rentcode.net/api/v2/available-services?apiKey={SimVariablesService.ApiKeyRentCode}";
            var data = HttpRequestService.RequestDicData(url);
            return data;
        }
        /// <summary>
        /// Đọc thông tin của 1 Service dựa vào ServiceName (vd: Facebook)
        /// => Trả về JObject giống Dictionary => kiểu này của thư viện "Newtonsoft.Json.Linq;"
        /// => Dùng Object này có thể kiểm tra được từng thông tin của Service như Dictionary
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public JObject GetService(string serviceName)
        {
            JObject service = null;
            if (SimVariablesService.ServicesRentCode == null)
            {
                // Lưu dữ liệu vào biến này để có thể dùng lại nhiều lần => Không cần request nhiều
                SimVariablesService.ServicesRentCode = Services();
            }
            foreach (var sv in SimVariablesService.ServicesRentCode["results"])
            {
                if (sv["name"] == serviceName)
                {
                    service = sv;
                    break;
                }
            }
            return service;
        }
        /// <summary>
        /// Tạo Request
        /// </summary>
        public void CreateRequest()
        {
            // Đọc Facebook service Id và giá service
            var service = GetService(SimVariablesService.FbServiceNameRentCode);
            string fbSvId = service["id"].ToString();
            int fbPrice = 0;
            try
            {
                fbPrice = Int32.Parse(service["price"].ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi đọc giá dịch vụ - Rentcode");
            }
            // Check tài khoản
            var balance = Balance();
            int myBalance = 0;
            if (balance["success"] == true)
            {
                myBalance = Int32.Parse(balance["results"]["balance"].ToString());
            }
            // Kiểm tra còn đủ tiền hay không => thực hiện CreateRequest
            if (myBalance > fbPrice)
            {
                string url = $"https://api.rentcode.net/api/v2/order/request?apiKey={SimVariablesService.ApiKeyRentCode}&ServiceProviderId={fbSvId}&MaximumSms=5";
                var data = HttpRequestService.RequestDicData(url);
                requestId = data["id"].ToString();
            }
        }
        /// <summary>
        /// Kiểm tra Request
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, dynamic> CheckRequest()
        {
            string url = $"https://api.rentcode.net/api/v2/order/{requestId}/check?apiKey={SimVariablesService.ApiKeyRentCode}";
            var data = HttpRequestService.RequestDicData(url);
            return data;
        }
        public void CancelRequest()
        {
            string url = $"https://api.rentcode.net/api/v2/order/{requestId}/cancel?apiKey={SimVariablesService.ApiKeyRentCode}";
            HttpRequestService.RequestDicData(url);
        }

        /// <summary>
        /// Lấy sdt từ id vừa createRequest:
        /// + Dùng checkRequest(requestID) để lấy sdt, requestID trả về từ việc gọi createRequest
        /// + Tạo biến string nhận sdt, đặt trong vòng lặp while khi có sdt thì break
        /// </summary>
        /// <returns></returns>
        public string GetNumber()
        {
            string numberPhone = "";
            int n = 0;
            while (true)
            {
                if (n == 12)
                {
                    break;
                }
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Dictionary<string, dynamic> data = CheckRequest();
                try
                {
                    numberPhone = data["phoneNumber"];
                }
                catch { }
                
                if (numberPhone != "")
                {
                    break;
                }
                n++;
            }
            return numberPhone;
        }

        /// <summary>
        /// Lấy sms fb trả về khi yêu cầu lập nick
        /// </summary>
        /// <returns></returns>
        public string GetSms()
        {
            string code = null;
            int n = 0;
            while (true)
            {
                if (n == 12)
                {
                    break;
                }
                n++;
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Dictionary<string, dynamic> data = CheckRequest();
                IList collection = (IList)data["messages"];

                foreach (var sms in collection)
                {
                    Dictionary<string, dynamic> mesData = null;
                    try
                    {
                        mesData = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(sms.ToString());
                    }
                    catch (Exception)
                    {

                    }
                    if (mesData != null)
                    {
                        string message = mesData["message"].ToString();
                        foreach (string value in Regex.Split(message, @"\D+"))
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                if (value.Length == 5)
                                {
                                    code = value;
                                }
                            }
                        }
                    }
                }
                if ((code != null))
                {
                    break;
                }
            }
            return code;
        }
    }
}
