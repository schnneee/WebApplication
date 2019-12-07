using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication.Models.ViewModel;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly LedgerService _ledgerService;

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
            var list = _ledgerService.GetList();
            var model = list.Select(x => new LedgerViewModel
            {
                Date = x.Dateee,
                Type = (LedgerType)x.Categoryyy,
                Money = x.Amounttt
            });

            ViewData["Title"] = "我的記帳本";

            return View(list);
        }
    }
}