using CreateAccountsProject.Services;
using CreateAccountsProject.Services.VariableServices;
using CreateAccountsProject.Models;
using CreateAccountsProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private SimThueService simthue = new SimThueService();

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
            if (!ld.Status)
            {
                // Khởi động LD
                LdPlayerService.Run(ld.Name);
                Thread.Sleep(TimeSpan.FromSeconds(DeviceVariablesService.TimeRunDevice));
                //Thread.Sleep(TimeSpan.FromSeconds(5)); // TEST
            }
            // Run app
            // Kiểm tra số browser đã có tài khoản
            // Trong LD đã có thông tin Browser
            for (int i = 0; i < ld.Accounts.Count; i++)
            {
                // TH: Nếu Browser chưa được sử dụng
                if (!ld.Accounts[i].BrowserStatus)
                {
                    bool runOk = false;
                    int nError = 0;
                    while (!runOk)
                    {
                        if (nError == 2)
                        {
                            // Show Error
                            ErrorService.SimThue_GetSmsError();                         
                            return;
                        }
                        // Tạo Account Name
                        AddAccountName(ld.Accounts[i].BrowserName);
                        AddBrithday();
                        string phoneNumber = "";
                        if (SimVariablesService.UseSimThue)
                        {
                            simthue.CreateRequest();
                            int n = 0;
                            while (phoneNumber == "")
                            {
                                // Lỗi lấy sđt 5 lần
                                if (n == 3)
                                {
                                    ErrorService.SimThue_GetNumberError();
                                    return;
                                }
                                DelayService.Seconds(10); //
                                phoneNumber = AddPhoneNumber();
                                // delay ni a
                                if (phoneNumber == "")
                                {
                                    DelayService.Seconds(3);
                                    simthue.CreateRequest();
                                }
                                n++;
                            }
                        }
                        ld.Accounts[i].PhoneNumber = phoneNumber;
                        string pass = AddPassWord();
                        ld.Accounts[i].Password = pass;
                        bool smsOk = RequestSms();
                        // TH không lấy được Message
                        if (!smsOk)
                        {
                            // Xóa browser
                            LdPlayerService.UnInstallApp(ld.Name, ld.Accounts[i].BrowserName);
                            DelayService.Seconds(40);
                            // Cài lại
                            LdPlayerService.InstallApp(ld.Name, ld.Accounts[i].BrowserFileName);
                            DelayService.Seconds(40);
                            // Cho chạy lại trình duyệt này
                            nError++;
                        }
                        else
                        {
                            runOk = true;
                        }
                    }                    
                    UpAddress();
                    string uid = GetUserId();
                    ld.Accounts[i].UserId = uid;
                    string code2Fa = Setup2Fa();
                    ld.Accounts[i].Fb2FACode = code2Fa;
                    // Get link image
                    var dataImage = HttpRequestService.RequestDicData(DeviceVariablesService.GetAvatarUrl);
                    if (dataImage["success"] == true)
                    {
                        UpdateAvatar(dataImage["url"]);
                    }
                    AddFriend();
                    // Cập nhật dữ liệu vào Db
                    ld.ActivedAccounts++;
                    ld.Accounts[i].BrowserStatus = true;
                    devicesRepo.UpdateNewAccount(ld, i);
                }
            }
            // Update Status
            devicesRepo.UpdateStatus(ld.Id, false);           
            LdPlayerService.Quit(ld.Name);
            DeviceVariablesService.ThreadRunning -= 1;
        }

        /// <summary>
        /// Tạo tên tài khoản
        /// </summary>
        /// <param name="browserName"></param>
        public void AddAccountName(string browserName)
        {
            string deviceID = ld.DeviceIp;
            // Set họ 
            KAutoHelper.ADBHelper.ExecuteCMD("adb shell monkey -p com.example.namefacebook -c android.intent.category.LAUNCHER 1");
            DelayService.Seconds(5);
            try
            {
                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_firstName = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BMPVariablesService.BMP_FirstName);
                DelayService.Seconds(1);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_firstName.Value.X, compare_firstName.Value.Y);
            }
            catch
            {
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 48.6, 23.7);
            }
            DelayService.Seconds(1);
            // Load vào web đăng ký
            KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p {browserName} -c android.intent.category.LAUNCHER 1");
            DelayService.Seconds(5);
            loadLink("https://mbasic.facebook.com/reg");
            DelayService.Seconds(2);
            // Get họ
            KAutoHelper.ADBHelper.LongPress(deviceID, 100, 250, 1000);
            DelayService.Seconds(2);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.3, 20.9);
            DelayService.Seconds(2);

            if (random.Next(2) == 0)
            {
                // Set tên nữ
                KAutoHelper.ADBHelper.ExecuteCMD("adb shell monkey -p com.example.namefacebook -c android.intent.category.LAUNCHER 1");
                DelayService.Seconds(5);
                try
                {
                    var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_lastNameFemale = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, BMPVariablesService.BMP_LastNameFemale);
                    DelayService.Seconds(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_lastNameFemale.Value.X, compare_lastNameFemale.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.1, 32.1);
                }
                DelayService.Seconds(1);
                // Vào lại trang đăng ký
                KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p {browserName} -c android.intent.category.LAUNCHER 1");
                DelayService.Seconds(5);
                // Get tên nữ
                KAutoHelper.ADBHelper.LongPress(deviceID, 100, 333, 1000);
                DelayService.Seconds(2);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.0, 29.9);
                DelayService.Seconds(1);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.0, 51.5);
            }
            else
            {
                // Set tên nam
                KAutoHelper.ADBHelper.ExecuteCMD("adb shell monkey -p com.example.namefacebook -c android.intent.category.LAUNCHER 1");
                DelayService.Seconds(5);
                try
                {
                    var screen2 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_lastNameMale = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, BMPVariablesService.BMP_LastNameMale);
                    DelayService.Seconds(1);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_lastNameMale.Value.X, compare_lastNameMale.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 49.1, 39.9);
                }
                DelayService.Seconds(1);
                KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p {browserName} -c android.intent.category.LAUNCHER 1");
                DelayService.Seconds(5);
                // Get tên nam
                KAutoHelper.ADBHelper.LongPress(deviceID, 100, 333, 1000);
                DelayService.Seconds(2);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 9.0, 29.9);
                DelayService.Seconds(1);
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 38.1, 51.5);
            }
        }

        /// <summary>
        /// Hàm ngày tháng năm sinh 
        /// </summary>
        /// <returns></returns>
        private void AddBrithday()
        {
            string deviceID = ld.DeviceIp;
            // Chọn ngày sinh
            int[] y = { 885, 790, 690, 590, 490, 390, 290, 190, 90 };
            DelayService.Seconds(2);
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 14.5, 66.2);
            DelayService.Seconds(2);
            KAutoHelper.ADBHelper.Tap(deviceID, 150, y[random.Next(y.Length)]);
            DelayService.Seconds(2);
            // Chọn tháng sinh
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 36.5, 66.2);
            DelayService.Seconds(2);
            KAutoHelper.ADBHelper.Tap(deviceID, 150, y[random.Next(y.Length)]);
            DelayService.Seconds(2);
            // Chọn năm sinh nếu mặc định năm sinh 2020 thì swipe
            KAutoHelper.ADBHelper.TapByPercent(deviceID, 59.0, 66.2);
            DelayService.Seconds(2);
            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
            var compare_Year1995 = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BMPVariablesService.BMP_Year1995);
            
            if (compare_Year1995 == null)
            {
                KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 51.3, 94.3, 51.3, 52);
                DelayService.Seconds(1);
            }
            KAutoHelper.ADBHelper.Tap(deviceID, 150, y[random.Next(y.Length)]);
        }

        /// <summary>
        /// Thêm mật khẩu
        /// </summary>
        /// <returns>Password</returns>
        private string AddPassWord()
        {
            string password = DeviceVariablesService.Password;
            DelayService.Seconds(1);
            KAutoHelper.ADBHelper.TapByPercent(ld.DeviceIp, 17.8, 75.2);
            DelayService.Seconds(1);
            KAutoHelper.ADBHelper.InputText(ld.DeviceIp, password);
            DelayService.Seconds(1);
            KAutoHelper.ADBHelper.Key(ld.DeviceIp, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
            DelayService.Seconds(10);
            return password;
        }

        /// <summary>
        /// Hàm lấy sdt
        /// </summary>
        /// <returns></returns>
        private string AddPhoneNumber()
        {
            // click button sdt
            KAutoHelper.ADBHelper.TapByPercent(ld.DeviceIp, 11.7, 43.3);
            DelayService.Seconds(1);
            // điền sdt
            // TH: Sử dụng Sim thuê Service
            string phoneNumber = "";
            if (SimVariablesService.UseSimThue)
            {
                int n = 0;
                while(phoneNumber == "" && n < 3)
                {
                    phoneNumber = simthue.GetNumber();
                    DelayService.Seconds(10);
                    n++;
                }
                KAutoHelper.ADBHelper.InputText(ld.DeviceIp, phoneNumber);
            }
            return phoneNumber;
        }


        /// <summary>
        /// Hàm lấy mã xác thực
        /// </summary>
        /// <returns></returns>
        private bool RequestSms()
        {
            var screen = KAutoHelper.ADBHelper.ScreenShoot(ld.DeviceIp);
            var compare_chooseName = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BMPVariablesService.BMP_ChooseName);
            var compare_confirmName = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BMPVariablesService.BMP_ConfirmName);
            if (compare_confirmName != null)
            {
                KAutoHelper.ADBHelper.Tap(ld.DeviceIp, compare_chooseName.Value.X, compare_chooseName.Value.Y);
                DelayService.Seconds(1);
                KAutoHelper.ADBHelper.Tap(ld.DeviceIp, compare_confirmName.Value.X, compare_confirmName.Value.Y);
                DelayService.Seconds(30);
                loadLink("mbasic.facebook.com/confirmemail.php");
                DelayService.Seconds(10);
            }
            else
            {
                // click button đăng nhập 1 lần
                KAutoHelper.ADBHelper.TapByPercent(ld.DeviceIp, 48.9, 55.1);
                DelayService.Seconds(5);
            }
            try
            {
                var screen2 = KAutoHelper.ADBHelper.ScreenShoot(ld.DeviceIp);
                var compare_editCode = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, BMPVariablesService.BMP_EditCode);
                DelayService.Seconds(1);
                KAutoHelper.ADBHelper.Tap(ld.DeviceIp, compare_editCode.Value.X, compare_editCode.Value.Y);
            }
            catch
            {
                KAutoHelper.ADBHelper.TapByPercent(ld.DeviceIp, 15.9, 28.6);
            }
            KAutoHelper.ADBHelper.TapByPercent(ld.DeviceIp, 15.9, 28.6);
            DelayService.Seconds(1);
            string sms = simthue.GetSms();
            if (sms == null)
            {
                return false;
            }
            KAutoHelper.ADBHelper.InputText(ld.DeviceIp, sms);
            DelayService.Seconds(1);
            KAutoHelper.ADBHelper.Key(ld.DeviceIp, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
            DelayService.Seconds(5);
            return true;
        }

        public void AddFriend()
        {
            string deviceID = ld.DeviceIp;
            try
            {
                string[] nameFriend = { "Linh", "manh", "thuong", "hoai", "sang", "quoc", "vu", "tuan", "nga", "hung",
                                    "Dong", "ly", "tan", "mai", "Nhi", "Hoai", "Thanh", "Cat", "Trang", "Thao", "Nguyen"};
                Thread.Sleep(TimeSpan.FromSeconds(5));
                for (int i = 0; i <= 2; i++)
                {
                    loadLink("https://mbasic.facebook.com/friends/center/search");
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 16.4, 37.6);
                    KAutoHelper.ADBHelper.InputText(deviceID, nameFriend[random.Next(nameFriend.Length)]);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    for (int j = 0; j <= 5; j++)
                    {
                        try
                        {
                            var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                            var compare_addFriend = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BMPVariablesService.BMP_AddFriend);
                            KAutoHelper.ADBHelper.Tap(deviceID, compare_addFriend.Value.X, compare_addFriend.Value.Y);
                            Thread.Sleep(TimeSpan.FromSeconds(random.Next(100, 130)));
                        }
                        catch { break; }
                    }
                }
            }
            catch { /* Lỗi addFriend */ }

        }

        public void UpAddress()
        {
            string deviceID = ld.DeviceIp;
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                loadLink("https://mbasic.facebook.com/profile/questions/view");
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 14.8, 23.4);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                while (true)
                {
                    var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_ignore = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BMPVariablesService.BMP_Ignore);
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

        public string GetUserId()
        {
            string deviceID = ld.DeviceIp;
            try
            {
                // load đến link chứa uid
                Thread.Sleep(TimeSpan.FromSeconds(3));
                loadLink("https://mbasic.facebook.com/profile");
                try
                {
                    var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_LoadLinkGetId = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, BMPVariablesService.BMP_LoadLinkGetId);
                    if (compare_LoadLinkGetId != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, compare_LoadLinkGetId.Value.X, compare_LoadLinkGetId.Value.Y);
                    }
                    else
                    {
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 37.3, 16.6);
                    }
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 37.3, 16.6);
                }
                Thread.Sleep(TimeSpan.FromSeconds(10));
                // Get uid từ link
                // Lấy quyền sử dụng Clipboard
                // - Chờ cho đến khi có quyền sử dụng Clipboard
                while (DeviceVariablesService.UseClipboard)
                {
                    DelayService.Seconds(5);
                }
                // - Lấy quyền sử dụng Clipboard
                DeviceVariablesService.UseClipboard = true;
                string linkURL = "";
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 15.6, 7.6);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                KAutoHelper.ADBHelper.LongPress(deviceID, 90, 70, 1000);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 80.0, 8.8);
                // Lấy dữ liệu từ clipboard
                Exception threadEx = null;
                Thread staThread = new Thread(
                    delegate ()
                    {
                        try
                        {
                            linkURL = System.Windows.Forms.Clipboard.GetText();
                            DeviceVariablesService.UseClipboard = false;
                        }
                        catch (Exception ex)
                        {
                            threadEx = ex;
                        }
                    });
                staThread.SetApartmentState(ApartmentState.STA);
                staThread.Start();
                staThread.Join();
                // Tách Uid từ link
                string Uid = null;
                foreach (string value in Regex.Split(linkURL, @"\D+"))
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        if (value.Length >= 15)
                        {
                            Uid = value;
                        }
                    }
                }
                return Uid;
            }
            catch { return null; }
        }

        public string Setup2Fa()
        {
            string deviceID = ld.DeviceIp;
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                loadLink("https://mbasic.facebook.com/security/2fac/setup/intro/");
                // click vào button chuyển đến setup 2fa
                try
                {
                    var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_Confirm2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, BMPVariablesService.BMP_Confirm2Fa);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_Confirm2Fa.Value.X, compare_Confirm2Fa.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 48.3, 67.8);
                }
                Thread.Sleep(TimeSpan.FromSeconds(5));

                // Xác nhận mật khẩu trước khi setup 2fa
                var screen2 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_ConfirmPass2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, BMPVariablesService.BMP_ConfirmPass2Fa);
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

                // Lấy quyền sử dụng Clipboard
                // - Chờ cho đến khi có quyền sử dụng Clipboard
                while(DeviceVariablesService.UseClipboard)
                {
                    DelayService.Seconds(5);
                }
                // - Lấy quyền sử dụng Clipboard
                DeviceVariablesService.UseClipboard = true;
                // Press mã qr 2Fa
                try
                {
                    var screen3 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_LongPress2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen3, BMPVariablesService.BMP_LongPress2Fa);
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
                    var compare_GetLinkCode2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen4, BMPVariablesService.BMP_GetLinkCode2Fa);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_GetLinkCode2Fa.Value.X, compare_GetLinkCode2Fa.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 42.5, 39.5);
                }

                // Tách mã 2fa từ link vừa get đc
                string Code2Fa = null;
                Exception threadEx = null;
                Thread staThread = new Thread(
                    delegate ()
                    {
                        try
                        {
                            Code2Fa = System.Windows.Forms.Clipboard.GetText();
                            // Trả quyền sử dụng ClipBoard
                            DeviceVariablesService.UseClipboard = false;
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
                    var compare_Next2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen5, BMPVariablesService.BMP_Next2Fa);
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
                    var compare_EditCode2Fa = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen5, BMPVariablesService.BMP_EditCode2Fa);
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_EditCode2Fa.Value.X, compare_EditCode2Fa.Value.Y);
                }
                catch
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 19.7, 58.7);
                }
                Dictionary<string, dynamic> ma30s = Check2FAService.GetCode(Code2Fa);
                KAutoHelper.ADBHelper.InputText(deviceID, ma30s["key"]);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 50.0, 77.4);
                return Code2Fa;
            }
            catch 
            { /* Lỗi setup2Fa */
                return null;
            }

        }

        /// <summary>
        /// Cập nhập ảnh đại diện
        /// </summary>
        /// <param name="linkImage"></param>
        /// <returns></returns>
        public void UpdateAvatar(string linkImage)
        {
            string deviceID = ld.DeviceIp;
            try
            {
                // Save Image
                loadLink(link: linkImage);
                KAutoHelper.ADBHelper.LongPress(deviceID, 243, 178, 1000);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_SaveImage = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, BMPVariablesService.BMP_SaveImage);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_SaveImage.Value.X, compare_SaveImage.Value.Y);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_ConfirmSaveImage = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, BMPVariablesService.BMP_ConfirmSaveImage);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_ConfirmSaveImage.Value.X, compare_ConfirmSaveImage.Value.Y);
                // Up avatar
                loadLink(link: "https://mbasic.facebook.com/profile_picture");
                // Click nút chọn ảnh 
                var screen2 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_ChooseImage = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, BMPVariablesService.BMP_ChooseImage);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_ChooseImage.Value.X, compare_ChooseImage.Value.Y);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                // Kiểm tra có ở trong file ảnh gần đây không
                var screen3 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_CheckUpImage = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen3, BMPVariablesService.BMP_CheckUpImage);
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
                var compare_ConfirmUpAvatar = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen4, BMPVariablesService.BMP_ConfirmUpAvatar);
                KAutoHelper.ADBHelper.Tap(deviceID, compare_ConfirmUpAvatar.Value.X, compare_ConfirmUpAvatar.Value.Y);

            }
            catch { }
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
            DelayService.Seconds(1);
            // Dán địa chỉ 
            KAutoHelper.ADBHelper.InputText(deviceID, link);
            DelayService.Seconds(1);
            // Enter load địa chỉ
            KAutoHelper.ADBHelper.Key(deviceID, KAutoHelper.ADBKeyEvent.KEYCODE_ENTER);
            DelayService.Seconds(10);
        }
    }
}
