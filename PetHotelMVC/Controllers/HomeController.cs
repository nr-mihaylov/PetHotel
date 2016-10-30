using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel.PetHotelORM;
using DataModel.Handler;

namespace PetHotelMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Prices()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult _Prices()
        {
            return PartialView(DataHandler.getPriceList());
        }

        [ChildActionOnly]
        public ActionResult _Contact()
        {
            return PartialView(DataHandler.getContactList());
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}