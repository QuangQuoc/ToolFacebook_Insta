using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fosterAccount
{
    public class Foster
    {
        private string deviceID;
        private int browser;

        public Foster(string _deviceID, int _browser)
        {
            deviceID = _deviceID;
            browser = _browser;
            // Try cập browser
            KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p mark.via.gp0{browser.ToString()} -c android.intent.category.LAUNCHER 1");
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
        

        /// <summary>
        /// Huỷ các lời mời đã gửi kết bạn quá lâu
        /// </summary>
        /// <param name="times"></param>
        /// <param name="timeSleep"></param>
        /// <returns></returns>
        public void outGoingFriend(int times, int timeSleep)
        {
            try
            {
                // Load link out Friend
                loadLink(link: "https://mbasic.facebook.com/friends/center/requests/outgoing");
                for (int i = 1; i <= times; i++)
                {
                    var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_OutGiongFriend = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_OutGoringFriend);
                    if (compare_OutGiongFriend != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, compare_OutGiongFriend.Value.X, compare_OutGiongFriend.Value.Y);
                        Thread.Sleep(TimeSpan.FromSeconds(Variables.random.Next(timeSleep / 2, timeSleep + timeSleep / 2)));
                    }
                    else { break; }
                }
            }
            catch 
            {
                /* Lỗi xác nhận lời mời kết bạn */
            }
        }

        /// <summary>
        /// Xác nhận lời mời kết bạn
        /// </summary>
        /// <param name="times"></param>
        /// <param name="timeSleep"></param>
        /// <returns></returns>
        public void addFriendRequest(int times, int timeSleep)
        {
            try
            {
                // Load link add Friend Suggesttions
                loadLink(link: "https://mbasic.facebook.com/friends/center/requests");
                // Kết bạn
                for (int i = 1; i <= times; i++)
                {
                    var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_AddFriendRequest = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_AddFriendRequest);
                    if (compare_AddFriendRequest != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, compare_AddFriendRequest.Value.X, compare_AddFriendRequest.Value.Y);
                        Thread.Sleep(TimeSpan.FromSeconds(Variables.random.Next(timeSleep / 2, timeSleep + timeSleep / 2)));
                    }
                    else { break; }
                }
            }
            catch
            {
                /* Lỗi xác nhận lời mời kết bạn */
            }
        }

        /// <summary>
        /// Kết bạn theo gợi ý của fb
        /// </summary>
        /// <param name="times"></param>
        /// <param name="timeSleep"></param>
        /// <returns></returns>
        public void addFriendSuggestions(int times, int timeSleep)
        {
            try
            {
                // Load link add Friend Suggesttions
                loadLink(link: "https://mbasic.facebook.com/friends/center/suggestions");
                // Kết bạn
                for (int i = 1; i <= times; i++)
                {
                    var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_AddFriendSuggestions = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_AddFriendSuggrestions);
                    if (compare_AddFriendSuggestions != null)
                    {
                        KAutoHelper.ADBHelper.Tap(deviceID, compare_AddFriendSuggestions.Value.X, compare_AddFriendSuggestions.Value.Y);
                        Thread.Sleep(TimeSpan.FromSeconds(Variables.random.Next(timeSleep / 2, timeSleep + timeSleep / 2)));
                    }
                    else { break; }
                }
            }
            catch
            {
                /* Lỗi Kết bạn theo gợi ý của fb */
            }
        }

        /// <summary>
        /// Lướt newsFeed 
        /// </summary>
        /// <returns></returns>
        public void newsFeed()
        {
            try
            {
                // Load link lướt newFeed
                loadLink(link: "https://mbasic.facebook.com/stories.php");
                bool checkLike = false;
                for (int i=0; i<=2; i++)
                {
                    while (true)
                    {
                        // kiểm tra button chuyển tin newsfeed
                        var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                        var compare_NextNewsfeed = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_NextNewsFeed);
                        var compare_LikeNewsfeed = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_LikeNewsFeed);

                        if (compare_NextNewsfeed != null)
                        {
                            KAutoHelper.ADBHelper.Tap(deviceID, compare_NextNewsfeed.Value.X, compare_NextNewsfeed.Value.Y);
                            checkLike = false;
                            break;
                        }
                        else
                        {
                            // Kéo lướt newsFeed
                            if ((compare_LikeNewsfeed != null) && (checkLike == false))
                            {
                                // Like bài viết 
                                KAutoHelper.ADBHelper.Tap(deviceID, compare_LikeNewsfeed.Value.X, compare_LikeNewsfeed.Value.Y);
                                checkLike = true;
                                Thread.Sleep(TimeSpan.FromSeconds(5));
                            }
                            KAutoHelper.ADBHelper.SwipeByPercent(deviceID, 50, 87.6, 50, 14, 250);
                            Thread.Sleep(TimeSpan.FromSeconds(3));
                        }
                    }
                    // Kiểm tra còn newsFeed không
                    var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                    var compare_CheckNewsFeed = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, Variables.BMP_CheckNewsFeed);
                    if (compare_CheckNewsFeed != null)
                    {
                        break;
                    }
                }
                // Xem tất cả thông báo
                loadLink(link: "https://mbasic.facebook.com/notifications");
                KAutoHelper.ADBHelper.TapByPercent(deviceID, 23.8, 23.8);
            }
            catch
            {
                /* Lỗi lướt newFeed */
            }
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
