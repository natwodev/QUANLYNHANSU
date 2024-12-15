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
    public partial class frmTRINHDO : DevExpress.XtraEditors.XtraForm
    {
        public frmTRINHDO()
        {
            InitializeComponent();
        }
        dbTRINHDO _trinhdo;
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
        private void frmTRINHDO_Load(object sender, EventArgs e)
        {
            _them = false;
            _trinhdo = new dbTRINHDO();
            _showHide(true);
            loadData();
        }

        void loadData()
        {
            gridControl1.DataSource = _trinhdo.getList();
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
            _them = false;
            _showHide(false);//sửa
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _trinhdo.Delete(_id);
                loadData();
                //MessageBox.Show("Xóa thành công", "Thống báo", MessageBoxButtons.OK);
            }


            //xóa
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
                TRINHDO td = new TRINHDO();
                td.TENTD = textEdit1.Text;
                _trinhdo.Add(td);
            }
            else
            {
                var td = _trinhdo.getItem(_id);
                td.TENTD = textEdit1.Text;
                _trinhdo.Update(td);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            _id = int.Parse(gridView1.GetFocusedRowCellValue("IDTD").ToString());
            textEdit1.Text = gridView1.GetFocusedRowCellValue("TENTD").ToString();
        }

        private void frmTRINHDO_Click(object sender, EventArgs e)
        {

        }
    }
}