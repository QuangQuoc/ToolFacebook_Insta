using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateAccountsProject.Services
{
    public class ErrorService
    {
        #region SIM THUE 
        public static void SimThue_GetNumberError() // DOING
        {
            MessageBox.Show("Lỗi lấy số điện thoại sim thuê", "Lỗi Sim Thuê", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void SimThue_GetSmsError() // DOING
        {
            MessageBox.Show("Lỗi đọc tin nhắn từ Sim Thuê", "Lỗi Sim Thuê", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void UpdateAddress()
        {
            MessageBox.Show("Lỗi cập nhật địa chỉ", "Lỗi Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void GetUserId()
        {
            MessageBox.Show("Lỗi đọc userId", "Lỗi Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Setup2Fa()
        {
            MessageBox.Show("Lỗi cài đặt 2FA", "Lỗi Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void UpdateAvatar()
        {
            MessageBox.Show("Lỗi cập nhật avatar", "Lỗi Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void GetUrlImage()
        {
            MessageBox.Show("Lỗi đọc url ảnh avatar", "Lỗi Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void AddFriends()
        {
            MessageBox.Show("Lỗi thêm bạn bè", "Lỗi Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
        #region Thread
        public static void AbortThread()
        {
            MessageBox.Show("Lỗi hủy thread", "Lỗi Thread", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
        public static void AdbKteam(Exception e)
        {
            MessageBox.Show(e.ToString(), "Lỗi ADB Kteam", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
