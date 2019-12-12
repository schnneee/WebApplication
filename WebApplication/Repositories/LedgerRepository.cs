using System.Collections.Generic;
using WebApplication.Interfaces;
using WebApplication.Models;

namespace WebApplication.Repositories
{
    public class LedgerRepository : GenericRepository, ILedgerRepository
    {
        public LedgerRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<AccountBook> GetAccountBookList()
        {
            string sql = @"
                SELECT
                    Id,
                    Categoryyy,
                    Amounttt,
                    Dateee,
                    Remarkkk
                FROM AccountBook NOLOCK";

            return Query<AccountBook>(sql);
        }
    }
}