using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;

namespace ReportViewer1.View
{
    public partial class FrmPreview : Form
    {
        public FrmPreview()
        {
            InitializeComponent();

            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            this.reportViewer1.ZoomPercent = 100;
        }

        public FrmPreview(string header, string reportName, ReportDataSource reportDataSource, 
            IEnumerable<ReportParameter> parameters = null) : this()
        {
            this.Text = header;

            // Set RDL file.
            this.reportViewer1.LocalReport.ReportPath = string.Format("View\\Report\\{0}.rdlc", reportName);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            if (!(parameters == null))
                this.reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.RefreshReport();
        }
    }
}
