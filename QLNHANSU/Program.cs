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

            while (true) // Vòng lặp vĩnh viễn để quản lý đăng nhập - đăng xuất
            {
                // Hiển thị form đăng nhập
                using (frmLOGIN loginForm = new frmLOGIN())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK) // Đăng nhập thành công
                    {
                        // Khi đăng nhập thành công, mở Form1
                        using (Form1 mainForm = new Form1(_user)) // _user là thông tin người dùng
                        {
                            if (mainForm.ShowDialog() == DialogResult.Cancel) // Nhấn nút Đăng xuất
                            {
                                continue; // Quay lại form đăng nhập
                            }
                        }
                    }
                    else
                    {
                        // Nếu đóng form đăng nhập hoặc đăng nhập thất bại, thoát ứng dụng
                        break;
                    }
                }
            }

            // Thoát ứng dụng
            Application.Exit();
        }

    }
}
