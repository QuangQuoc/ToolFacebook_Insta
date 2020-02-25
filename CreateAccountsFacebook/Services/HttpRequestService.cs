using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlLdPlayer.Services
{
    public class HttpRequestService
    {
        /// <summary>
        /// Tạo Http Request đến Url 
        /// => Trả về nội dung dạng String
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string RequestRawData(string url)
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
        public static Dictionary<string, dynamic> RequestDicData(string url)
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
    }
}
