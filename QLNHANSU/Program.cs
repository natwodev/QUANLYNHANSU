using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DATALAYER;
using DATALAYER.context;
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
            ShowLoginForm();

            // Thoát ứng dụng khi người dùng đóng các form
            Application.Exit();
        }

        private static void ShowLoginForm()
        {
            using (frmLOGIN loginForm = new frmLOGIN())
            {
                if (loginForm.ShowDialog() == DialogResult.OK) // Nếu đăng nhập thành công
                {
                    ShowMainForm(); // Mở Form1
                }
                // Nếu nhấn "Thoát" trong màn hình đăng nhập thì không làm gì và ứng dụng kết thúc
            }
        }

        private static void ShowMainForm()
        {
            using (Form1 mainForm = new Form1(_user))
            {
                DialogResult result = mainForm.ShowDialog();

                if (result == DialogResult.Cancel) // Nếu nhấn "Đăng xuất"
                {
                    ShowLoginForm(); // Quay lại form đăng nhập
                }
                // Nếu nhấn "Thoát" thì không làm gì và ứng dụng kết thúc
            }
        }


    }
}
