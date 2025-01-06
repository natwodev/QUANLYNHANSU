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
using QLNHANSU.REPORTS;

namespace QLNHANSU
{
    public partial class frmTHOIVIEC : Form
    {
        public frmTHOIVIEC()
        {
            InitializeComponent();
        }
        dbNHANVIEN _nhanvien;
        dbNHANVIEN_THOIVIEC _nhanvien_thoiviec;
        bool _them;
        string _SOQD;
        
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmTHOIVIEC_Load(object sender, EventArgs e)
        {
            _nhanvien_thoiviec = new dbNHANVIEN_THOIVIEC();
            _nhanvien = new dbNHANVIEN();
            _them = false;
            _showHide(true);
            loadData();
            loadNhanVien(false);
            splitContainer1.Panel1Collapsed = true;
        }
        void loadData()
        {
            gridControl1.DataSource = _nhanvien_thoiviec.getListFull();
            gridView1.OptionsBehavior.Editable = false;

        }
        void loadNhanVien(bool check)
        {
            searchLookUpEdit1.Properties.DataSource = _nhanvien.getListFalse(check);
            searchLookUpEdit1.Properties.ValueMember = "MANV";
            searchLookUpEdit1.Properties.DisplayMember = "HOTEN";
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
            textEdit1.Enabled = !kt;
            gridControl1.Enabled = kt;
            textEdit1.Enabled = !kt;
            textEdit2.Enabled = !kt;
            textEdit3.Enabled = !kt;
          
            searchLookUpEdit1.Enabled = !kt;

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false); //thêm
            _them = true;
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }
        void _reset()
        {
            textEdit1.Clear();
            textEdit2.Clear();
            textEdit3.Clear();
            searchLookUpEdit1.Clear();
            dateTimePicker1.Value = dateTimePicker3.Value.AddDays(45);
            dateTimePicker3.Value = DateTime.Now;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra xem textEdit1 có trống không
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Chưa có id cần sửa. Vui lòng chọn thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng việc sửa nếu textEdit1 trống
            }
            _them = false;
            _showHide(false);//sửa
                             // pictureBox1.Image = _hinh;
            splitContainer1.Panel1Collapsed = false;
            gridControl1.Enabled = true;
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
                _nhanvien_thoiviec.Delete(_SOQD, Program._user.MANV);
                loadData();
                textEdit1.Clear();
            }

            string _manv = searchLookUpEdit1.EditValue.ToString();
            _nhanvien = new dbNHANVIEN();
            var nv = _nhanvien.getItem(_manv);
            nv.THOIVIEC = false;
            _nhanvien.Update(nv);

            //xóa
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (string.IsNullOrEmpty(searchLookUpEdit1.EditValue?.ToString()))
            {
                MessageBox.Show("Không thể để trống nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveData();
            loadData();
            _them = false;
            _showHide(true);//lưu
            textEdit1.Clear();
            splitContainer1.Panel1Collapsed = true;
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);//hủy
            splitContainer1.Panel1Collapsed = true;
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                _SOQD = gridView1.GetFocusedRowCellValue("SOQD").ToString();
                var hd = _nhanvien_thoiviec.getItem(_SOQD);
                textEdit1.Text = _SOQD;
                textEdit2.Text = hd.LYDO;
                textEdit3.Text = hd.GHICHU;
                dateTimePicker3.Value = hd.NGAYNOPDON.Value;
                dateTimePicker1.Value = hd.NGAYNGHI.Value;
                searchLookUpEdit1.EditValue = hd.MANV;
            }
        }
        void SaveData()
        {
            
            if (_them)
            {
                NHANVIEN_THOIVIEC nvtv = new NHANVIEN_THOIVIEC();
                nvtv.SOQD = code();
                nvtv.MANV = searchLookUpEdit1.EditValue.ToString();
                nvtv.LYDO = textEdit2.Text;
                nvtv.GHICHU = textEdit3.Text;
                nvtv.NGAYNOPDON = dateTimePicker3.Value;
                nvtv.NGAYNGHI = dateTimePicker1.Value;
                nvtv.CREATED = Program._user.MANV;
                nvtv.CREATED_DATE = DateTime.Now;
                _nhanvien_thoiviec.Add(nvtv);
            }
            else
            {
                var _nvtv = _nhanvien_thoiviec.getItem(_SOQD);
                _nvtv.MANV = searchLookUpEdit1.EditValue.ToString();
                _nvtv.LYDO = textEdit2.Text;
                _nvtv.GHICHU = textEdit3.Text;
                _nvtv.NGAYNOPDON = dateTimePicker3.Value;
                _nvtv.NGAYNGHI = dateTimePicker1.Value;
                _nvtv.UPDATED = Program._user.MANV;
                _nvtv.UPDATED_DATE = DateTime.Now;
                _nhanvien_thoiviec.Update(_nvtv);
            }
            string _manv = searchLookUpEdit1.EditValue.ToString();
            _nhanvien = new dbNHANVIEN();
            var nv = _nhanvien.getItem(_manv);
            nv.THOIVIEC = true;
            _nhanvien.Update(nv);
        }
        public string code()
        {
            // Tạo instance kết nối cơ sở dữ liệu
            _nhanvien = new dbNHANVIEN();

            // Lấy danh sách nhân viên
            var listKT = _nhanvien_thoiviec.getList();

            string maHD;
            if (listKT == null || listKT.Count == 0)
            {
                // Nếu danh sách trống, mã nhân viên đầu tiên là 0000000001
                maHD = "0000000001QD";
            }
            else
            {

                // Lấy mã nhân viên cuối cùng theo thứ tự số học
                var lastEmployee = listKT.OrderBy(x => x.SOQD).Last(); // Sắp xếp dựa trên giá trị chuỗi
                string st = lastEmployee.SOQD;
                maHD = st.Substring(0, st.Length - 2);
                // Chuyển mã cuối cùng sang số và tăng lên 1
                long newCode = long.Parse(maHD) + 1;
                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                // Định dạng mã mới thành 10 ký tự
                maHD = day.ToString("D2") + month.ToString("D2") + year.ToString("D2") + newCode.ToString("D10") + "QD";
            }

            return maHD;
        }
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
