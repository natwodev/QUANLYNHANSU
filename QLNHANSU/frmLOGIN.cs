using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace QLNHANSU
{
    public partial class frmLOGIN : DevExpress.XtraEditors.XtraForm
    {
        public frmLOGIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textEdit1.Text.Trim();
            string password = textEdit2.Text.Trim();

            // Giả sử tài khoản hợp lệ là admin / 123
            if (username == "admin" && password == "123")
            {
                // Nếu đăng nhập thành công, trả về DialogResult.OK
                this.DialogResult = DialogResult.OK;
                this.Close();  // Đóng form đăng nhập
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmLOGIN_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}