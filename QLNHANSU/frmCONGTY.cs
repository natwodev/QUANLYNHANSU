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

namespace QLNHANSU
{
    public partial class frmCONGTY : DevExpress.XtraEditors.XtraForm
    {

        public frmCONGTY()
        {
            InitializeComponent();
        }
        dbCONGTY _congty;
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
            barButtonItem7.Enabled = kt;
            textEdit1.Enabled = !kt;
            textEdit2.Enabled = !kt;
            textEdit3.Enabled = !kt;
            textEdit4.Enabled = !kt;

        }
        private void frmCONGTY_Load(object sender, EventArgs e)
        {
            _them = false;
            _congty = new dbCONGTY();
            _showHide(true);
            loadData();
        }

        void loadData()
        {
            gridControl1.DataSource = _congty.getList();
            gridView1.OptionsBehavior.Editable = false;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _showHide(false); //thêm
            textEdit1.Text = string.Empty;
            textEdit2.Text = string.Empty;
            textEdit3.Text = string.Empty;
            textEdit4.Text = string.Empty;

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
            _congty = new dbCONGTY();
            var listCTy = _congty.getList();
            _nhanvien = new dbNHANVIEN();
            int idcty = listCTy.FirstOrDefault(x => x.TENCT == textEdit1.Text)?.IDCT ?? 0;
            var listNV = _nhanvien.getList();
            bool isReferenced = listNV.Any(x => x.IDCT == idcty);
            if (isReferenced)
            {
                MessageBox.Show("Công ty đã tồn tại trên bảng khác nên không thể thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _congty.Delete(_id);
                loadData();

                // Làm sạch các TextEdit sau khi xóa
                textEdit1.Clear();
                textEdit2.Clear();
                textEdit3.Clear();
                textEdit4.Clear();
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textEdit1.Text))
                {
                    MessageBox.Show("Tên không thể để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại nếu text1 trống
                }

                SaveData();
                loadData();
                _them = false;
                _showHide(true); // lưu
                                 // Làm sạch các TextEdit sau khi xóa
                textEdit1.Clear();
                textEdit2.Clear();
                textEdit3.Clear();
                textEdit4.Clear();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi trong quá trình thực thi
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                CONGTY ct = new CONGTY();
                ct.TENCT = textEdit1.Text;
                ct.DIENTHOAI = textEdit2.Text;
                ct.EMAIL = textEdit3.Text;
                ct.DIACHI = textEdit4.Text;
                _congty.Add(ct);
            }
            else
            {
                var ct = _congty.getItem(_id);
                ct.TENCT = textEdit1.Text;
                ct.DIENTHOAI = textEdit2.Text;
                ct.EMAIL = textEdit3.Text;
                ct.DIACHI = textEdit4.Text;
                _congty.Update(ct);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (gridView1.RowCount>0 )
                {
                    _id = int.Parse(gridView1.GetFocusedRowCellValue("IDCT").ToString());
                    var cty = _congty.getItem(_id);
                    textEdit1.Text = cty.TENCT;
                    textEdit2.Text = cty.DIENTHOAI;
                    textEdit3.Text = cty.EMAIL;
                    textEdit4.Text = cty.DIACHI;
                    
                    /*
                    textEdit1.Text = gridView1.GetFocusedRowCellValue("TENCT").ToString();
                    textEdit2.Text = gridView1.GetFocusedRowCellValue("EMAIL").ToString();
                    textEdit3.Text = gridView1.GetFocusedRowCellValue("DIENTHOAI").ToString();
                    textEdit4.Text = gridView1.GetFocusedRowCellValue("DIACHI").ToString();
                    */
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

        private void textEdit1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {


        }
    }
}