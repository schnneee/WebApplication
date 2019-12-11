using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using WebApplication.Interfaces;

namespace WebApplication.Repositories
{
    public class GenericRepository : IGenericRepository
    {
        private IUnitOfWork _unitOfWork;
        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<T> Query<T>(String sqlCommand, DynamicParameters parameters = null, CommandType? commandType = null)
        {
            try
            {
                _unitOfWork.Open();
                return _unitOfWork.Connection.Query<T>(sql: sqlCommand, param: parameters, transaction: _unitOfWork.Transaction, commandType: commandType);
            }
            catch //(Exception ex)
            {
                // TODO: add log
                throw;
            }
        }

        public Int32 Execute(String sqlCommand, DynamicParameters parameters = null, CommandType? commandType = null)
        {
            try
            {
                _unitOfWork.Open();
                return _unitOfWork.Connection.Execute(sql: sqlCommand, param: parameters, transaction: _unitOfWork.Transaction, commandType: commandType);
            }
            catch //(Exception ex)
            {
                // TODO: add log
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}