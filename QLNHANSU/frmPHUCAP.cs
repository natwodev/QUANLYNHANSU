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
using DATALAYER;
using BUSINESSLAYER;
using DATALAYER.context;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QLNHANSU
{
    public partial class frmPHUCAP : DevExpress.XtraEditors.XtraForm
    {

        public frmPHUCAP()
        {
            InitializeComponent();
        }
        dbNHANVIEN_PHU _nhanvienphu;
        dbNHANVIEN _nhanvien;
        bool _them;
        int _id;
        void _showHide(bool kt)
        {
            barButtonItem1.Enabled = kt;
            barButtonItem2.Enabled = kt;
            barButtonItem3.Enabled = kt;
            barButtonItem4.Enabled = !kt;
            barButtonItem5.Enabled = !kt;
            barButtonItem6.Enabled = kt;
            spinEdit1.Enabled = !kt;

        }
        private void frmPHUCAP_Load(object sender, EventArgs e)
        {
            _them = false;
            _nhanvienphu = new dbNHANVIEN_PHU();
            _nhanvien = new dbNHANVIEN();
            _showHide(true);
            loadData();
            loadNhanVien(false);
            splitContainer1.Panel1Collapsed = true;
        }
        void loadNhanVien(bool check)
        {
            searchLookUpEdit1.Properties.DataSource = _nhanvien.getListFalse(check);
            searchLookUpEdit1.Properties.ValueMember = "MANV";
            searchLookUpEdit1.Properties.DisplayMember = "HOTEN";
        }

        void loadData()
        {
            gridControl1.DataSource = _nhanvienphu.getListFull();
            gridView1.OptionsBehavior.Editable = false;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _showHide(false); //thêm
            textEdit3.Text = string.Empty;
            textEdit1.Text = string.Empty;
            textEdit2.Text = string.Empty;
            spinEdit1.Text = string.Empty;
            searchLookUpEdit1.Text = string.Empty;

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(false);//sửa
            splitContainer1.Panel1Collapsed = false;

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra xem textEdit1 có trống không
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Chưa có id cần xóa. Vui lòng chọn thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng việc xóa nếu textEdit1 trống
            }
            if (MessageBox.Show("Có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nhanvienphu.Delete(_id,Program._user.MANV);
                loadData();
                textEdit3.Text = string.Empty;
                textEdit1.Text = string.Empty;
                textEdit2.Text = string.Empty;
                spinEdit1.Text = string.Empty;
                searchLookUpEdit1.Text = string.Empty;
            }
            splitContainer1.Panel1Collapsed = true;

            //xóa
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            SaveData();
            loadData();
            _them = false;
            _showHide(true);//lưu

            textEdit3.Text = string.Empty;
            textEdit1.Text = string.Empty;
            textEdit2.Text = string.Empty;
            spinEdit1.Text = string.Empty;
            searchLookUpEdit1.Text = string.Empty;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);//hủy
            splitContainer1.Panel1Collapsed = true;
            textEdit3.Text = string.Empty;
            textEdit1.Text = string.Empty;
            textEdit2.Text = string.Empty;
            spinEdit1.Text = string.Empty;
            searchLookUpEdit1.Text = string.Empty;

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
        void SaveData()
        {
            if (_them)
            {
                NHANVIEN_PHU pc = new NHANVIEN_PHU();
                pc.NGAY = DateTime.Now;
                pc.GHICHU = textEdit3.Text;
                pc.TENPC = textEdit1.Text;
                pc.SOTIEN = float.Parse(spinEdit1.EditValue.ToString());
                pc.MANV = searchLookUpEdit1.EditValue.ToString();
                pc.CREATED = Program._user.MANV;
                pc.CREATED_DATE = DateTime.Now;
                _nhanvienphu.Add(pc);
            }
            else
            {
                var pc = _nhanvienphu.getItem(_id);
                pc.SOTIEN = float.Parse(spinEdit1.EditValue.ToString());
                pc.NGAY = DateTime.Now;
                pc.GHICHU = textEdit3.Text;
                pc.TENPC = textEdit1.Text;
                pc.SOTIEN = float.Parse(spinEdit1.EditValue.ToString());
                pc.MANV = searchLookUpEdit1.EditValue.ToString();
                pc.UPDATED = Program._user.MANV;
                pc.UPDATED_DATE = DateTime.Now;
                _nhanvienphu.Update(pc);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle > -1)
                {
                    _id = int.Parse(gridView1.GetFocusedRowCellValue("IDNVP").ToString());
                    textEdit1.Text = gridView1.GetFocusedRowCellValue("IDNVP").ToString();
                    textEdit3.Text = gridView1.GetFocusedRowCellValue("GHICHU").ToString();
                    spinEdit1.EditValue = gridView1.GetFocusedRowCellValue("SOTIEN");
                    searchLookUpEdit1.EditValue = gridView1.GetFocusedRowCellValue("MANV");
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

        private void frmDANTOC_Click(object sender, EventArgs e)
        {

        }

        private void spinEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}