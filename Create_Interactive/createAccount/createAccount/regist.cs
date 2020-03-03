using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;




namespace createAccount
{
    public class Regist
    {
        #region Biến
        private string deviceID;
        private int browser;
        private SimAPI phone = new SimAPI();

        #endregion

        /// <param name = "_deviceID" ></ param >
        /// <param name = "_browser" ></ param >
        public Regist(string _deviceID, int _browser)
        {
            deviceID = _deviceID;
            browser  = _browser;
        }

        /// <summary>
        /// chạy theo trình tự name, ngày sinh, sdt, pass, mã xác thực
        /// </summary>
        /// <returns></returns>
        public void run()
        {
            nameAccount();
            birthDay();
            phone.CreateRequest();
            numberPhone();
            passWord();
            requestSms();
        }

        /// <summary>
        /// Điền thông tin họ và tên, giới tính
        /// </summary>
        /// <returns></returns>
        private void nameAccount()
        {
            // Set họ 
            KAutoHelper.ADBHelper.ExecuteCMD("adb shell monkey -p com.example.namefacebook -c android.intent.category.LAUNCHER 1");
            Delay(5);
            try
            {
                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_firstName = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_FirstName);
                Delay(1);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_firstName.Value.X, compare_firstName.Value.Y);
            }
            catch
            {
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 48.6, 23.7);
            }
            Delay(1);
            // Load vào web đăng ký
            KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p mark.via.gp0{browser.ToString()} -c android.intent.category.LAUNCHER 1");
            Delay(5);
            loadLink("https://mbasic.facebook.com/reg");
            Delay(2);
            // Get họ
            KAutoHelper.ADBHelper.LongPress(deviceID, 100, 250, 1000);
            Delay(2);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.3, 20.9);
            Delay(2);

            if (Variables.random.Next(2) == 0) 
            {
                // Set tên nữ
                KAutoHelper.ADBHelper.ExecuteCMD("adb shell monkey -p com.example.namefacebook -c android.intent.category.LAUNCHER 1");
                Delay(5);
                try
                {
                    var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_lastNameFemale = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, Variables.BMP_LastNameFemale);
                    Delay(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_lastNameFemale.Value.X, compare_lastNameFemale.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.1, 32.1);
                }
                Delay(1);
                // Vào lại trang đăng ký
                KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p mark.via.gp0{browser.ToString()} -c android.intent.category.LAUNCHER 1");
                Delay(5);
                // Get tên nữ
                KAutoHelper.ADBHelper.LongPress(deviceID, 100, 333, 1000);
                Delay(2);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.0, 29.9);
                Delay(1);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.0, 51.5);
            }
            else {
                // Set tên nam
                KAutoHelper.ADBHelper.ExecuteCMD("adb shell monkey -p com.example.namefacebook -c android.intent.category.LAUNCHER 1");
                Delay(5);
                try
                {
                    var screen2 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_lastNameMale = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, Variables.BMP_LastNameMale);
                    Delay(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_lastNameMale.Value.X, compare_lastNameMale.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.1, 39.9);
                }
                Delay(1);
                KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p mark.via.gp0{browser.ToString()} -c android.intent.category.LAUNCHER 1");
                Delay(5);
                // Get tên nam
                KAutoHelper.ADBHelper.LongPress(deviceID, 100, 333, 1000);
                Delay(2);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.0, 29.9);
                Delay(1);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 38.1, 51.5);
            }
        }

        /// <summary>
        /// Hàm ngày tháng năm sinh 
        /// </summary>
        /// <returns></returns>
        private void birthDay()
        {
            // Chọn ngày sinh
            int[] y = { 885, 790, 690, 590, 490, 390, 290, 190, 90 };
            Delay(1);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 14.5, 66.2);
            Delay(1);
            KAutoHelper.ADBHelper.Tap(deviceID, 150, y[Variables.random.Next(y.Length)]);
            Delay(1);
            // Chọn tháng sinh
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 36.5, 66.2);
            Delay(1);
            KAutoHelper.ADBHelper.Tap(deviceID, 150, y[Variables.random.Next(y.Length)]);
            Delay(1);
            // Chọn năm sinh nếu mặc định năm sinh 2020 thì swipe
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var compare_Year1995 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_Year1995);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 59.0, 66.2);
            Delay(1);
            // Kiểm tra năm sinh mặc định có phải 1995 không
            if (compare_Year1995 == null)
            {
                KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 51.3, 94.3, 51.3, 52);
                Delay(1);
            }
            KAutoHelper.ADBHelper.Tap(deviceID, 150, y[Variables.random.Next(y.Length)]);
        }

        /// <summary>
        /// Hàm mật khẩu
        /// </summary>
        /// <returns></returns>
        private void passWord()
        {
            // điền mk vào trang đăng ký
            Delay(1);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 17.8, 75.2);
            Delay(1);
            KAutoHelper.ADBHelper.InputText(deviceID, "quocsang199698");
            Delay(1);
            // Enter thay cho nút nhấn đăng ký
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
            Delay(10);
        }

        /// <summary>
        /// Hàm lấy sdt
        /// </summary>
        /// <returns></returns>
        private void numberPhone()
        {
            // click vào edit sdt
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.7, 43.3);
            Delay(1);
            // điền sdt
            KAutoHelper.ADBHelper.InputText(deviceID, phone.getNumber());
        }

        /// <summary>
        /// Hàm lấy mã xác thực
        /// </summary>
        /// <returns></returns>
        private void requestSms()
        {
            // kiểm tra xem có bắt thay đổi tên không nếu có thì chạy theo kịch bản chọn tên mới
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var compare_chooseName = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_ChooseName);
            var compare_confirmName = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_ConfirmName);
            if (compare_confirmName != null)
            {
                KAutoHelper.ADBHelper.Tap(deviceID, compare_chooseName.Value.X, compare_chooseName.Value.Y);
                Delay(1);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_confirmName.Value.X, compare_confirmName.Value.Y);
                Delay(30);
                loadLink("mbasic.facebook.com/confirmemail.php");
                Delay(10);
            }
            else
            {
                // click button đăng nhập 1 lần
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 48.9, 55.1);
                Delay(10);
            }

            // click vào ô điền mã xác thực fb
            var screen2 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var compare_editCode = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, Variables.BMP_EditCode);
            Delay(1);
            KAutoHelper.ADBHelper.Tap(deviceID, compare_editCode.Value.X, compare_editCode.Value.Y);
            Delay(1);
            KAutoHelper.ADBHelper.InputText(deviceID, phone.getSms());
            Delay(1);
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
            Delay(10);
        }

        /// <summary>
        /// Hàm load link 
        /// </summary>
        /// <param name = "link" ></ param >
        /// <returns></returns>
        private void loadLink(string link)
        {
            // Click thanh địa chỉ
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 20.3, 7.1);
            Delay(1);
            // Dán địa chỉ 
            KAutoHelper.ADBHelper.InputText(deviceID, link);
            Delay(1);
            // Enter load địa chỉ
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
            Delay(10);
        }

        /// <summary>
        /// Delay 
        /// </summary>
        /// <param name = "delay" ></ param >
        /// <returns></returns>
        public void Delay(int delay)
            {
                while (delay > 0)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    delay--;
                }
            }
    }
}
