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
using DATALAYER.context;

namespace QLNHANSU
{
    public partial class frmLOAICA : DevExpress.XtraEditors.XtraForm
    {

        public frmLOAICA()
        {
            InitializeComponent();
        }
        dbLOAICA _loaica;
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
            textEdit1.Enabled = !kt;
            spinEdit2.Enabled = !kt;

        }
        private void frmLOAICA_Load(object sender, EventArgs e)
        {
            _them = false;
            _loaica = new dbLOAICA();
            _showHide(true);
            loadData();
        }

        void loadData()
        {
            gridControl1.DataSource = _loaica.getList();
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
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Chưa có id cần xóa. Vui lòng chọn thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _loaica = new dbLOAICA();
            var listDT = _loaica.getList();
            _nhanvien = new dbNHANVIEN();
            int iddt = listDT.FirstOrDefault(x => x.TENLOAICA == textEdit1.Text)?.IDLOAICA ?? 0;
            var listNV = _nhanvien.getList();
            bool isReferenced = listNV.Any(x => x.IDDT == iddt);
            if (isReferenced)
            {
                MessageBox.Show("không thể thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _loaica.Delete(_id);
                loadData();
                textEdit1.Clear();
                spinEdit2.Clear();
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
            textEdit1.Clear();

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
                LOAICA lc = new LOAICA();
                lc.TENLOAICA = textEdit1.Text;
                lc.HESO = float.Parse(spinEdit2.EditValue.ToString());
                _loaica.Add(lc);
            }
            else
            {
                var lc = _loaica.getItem(_id);
                lc.TENLOAICA = textEdit1.Text;
                lc.HESO = float.Parse(spinEdit2.EditValue.ToString());
                _loaica.Update(lc);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.FocusedRowHandle > -1)
                {
                    _id = int.Parse(gridView1.GetFocusedRowCellValue("IDLOAICA").ToString());
                    textEdit1.Text = gridView1.GetFocusedRowCellValue("TENLOAICA").ToString();
                    spinEdit2.EditValue = gridView1.GetFocusedRowCellValue("HESO").ToString();
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

     
    }
}