using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUSINESSLAYER;
using DevExpress.XtraEditors;
using DevExpress.XtraWaitForm;

namespace QLNHANSU
{
    public partial class frmLOGIN : DevExpress.XtraEditors.XtraForm
    {
        dbTAIKHOAN _taikhoan;
        public frmLOGIN()
        {
            InitializeComponent();
        }

        private void frmLOGIN_Load(object sender, EventArgs e)
        {
            textEdit1.Text = "admin";
            textEdit2.Text = "123";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ textbox
            string username = textEdit1.Text.Trim();
            string password = textEdit2.Text.Trim();
            _taikhoan = new dbTAIKHOAN();
            // Kiểm tra thông tin đăng nhập
            var user = _taikhoan.ValidateUser(username, password);
            if (user != null)
            {
                if (user.TRANGTHAI == true) // Assuming TRANGTHAI is a boolean indicating active status
                {
                    // Đăng nhập thành công
                    MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Trả về DialogResult.OK
                    Program._user = user;
                    dbHOPDONG._user = user;
                    Form1._user = user;
                    this.DialogResult = DialogResult.OK;
                    this.Hide();

                }
                else
                {
                    // Tài khoản bị khóa hoặc không hoạt động
                    MessageBox.Show("Tài khoản của bạn đã bị khóa hoặc không hoạt động.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}