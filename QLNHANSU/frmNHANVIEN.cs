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

namespace QLNHANSU
{
    public partial class frmNHANVIEN : DevExpress.XtraEditors.XtraForm
    {

        public frmNHANVIEN()
        {
            InitializeComponent();
        }
        dbNHANVIEN _nhanvien;
        dbDANTOC _dantoc;
        dbTONGIAO _tongiao;
        dbCHUCVU _chucvu;
        dbTRINHDO _trinhdo;
        dbPHONGBAN _phongban;
        dbBOPHAN _bophan;
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
            textEdit2.Enabled = !kt;
            textEdit3.Enabled = !kt;
            textEdit4.Enabled = !kt;
            checkBox1.Enabled = !kt;
            comboBox1.Enabled = !kt;//phòng ban
            comboBox4.Enabled = !kt; //trình độ
            comboBox2.Enabled = !kt; //bộ phận
            comboBox3.Enabled = !kt; //chức vụ 
            comboBox5.Enabled = !kt; //dân tộc
            comboBox6.Enabled = !kt; //tôn giáo
            dateTimePicker1.Enabled = !kt;
            simpleButton1.Enabled = !kt;



        }
        private void frmNHANVIEN_Load(object sender, EventArgs e)
        {
            _them = false;
            _nhanvien = new dbNHANVIEN();
             _dantoc = new dbDANTOC();
             _tongiao = new dbTONGIAO();
             _chucvu = new dbCHUCVU();
             _trinhdo = new dbTRINHDO();
             _phongban = new dbPHONGBAN();
             _bophan = new dbBOPHAN();
            _showHide(true);
            loadData();
            Loadcombo();
            splitContainer1.Panel1Collapsed = true; 
        }
        void Loadcombo()
        {
            comboBox1.DataSource = _phongban.getList();//phòng ban
            comboBox1.DisplayMember = "TENPB";
            comboBox1.ValueMember = "IDPB";
            comboBox4.DataSource = _trinhdo.getList(); //trình độ
            comboBox4.DisplayMember = "TENTD";
            comboBox4.ValueMember = "IDTD";
            comboBox2.DataSource = _bophan.getList(); //bộ phận
            comboBox2.DisplayMember = "TENBP";
            comboBox2.ValueMember = "IDBP";
            comboBox3.DataSource = _chucvu.getList(); //chức vụ 
            comboBox3.DisplayMember = "TENCV";
            comboBox3.ValueMember = "IDCV";
            comboBox5.DataSource = _dantoc.getList(); //dân tộc
            comboBox5.DisplayMember = "TENDT";
            comboBox5.ValueMember = "IDDT";
            comboBox6.DataSource = _tongiao.getList(); //tôn giáo
            comboBox6.DisplayMember = "TENTG";
            comboBox6.ValueMember = "IDTG";
        }
        void loadData()
        {
            gridControl1.DataSource = _nhanvien.getList();
            gridView1.OptionsBehavior.Editable = false;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _showHide(false); //thêm
          //  textEdit1.Text = string.Empty;
            _reset();
            splitContainer1.Panel1Collapsed = false;
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            splitContainer1.Panel1Collapsed = false;
            // Kiểm tra xem textEdit1 có trống không
            /*
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Chưa có id cần sửa. Vui lòng chọn thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng việc xóa nếu textEdit1 trống
            }
            */
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
                _nhanvien.Delete(_id);
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
                NHANVIEN nv = new NHANVIEN();
                nv.MANV = GenerateEmployeeCode(dateTimePicker1.Value);
                nv.HOTEN = textEdit1.Text;
                nv.GIOITINH = checkBox1.Checked;
                nv.NGAYSINH = dateTimePicker1.Value;
                nv.DIENTHOAI = textEdit3.Text;
                nv.CCCD = textEdit2.Text;
                nv.DIACHI = textEdit4.Text;
                nv.HINHANH = ImageToBase64(pictureBox1.Image,pictureBox1.Image.RawFormat);

                nv.IDPB = int.Parse(comboBox1.SelectedValue.ToString());//phòng ban
                nv.IDTD = int.Parse(comboBox4.SelectedValue.ToString()); //trình độ
                nv.IDBP = int.Parse(comboBox2.SelectedValue.ToString()); //bộ phận
                nv.IDCV = int.Parse(comboBox3.SelectedValue.ToString()); //chức vụ 
                nv.IDDT = int.Parse(comboBox5.SelectedValue.ToString()); //dân tộc
                nv.IDTG = int.Parse(comboBox6.SelectedValue.ToString()); //tôn giáo
                nv.IDCT = 1;
                _nhanvien.Add(nv);
            }
            else
            {
                var nv = _nhanvien.getItem(_id);
                nv.MANV = GenerateEmployeeCode(dateTimePicker1.Value);
                nv.HOTEN = textEdit1.Text;
                nv.GIOITINH = checkBox1.Checked;
                nv.NGAYSINH = dateTimePicker1.Value;
                nv.DIENTHOAI = textEdit3.Text;
                nv.CCCD = textEdit2.Text;
                nv.DIACHI = textEdit4.Text;
                nv.HINHANH = ImageToBase64(pictureBox1.Image, pictureBox1.Image.RawFormat);

                nv.IDPB = int.Parse(comboBox1.SelectedValue.ToString());//phòng ban
                nv.IDTD = int.Parse(comboBox4.SelectedValue.ToString()); //trình độ
                nv.IDBP = int.Parse(comboBox2.SelectedValue.ToString()); //bộ phận
                nv.IDCV = int.Parse(comboBox3.SelectedValue.ToString()); //chức vụ 
                nv.IDDT = int.Parse(comboBox5.SelectedValue.ToString()); //dân tộc
                nv.IDTG = int.Parse(comboBox6.SelectedValue.ToString()); //tôn giáo
                nv.IDCT = 1;
                _nhanvien.Update(nv);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

            try
            {
                if (gridView1.FocusedRowHandle >= 0) {
                    _id = gridView1.GetFocusedRowCellValue("MANV").ToString();
                    var nv = _nhanvien.getItem(_id);
                    textEdit1.Text = gridView1.GetFocusedRowCellValue("HOTEN").ToString();
                    // nv.MANV = GenerateEmployeeCode(dateTimePicker1.Value);
                    textEdit1.Text = nv.HOTEN;
                    checkBox1.Checked = nv.GIOITINH.Value;
                    dateTimePicker1.Value = nv.NGAYSINH.Value;
                    textEdit3.Text = nv.DIENTHOAI;
                    textEdit2.Text = nv.CCCD;
                    textEdit4.Text = nv.DIACHI;
                    pictureBox1.Image = Base64ToImage(nv.HINHANH);

                    comboBox1.SelectedValue = nv.IDPB;//phòng ban
                    comboBox4.SelectedValue = nv.IDTD; //trình độ
                    comboBox2.SelectedValue = nv.IDBP; //bộ phận
                    comboBox3.SelectedValue = nv.IDCV; //chức vụ 
                    comboBox5.SelectedValue = nv.IDDT; //dân tộc
                    comboBox6.SelectedValue = nv.IDTG; //tôn giáo
                                                       //nv.IDCT = 1;
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
            textEdit2.Clear();
            textEdit3.Clear();
            textEdit4.Clear();
            checkBox1.Checked = false;
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

      
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file (.png,jpg)|*.png;*.jpg";
            openFile.Title = "Chọn ảnh";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFile.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
    }
}