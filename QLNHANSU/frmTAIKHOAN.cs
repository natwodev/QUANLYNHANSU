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
using DevExpress.XtraEditors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BUSINESSLAYER.DATA_OBJECT;

namespace QLNHANSU
{
    public partial class frmTAIKHOAN : Form
    {
        public frmTAIKHOAN()
        {
            InitializeComponent();
        }
        dbTAIKHOAN _taikhoan;
        dbQUYENHAN _quyenhan;   
        string _id;

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTAIKHOAN_Load(object sender, EventArgs e)
        {
            _taikhoan = new dbTAIKHOAN();
            _quyenhan = new dbQUYENHAN();
            loadData();
            loadCombo();
            splitContainer1.Panel1Collapsed = true;

        }
        void loadData()
        {
            gridControl1.DataSource = _taikhoan.getListFull();
            gridView1.OptionsBehavior.Editable = false;
            //_listNVDTO = _nhanvien.getListFull();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false); //thêm
                              //  textEdit1.Text = string.Empty;
            splitContainer1.Panel1Collapsed = false;
            barButtonItem2.Enabled = false;
            textEdit1.Text = string.Empty;
            checkBox1.Checked = false;
            comboBox6.SelectedIndex = -1;
        }
        void _showHide(bool kt)
        {
            barButtonItem1.Enabled = kt;
            barButtonItem2.Enabled = kt;
            barButtonItem3.Enabled = kt;
            barButtonItem4.Enabled = !kt;
            barButtonItem5.Enabled = !kt;
            barButtonItem6.Enabled = kt;
            barButtonItem7.Enabled = kt;
        }
        void loadCombo()
        {
            comboBox6.DataSource = _quyenhan.getList();
            comboBox6.DisplayMember = "TENQUYEN";
            comboBox6.ValueMember = "IDQUYEN";
            // Đặt lại SelectedIndex để không có mục nào được chọn
            comboBox6.SelectedIndex = -1;
        }
        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle >= -1)
                {
                    _id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDTK").ToString();
                    int idd = int.Parse(_id);
                    var tkk = _taikhoan.getItem(idd);
                    var manvValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MANV");
                    textEdit1.Text = manvValue != null ? manvValue.ToString() : string.Empty;
                    textEdit1.Text = tkk?.MANV ?? string.Empty;

                    checkBox1.Checked = tkk.TRANGTHAI.Value;
                    comboBox6.SelectedValue = tkk.IDQUYEN;
                    //   comboBox6.SelectedValue = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "IDQUYEN");
                }

            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Không có giá trị nào được chọn hoặc dữ liệu bị thiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text) && comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Không thể để trống mã/tên/khoa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _taikhoan = new dbTAIKHOAN();
            var resultList = _taikhoan.getListFull();

            if (!string.IsNullOrEmpty(textEdit1.Text))
            {
                resultList = resultList.Where(tk => tk.MANV != null && tk.MANV.Contains(textEdit1.Text)).ToList();
            }
            if (comboBox6.SelectedIndex != -1)
            {
                int quyenhan = (int)comboBox6.SelectedValue;
                resultList = resultList.Where(tk => tk.IDQUYEN == quyenhan).ToList();
            }

            gridControl1.DataSource = resultList;
            //dataGridView1.Columns["MAK"].Visible = false; 
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Mã nhân viên không thể để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu text1 trống
            }
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var listTk = _taikhoan.getList();
            var nvv = listTk.FirstOrDefault(x => x.MANV == textEdit1.Text);
            if (nvv == null)
            {
                MessageBox.Show("Không thể xác định tài khoản ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Ensure Program._user is properly initialized
            if (Program._user == null)
            {
                MessageBox.Show("Không thể xác định tài khoản đang đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var tk = listTk.FirstOrDefault(x => x.MANV == Program._user.MANV);
            if (tk != null && tk.MANV == textEdit1.Text)
            {
                MessageBox.Show("Không thay đổi được tài khoản đang đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveData();
        }

        void SaveData()
        {
            int idd = int.Parse(_id);
            var tk = _taikhoan.getItem(idd);
            tk.IDQUYEN = int.Parse(comboBox6.SelectedValue.ToString());
            tk.TRANGTHAI = checkBox1.Checked;
            _taikhoan.Update(tk);
            MessageBox.Show("Cập nhật tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadData(); // Refresh the data grid
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);//hủy
            splitContainer1.Panel1Collapsed = true;
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
