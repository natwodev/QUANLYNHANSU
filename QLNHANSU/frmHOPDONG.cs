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
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
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

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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



        private void textEdit1_EditValueChanged_2(object sender, EventArgs e)
        {

        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}