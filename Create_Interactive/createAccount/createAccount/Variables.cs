using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace createAccount
{
     public static class Variables
    {
        public static string apiKey = "BTaKJG45nKYfNrYIqYX_MQt6f";

        public static string fbServiceName = "Facebook";

        public static Dictionary<string, dynamic> simServices;

        public static Random random = new Random();

        public static Bitmap
                             // Lấy họ tên
                             BMP_FirstName = (Bitmap)Bitmap.FromFile("Data/button_firstName.png"),
                             BMP_LastNameFemale = (Bitmap)Bitmap.FromFile("Data/button_lastNameFemale.png"),
                             BMP_LastNameMale = (Bitmap)Bitmap.FromFile("Data/button_lastNameMale.png"),
                             // Chọn năm sinh
                             BMP_Year1995 = (Bitmap)Bitmap.FromFile("Data/button_year1995.png"),
                             // Xác nhận tên
                             BMP_ChooseName = (Bitmap)Bitmap.FromFile("Data/button_chooseName.png"),
                             BMP_ConfirmName = (Bitmap)Bitmap.FromFile("Data/button_confirmName.png"),
                             // Điền mã xác thực
                             BMP_EditCode = (Bitmap)Bitmap.FromFile("Data/button_dienMaCode.png"),
                             BMP_VerifyCode = (Bitmap)Bitmap.FromFile("Data/button_xacNhanMaCode.png"),
                             // Thêm 15 bạn khi mới đăng kí
                             BMP_AddFriend = (Bitmap)Bitmap.FromFile("Data/upInfo/button_addFriend.png"),
                             // Button bỏ qua khi cập nhập thông tin
                             BMP_Ignore = (Bitmap)Bitmap.FromFile("Data/upInfo/button_ignore.png"),
                             // Setup 2fa
                             BMP_Confirm2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_dungUngDungXacThuc.png"),
                             BMP_ConfirmPass2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_xacNhanPass2Fa.png"),
                             BMP_LongPress2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_longPress2Fa.png"),
                             BMP_GetLinkCode2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_getLinkCode2Fa.png"),
                             BMP_Next2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_tiepTuc2Fa.png"),
                             BMP_EditCode2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_editCode2Fa.png"),
                             // updateAvatar
                             BMP_SaveImage = (Bitmap)Bitmap.FromFile("Data/upInfo/button_saveImage.png"),
                             BMP_ConfirmSaveImage = (Bitmap)Bitmap.FromFile("Data/upInfo/button_confirmSaveImage.png"),
                             BMP_ChooseImage = (Bitmap)Bitmap.FromFile("Data/upInfo/button_chooseImage.png"), 
                             BMP_ConfirmUpAvatar = (Bitmap) Bitmap.FromFile("Data/upInfo/button_confirmUpAvatar.png"),
                             BMP_CheckUpImage = (Bitmap)Bitmap.FromFile("Data/upInfo/button_checkUpImage.png");
    } 
}
