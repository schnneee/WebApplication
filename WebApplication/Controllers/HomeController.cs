using System.Linq;
using System.Web.Mvc;
using WebApplication.Models.ViewModel;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly LedgerService _ledgerService;

        public HomeController()
        {
            _ledgerService = new LedgerService();
        }

        public ActionResult Index()
        {
            ViewData["Title"] = "我的記帳本";
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

            return View(list);
        }
    }
}