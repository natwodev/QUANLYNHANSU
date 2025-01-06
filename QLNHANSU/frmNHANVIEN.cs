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
using DATALAYER.context;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using DevExpress.Office.Utils;
namespace QLNHANSU
{
    public partial class frmNHANVIEN : DevExpress.XtraEditors.XtraForm
    {

        public frmNHANVIEN()
        {
            InitializeComponent();
        }
        private dbNHANVIEN _nhanvien;
        private dbDANTOC _dantoc;
        private dbTONGIAO _tongiao;
        private dbCHUCVU _chucvu;
        private dbTRINHDO _trinhdo;
        private dbPHONGBAN _phongban;
        private dbBOPHAN _bophan;
        private dbCONGTY _congty;
        private string _tempMANV;
        // private Image _hinh = null;
        bool _them;
        string _id;
        List<NHANVIEN_DTO> _listNVDTO;
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
            _congty = new dbCONGTY();
            _showHide(true);
            loadData(false);
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
            comboBox7.DataSource = _congty.getList();
            comboBox7.ValueMember = "IDCT";
            comboBox7.DisplayMember = "TENCT";
        }
        void loadData(bool check)
        {
            gridControl1.DataSource = _nhanvien.getListFull(check);
            gridView1.OptionsBehavior.Editable = false;
            _listNVDTO = _nhanvien.getListFull(check);
        }
        /*
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
     
        */
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = true;
            _showHide(false); //thêm
                              //  textEdit1.Text = string.Empty;
            _reset();
            splitContainer1.Panel1Collapsed = false;
            barButtonItem2.Enabled = false;
            textEdit5.Enabled = false;
            button1.Enabled = false;
            textEdit5.Clear();


        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            // Kiểm tra xem textEdit1 có trống không
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Chưa có id cần sửa. Vui lòng chọn thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng việc xóa nếu textEdit1 trống
            }
            splitContainer1.Panel1Collapsed = false;
            _them = false;
            _showHide(false);//sửa
           // pictureBox1.Image = _hinh;
            dateTimePicker1.Enabled = true;
            textEdit5.Enabled = true;
            button1.Enabled = true;
            textEdit5.Clear();
        }


        private void button2_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Có muốn xóa không nhân viên vừa thêm không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nhanvien.Delete(_tempMANV);
                loadData(false);
                textEdit1.Clear();
            }
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textEdit1.Clear();
            _showHide(true);//sửa
            splitContainer1.Panel1Collapsed = true;
            //xóa
        }
      

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit1.Text))
            {
                MessageBox.Show("Tên không thể để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu text1 trống
            }
           
            // Check if other controls are empty or invalid
            if (string.IsNullOrEmpty(textEdit3.Text))
            {
                MessageBox.Show("SĐT không thể để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textEdit2.Text))
            {
                MessageBox.Show("CCCD không thể để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(textEdit4.Text))
            {
                MessageBox.Show("Địa không thể để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Vui lòng chọn hình ảnh", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một Phòng Ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox4.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một Trình độ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một Bộ phận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboBox5.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một Dân tộc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (comboBox6.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn một Tôn giáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string cccd = textEdit2.Text.Trim();
            if (cccd.Length != 9 && cccd.Length != 12)
            {
                MessageBox.Show("Vui lòng nhập CCCD hoặc CMND với độ dài là 9 hoặc 12 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string sdt = textEdit3.Text.Trim();
            if (sdt.Length != 10 && sdt.Length != 11)
            {
                MessageBox.Show("Vui lòng nhập SĐT với độ dài là 10 hoặc 11 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime selectedDate = dateTimePicker1.Value;
            DateTime currentDate = DateTime.Now;
            DateTime minDate = currentDate.AddYears(-18);

            // Kiểm tra giá trị và xuất ra MessageBox
            if (selectedDate >= minDate)
            {
                MessageBox.Show("Ngày bạn chọn nhỏ hơn 18 năm trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (selectedDate > currentDate)
            {
                MessageBox.Show("Ngày bạn chọn vượt quá ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            SaveData();
            _them = false;
            loadData(false);   
            _showHide(true); //lưu
            textEdit1.Clear();
            splitContainer1.Panel1Collapsed = true;
            textEdit5.Clear();


        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);//hủy
            loadData(false);
            splitContainer1.Panel1Collapsed = true;
            textEdit5.Clear();

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rpDSNHANVIEN rpt = new rpDSNHANVIEN(_listNVDTO);

            // Hiển thị chế độ preview full màn hình
            var previewForm = new DevExpress.XtraReports.UI.ReportPrintTool(rpt);
            previewForm.PreviewForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            previewForm.ShowRibbonPreview(); //ShowRibbonPreview

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
                nv.MANV = code();
                _tempMANV = nv.MANV;
                nv.HOTEN = textEdit1.Text;
                nv.GIOITINH = checkBox1.Checked;
                nv.NGAYSINH = dateTimePicker1.Value;
                nv.DIENTHOAI = textEdit3.Text;
                nv.CCCD = textEdit2.Text;
                nv.DIACHI = textEdit4.Text;
                nv.HINHANH = ImageToBase64(pictureBox1.Image,pictureBox1.Image.RawFormat);
                nv.THOIVIEC = false;
                nv.IDPB = int.Parse(comboBox1.SelectedValue.ToString());//phòng ban
                nv.IDTD = int.Parse(comboBox4.SelectedValue.ToString()); //trình độ
                nv.IDBP = int.Parse(comboBox2.SelectedValue.ToString()); //bộ phận
                nv.IDCV = int.Parse(comboBox3.SelectedValue.ToString()); //chức vụ 
                nv.IDDT = int.Parse(comboBox5.SelectedValue.ToString()); //dân tộc
                nv.IDTG = int.Parse(comboBox6.SelectedValue.ToString()); //tôn giáo
                nv.IDCT = int.Parse(comboBox7.SelectedValue.ToString());
                _nhanvien.Add(nv);
            }
            else
            {
                var nv = _nhanvien.getItem(_id);
                nv.HOTEN = textEdit1.Text;
                nv.GIOITINH = checkBox1.Checked;
                nv.NGAYSINH = dateTimePicker1.Value;
                nv.DIENTHOAI = textEdit3.Text;
                nv.CCCD = textEdit2.Text;
                nv.DIACHI = textEdit4.Text;
                nv.HINHANH = ImageToBase64(pictureBox1.Image, pictureBox1.Image.RawFormat);
                nv.THOIVIEC = false;
                nv.IDPB = int.Parse(comboBox1.SelectedValue.ToString());//phòng ban
                nv.IDTD = int.Parse(comboBox4.SelectedValue.ToString()); //trình độ
                nv.IDBP = int.Parse(comboBox2.SelectedValue.ToString()); //bộ phận
                nv.IDCV = int.Parse(comboBox3.SelectedValue.ToString()); //chức vụ 
                nv.IDDT = int.Parse(comboBox5.SelectedValue.ToString()); //dân tộc
                nv.IDTG = int.Parse(comboBox6.SelectedValue.ToString()); //tôn giáo
                nv.IDCT = int.Parse(comboBox7.SelectedValue.ToString());
                _nhanvien.Update(nv);
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_them) // Kiểm tra nếu _them là false
                {
                    if (gridView1.FocusedRowHandle >= -1)
                    {
                        _id = gridView1.GetFocusedRowCellValue("MANV").ToString();
                        var nv = _nhanvien.getItem(_id);
                        textEdit1.Text = gridView1.GetFocusedRowCellValue("HOTEN").ToString();
                        textEdit1.Text = nv.HOTEN;
                        checkBox1.Checked = nv.GIOITINH.Value;
                        dateTimePicker1.Value = nv.NGAYSINH.Value;
                        textEdit3.Text = nv.DIENTHOAI;
                        textEdit2.Text = nv.CCCD;
                        textEdit4.Text = nv.DIACHI;
                        pictureBox1.Image = Base64ToImage(nv.HINHANH);

                        comboBox1.SelectedValue = nv.IDPB; //phòng ban
                        comboBox4.SelectedValue = nv.IDTD; //trình độ
                        comboBox2.SelectedValue = nv.IDBP; //bộ phận
                        comboBox3.SelectedValue = nv.IDCV; //chức vụ
                        comboBox5.SelectedValue = nv.IDDT; //dân tộc
                        comboBox6.SelectedValue = nv.IDTG; //tôn giáo
                                                           //nv.IDCT = 1;
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
            textEdit2.Clear();
            textEdit3.Clear();
            textEdit4.Clear();
            checkBox1.Checked = false;

            // Lấy đường dẫn đến hình ảnh trong thư mục Image
            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "1.jpg");

            // Kiểm tra nếu file tồn tại
            if (System.IO.File.Exists(imagePath))
            {
                pictureBox1.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("Không tìm thấy file hình ảnh mặc định!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Hàm chuyển đổi hình ảnh sang Base64 nếu có hình ảnh
        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            if (image == null)
            {
                // Không có hình ảnh, trả về null hoặc một mảng byte rỗng
                return null;
            }

            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }

        // Hàm chuyển đổi Base64 (mảng byte) thành hình ảnh nếu có dữ liệu
        public Image Base64ToImage(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                // Không có dữ liệu hình ảnh, trả về null hoặc thông báo lỗi
                return null;
            }

            MemoryStream ms = new MemoryStream(imageBytes);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        public string code()
        {
            // Tạo instance kết nối cơ sở dữ liệu
            _nhanvien = new dbNHANVIEN();

            // Lấy danh sách nhân viên
            var listNV = _nhanvien.getList();

            string maNV;

            if (listNV == null || listNV.Count == 0)
            {
                // Nếu danh sách trống, mã nhân viên đầu tiên là 0000000001
                maNV = "0000000001";
            }
            else
            {
                // Lấy mã nhân viên cuối cùng theo thứ tự số học
                var lastEmployee = listNV
                    .OrderBy(x => long.Parse(x.MANV)) // Sắp xếp dựa trên giá trị số
                    .Last();

                // Chuyển mã cuối cùng sang số và tăng lên 1
                long newCode = long.Parse(lastEmployee.MANV) + 1;

                // Định dạng mã mới thành 10 ký tự
                maNV = newCode.ToString("D10");
            }

            return maNV;
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

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textEdit3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys (e.g., backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Prevent non-numeric characters
            }
        }

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {

            // Allow only digits and control keys (e.g., backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Prevent non-numeric characters
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // Lấy đường dẫn tương đối đến thư mục Image
            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image", "1.jpg");

            // Kiểm tra nếu file tồn tại
            if (System.IO.File.Exists(imagePath))
            {
                // Đặt hình ảnh vào PictureBox
                pictureBox1.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("Không tìm thấy file hình ảnh trong thư mục Image!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /*
         * private void simpleButton2_Click(object sender, EventArgs e)
        {
            // Loại bỏ hình ảnh hiện tại trong PictureBox
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null; // Gán null để xóa hình ảnh
            }
        }
            private void simpleButton2_Click(object sender, EventArgs e)
        {
            // Đường dẫn đến hình ảnh
            string imagePath = @"C:\Users\nam\Desktop\avatar_trang_1_cd729c335b.jpg";

            // Kiểm tra nếu file tồn tại
            if (System.IO.File.Exists(imagePath))
            {
                // Đặt hình ảnh vào PictureBox
                pictureBox1.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("Không tìm thấy file hình ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
         */

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textEdit5.Text))
            {
                MessageBox.Show("Mã không thể để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại nếu text1 trống
            }
            string maNhanVien = textEdit5.Text;

            _listNVDTO = _nhanvien.getListFull(false);
            var nhanVienLoc = _listNVDTO.Where(nv => nv.MANV == maNhanVien).ToList();

            // Kiểm tra nếu danh sách lọc trống
            if (nhanVienLoc.Count == 0)
            {
                MessageBox.Show("Không tìm thấy nhân viên với mã: " + maNhanVien, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _them = false;
            // Hiển thị thông tin nhân viên lên gridControl1
            _id = nhanVienLoc[0].MANV;
            gridControl1.DataSource = nhanVienLoc;
            textEdit1.Text = nhanVienLoc[0].HOTEN;
            checkBox1.Checked = (bool)nhanVienLoc[0].GIOITINH;
            dateTimePicker1.Value = (DateTime)nhanVienLoc[0].NGAYSINH;
            textEdit3.Text = nhanVienLoc[0].DIENTHOAI;
            textEdit2.Text = nhanVienLoc[0].CCCD;
            textEdit4.Text = nhanVienLoc[0].DIACHI;
            pictureBox1.Image = Base64ToImage(nhanVienLoc[0].HINHANH);
            comboBox1.SelectedValue = nhanVienLoc[0].IDPB;
            comboBox4.SelectedValue = nhanVienLoc[0].IDTD;
            comboBox2.SelectedValue = nhanVienLoc[0].IDBP;
            comboBox3.SelectedValue = nhanVienLoc[0].IDCV;
            comboBox5.SelectedValue = nhanVienLoc[0].IDDT;
            comboBox6.SelectedValue = nhanVienLoc[0].IDTG;
            comboBox7.SelectedValue = nhanVienLoc[0].IDCT;


        }

        private void button3_Click(object sender, EventArgs e)
        {

            var listNV = _nhanvien.getList();
            var lastEmployee = listNV.Where(x => x.MANV == _tempMANV).ToList(); // Sắp xếp dựa trên giá trị chuỗi

            // Kiểm tra nếu danh sách lọc trống
            if (lastEmployee.Count == 0 && _tempMANV == null)
            {
                MessageBox.Show("Không tìm thấy nhân viên vừa thêm ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _them = false;
            // Hiển thị thông tin nhân viên lên gridControl1
            _id = lastEmployee[0].MANV;
            gridControl1.DataSource = lastEmployee;
            textEdit1.Text = lastEmployee[0].HOTEN;
            checkBox1.Checked = (bool)lastEmployee[0].GIOITINH;
            dateTimePicker1.Value = (DateTime)lastEmployee[0].NGAYSINH;
            textEdit3.Text = lastEmployee[0].DIENTHOAI;
            textEdit2.Text = lastEmployee[0].CCCD;
            textEdit4.Text = lastEmployee[0].DIACHI;
            pictureBox1.Image = Base64ToImage(lastEmployee[0].HINHANH);
            comboBox1.SelectedValue = lastEmployee[0].IDPB;
            comboBox4.SelectedValue = lastEmployee[0].IDTD;
            comboBox2.SelectedValue = lastEmployee[0].IDBP;
            comboBox3.SelectedValue = lastEmployee[0].IDCV;
            comboBox5.SelectedValue = lastEmployee[0].IDDT;
            comboBox6.SelectedValue = lastEmployee[0].IDTG;
            comboBox7.SelectedValue = lastEmployee[0].IDCT;


        }

        private void textEdit6_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}