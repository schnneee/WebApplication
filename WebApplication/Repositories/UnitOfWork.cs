using System;
using System.Data;
using System.Data.SqlClient;
using WebApplication.Interfaces;

namespace WebApplication.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        internal UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
        }

        IDbConnection IUnitOfWork.Connection
        {
            get { return _connection; }
        }

        IDbTransaction IUnitOfWork.Transaction
        {
            get { return _transaction; }
        }

        public void Open()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
        }

        public void Close()
        {
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();

            _transaction = null;
        }

        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public bool Commit()
        {
            var isCommitOk = true;

            if (_transaction != null)
            {
                try
                {
                    _transaction.Commit();
                }
                catch //(Exception ex)
                {
                    // TODO: add log
                    _transaction.Rollback();

                    isCommitOk = false;
                }
                finally
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }

            return isCommitOk;
        }

        public void Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        ~UnitOfWork()
        {
            Dispose();
        }
    }
}