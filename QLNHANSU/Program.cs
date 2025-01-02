using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DATALAYER;
using DevExpress.Skins;
using DevExpress.UserSkins;

namespace QLNHANSU
{

    internal static class Program
    {

        internal static TAIKHOAN _user;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Hiển thị form đăng nhập
            frmLOGIN loginForm = new frmLOGIN();
            
            
            if (loginForm.ShowDialog() == DialogResult.OK)  // Kiểm tra khi đăng nhập thành công
            {
                // Nếu đăng nhập thành công, mở form chính
                Application.Run(new Form1(_user));
            }
            else
            {
                // Nếu đăng nhập thất bại hoặc form đăng nhập bị đóng, ứng dụng sẽ dừng lại
                Application.Exit();
            }
            
        }
    }
}
