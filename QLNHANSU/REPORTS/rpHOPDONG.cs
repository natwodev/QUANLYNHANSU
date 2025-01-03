using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using BUSINESSLAYER.DATA_OBJECT;
using DevExpress.XtraReports.UI;

namespace QLNHANSU.REPORTS
{
    public partial class rpHOPDONG : DevExpress.XtraReports.UI.XtraReport
    {
        public rpHOPDONG()
        {
            InitializeComponent();
        }
        public rpHOPDONG(HOPDONG_DTO hd)
        {
            InitializeComponent();
            this._hd = hd;
            this.DataSource = _hd;
        }
        HOPDONG_DTO _hd;

    }
}
