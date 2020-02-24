using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace fosterAccount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Button Start
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task t = new Task(() =>
            {
                Auto();
            });
            t.Start();
        }

        void Auto()
        {
            List<String> devices = new List<string>();
            // Lấy ra danh sách devices
            devices = KAutoHelper.ADBHelper.GetDevices();
            // Chạy từng device để điều khiển theo kịch bản
            foreach (var deviceID in devices)
            {
                Task t = new Task(() =>
                {
                    // chạy 5 browser
                    for (int browser = 1; browser <= 5; browser++)
                    {
                        KAutoHelper.ADBHelper.ExecuteCMD($"adb shell monkey -p mark.via.gp0{browser.ToString()} -c android.intent.category.LAUNCHER 1");
                        Foster foster = new Foster(deviceID, browser);
                        foster.newsFeed();
                        LikeComment likeComment = new LikeComment(deviceID, browser);
                        likeComment.reactionsPost(postId: "2528548980733636", reactionId: 2);
                        foster.addFriendRequest(times: 5, timeSleep: 30);
                        foster.addFriendSuggestions(times: 5, timeSleep: 200);

                        //SharePost sharePost = new SharePost(deviceID, browser);

                        //sharePost.checkGroup(groupId: "223475167856228");
                        //sharePost.shareGroup(groupId: "223475167856228", postId: "113499553458620");
                        //sharePost.deleteSharePost(sharePostId: "1236923666511368");

                        
                        //likeComment.likeFanpage(fanpageId: "totokids.quanaotreem");
                        //likeComment.commentPost(postId: "113499553458620", content: "<3");
                        
                    }
                });
                t.Start();
            }
        }
    }
}
