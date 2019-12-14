using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WebApplication.Helper;
using WebApplication.Models;
using WebApplication.Models.ViewModel;
using WebApplication.Repositories;

namespace WebApplication.Services
{
    public class LedgerService
    {
        private readonly string _homeworkDbConnectionString = ConfigurationManager.ConnectionStrings["HomeworkDB"].ConnectionString;

        /// <summary>
        /// 取得記帳本列表假資料
        /// </summary>
        public IEnumerable<LedgerViewModel> GetFakeList()
        {
            var list = new List<LedgerViewModel>();
            var count = 100;
            var startDate = DateTime.Now.AddMonths(-3);
            var random = new Random();

            for (var i = 1; i <= count; i++)
            {
                var num = random.Next(1, 1000);

                list.Add(new LedgerViewModel
                {
                    Date = startDate.AddMinutes(num * i),
                    Type = (LedgerType)(num % 2),
                    Money = (num % i + 1) * i
                });
            }

            return list.OrderByDescending(x => x.Date);
        }

        /// <summary>
        /// 從DB取得記帳本列表
        /// </summary>
        public IEnumerable<LedgerViewModel> GetList()
        {
            IEnumerable<AccountBook> list = new List<AccountBook>();

            using (DBHelper dBHelper = new DBHelper(_homeworkDbConnectionString))
            {
                var ledgerRepository = new LedgerRepository(dBHelper.UnitOfWork);
                list = ledgerRepository.GetAccountBookList();
            }

            var result = list.Select(x => new LedgerViewModel
            {
                Date = x.Dateee,
                Type = x.Categoryyy.TryParseLedgerType(),
                Money = x.Amounttt
            }).OrderByDescending(x => x.Date).ToList();

            return result;
        }
    }
}