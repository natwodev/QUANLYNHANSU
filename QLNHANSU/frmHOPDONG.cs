﻿using System;
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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QLNHANSU.REPORTS;
using BUSINESSLAYER.DATA_OBJECT;
using DevExpress.XtraReports.UI;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using DATALAYER.context;
namespace QLNHANSU
{
    public partial class frmHOPDONG : DevExpress.XtraEditors.XtraForm
    {

        public frmHOPDONG()
        {
            InitializeComponent();
        }

        dbHOPDONG _hopdong;
        dbNHANVIEN _nhanvien;
        List<HOPDONG_DTO> _listHD;
        dbCONGTY _congty;
        bool _them;
        string _id;
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
            dateTimePicker1.Enabled = !kt;
            dateTimePicker2.Enabled = !kt;
            dateTimePicker3.Enabled = !kt;
            spinEdit1.Enabled = !kt;
            spinEdit2.Enabled = !kt;
            searchLookUpEdit1.Enabled = !kt;

        }
        private void frmHOPDONG_Load(object sender, EventArgs e)
        {
            _hopdong = new dbHOPDONG();
            _nhanvien = new dbNHANVIEN();
            _congty = new dbCONGTY();
            _them = false;
            _showHide(true);
            loadData();
            loadcongty();
            loadNhanVien();
            splitContainer1.Panel1Collapsed = true;
        }
        void loadNhanVien()
        {
            searchLookUpEdit1.Properties.DataSource = _nhanvien.getListFull(false);
            searchLookUpEdit1.Properties.ValueMember = "MANV";
            searchLookUpEdit1.Properties.DisplayMember = "HOTEN";
        }
        void loadData()
        {
            gridControl1.DataSource = _hopdong.getListFull();
            gridView1.OptionsBehavior.Editable = false;

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

       
        void _reset()
        {
            textEdit1.Clear();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = dateTimePicker1.Value.AddMonths(6);
            dateTimePicker3.Value = DateTime.Now;
            spinEdit1.Text = "1";
            spinEdit2.Text = "1";
            searchLookUpEdit1.Clear();
        }

        public string code()
        {
            // Tạo instance kết nối cơ sở dữ liệu
            _nhanvien = new dbNHANVIEN();

            // Lấy danh sách nhân viên
            var listHD = _hopdong.getList();

            string maHD;

            if (listHD == null || listHD.Count == 0)
            {
                // Nếu danh sách trống, mã nhân viên đầu tiên là 0000000001
                maHD = "0000000001";
            }
            else
            {
                // Lấy mã nhân viên cuối cùng theo thứ tự số học
                var lastEmployee = listHD
                    .OrderBy(x => long.Parse(x.SOHD)) // Sắp xếp dựa trên giá trị số
                    .Last();

                // Chuyển mã cuối cùng sang số và tăng lên 1
                long newCode = long.Parse(lastEmployee.SOHD) + 1;

                // Định dạng mã mới thành 10 ký tự
                maHD = newCode.ToString("D10");
            }

            return maHD;
        }


        private void textEdit1_EditValueChanged_2(object sender, EventArgs e)
        {

        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            _showHide(false); //thêm
            _them = true;
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
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
            dateTimePicker1.Enabled = true;
            gridControl1.Enabled = true;
        }

        private void barButtonItem3_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            // Kiểm tra xem textEdit1 có trống không
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Chưa có id cần xóa. Vui lòng chọn thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng việc xóa nếu textEdit1 trống
            }

            if (MessageBox.Show("Có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _hopdong.Delete(_id,Program._user.MANV);
                loadData();
                textEdit1.Clear();
            }


            //xóa
        }

        private void barButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {

            if (string.IsNullOrEmpty(searchLookUpEdit1.EditValue?.ToString()))
            {
                MessageBox.Show("Không thể để trống nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveData();
            _them = false;
            loadData();
        
            _showHide(true);//lưu
            textEdit1.Clear();
            splitContainer1.Panel1Collapsed = true;
        }

        private void barButtonItem5_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);//hủy
            splitContainer1.Panel1Collapsed = true;
        }

        void loadcongty()
        {
            comboBox1.DataSource = _congty.getList();
            comboBox1.ValueMember = "IDCT";
            comboBox1.DisplayMember = "TENCT";
        }

        private void barButtonItem6_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }
        void SaveData()
        {
            if (_them)
            {
                HOPDONG hd = new HOPDONG();
                hd.SOHD = code();
                hd.NGAYBATDAU = dateTimePicker1.Value;
                hd.NGAYKETTHUC = dateTimePicker2.Value;
                hd.NGAYKY = dateTimePicker3.Value;
                hd.THOIHAN = comboBox6.Text.ToString();
                hd.NOIDUNG = richEditControl1.RtfText;
                hd.HESOLUONG = float.Parse(spinEdit1.EditValue.ToString());
                hd.LANKY = int.Parse(spinEdit2.EditValue.ToString());
                hd.MANV = searchLookUpEdit1.EditValue.ToString();
                hd.IDCT = int.Parse(comboBox1.SelectedValue.ToString());
                hd.CREATED = Program._user.MANV;
                hd.CREATED_DATE = DateTime.Now;
                _hopdong.Add(hd);
            }
            else
            {
                var hd = _hopdong.getItem(_id);
                hd.NGAYBATDAU = dateTimePicker1.Value;
                hd.NGAYKETTHUC = dateTimePicker2.Value;
                hd.NGAYKY = dateTimePicker3.Value;
                hd.THOIHAN = comboBox6.Text;
                hd.HESOLUONG = float.Parse(spinEdit1.EditValue.ToString());
                hd.LANKY = int.Parse(spinEdit2.EditValue.ToString());
                hd.MANV = searchLookUpEdit1.EditValue.ToString();
                hd.NOIDUNG = richEditControl1.RtfText;
                hd.IDCT = int.Parse(comboBox1.SelectedValue.ToString());
                hd.UPDATED = Program._user.MANV;
                hd.UPDATE_DATE = DateTime.Now;
                _hopdong.Update(hd);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                _id = gridView1.GetFocusedRowCellValue("SOHD").ToString();
                var hd = _hopdong.getItem(_id);
                textEdit1.Text = _id;
                dateTimePicker1.Value = hd.NGAYBATDAU.Value;
                dateTimePicker2.Value = hd.NGAYKETTHUC.Value;
                dateTimePicker3.Value = hd.NGAYKY.Value;
                comboBox6.Text = hd.THOIHAN;
                spinEdit1.Text = hd.HESOLUONG.ToString();
                spinEdit2.Text = hd.LANKY.ToString();
                searchLookUpEdit1.EditValue = hd.MANV;
                richEditControl1.RtfText = hd.NOIDUNG;
                _listHD = _hopdong.getItemFull(_id);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void spinEdit1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void richEditControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_id!=null)
            {
                _listHD  = _hopdong.getItemFull(_id);
                rpHOPDONG rpt = new rpHOPDONG(_listHD);
                rpt.ShowRibbonPreview();
            }
            else
            {
                MessageBox.Show("Chưa có hợp đồng nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}