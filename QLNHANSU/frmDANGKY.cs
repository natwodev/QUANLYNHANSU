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
using DATALAYER.context;

namespace QLNHANSU
{
    public partial class frmDANGKY : Form
    {
        dbNHANVIEN _nhanvien;
        dbTAIKHOAN _taikhoan;
        dbQUYENHAN _quyenhan;
        public frmDANGKY()
        {
            InitializeComponent();
        }
        private void frmDANGKY_Load(object sender, EventArgs e)
        {
            _nhanvien = new dbNHANVIEN();
            _quyenhan = new dbQUYENHAN();
            loadNhanVien();
            loadCombo();
        }
        void loadNhanVien()
        {
            searchLookUpEdit1.Properties.DataSource = _nhanvien.getList();
            searchLookUpEdit1.Properties.ValueMember = "MANV";
            searchLookUpEdit1.Properties.DisplayMember = "HOTEN";
        }
        void loadCombo()
        {
            comboBox6.DataSource = _quyenhan.getList();
            comboBox6.DisplayMember =  "TENQUYEN";
            comboBox6.ValueMember = "IDQUYEN";
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string username = textEdit1.Text;
            string password1 = textEdit2.Text;
            string password2 = textEdit3.Text;
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Tên đăng nhập không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu text1 trống
            }
            
            _taikhoan = new dbTAIKHOAN();
            var listTK = _taikhoan.getList();
            var tkk = listTK.FirstOrDefault(x => x.TENDANGNHAP == username);
            if (tkk != null)
            {
                MessageBox.Show("Nhập một tên đăng nhập khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
            if (string.IsNullOrEmpty(textEdit2.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu text1 trống
            }

            if (string.IsNullOrEmpty(textEdit3.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu text1 trống
            }
            string mkm = textEdit2.Text.Trim();
            if (mkm.Length > 50)
            {
                MessageBox.Show("Mật khẩu không được lớn hơn 50 kí tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password1 != password2)
            {
                MessageBox.Show("Mật khẩu không khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (searchLookUpEdit1.EditValue == null)
            {
                MessageBox.Show("Chưa chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox6.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn quyền hạn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string manv = searchLookUpEdit1.EditValue.ToString(); 
            var nvv = listTK.FirstOrDefault(x => x.MANV == manv);
            if (nvv != null)
            {
                MessageBox.Show("Nhân viên này đã có tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TAIKHOAN tk = new TAIKHOAN();
            tk.TENDANGNHAP = textEdit1.Text;
            tk.MATKHAU = textEdit2.Text;
            tk.MANV = searchLookUpEdit1.EditValue.ToString();
            tk.IDQUYEN = int.Parse(comboBox6.SelectedValue.ToString());
            tk.TRANGTHAI = true;
            _taikhoan.Add(tk);
            MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textEdit1.Text = "";
            textEdit2.Text = "";
            textEdit3.Text = "";


        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}




















//NGUYỄN HUỲNH NAM
//TRẦN NHƯ KHÁNH
//LÂM QUỐC ĐẠT 
//NGUYÊN QUANG VINH
