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
using DATALAYER;
using DevExpress.XtraEditors;

namespace QLNHANSU
{
    public partial class frmPHONGBAN : DevExpress.XtraEditors.XtraForm
    {
        public frmPHONGBAN()
        {
            InitializeComponent();
        }
        dbPHONGBAN _phongban;
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
            barButtonItem7.Enabled = kt;
            textEdit1.Enabled = !kt;

        }
        private void frmPHONGBAN_Load(object sender, EventArgs e)
        {
            _them = false;
            _phongban = new dbPHONGBAN();
            _showHide(true);
            loadData();
        }

        void loadData()
        {
            gridControl1.DataSource = _phongban.getList();
            gridView1.OptionsBehavior.Editable = false;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _showHide(false); //thêm
            textEdit1.Text = string.Empty;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra xem textEdit1 có trống không
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Chưa có id cần sửa. Vui lòng chọn thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng việc xóa nếu textEdit1 trống
            }
            _them = false;
            _showHide(false);//sửa
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
                _phongban.Delete(_id);
                loadData();
                //MessageBox.Show("Xóa thành công", "Thống báo", MessageBoxButtons.OK);
            }


            //xóa
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Tên không thể để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu text1 trống
            }
            SaveData();
            loadData();
            _them = false;
            _showHide(true);//lưu

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);//hủy

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
                PHONGBAN pb = new PHONGBAN();
                pb.TENPB = textEdit1.Text;
                _phongban.Add(pb);
            }
            else
            {
                var pb = _phongban.getItem(_id);
                pb.TENPB = textEdit1.Text;
                _phongban.Update(pb);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                _id = int.Parse(gridView1.GetFocusedRowCellValue("IDPB").ToString());
                textEdit1.Text = gridView1.GetFocusedRowCellValue("TENPB").ToString();
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

    }
}