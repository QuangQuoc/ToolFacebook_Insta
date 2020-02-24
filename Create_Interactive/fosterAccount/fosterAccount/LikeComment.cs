using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fosterAccount
{
    public class LikeComment
    {
        private string deviceID;
        private int browser;
        public LikeComment(string _deviceID, int _browser)
        {
            deviceID = _deviceID;
            browser = _browser;
            // Try cập browser
            KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p mark.via.gp0{browser.ToString()} -c android.intent.category.LAUNCHER 1");
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        /// <summary>
        /// Like bài post
        /// </summary>
        /// <param name="fanpageId"></param>
        /// <returns></returns>
        public void likeFanpage(string fanpageId)
        {
            try
            {
                // Load link đến bài cần like
                loadLink(link: $"https://mbasic.facebook.com/{fanpageId}");
                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var conpare_LikeFanpage = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_LikeFanpage);
                if (conpare_LikeFanpage != null)
                {
                    KAutoHelper.ADBHelper.Tap(deviceID, conpare_LikeFanpage.Value.X, conpare_LikeFanpage.Value.Y);
                }
                else { /* Đã được like*/ }
            }
            catch { }
        }
       
            
            /// <summary>
        /// Reactions bài post
        /// + reactionId = 1: Thích
        /// + reactionId = 2: Yêu thích
        /// + reactionId = 3: Haha
        /// + reactionId = 4: Wow
        /// + reactionId = 5: Buồn
        /// + reactionId = 6: Phẫn nộ
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="reactionId"></param>
        /// <returns></returns>
        public void reactionsPost(string postId, int reactionId)
        {
            try
            {
                // Load link đến bài cần like
                loadLink(link: $"https://mbasic.facebook.com/reactions/picker/?is_permalink=1&ft_id={postId}");
                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var conpare_ReactionsPost = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_ReactionsPost);
                if (conpare_ReactionsPost != null)
                {
                    // chọn reaction
                    switch (reactionId)
                    {
                        case 1: KAutoHelper.ADBHelper.TapByPercent(deviceID, 13.1, 18.1); break;
                        case 2: KAutoHelper.ADBHelper.TapByPercent(deviceID, 13.7, 25.6); break;
                        case 3: KAutoHelper.ADBHelper.TapByPercent(deviceID, 12.3, 33.1); break;
                        case 4: KAutoHelper.ADBHelper.TapByPercent(deviceID, 11.2, 41.0); break;
                        case 5: KAutoHelper.ADBHelper.TapByPercent(deviceID, 13.4, 47.7); break;
                        case 6: KAutoHelper.ADBHelper.TapByPercent(deviceID, 13.7, 55.7); break;
                    }
                }
                else { /* Đã được Reactions*/ }
            }
            catch { }
        }

        /// <summary>
        /// Comment bài post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public void commentPost(string postId, string content)
        {
            try
            {
                // Load link đến bài cần like
                loadLink(link: $"https://mbasic.facebook.com/mbasic/comment/advanced/?target_id={postId}&pap&at=compose&photo_comment");
                // Nhập nội dung comment
                var screen = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var conpare_EditComment = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen, Variables.BMP_EditComment);
                KAutoHelper.ADBHelper.Tap(deviceID, conpare_EditComment.Value.X, conpare_EditComment.Value.Y);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                KAutoHelper.ADBHelper.InputText(deviceID, content);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                // Comment
                var screen1 = KAutoHelper.ADBHelper.ScreenShoot(deviceID);
                var conpare_Comment = KAutoHelper.ImageScanOpenCV.FindOutPoint(screen1, Variables.BMP_Comment);
                KAutoHelper.ADBHelper.Tap(deviceID, conpare_Comment.Value.X, conpare_Comment.Value.Y);
            }
            catch { }
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
