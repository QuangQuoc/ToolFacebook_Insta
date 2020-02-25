using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLdPlayer.Services
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
        #endregion
    }
}
