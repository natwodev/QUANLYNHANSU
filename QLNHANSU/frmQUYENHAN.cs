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
    public partial class frmQUYENHAN : DevExpress.XtraEditors.XtraForm
    {

        public frmQUYENHAN()
        {
            InitializeComponent();
        }
        dbQUYENHAN _quyenhan;
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

        }
        private void frmQUYENHAN_Load(object sender, EventArgs e)
        {

            _them = false;
            _quyenhan = new dbQUYENHAN();
            _showHide(true);
            loadData();
            splitContainer1.Panel1Collapsed = true;

        }

        void loadData()
        {
            gridControl1.DataSource = _quyenhan.getList();
            gridView1.OptionsBehavior.Editable = false;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var listCheck = _quyenhan.getList();
            if (listCheck == null || listCheck.Count < 4) // Kiểm tra nếu danh sách rỗng hoặc có ít hơn 4 phần tử
            {
                _them = true; // Gán trạng thái cho phép thêm
                _quyenhan = new dbQUYENHAN(); // Khởi tạo lại đối tượng
                loadData(); // Tải lại dữ liệu
                _showHide(false);
                splitContainer1.Panel1Collapsed = false;

            }
            else
            {
                MessageBox.Show("Không thể thêm, danh sách đã đủ 4 quyền hạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Kiểm tra xem textEdit1 có trống không
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Chưa có id cần sửa. Vui lòng chọn thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng việc xóa nếu textEdit1 trống
            }
            _showHide(false);
            _them = false;
            splitContainer1.Panel1Collapsed = false;

        }


        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textEdit2.Text))
                {
                    MessageBox.Show("Tên không thể để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng lại nếu text1 trống
                }

                SaveData();
                loadData();
                _them = false;
                _showHide(true);
                // Làm sạch các TextEdit sau khi xóa
                textEdit1.Clear();
                textEdit2.Clear();
                splitContainer1.Panel1Collapsed = true;

            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi trong quá trình thực thi
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(true);
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
                QUYENHAN qh = new QUYENHAN();
                qh.TENQUYEN = textEdit2.Text;
                _quyenhan.Add(qh);
            }
            else
            {
                var qh = _quyenhan.getItem(_id);
                qh.TENQUYEN = textEdit2.Text;
                _quyenhan.Update(qh);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount > -1)
            {
                _id = int.Parse(gridView1.GetFocusedRowCellValue("IDQUYEN").ToString());
                textEdit1.Text = gridView1.GetFocusedRowCellValue("IDQUYEN").ToString();
                textEdit2.Text = gridView1.GetFocusedRowCellValue("TENQUYEN").ToString();
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