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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLNHANSU
{
    public partial class frmDIEUCHUYEN : Form
    {
        public frmDIEUCHUYEN()
        {
            InitializeComponent();
        }
        dbNHANVIEN _nhanvien;
        dbNHANVIEN_DIEUCHUYEN _nhanvien_dieuchuyen;
        dbPHONGBAN _phongban;
        bool _them;
        string _SOQD;
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDIEUCHUYEN_Load(object sender, EventArgs e)
        {
            _nhanvien_dieuchuyen = new dbNHANVIEN_DIEUCHUYEN();
            _nhanvien = new dbNHANVIEN();
            _phongban = new dbPHONGBAN();
            _them = false;
            _showHide(true);
            loadData();
            loadNhanVien();
            Loadcombo();
            splitContainer1.Panel1Collapsed = true;
        }
        void loadData()
        {
            gridControl1.DataSource = _nhanvien_dieuchuyen.getListFull();
            gridView1.OptionsBehavior.Editable = false;

        }
        void loadNhanVien()
        {
            searchLookUpEdit1.Properties.DataSource = _nhanvien.getList();
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
            /*
            dateTimePicker1.Enabled = !kt;
            dateTimePicker2.Enabled = !kt;
            dateTimePicker3.Enabled = !kt;
            */
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
            /*
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(6);
            dateTimePicker3.Value = DateTime.Now;
            */
            searchLookUpEdit1.Clear();
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
                _nhanvien_dieuchuyen.Delete(_SOQD, Program._user.MANV);
                loadData();
                textEdit1.Clear();
            }
            string _manv = searchLookUpEdit1.EditValue.ToString();
            int _mapb2 = (int)_nhanvien_dieuchuyen.getItem(_SOQD).MAPB2;
            _nhanvien = new dbNHANVIEN();
            var nv = _nhanvien.getItem(_manv);
            nv.IDPB = _mapb2;
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
                var hd = _nhanvien_dieuchuyen.getItem(_SOQD);
                textEdit1.Text = _SOQD;
                textEdit2.Text = hd.LYDO;
                textEdit3.Text = hd.GHICHU;
                dateTimePicker3.Value = hd.NGAY.Value;
                searchLookUpEdit1.EditValue = hd.MANV;
                comboBox2.SelectedValue = hd.MAPB2;
            }
        }
        void Loadcombo()
        {
            comboBox2.DataSource = _phongban.getList();//phòng ban
            comboBox2.DisplayMember = "TENPB";
            comboBox2.ValueMember = "IDPB";
        }
        void SaveData()
        {
            if (_them)
            {
                NHANVIEN_DIEUCHUYEN nvdc = new NHANVIEN_DIEUCHUYEN();
                nvdc.SOQD = GenerateEmployeeCode(dateTimePicker3.Value);
                nvdc.MANV = searchLookUpEdit1.EditValue.ToString();
                nvdc.NGAY = dateTimePicker3.Value;
                nvdc.LYDO = textEdit2.Text;
                nvdc.GHICHU = textEdit3.Text;
                nvdc.MAPB = _nhanvien.getItem(nvdc.MANV).IDPB;
                nvdc.MAPB2 = (int)comboBox2.SelectedValue;
                nvdc.CREATED = Program._user.MANV;
                nvdc.CREATED_DATE = DateTime.Now;
                _nhanvien_dieuchuyen.Add(nvdc);
            }
            else
            {
                var _nvdc = _nhanvien_dieuchuyen.getItem(_SOQD);
                _nvdc.MANV = searchLookUpEdit1.EditValue.ToString();
                _nvdc.NGAY = dateTimePicker3.Value;
                _nvdc.LYDO = textEdit2.Text;
                _nvdc.GHICHU = textEdit3.Text;
                _nvdc.MAPB = _nhanvien.getItem(_nvdc.MANV).IDPB;
                _nvdc.MAPB2 = (int)comboBox2.SelectedValue;
                _nvdc.UPDATED = Program._user.MANV;
                _nvdc.UPDATED_DATE = DateTime.Now;
                _nhanvien_dieuchuyen.Update(_nvdc);
            }
             string _manv = searchLookUpEdit1.EditValue.ToString();
            int _mapb = (int)comboBox2.SelectedValue;
            _nhanvien = new dbNHANVIEN();
            var nv = _nhanvien.getItem(_manv);
            nv.IDPB = _mapb;
            _nhanvien.Update(nv);
        }
        static string GenerateEmployeeCode(DateTime ngay)
        {
            // Lấy 2 số cuối của năm hiện tại
            string yearSuffix = DateTime.Now.Year.ToString().Substring(2, 2);

            // Lấy ngày giờ phút hiện tại
            string timeNow = DateTime.Now.ToString("ddHHmm").Substring(0, 6); // Lấy 6 ký tự (Ngày + Giờ + Phút)

            // Lấy 2 ký tự đầu của ngày sinh từ DateTime
            string dayOfBirth = ngay.Day.ToString("D2"); // Đảm bảo luôn có 2 chữ số (ví dụ: 01, 02)

            // Kết hợp các thành phần để tạo mã nhân viên (tổng cộng 10 ký tự) và thêm "QD" ở cuối
            string code = $"{yearSuffix}{timeNow}{dayOfBirth}QD";

            return code;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
