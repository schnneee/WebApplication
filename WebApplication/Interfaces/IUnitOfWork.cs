using System;
using System.Data;

namespace WebApplication.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Open();
        void Close();
        void Begin();
        bool Commit();
        void Rollback();
    }
}