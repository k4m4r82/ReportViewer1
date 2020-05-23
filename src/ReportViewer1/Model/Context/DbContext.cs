using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;

namespace ReportViewer1.Model.Context
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Conn { get; }
    }

    public class DbContext : IDbContext
    {
        private IDbConnection _conn;

        private readonly string _providerName = "System.Data.SQLite";
        private readonly string _connectionString;

        public DbContext()
        {
            var dbName = Path.Combine(IsRunningUnderIDE() ? GetSolutionPath()
                : GetAppPath(), @"database\Northwind.db");

            _connectionString = string.Format("Data Source={0}", dbName);
        }

        public IDbConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection(_providerName, _connectionString)); }
        }

        private bool IsRunningUnderIDE()
        {
            return System.Diagnostics.Debugger.IsAttached;
        }

        private string GetSolutionPath()
        {
            return Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        }

        private string GetAppPath()
        {
            return Directory.GetCurrentDirectory();
        }

        private IDbConnection GetOpenConnection(string providerName, string connectionString)
        {
            IDbConnection conn = null;

            try
            {
                var provider = DbProviderFactories.GetFactory(providerName);
                conn = provider.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
            }
            catch
            {
            }

            return conn;
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
