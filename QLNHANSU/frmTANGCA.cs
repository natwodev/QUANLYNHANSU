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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace QLNHANSU
{
    public partial class frmTANGCA : DevExpress.XtraEditors.XtraForm
    {

        public frmTANGCA()
        {
            InitializeComponent();
        }
        dbTANGCA _tangca;
        dbNHANVIEN _nhanvien;
        dbLOAICA _loaica;
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
        private void frmTANGCA_Load(object sender, EventArgs e)
        {
            _them = false;
            _tangca = new dbTANGCA();
            _nhanvien = new dbNHANVIEN();
            _loaica = new dbLOAICA();
            _showHide(true);
            loadData();
            loadLoaica();
            loadNhanVien(false);
            splitContainer1.Panel1Collapsed = true;
        }
        void loadNhanVien(bool check)
        {
            searchLookUpEdit1.Properties.DataSource = _nhanvien.getListFalse(check);
            searchLookUpEdit1.Properties.ValueMember = "MANV";
            searchLookUpEdit1.Properties.DisplayMember = "HOTEN";
        }

        void loadLoaica()
        {
            comboBox1.DataSource = _loaica.getList();
            comboBox1.ValueMember = "IDLOAICA";
            comboBox1.DisplayMember = "TENLOAICA";
        }
        void loadData()
        {
            gridControl1.DataSource = _tangca.getListFull();
            gridView1.OptionsBehavior.Editable = false;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _showHide(false); //thêm
            textEdit3.Text = string.Empty;
            textEdit1.Text = string.Empty;
            spinEdit1.Text = string.Empty;
            searchLookUpEdit1.Text = string.Empty;
            splitContainer1.Panel1Collapsed = false;
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
                _tangca.Delete(_id, Program._user.MANV);
                loadData();
                textEdit3.Text = string.Empty;
                textEdit1.Text = string.Empty;
                spinEdit1.Text = string.Empty;
                searchLookUpEdit1.Text = string.Empty;
            }
            splitContainer1.Panel1Collapsed = true;

            //xóa
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchLookUpEdit1.Text))
            {
                MessageBox.Show("Không được để trống nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Không được để trống loại ca nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (spinEdit1.EditValue == null || string.IsNullOrWhiteSpace(spinEdit1.EditValue.ToString()))
            {
                MessageBox.Show("Không được để trống số tiền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveData();
            loadData();
            _them = false;
            _showHide(true);//lưu

            textEdit3.Text = string.Empty;
            textEdit1.Text = string.Empty;
            spinEdit1.Text = string.Empty;
            searchLookUpEdit1.Text = string.Empty;
            splitContainer1.Panel1Collapsed = true;

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);//hủy
            splitContainer1.Panel1Collapsed = true;
            textEdit3.Text = string.Empty;
            textEdit1.Text = string.Empty;
            spinEdit1.Text = string.Empty;
            searchLookUpEdit1.Text = string.Empty;
            splitContainer1.Panel1Collapsed = true;

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
                TANGCA tc = new TANGCA();
                tc.IDLOAICA = int.Parse(comboBox1.SelectedValue.ToString());
                tc.SOGIO = int.Parse(spinEdit1.Text);
                tc.MANV = searchLookUpEdit1.EditValue.ToString();
                tc.GHICHU = textEdit3.Text;
                tc.NGAY = DateTime.Now.Day;
                tc.THANG = DateTime.Now.Month;
                tc.NAM = DateTime.Now.Year;
                tc.CREATED = Program._user.MANV;
                tc.CREATED_DATE = DateTime.Now;
                _tangca.Add(tc);
            }
            else
            {
                var tc = _tangca.getItem(_id);
                tc.IDLOAICA = int.Parse(comboBox1.SelectedValue.ToString());
                tc.SOGIO = int.Parse(spinEdit1.Text);
                tc.MANV = searchLookUpEdit1.EditValue.ToString();
                tc.GHICHU = textEdit3.Text;
                tc.NGAY = DateTime.Now.Day;
                tc.THANG = DateTime.Now.Month;
                tc.NAM = DateTime.Now.Year;
                tc.UPDATED = Program._user.MANV;
                tc.UPDATED_DATE = DateTime.Now;
                _tangca.Update(tc);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle > -1)
                {
                    _id = int.Parse(gridView1.GetFocusedRowCellValue("IDTC").ToString());
                    textEdit1.Text = gridView1.GetFocusedRowCellValue("IDTC").ToString();
                    textEdit3.Text = gridView1.GetFocusedRowCellValue("GHICHU").ToString();
                    spinEdit1.EditValue = gridView1.GetFocusedRowCellValue("SOGIO");
                    searchLookUpEdit1.EditValue = gridView1.GetFocusedRowCellValue("MANV");
                    comboBox1.SelectedValue = int.Parse(gridView1.GetFocusedRowCellValue("IDLOAICA").ToString());
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged_1(object sender, EventArgs e)
        {

        }
    }
}