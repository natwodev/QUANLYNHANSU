using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNHANSU
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true; // Form này sẽ là MDI Parent
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           ribbonControl1.SelectedPage = ribbonPage2; //hiển page nhân sự 
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
            // Ẩn Form chính thay vì đóng
            this.Hide();

            // Mở lại form đăng nhập
            frmLOGIN loginForm = new frmLOGIN();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Nếu đăng nhập thành công, mở lại form chính
                this.Show(); // Mở lại Form chính mà không cần khởi động lại vòng lặp ứng dụng
            }
            else
            {
                // Nếu đăng nhập thất bại hoặc form đăng nhập bị đóng, thoát ứng dụng
                Application.Exit();
            }
        }

    }
}
