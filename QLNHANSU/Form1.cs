using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUSINESSLAYER;
using BUSINESSLAYER.DATA_OBJECT;
using DATALAYER;
using DATALAYER.context;
using DevExpress.XtraBars;

namespace QLNHANSU
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string _userRole;
        private string _userName;

        dbTAIKHOAN _taikhoan;
        List<TAIKHOAN_DTO> _listTKDTO;
        public static TAIKHOAN _user;
        public Form1(TAIKHOAN tk)
        {
            InitializeComponent();
            _taikhoan = new dbTAIKHOAN();
            _listTKDTO = _taikhoan.getListFull();
            // Giả sử _listTKDTO đã được khởi tạo hoặc tải dữ liệu trước
            var matchedRole = _listTKDTO.FirstOrDefault(dto => dto.IDTK == tk.IDTK);
            if (matchedRole != null)
            {
                var tkk = _taikhoan.getItem(tk.IDTK);
                tkk.LAST_LOGIN = DateTime.Now;
                _taikhoan.Update(tkk);
                _userRole = matchedRole.TENQUYEN; // Lấy tên quyền tương ứng
                _userName = matchedRole.HOTEN;
            }
            else
            {
                _userRole = "Quyền không xác định"; // Trường hợp không tìm thấy quyền
            }
        }
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true; // Form này sẽ là MDI Parent

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show($"Chào mừng : {_userName} với quyền : {_userRole}", "Role Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ApplyRolePermissions();
            ribbonControl1.SelectedPage = ribbonPage2; //hiển page nhân sự 
        }
        private void ApplyRolePermissions()
        {
            // Giả sử _userRole có các giá trị như "Admin", "User1", v.v.
            if (_userRole == "admin")
            {

                // Admin có thể sử dụng tất cả các nút


            }
            else if (_userRole == "user1")
            {
                barButtonItem18.Enabled = false; //tắt sao lưu
                barButtonItem19.Enabled = false; //tắt phục hồi
                barButtonItem28.Enabled = false; //tắt tài khoản (danh sách tài khoản)
                barButtonItem30.Enabled = false; //tắt đăng ký (tạo tài khoản)
                barButtonItem32.Enabled = false; //tắt sửa đổi quyền
                barButtonItem21.Enabled = false; //tắt công ty
            }
            else if (_userRole == "user2")
            {
                barButtonItem18.Enabled = false; //tắt sao lưu
                barButtonItem19.Enabled = false; //tắt phục hồi
                barButtonItem28.Enabled = false; //tắt tài khoản (danh sách tài khoản)
                barButtonItem30.Enabled = false; //tắt đăng ký (tạo tài khoản)
                ribbonPageGroup3.Enabled = false; //tắt nghiệp vụ (nghiệp vụ)
                barButtonItem32.Enabled = false; //tắt sửa đổi quyền
                barButtonItem21.Enabled = false; //tắt công ty
            }
            else if (_userRole == "user3")
            {
                barButtonItem18.Enabled = false; //tắt sao lưu
                barButtonItem19.Enabled = false; //tắt phục hồi
                barButtonItem28.Enabled = false; //tắt tài khoản (danh sách tài khoản)
                barButtonItem30.Enabled = false; //tắt đăng ký (tạo tài khoản)
                ribbonPageGroup3.Enabled = false; //tắt nghiệp vụ (nghiệp vụ)
                ribbonPage3.Ribbon.Visible = false; //ẩn page chấm công
                ribbonPage4.Ribbon.Visible = false; //ẩn page báo cáo
                barButtonItem32.Enabled = false; //tắt sửa đổi quyền
                barButtonItem21.Enabled = false; //tắt công ty
            }
            else
            {
                // Nếu không phải là admin hoặc user1, user2, user3 thì tắt tất cả các nút
                foreach (var item in ribbonControl1.Items)
                {
                    if (item is DevExpress.XtraBars.BarButtonItem)
                    {
                        ((DevExpress.XtraBars.BarButtonItem)item).Enabled = false;
                    }
                }
            }
        }

        void openForm(Type typeForm)
        {
            foreach(var frm in MdiChildren)
            {
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }   
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }
        void openFormT(Type typeForm) 
        {
            foreach (var frm in MdiChildren)
            {
                if (frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                }
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmTONGIAO));//TÔN GIÁO
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmTRINHDO));//TRÌNH ĐỘ

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmDANTOC));//DÂN TỘC
            
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmPHONGBAN));//PHÒNG BAN
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmNHANVIEN));//NHÂN VIÊN
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmCONGTY));//CÔNG TY
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmHOPDONG));//HỢP ĐỒNG
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmBOPHAN)); //BỘ PHẬN
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmCHUCVU));//CHỨC VỤ 
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.DialogResult = DialogResult.None; // Đặt DialogResult là None
            Application.Exit();
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          //  this.DialogResult = DialogResult.None; // Đặt DialogResult là None
            Application.Exit();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            openForm(typeof(frmDOIMATKHAU));//Đổi mk
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.DialogResult = DialogResult.Cancel; // Đặt DialogResult là Cancel
            this.Close();
        }

    



        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmTAIKHOAN));//danh sách tài khoản
        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem30_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmDANGKY));//Đăng ký
        }

        private void barButtonItem31_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmKHENTHUONG));//Khen thưởng
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmKYLUAT));//Kỷ luật
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmLOAICA));//Loại ca
        }

        private void barButtonItem11_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmLOAICONG));//Loại công
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmTHOIVIEC));//Thôi việc
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmDIEUCHUYEN));//Điều chuyển
        }

        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barButtonItem12_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmPHUCAP));//Phụ cấp
        }

        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmTANGCA));//Tăng ca
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void barButtonItem32_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmQUYENHAN));//Quyền hạn

        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Chức năng này đang được phát triển", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
