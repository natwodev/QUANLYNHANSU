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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using QLNHANSU.REPORTS;
using BUSINESSLAYER.DATA_OBJECT;
using DevExpress.XtraReports.UI;
namespace QLNHANSU
{
    public partial class frmHOPDONG : DevExpress.XtraEditors.XtraForm
    {

        public frmHOPDONG()
        {
            InitializeComponent();
        }

        dbHOPDONG _hopdong;
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
            _them = false;
            _showHide(true);
            loadData();
            splitContainer1.Panel1Collapsed = true;
        }
        void loadData()
        {
            gridControl1.DataSource = _hopdong.getList();
            gridView1.OptionsBehavior.Editable = false;
          
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            _showHide(false); //thêm
            _them = true;            //  textEdit1.Text = string.Empty;
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            _them = false;
            _showHide(false);//sửa
           splitContainer1.Panel1Collapsed = false;
            gridControl1.Enabled = true; // Đảm bảo GridControl được bật

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
                _hopdong.Delete(_id,1);
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

            }
            else
            {

            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_them) // Kiểm tra nếu _them là false
                {
                    if (gridView1.FocusedRowHandle >= 0)
                    {
                        _id = gridView1.GetFocusedRowCellValue("SOHD").ToString();
                       
                    }
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

        //Hàm chuyển đổi hình ảnh lưu vào database  
        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                return imageBytes;
            }
        }

        public Image Base64ToImage(byte[] imageBytes)
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        static string GenerateEmployeeCode(DateTime ngaySinh)
        {
            // Lấy 2 số cuối của năm hiện tại
            string yearSuffix = DateTime.Now.Year.ToString().Substring(2, 2);

            // Lấy ngày giờ phút hiện tại
            string timeNow = DateTime.Now.ToString("ddHHmm").Substring(0, 6); // Lấy 6 ký tự (Ngày + Giờ + Phút)

            // Lấy 2 ký tự đầu của ngày sinh từ DateTime
            string dayOfBirth = ngaySinh.Day.ToString("D2"); // Đảm bảo luôn có 2 chữ số (ví dụ: 01, 02)

            // Kết hợp các thành phần để tạo mã nhân viên (tổng cộng 10 ký tự)
            string code = $"{yearSuffix}{timeNow}{dayOfBirth}";

            return code;
        }


        private void textEdit1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit4_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

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
    }
}