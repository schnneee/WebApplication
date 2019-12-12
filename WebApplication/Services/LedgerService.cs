using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WebApplication.Helper;
using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Services
{
    public class LedgerService
    {
        private readonly string _homeworkDbConnectionString = ConfigurationManager.ConnectionStrings["HomeworkDB"].ConnectionString;

        /// <summary>
        /// 取得記帳本列表假資料
        /// </summary>
        public IEnumerable<AccountBook> GetFakeList()
        {
            var list = new List<AccountBook>();
            var count = 100;
            var startDate = DateTime.Now.AddMonths(-3);
            var random = new Random();

            for (var i = 1; i <= count; i++)
            {
                var num = random.Next(1, 1000);

                list.Add(new AccountBook
                {
                    Dateee = startDate.AddMinutes(num * i),
                    Categoryyy = num % 2,
                    Amounttt = (num % i + 1) * i
                });
            }

            return list.OrderByDescending(x => x.Dateee);
        }

        /// <summary>
        /// 從DB取得記帳本列表
        /// </summary>
        public IEnumerable<AccountBook> GetList()
        {
            IEnumerable<AccountBook> list = new List<AccountBook>();

            using (DBHelper dBHelper = new DBHelper(_homeworkDbConnectionString))
            {
                var ledgerRepository = new LedgerRepository(dBHelper.UnitOfWork);
                list = ledgerRepository.GetAccountBookList();
            }

            return list;
        }
    }
}