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
using DATALAYER;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace QLNHANSU
{
    public partial class frmDOIMATKHAU : Form
    {

        public frmDOIMATKHAU()
        {
            InitializeComponent();
        }

      
        private dbTAIKHOAN _tk;
        private void frmDOIMATKHAU_Load(object sender, EventArgs e)
        {
            _tk = new dbTAIKHOAN();
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
        //NGUYỄN HUỲNH NAM
        //TRẦN NHƯ KHÁNH
        //LÂM QUỐC ĐẠT 
        //NGUYÊN QUANG VINH
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Mật khẩu cũ không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu text1 trống
            }

            if (string.IsNullOrEmpty(textEdit2.Text))
            {
                MessageBox.Show("Mật khẩu mới không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu text1 trống
            }
            string mkm = textEdit2.Text.Trim();
            if (mkm.Length > 50)
            {
                MessageBox.Show("Mật khẩu không được lớn hơn 50 kí tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var listTk = _tk.getList();
            var tk = listTk.FirstOrDefault(x => x.IDTK == Program._user.IDTK);
            if (tk != null)
            {
                if (tk.MATKHAU == textEdit1.Text)
                {
                    tk.MATKHAU = textEdit2.Text;
                    _tk.Update(tk);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

       
    }
}










//NGUYỄN HUỲNH NAM
//TRẦN NHƯ KHÁNH
//LÂM QUỐC ĐẠT 
//NGUYÊN QUANG VINH