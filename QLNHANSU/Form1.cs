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

namespace QLNHANSU
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string _userRole;
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
            MessageBox.Show($"User role: {_userRole}", "Role Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ApplyRolePermissions();
            ribbonControl1.SelectedPage = ribbonPage2; //hiển page nhân sự 
        }
        private void ApplyRolePermissions()
        {
            // Giả sử _userRole có các giá trị như "Admin", "User1", v.v.
            if (_userRole == "admin")
            {



            }
            else if (_userRole == "user")
            {
                // Admin có thể sử dụng tất cả các nút
                ribbonPage2.Visible = false; // Kích hoạt trang ribbonPage2
                barButtonItem18.Enabled = false;
                barButtonItem19.Enabled = false;
            }
            else
            {
              
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
            this.Close();
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            // Đặt DialogResult là Cancel để quay lại form đăng nhập
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    



        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem29_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
