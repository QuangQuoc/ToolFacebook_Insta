using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace createAccount
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
            String[] avatar = { "",
                                "https://sohatravel.vn/image/data/hong%20an/2019/thang%201/doan-fresh-studio-innovations-Asia-vui-choi-teambuilding-binh-quoi/6-doan-fresh-studio-innovations-asia-vui-choi-teambuilding-binh-quoi.JPG",
                                "https://diendanteambuilding.com/wp-content/uploads/2018/01/team-building-e1514885351360.jpg",
                                "https://datviettour.com.vn/wp-content/uploads/2016/10/tro-choi-team-building-khoi-dong-phan-1-3.png",
                                "https://pystravel.vn/wp-content/uploads/2017/04/gioi-thieu-pys-travel0082.jpg",
                                "https://sieuthisongkhoe.com/wp-content/uploads/2019/05/team-building-sieu-thi-song-khoe-vung-tau-2018.jpg"};
            List<String> devices = new List<string>();
            // Lấy ra danh sách devices
            devices = KAutoHelper.ADBHelper.GetDevices();
            // Chạy từng device để điều khiển theo kịch bản
            foreach (var deviceID in devices)
            {
                Task t = new Task(() =>
                {
                    // chạy 5 browser
                    for(int i=5; i<=5; i++) 
                    {
                        Regist nick = new Regist(deviceID, i);
                        nick.run();
                        //UpdateInfo upInfo = new UpdateInfo(deviceID, i);
                        //upInfo.upAddress();
                        //upInfo.updateAvatar(avatar[i]);
                        ////upInfo.setup2Fa();
                        //upInfo.addFriend();
                    }
                });
                t.Start();
            }
        }
    }
}
