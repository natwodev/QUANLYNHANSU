﻿using System;
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
    public partial class frmKYLUAT : Form
    {
        public frmKYLUAT()
        {
            InitializeComponent();
        }
        dbNHANVIEN _nhanvien;
        dbKHENTHUONG_KYLUAT _khenthuong_kyluat;
        bool _them;
        string _SOQD;
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmKYLUAT_Load(object sender, EventArgs e)
        {
            _khenthuong_kyluat = new dbKHENTHUONG_KYLUAT();
            _nhanvien = new dbNHANVIEN();
            _them = false;
            _showHide(true);
            loadData();
            loadNhanVien();
            splitContainer1.Panel1Collapsed = true;
        }
        void loadData()
        {
            gridControl1.DataSource = _khenthuong_kyluat.getItemFull(2);
            gridView1.OptionsBehavior.Editable = false;

        }
        void loadNhanVien()
        {
            searchLookUpEdit1.Properties.DataSource = _nhanvien.getListFull(false);
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
                _khenthuong_kyluat.Delete(_SOQD, Program._user.MANV);
                loadData();
                textEdit1.Clear();
            }


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
                var hd = _khenthuong_kyluat.getItem(_SOQD);
                textEdit1.Text = _SOQD;
                textEdit2.Text = hd.LYDO;
                textEdit3.Text = hd.NOIDUNG;
                dateTimePicker3.Value = hd.NGAY.Value;
                searchLookUpEdit1.EditValue = hd.MANV;
            }
        }
        void SaveData()
        {
            if (_them)
            {
                KHENTHUONG_KYLUAT ktkl = new KHENTHUONG_KYLUAT();
                ktkl.SOQD = code();
                ktkl.MANV = searchLookUpEdit1.EditValue.ToString();
                ktkl.LYDO = textEdit2.Text;
                ktkl.NOIDUNG = textEdit3.Text;
                ktkl.NGAY = dateTimePicker3.Value;
                ktkl.LOAI = 2;
                ktkl.CREATED = Program._user.MANV;
                ktkl.CREATED_DATE = DateTime.Now;
                _khenthuong_kyluat.Add(ktkl);
            }
            else
            {
                var ktkl = _khenthuong_kyluat.getItem(_SOQD);
                ktkl.MANV = searchLookUpEdit1.EditValue.ToString();
                ktkl.NGAY = dateTimePicker3.Value;
                ktkl.LYDO = textEdit2.Text;
                ktkl.NOIDUNG = textEdit3.Text;
                ktkl.UPDATED = Program._user.MANV;
                ktkl.UPDATED_DATE = DateTime.Now;
                _khenthuong_kyluat.Update(ktkl);
            }
        }
        public string code()
        {
            // Tạo instance kết nối cơ sở dữ liệu
            _nhanvien = new dbNHANVIEN();

            // Lấy danh sách nhân viên
            var listKT = _khenthuong_kyluat.getList();

            string maHD;
            if (listKT == null || listKT.Count == 0)
            {
                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                string lastTwoDigits = year.ToString().Substring(2, 2);
                maHD = day.ToString("D2") + month.ToString("D2") + lastTwoDigits + "00001QD2";
            }
            else
            {

                // Lấy mã nhân viên cuối cùng theo thứ tự số học
                var lastEmployee = listKT.OrderBy(x => x.SOQD).Last(); // Sắp xếp dựa trên giá trị chuỗi
                string st = lastEmployee.SOQD;
                maHD = st.Substring(6, st.Length - 9); // Bỏ 6 ký tự đầu và 3 ký tự cuối
                // Chuyển mã cuối cùng sang số và tăng lên 1
                long newCode = long.Parse(maHD) + 1;
                int day = DateTime.Now.Day;
                int month = DateTime.Now.Month;
                int year = DateTime.Now.Year;
                string lastTwoDigits = year.ToString().Substring(2, 2);
                // Định dạng mã mới thành 10 ký tự
                maHD = day.ToString("D2") + month.ToString("D2") + lastTwoDigits.ToString() + newCode.ToString("D5") + "QD2";
            }

            return maHD;
        }
        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

       
    }
}
