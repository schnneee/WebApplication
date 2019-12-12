using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace WebApplication.Interfaces
{
    public interface IGenericRepository
    {
        /// <summary>
        /// 查詢
        /// </summary>
        IEnumerable<T> Query<T>(String sqlCommand, DynamicParameters parameters = null, CommandType? commandType = null);

        /// <summary>
        /// 執行
        /// </summary>
        Int32 Execute(String sqlCommand, DynamicParameters parameters = null, CommandType? commandType = null);
    }
}