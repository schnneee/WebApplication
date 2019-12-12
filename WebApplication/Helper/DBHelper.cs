using System;
using System.Data.SqlClient;
using WebApplication.Repositories;

namespace WebApplication.Helper
{
    public class DBHelper : IDisposable
    {
        private readonly SqlConnection _connection;

        public DBHelper(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            UnitOfWork = new UnitOfWork(_connection);
        }

        public UnitOfWork UnitOfWork { get; }

        public void Dispose()
        {
            UnitOfWork.Dispose();
            _connection.Dispose();
        }

        ~DBHelper()
        {
            Dispose();
        }
    }
}