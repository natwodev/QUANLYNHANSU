using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using BUSINESSLAYER.DATA_OBJECT;
using DevExpress.Office.Utils;
using DevExpress.XtraReports.UI;

namespace QLNHANSU.REPORTS
{
    public partial class rpHOPDONG : DevExpress.XtraReports.UI.XtraReport
    {
        public rpHOPDONG()
        {
            InitializeComponent();
        }
        public rpHOPDONG(List<HOPDONG_DTO> listHD)
        {
            InitializeComponent();
            this._listHD = listHD;
            this.DataSource = _listHD;
            loadData();
        }
        List<HOPDONG_DTO> _listHD;
        void loadData()
        {
           xrLabel5.DataBindings.Add("Text", _listHD, "SOHD");
            /*
           xrLabel7.DataBindings.Add("Text", _listHD, "HOTEN");
           xrLabel8.DataBindings.Add("Text", _listHD, "DIENTHOAI");
           xrLabel9.DataBindings.Add("Text", _listHD, "DIACHI");
            xrLabel10.DataBindings.Add("Text", _listHD, "TENCT");
            */
        }
    }
}
