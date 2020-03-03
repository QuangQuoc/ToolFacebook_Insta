using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace createAccount
{
    public class SimAPI
    {
        private string requestID ;
        /// <summary>
        /// Đọc Balance của tài khoản => trả về Dictionary
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, dynamic> GetBalance()
        {
            string url = $"http://api.pvaonline.net/balance?key={Variables.apiKey}";
            var data = RequestDicData(url);
            return data;
        }

        /// <summary>
        /// Đọc thông tin tất cả các Service của Simthue
        /// => Trả về Dictionary => dùng dữ liệu này để xử lý tiếp
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, dynamic> GetAvailableServices()
        {
            string url = $"http://api.pvaonline.net/service?key={Variables.apiKey}";
            var data = RequestDicData(url);
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
            if (Variables.simServices == null)
            {
                // Lưu dữ liệu vào biến này để có thể dùng lại nhiều lần => Không cần request nhiều
                Variables.simServices = GetAvailableServices();
            }
            foreach (var sv in Variables.simServices["services"])
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
        /// Tạo yêu cầu thuê sim mới hoạt động như sau:
        /// + Lấy thông tin Service Facebook: ServiceId, Balance
        /// + Lấy thông tin tài khoản: Balance
        /// + Kiểm tra còn đủ tiền dùng Service Facebook không?
        /// => Nếu còn: Tạo Request và trả về dữ liệu => Dùng dữ liệu này để lấy RequestId (VD)
        /// => Nếu không đủ: Trả về dữ liệu null
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, dynamic> CreateRequest()
        {
            Dictionary<string, dynamic> data = null;
            // Lấy thông tin FBService
            var service = GetService(Variables.fbServiceName);
            string fbServiceId = service["id"].ToString();
            int fbPrice = 0;
            try
            {
                fbPrice = Int32.Parse(service["price"].ToString());
            }
            catch (Exception)
            {
                return data;
            }
            // Check tài khoản
            var balance = GetBalance();
            int myBalance = 0;
            if (balance["success"] == true)
            {
                myBalance = Int32.Parse(balance["balance"].ToString());
            }
            // Kiểm tra còn đủ tiền hay không => thực hiện CreateRequest
            if (myBalance > fbPrice)
            {
                string url = $"http://api.pvaonline.net/request/create?key={Variables.apiKey}&service_id={fbServiceId}";
                data = RequestDicData(url);
                requestID = data["id"];
            }
            return data;
        }

        /// <summary>
        /// Kiểm tra Request
        /// => Trả về dữ liệu kiểu Dictionary => Lây dữ liệu và xử lý tiếp
        /// </summary>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public Dictionary<string, dynamic> CheckRequest(string requestId)
        {
            string url = $"http://api.pvaonline.net/request/check?key={Variables.apiKey}&id={requestId}";
            var data = RequestDicData(url);
            return data;
        }

        public Dictionary<string, dynamic> CancelRequest(string requestId)
        {
            string url = $"http://api.pvaonline.net/request/cancel?key={Variables.apiKey}&id={requestId}";
            var data = RequestDicData(url);
            return data;
        }

        public Dictionary<string, dynamic> FinishRequest(string requestId)
        {
            string url = $"http://api.pvaonline.net/request/finish?key={Variables.apiKey}&id={requestId}";
            var data = RequestDicData(url);
            return data;
        }

        /// <summary>
        /// Tạo Http Request đến Url 
        /// => Trả về nội dung dạng String
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string RequestRawData(string url)
        {
            string rawData = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                rawData = reader.ReadToEnd();
            }
            return rawData;
        }

        /// <summary>
        /// Tạo Http Request đến 2 Url
        /// => Trả về nội dung dạng Dictionary nếu dữ liệu nhận về kiểu Json
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Dictionary<string, dynamic> RequestDicData(string url)
        {
            string rawData = RequestRawData(url);
            Dictionary<string, dynamic> data = null;
            try
            {
                data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(rawData);
            }
            catch (Exception)
            {

            }
            return data;
        }


        /// <summary>
        /// Lấy sdt từ id vừa createRequest:
        /// + Dùng checkRequest(requestID) để lấy sdt, requestID trả về từ việc gọi createRequest
        /// + Tạo biến string nhận sdt, đặt trong vòng lặp while khi có sdt thì break
        /// </summary>
        /// <returns></returns>
        public string getNumber()
        {
            string numberPhone = "";
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                Dictionary<string, dynamic> data = CheckRequest(requestID);
                try
                {
                    numberPhone = data["number"];
                }
                catch{}
                if (numberPhone != "")
                {
                    break;
                }
            }
            return numberPhone;
        }

        /// <summary>
        /// Lấy sms fb trả về khi yêu cầu lập nick
        /// </summary>
        /// <returns></returns>
        public string getSms()
        {
            string code = "";
            long checkTime=10;
            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));
                Dictionary<string, dynamic> data = CheckRequest(requestID);
                IList collection = (IList)data["sms"];
                
                foreach (var sms in collection)
                {
                    foreach (string value in Regex.Split(sms.ToString(), @"\D+"))
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
                checkTime = data["timeleft"];
                if ((code != "") || (checkTime <= 0))
                {
                    break;
                }
            }
            return code;
        }

        public Dictionary<string, dynamic> CheckRequest2Fa(string code2Fa)
        {
            string url = $"http://localhost:3000/key?secret={code2Fa}";
            var data = RequestDicData(url);
            return data;
        }

    }
}
