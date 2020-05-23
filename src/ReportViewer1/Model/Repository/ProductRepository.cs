using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dapper;
using ReportViewer1.Model.Entity;
using ReportViewer1.Model.Context;

namespace ReportViewer1.Model.Repository
{
    public interface IProductRepository
    {
        int Save(Product obj);
        int Update(Product obj);
        int Delete(Product obj);

        IList<Product> GetAll();
    }

    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _context;

        public ProductRepository(IDbContext context)
        {
            _context = context;
        }

        public int Save(Product obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Product obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Product obj)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            var list = new List<Product>();

            try
            {
                var sql = @"SELECT ProductID, ProductName, 
                            UnitPrice, UnitsInStock, QuantityPerUnit 
                            FROM Products
                            ORDER BY ProductName";
                list = _context.Conn.Query<Product>(sql)
                               .ToList();
            }
            catch
            {
            }

            return list;
        }
    }
}
