using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace fosterAccount
{
    public class SharePost
    {
        private string deviceID;
        private int browser;
        private string statusGroup = "";


        public SharePost(string _deviceID, int _browser)
        {
            deviceID = _deviceID;
            browser = _browser;
            // Try cập browser
            KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p mark.via.gp0{browser.ToString()} -c android.intent.category.LAUNCHER 1");
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        /// <summary>
        /// Kiểm tra trang thái nhóm
        /// + "Tham gia nhóm" : chưa tham gia --> gửi yêu cầu tham gia
        /// + "Đã yêu cầu tham gia nhóm" : đợi duyệt --> lâu quá thì chuyển nhóm khác
        /// + "Nhóm đã được tham gia - sẵn sàng share" : đã được tham gia --> sẵn sàng share
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public string checkGroup(string groupId) //362228173958804
        {
            try
            {
                // Load link đến group 
                loadLink(link: $"https://mbasic.facebook.com/{groupId}?view=info");
                // check trạng thái group
                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var compare_JoinGroup = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_JoinGroup);
                var compare_CancelRequestJoinGroup = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_CancelRequestJoinGroup);
                if (compare_JoinGroup != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, compare_JoinGroup.Value.X, compare_JoinGroup.Value.Y);
                    statusGroup = "Đã gửi yêu cầu tham gia";
                }
                else if (compare_CancelRequestJoinGroup != null)
                {
                    statusGroup = "Đang đợi xét duyệt";
                }
                else
                {
                    statusGroup = "Đã tham gia";
                }
            }
            catch
            {

            }
            return statusGroup;
        }

        /// <summary>
        /// Chia sẽ bài viết vào nhóm
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        public void shareGroup(string groupId, string postId)
        {
            try
            {
                if (statusGroup == "Đã tham gia")
                {
                    // Load link đến group 
                    loadLink(link: $"https://mbasic.facebook.com/composer/mbasic/?c_src=share&referrer=feed&sid={postId}&m=group&target={groupId}");
                    // Share vào bào group
                    var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_ShareGroup = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_ShareGroup);
                    if (compare_ShareGroup != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, compare_ShareGroup.Value.X, compare_ShareGroup.Value.Y);
                        Thread.Sleep(TimeSpan.FromSeconds(7));
                        // Get id bài vừa share
                        string linkURL = "";
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 15.6, 7.6);
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        KAutoHelper.ADBHelper.LongPress(deviceID, 90, 70, 1000);
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        KAutoHelper.ADBHelper.TapByPercent(deviceID, 80.0, 8.8);

                        Exception threadEx = null;
                        Thread staThread = new Thread(
                            delegate ()
                            {
                                try
                                {
                                    linkURL = System.Windows.Clipboard.GetText();
                                }
                                catch (Exception ex)
                                {
                                    threadEx = ex;
                                }
                            });
                        staThread.SetApartmentState(ApartmentState.STA);
                        staThread.Start();
                        staThread.Join();

                        // Tách id vài share từ link
                        List<string> shareGroupId = new List<string>();
                        foreach (string value in Regex.Split(linkURL, @"\D+"))
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                shareGroupId.Add(value);
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch { }
        }
      
        /// <summary>
        /// Xoá bài đã share
        /// </summary>
        /// <param name="sharePostId"></param>
        /// <returns></returns>
        public void deleteSharePost(String sharePostId)
        {
            try
            {
                // Load link đến bài cần xoá 
                loadLink(link: $"https://mbasic.facebook.com/{sharePostId}");
                // Xoá bài share
                var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var conpare_DeleteSharePost = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, Variables.BMP_DeleteSharePost);
                if (conpare_DeleteSharePost != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, conpare_DeleteSharePost.Value.X, conpare_DeleteSharePost.Value.Y);
                }
                else
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 17.8, 23.4);
                }
                Thread.Sleep(TimeSpan.FromSeconds(3));
                // Xác nhận xoá bài share
                var screen2 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var conpare_ConfirmDeleteSharePost = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen2, Variables.BMP_ConfirmDeleteSharePost);
                if (conpare_DeleteSharePost != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, conpare_ConfirmDeleteSharePost.Value.X, conpare_ConfirmDeleteSharePost.Value.Y);
                }
                else
                {
                    KAutoHelper.ADBHelper.TapByPercent(deviceID, 6.8, 32.1);
                }
            }
            catch { }
        }


        /// <summary>
        /// Share bài viết về trang cá nhân
        /// </summary>
        /// <param name="sharePostId"></param>
        /// <returns></returns>
        public void shareWall()
        {

        }

        /// <summary>
        /// Hàm load link 
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
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
