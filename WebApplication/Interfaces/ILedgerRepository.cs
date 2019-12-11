using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Interfaces
{
    public interface ILedgerRepository
    {
        IEnumerable<AccountBook> GetAccountBookList();
    }
}