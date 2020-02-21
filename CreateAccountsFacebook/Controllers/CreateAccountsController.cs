using CreateAccountsProject.Models;
using CreateAccountsProject.Repositories;
using CreateAccountsProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            // Khởi động LD
            ldControl.Run(ld.Name);
            Thread.Sleep(TimeSpan.FromSeconds(VariablesService.timeRunDevice));
            // Run app
            // Kiểm tra số browser đã có tài khoản

            // Tạo các tài khoản còn lại
        }
    }
}
