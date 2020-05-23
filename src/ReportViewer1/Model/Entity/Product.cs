using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportViewer1.Model.Entity
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public float UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string QuantityPerUnit { get; set; }
    }
}
