using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateAccountsProject.Services.VariableServices
{
    public class BMPVariablesService
    {
        public static Bitmap BMP_FirstName { get; set; }
        public static Bitmap BMP_LastNameFemale { get; set; }
        public static Bitmap BMP_LastNameMale { get; set; }
        public static Bitmap BMP_Year1995 { get; set; }
        public static Bitmap BMP_ChooseName { get; set; }
        public static Bitmap BMP_ConfirmName { get; set; }
        public static Bitmap BMP_EditCode { get; set; }
        public static Bitmap BMP_VerifyCode { get; set; }
        public static Bitmap BMP_AddFriend { get; set; }
        public static Bitmap BMP_Ignore { get; set; }
        public static Bitmap BMP_Confirm2Fa { get; set; }
        public static Bitmap BMP_ConfirmPass2Fa { get; set; }
        public static Bitmap BMP_LongPress2Fa { get; set; }
        public static Bitmap BMP_GetLinkCode2Fa { get; set; }
        public static Bitmap BMP_Next2Fa { get; set; }
        public static Bitmap BMP_EditCode2Fa { get; set; }
        public static Bitmap BMP_LoadLinkGetId { get; set; }
        public static Bitmap BMP_SaveImage { get; set; }
        public static Bitmap BMP_ConfirmSaveImage { get; set; }
        public static Bitmap BMP_ChooseImage { get; set; }
        public static Bitmap BMP_ConfirmUpAvatar { get; set; }
        public static Bitmap BMP_CheckUpImage { get; set; }

        public static void Initial()
        {
            string currentDir = Environment.CurrentDirectory;
            //// Lấy họ tên
            //BMP_FirstName = (Bitmap)Bitmap.FromFile("Data/button_firstName.png");
            //BMP_LastNameFemale = (Bitmap)Bitmap.FromFile("Data/button_lastNameFemale.png");
            //BMP_LastNameMale = (Bitmap)Bitmap.FromFile("Data/button_lastNameMale.png");
            //// Chọn năm sinh
            //BMP_Year1995 = (Bitmap)Bitmap.FromFile("Data/button_yearBrithday.png");
            //// Xác nhận tên
            //BMP_ChooseName = (Bitmap)Bitmap.FromFile("Data/button_chooseName.png");
            //BMP_ConfirmName = (Bitmap)Bitmap.FromFile("Data/button_confirmName.png");
            //// Điền mã xác thực
            //BMP_EditCode = (Bitmap)Bitmap.FromFile("Data/button_dienMaCode.png");
            //BMP_VerifyCode = (Bitmap)Bitmap.FromFile("Data/button_xacNhanMaCode.png");
            //// Thêm 15 bạn khi mới đăng kí
            //BMP_AddFriend = (Bitmap)Bitmap.FromFile("Data/upInfo/button_addFriend.png");
            //// Button bỏ qua khi cập nhập thông tin
            //BMP_Ignore = (Bitmap)Bitmap.FromFile("Data/upInfo/button_ignore.png");
            //// Setup 2fa
            //BMP_Confirm2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_dungUngDungXacThuc.png");
            //BMP_ConfirmPass2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_xacNhanPass2Fa.png");
            //BMP_LongPress2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_longPress2Fa.png");
            //BMP_GetLinkCode2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_getLinkCode2Fa.png");
            //BMP_Next2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_tiepTuc2Fa.png");
            //BMP_EditCode2Fa = (Bitmap)Bitmap.FromFile("Data/2Fa/button_editCode2Fa.png");
            //// Get UID
            //BMP_LoadLinkGetId = (Bitmap)Bitmap.FromFile("Data/GetUserId/button_loadLinkGetId.png");
            //// Up Avatar
            //BMP_SaveImage = (Bitmap)Bitmap.FromFile("Data/upInfo/button_saveImage.png");
            //BMP_ConfirmSaveImage = (Bitmap)Bitmap.FromFile("Data/upInfo/button_confirmSaveImage.png");
            //BMP_ChooseImage = (Bitmap)Bitmap.FromFile("Data/upInfo/button_chooseImage.png");
            //BMP_ConfirmUpAvatar = (Bitmap)Bitmap.FromFile("Data/upInfo/button_confirmUpAvatar.png");
            //BMP_CheckUpImage = (Bitmap)Bitmap.FromFile("Data/upInfo/button_checkUpImage.png");
            // Lấy họ tên
            BMP_FirstName = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\button_firstName.png");
            BMP_LastNameFemale = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\button_lastNameFemale.png");
            BMP_LastNameMale = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\button_lastNameMale.png");
            // Chọn năm sinh
            BMP_Year1995 = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\button_yearBrithday.png");
            // Xác nhận tên
            BMP_ChooseName = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\button_chooseName.png");
            BMP_ConfirmName = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\button_confirmName.png");
            // Điền mã xác thực
            BMP_EditCode = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\button_dienMaCode.png");
            BMP_VerifyCode = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\button_xacNhanMaCode.png");
            // Thêm 15 bạn khi mới đăng kí
            BMP_AddFriend = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\upInfo\button_addFriend.png");
            // Button bỏ qua khi cập nhập thông tin
            BMP_Ignore = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\upInfo\button_ignore.png");
            // Setup 2fa
            BMP_Confirm2Fa = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\2Fa\button_dungUngDungXacThuc.png");
            BMP_ConfirmPass2Fa = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\2Fa\button_xacNhanPass2Fa.png");
            BMP_LongPress2Fa = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\2Fa\button_longPress2Fa.png");
            BMP_GetLinkCode2Fa = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\2Fa\button_getLinkCode2Fa.png");
            BMP_Next2Fa = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\2Fa\button_tiepTuc2Fa.png");
            BMP_EditCode2Fa = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\2Fa\button_editCode2Fa.png");
            // Get UID
            BMP_LoadLinkGetId = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\GetUserId\button_loadLinkGetId.png");
            // Up Avatar
            BMP_SaveImage = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\upInfo\button_saveImage.png");
            BMP_ConfirmSaveImage = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\upInfo\button_confirmSaveImage.png");
            BMP_ChooseImage = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\upInfo\button_chooseImage.png");
            BMP_ConfirmUpAvatar = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\upInfo\button_confirmUpAvatar.png");
            BMP_CheckUpImage = (Bitmap)Bitmap.FromFile(currentDir + @"\Data\upInfo\button_checkUpImage.png");
        }
                             
    }
}
