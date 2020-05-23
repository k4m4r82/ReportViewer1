using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ReportViewer1.Model.Entity;
using ReportViewer1.Model.Context;
using ReportViewer1.Model.Repository;

namespace ReportViewer1.Controller
{
    public class ProductController
    {
        public IList<Product> GetAll()
        {
            var list = new List<Product>();

            using (var context = new DbContext())
            {
                var repository = new ProductRepository(context);

                list = repository.GetAll().ToList();
            }

            return list;
        }
    }
}
