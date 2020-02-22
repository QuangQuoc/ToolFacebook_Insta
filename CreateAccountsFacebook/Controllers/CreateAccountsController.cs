using ControlLdPlayer.Services;
using ControlLdPlayer.Services.VariableServices;
using CreateAccountsProject.Models;
using CreateAccountsProject.Repositories;
using CreateAccountsProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CreateAccountsProject.Controllers
{
    public class CreateAccountsController
    {
        // Khai báo biến
        private DevicesRepository devicesRepo = new DevicesRepository();
        private LdPlayerController ldControl = new LdPlayerController();
        private Device ld;
        private Random random = new Random();

        public CreateAccountsController(Device _ld)
        {
            ld = _ld;
        }
        /// <summary>
        /// - Điều khiển LD tạo tài khoản mới cho đến khi đủ tài khoản
        /// - Khi đủ tài khoản, cho biết "VariablesService.threadRunning" giảm 1 và đóng Thread 
        /// </summary>
        public void CreateAccountsLD()
        {
            // Khởi động LD
            LdPlayerService.Run(ld.Name);
            Thread.Sleep(TimeSpan.FromSeconds(DeviceVariablesService.TimeRunDevice));
            // Run app
            // Kiểm tra số browser đã có tài khoản

            // Tạo các tài khoản còn lại

            //TESTING
            Thread.Sleep(TimeSpan.FromMinutes(5));
            LdPlayerService.Quit(ld.Name);
            DeviceVariablesService.ThreadRunning -= 1;
        }

        public void AddAccountName()
        {
            string deviceID = ld.DeviceIp;
            string browerName = ld.browserName; //mark.via.gp0{browser.ToString()}
            // Set họ 
            KAutoHelper.ADBHelper.ExecuteCMD("adb shell monkey -p com.example.namefacebook -c android.intent.category.LAUNCHER 1");
            DelayService.Secounds(5);
            try
            {
                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_firstName = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BMPVariablesService.BMP_FirstName);
                DelayService.Secounds(1);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_firstName.Value.X, compare_firstName.Value.Y);
            }
            catch
            {
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 48.6, 23.7);
            }
            DelayService.Secounds(1);
            // Load vào web đăng ký
            KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p {browerName} -c android.intent.category.LAUNCHER 1");
            DelayService.Secounds(5);
            loadLink("https://mbasic.facebook.com/reg");
            DelayService.Secounds(2);
            // Get họ
            KAutoHelper.ADBHelper.LongPress(deviceID, 100, 250, 1000);
            DelayService.Secounds(2);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.3, 20.9);
            DelayService.Secounds(2);

            if (random.Next(2) == 0)
            {
                // Set tên nữ
                KAutoHelper.ADBHelper.ExecuteCMD("adb shell monkey -p com.example.namefacebook -c android.intent.category.LAUNCHER 1");
                DelayService.Secounds(5);
                try
                {
                    var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_lastNameFemale = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, BMPVariablesService.BMP_LastNameFemale);
                    DelayService.Secounds(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_lastNameFemale.Value.X, compare_lastNameFemale.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.1, 32.1);
                }
                DelayService.Secounds(1);
                // Vào lại trang đăng ký
                KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p {browerName} -c android.intent.category.LAUNCHER 1");
                DelayService.Secounds(5);
                // Get tên nữ
                KAutoHelper.ADBHelper.LongPress(deviceID, 100, 333, 1000);
                DelayService.Secounds(2);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.0, 29.9);
                DelayService.Secounds(1);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.0, 51.5);
            }
            else
            {
                // Set tên nam
                KAutoHelper.ADBHelper.ExecuteCMD("adb shell monkey -p com.example.namefacebook -c android.intent.category.LAUNCHER 1");
                DelayService.Secounds(5);
                try
                {
                    var screen2 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_lastNameMale = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, BMPVariablesService.BMP_LastNameMale);
                    DelayService.Secounds(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_lastNameMale.Value.X, compare_lastNameMale.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.1, 39.9);
                }
                DelayService.Secounds(1);
                KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p {browerName} -c android.intent.category.LAUNCHER 1");
                DelayService.Secounds(5);
                // Get tên nam
                KAutoHelper.ADBHelper.LongPress(deviceID, 100, 333, 1000);
                DelayService.Secounds(2);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.0, 29.9);
                DelayService.Secounds(1);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 38.1, 51.5);
            }
        }

        /// <summary>
        /// Hàm load link 
        /// </summary>
        /// <param name = "link" ></ param >
        /// <returns></returns>
        private void loadLink(string link)
        {
            string deviceID = ld.DeviceIp;
            // Click thanh địa chỉ
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 20.3, 7.1);
            DelayService.Secounds(1);
            // Dán địa chỉ 
            KAutoHelper.ADBHelper.InputText(deviceID, link);
            DelayService.Secounds(1);
            // Enter load địa chỉ
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
            DelayService.Secounds(10);
        }
    }
}
