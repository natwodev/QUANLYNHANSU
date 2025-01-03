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

namespace QLNHANSU
{
    public partial class frmCHUCVU : DevExpress.XtraEditors.XtraForm
    {

        public frmCHUCVU()
        {
            InitializeComponent();
        }
        dbCHUCVU _chucvu;
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

        }
        private void frmCHUCVU_Load(object sender, EventArgs e)
        {
            _them = false;
            _chucvu = new dbCHUCVU();
            _showHide(true);
            loadData();
        }

        void loadData()
        {
            gridControl1.DataSource = _chucvu.getList();
            gridView1.OptionsBehavior.Editable = false;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _showHide(false); //thêm
            textEdit1.Clear();
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
            if (_id <= 0)
            {
                MessageBox.Show("ID không hợp lệ. Vui lòng chọn lại thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _chucvu = new dbCHUCVU();
            var listCV = _chucvu.getList();
            _nhanvien = new dbNHANVIEN();
            int idcv = listCV.FirstOrDefault(x => x.TENCV == textEdit1.Text)?.IDCV ?? 0;
            var listNV = _nhanvien.getList();
            bool isReferenced = listNV.Any(x => x.IDCV == idcv);
            if (isReferenced)
            {
                MessageBox.Show("Chức vụ này đã tồn tại trên bảng khác nên không thể thể xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _chucvu.Delete(_id);
                loadData();
                textEdit1.Clear();

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
                CHUCVU cv = new CHUCVU();
                cv.TENCV = textEdit1.Text;
                _chucvu.Add(cv);
            }
            else
            {
                var cv = _chucvu.getItem(_id);
                cv.TENCV = textEdit1.Text;
                _chucvu.Update(cv);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

            try
            {
                if (gridView1.RowCount > -1)
                {
                    _id = int.Parse(gridView1.GetFocusedRowCellValue("IDCV").ToString());
                    textEdit1.Text = gridView1.GetFocusedRowCellValue("TENCV").ToString();
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
    }
}