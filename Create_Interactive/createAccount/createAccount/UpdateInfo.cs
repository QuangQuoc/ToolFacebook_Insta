using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace createAccount
{

    public class UpdateInfo
    {
        private string deviceID;
        private int browser;

        /// <param name="_deviceID"></param>
        /// <param name="_browser"></param>
        public UpdateInfo(string _deviceID, int _browser)
        {
            deviceID = _deviceID;
            browser = _browser;
        }

        /// <summary>
        /// Kết bạn >= 15 bạn nè ban đầu
        /// </summary>
        /// <returns></returns>
        public void addFriend()
        {
            try
            {
                // nameFriend: random tìm kiếm bạn bè theo tên để kết
                string[] nameFriend = { "Linh", "manh", "thuong", "hoai", "sang", "quoc", "vu", "tuan", "nga", "hung",
                                    "Dong", "ly", "tan", "mai", "Nhi", "Hoai", "Thanh", "Cat", "Trang", "Thao", "Nguyen"};
                KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p mark.via.gp0{browser.ToString()} -c android.intent.category.LAUNCHER 1");
                Thread.Sleep(TimeSpan.FromSeconds(5));
                // thay đổi tên tìm kiếm 
                for (int i = 0; i <= 2; i++)
                {
                    loadLink("https://mbasic.facebook.com/friends/center/search");
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 16.4, 37.6);
                    KAutoHelper.ADBHelper.InputText(deviceID, nameFriend[Variables.random.Next(nameFriend.Length)]);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    // số lượt kb trên 1 lần tìm kiếm
                    for (int j = 0; j <= 5; j++)
                    {
                        try
                        {
                            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                            var compare_addFriend = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_AddFriend);
                            KAutoHelper.ADBHelper.Tap(deviceID, compare_addFriend.Value.X, compare_addFriend.Value.Y);
                            Thread.Sleep(TimeSpan.FromSeconds(Variables.random.Next(100, 130)));
                        }
                        catch { break; }
                    }
                }
            }
            catch { /* Lỗi addFriend */ }

        }

        /// <summary>
        /// Cài thông tin cơ bản trong tường
        /// </summary>
        /// <returns></returns>
        public void upAddress()
        {
            try
            {
                KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p mark.via.gp0{browser.ToString()} -c android.intent.category.LAUNCHER 1");
                Thread.Sleep(TimeSpan.FromSeconds(3));
                loadLink("https://mbasic.facebook.com/profile/questions/view");
                while (true)
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 14.8, 23.4);
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_ignore = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_Ignore);
                    if (compare_ignore != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, compare_ignore.Value.X, compare_ignore.Value.Y);
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                    }
                    else { break; }
                }
            }
            catch { /* Lỗi upAddress */ }
        }

        /// <summary>
        /// Cài 2Fa vào tk
        /// </summary>
        /// <returns></returns>
        public void setup2Fa()
        {
            try
            {
                KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p mark.via.gp0{browser.ToString()} -c android.intent.category.LAUNCHER 1");
                Thread.Sleep(TimeSpan.FromSeconds(3));
                loadLink("https://mbasic.facebook.com/security/2fac/setup/intro/");
                // click vào button chuyển đến setup 2fa
                try
                {
                    var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_Confirm2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, Variables.BMP_Confirm2Fa);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_Confirm2Fa.Value.X, compare_Confirm2Fa.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 48.3, 67.8);
                }
                Thread.Sleep(TimeSpan.FromSeconds(5));

                // Xác nhận mật khẩu trước khi setup 2fa
                var screen2 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_ConfirmPass2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, Variables.BMP_ConfirmPass2Fa);
                if (compare_ConfirmPass2Fa != null)
                {
                    try
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, compare_ConfirmPass2Fa.Value.X, compare_ConfirmPass2Fa.Value.Y);
                    }
                    catch
                    {
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 10.6, 32.4);
                    }
                    KAutoHelper.ADBHelper.InputText(deviceID, "quocsang199698");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                }
                Thread.Sleep(TimeSpan.FromSeconds(5));

                // Press mã qr 2Fa
                try
                {
                    var screen3 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_LongPress2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen3, Variables.BMP_LongPress2Fa);
                    KAutoHelper.ADBHelper.LongPress(deviceID, compare_LongPress2Fa.Value.X, compare_LongPress2Fa.Value.Y, 1000);
                }
                catch
                {
                    KAutoHelper.ADBHelper.LongPress(deviceID, 146, 679, 1000);
                }

                // Get link chứa mã 2Fa
                try
                {
                    var screen4 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_GetLinkCode2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen4, Variables.BMP_GetLinkCode2Fa);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_GetLinkCode2Fa.Value.X, compare_GetLinkCode2Fa.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 42.5, 39.5);
                }

                // Tách mã 2fa từ link vừa get đc
                string Code2Fa = "";
                Exception threadEx = null;
                Thread staThread = new Thread(
                    delegate ()
                    {
                        try
                        {
                            Code2Fa = System.Windows.Clipboard.GetText();
                            string[] words = Code2Fa.Split('%');

                            foreach (string word in words)
                            {
                                if (word.Length == 34)
                                {
                                    Code2Fa = word.Substring(2, 32);
                                }
                            }
                        }

                        catch (Exception ex)
                        {
                            threadEx = ex;
                        }
                    });
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
                staThread.Join();

                // điền mã xác thực xác nhận setup 2Fa
                KAutoHelper.ADBHelper.Swipe(deviceID, 260, 870, 260, 125);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                try
                {
                    var screen5 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_Next2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen5, Variables.BMP_Next2Fa);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_Next2Fa.Value.X, compare_Next2Fa.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.4, 60.4);
                }
                Thread.Sleep(TimeSpan.FromSeconds(5));
                try
                {
                    var screen5 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_EditCode2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen5, Variables.BMP_EditCode2Fa);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_EditCode2Fa.Value.X, compare_EditCode2Fa.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 19.7, 58.7);
                }
                SimAPI ma2Fa = new SimAPI();
                Dictionary<string, dynamic>  ma30s = ma2Fa.CheckRequest2Fa(Code2Fa);
                KAutoHelper.ADBHelper.InputText(deviceID, ma30s["key"]);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.0, 77.4);
            }
            catch { /* Lỗi setup2Fa */ }
        }

        /// <summary>
        /// Cập nhập ảnh đại diện
        /// </summary>
        /// <param name="linkImage"></param>
        /// <returns></returns>
        public void updateAvatar(string linkImage)
        {
            try
            {
                // Save Image
                loadLink(link: linkImage);
                KAutoHelper.ADBHelper.LongPress(deviceID, 243, 178, 1000);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_SaveImage = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_SaveImage);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_SaveImage.Value.X, compare_SaveImage.Value.Y);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_ConfirmSaveImage = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, Variables.BMP_ConfirmSaveImage);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_ConfirmSaveImage.Value.X, compare_ConfirmSaveImage.Value.Y);
                // Up avatar
                loadLink(link: "https://mbasic.facebook.com/profile_picture");
                // Click nút chọn ảnh 
                var screen2 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_ChooseImage = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, Variables.BMP_ChooseImage);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_ChooseImage.Value.X, compare_ChooseImage.Value.Y);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                // Kiểm tra có ở trong file ảnh gần đây không
                var screen3 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_CheckUpImage = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen3, Variables.BMP_CheckUpImage);
                if (compare_CheckUpImage == null)
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 8.2, 8.7);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
                // Chọn ảnh tải mới nhất
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 27.4, 17.8);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 81.9, 17.8);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                // xác nhận cập nhập avatar
                var screen4 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_ConfirmUpAvatar = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen4, Variables.BMP_ConfirmUpAvatar);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_ConfirmUpAvatar.Value.X, compare_ConfirmUpAvatar.Value.Y);

            }
            catch { }
        }

    

        /// <param name="link"></param>
        private void loadLink(string link)
        {
            // Click thanh địa chỉ
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 20.3, 7.1);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            // Dán địa chỉ 
            KAutoHelper.ADBHelper.InputText(deviceID, link);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            // Enter load địa chỉ
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }
    }
    

}
