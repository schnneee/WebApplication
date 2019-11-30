using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.ViewModel;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult LedgerList()
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

            list = list.OrderByDescending(x => x.Date).ToList();

            ViewData["Title"] = "我的記帳本";

            return View(list);
        }
    }
}