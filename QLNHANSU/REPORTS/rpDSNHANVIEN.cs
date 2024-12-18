using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using BUSINESSLAYER.DATA_OBJECT;
using DevExpress.XtraReports.UI;

namespace QLNHANSU.REPORTS
{
    public partial class rpDSNHANVIEN : DevExpress.XtraReports.UI.XtraReport
    {
        public rpDSNHANVIEN()
        {
            InitializeComponent();
        }
        List<NHANVIEN_DTO> _lstNV;

        public rpDSNHANVIEN(List<NHANVIEN_DTO> lstNV)
        {
            InitializeComponent();
            this._lstNV = lstNV;
            this.DataSource = _lstNV;
            LoadData();
        }
        void LoadData()
        {
            xrTableCell13.DataBindings.Add("Text", _lstNV, "MANV");
            xrTableCell14.DataBindings.Add("Text", _lstNV, "HOTEN");
            xrTableCell15.DataBindings.Add("Text", _lstNV, "GIOITINH");
            xrTableCell16.DataBindings.Add("Text", _lstNV, "NGAYSINH");
            xrTableCell17.DataBindings.Add("Text", _lstNV, "CCCD");
            xrTableCell18.DataBindings.Add("Text", _lstNV, "DIENTHOAI");
            xrTableCell19.DataBindings.Add("Text", _lstNV, "TENPB");
            xrTableCell20.DataBindings.Add("Text", _lstNV, "TENCV");
            xrTableCell21.DataBindings.Add("Text", _lstNV, "TENTD");
            xrTableCell22.DataBindings.Add("Text", _lstNV, "TENBP");
            xrTableCell23.DataBindings.Add("Text", _lstNV, "TENDT");
            xrTableCell24.DataBindings.Add("Text", _lstNV, "TENTG");

        }

    }
}
