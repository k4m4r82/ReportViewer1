using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;
using ReportViewer1.Model.Entity;
using ReportViewer1.Controller;

namespace ReportViewer1.View
{
    public partial class FrmProduct : Form
    {
        // buat objek controller
        private readonly ProductController _controller;

        public FrmProduct()
        {
            InitializeComponent();
            InisialisasiListView();

            _controller = new ProductController();
            LoadData();
        }

        private void InisialisasiListView()
        {            
            lvwProduct.View = System.Windows.Forms.View.Details;
            lvwProduct.FullRowSelect = true;
            lvwProduct.GridLines = true;

            lvwProduct.Columns.Add("No.", 40, HorizontalAlignment.Center);
            lvwProduct.Columns.Add("Product name", 400, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Quantity per unit", 150, HorizontalAlignment.Left);
            lvwProduct.Columns.Add("Unit price", 80, HorizontalAlignment.Right);
            lvwProduct.Columns.Add("Unit in stock", 80, HorizontalAlignment.Right);
        }

        private void LoadData()
        {
            // panggil method GetAll
            // hasilnya berupa object collection
            var list = _controller.GetAll();

            lvwProduct.Items.Clear();

            foreach (var product in list)
            {
                FillToListView(product);
            }
        }

        private void FillToListView(Product product)
        {
            var noUrut = lvwProduct.Items.Count + 1;

            var item = new ListViewItem(noUrut.ToString());
            item.SubItems.Add(product.ProductName);
            item.SubItems.Add(product.QuantityPerUnit);
            item.SubItems.Add(product.UnitPrice.ToString());
            item.SubItems.Add(product.UnitsInStock.ToString());

            lvwProduct.Items.Add(item);
        }        

        private void btnPreview_Click(object sender, EventArgs e)
        {
            var list = _controller.GetAll();

            var reportDataSource = new ReportDataSource
            {
                Name = "DsProduct",
                Value = list
            };

            var header = "Laporan Product";
            var reportName = "RvProduct";

            var frmPreview = new FrmPreview(header, reportName, reportDataSource);
            frmPreview.ShowDialog();
        }

        private void btnSelesai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
