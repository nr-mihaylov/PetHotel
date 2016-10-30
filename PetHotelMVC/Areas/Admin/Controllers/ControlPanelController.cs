using System;
using System.Web.Mvc;
using DataModel.Handler;
using DataModel.PetHotelORM;
using PetHotelMVC.Util;

namespace PetHotelMVC.Areas.Admin.Controllers
{
    public class ControlPanelController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReservationList()
        {
            return View(DataHandler.getReservationList());
        }

        [HttpPost]
        public ActionResult EditReservation(FormCollection fc)
        {
                reservation reservationDraft = DataHandler.getReservation(Convert.ToInt32(fc["reservationID"]));
                Session["reservationDraft"] = reservationDraft;
                return RedirectToAction("ReservationEditor");
        }

        [HttpGet]
        public ActionResult ReservationEditor()
        {
            ViewBag.speciesList = DDContentGenerator.convertSpecies(DataHandler.getSpeciesList());
            return View((reservation)Session["reservationDraft"]);
        }

        [HttpPost]
        public ActionResult ReservationEditor(reservation res)
        {

            if (ModelState.IsValid)
            {
                    DataHandler.editReservation(res);
                    Session["reservationDraft"] = null;

                    return RedirectToAction("ReservationList");

            }

            ViewBag.speciesList = DDContentGenerator.convertSpecies(DataHandler.getSpeciesList());

            return View();
        }

        [HttpGet]
        public ActionResult EmployeeList()
        {
            return View(DataHandler.getEmployeeList());
        }

        [HttpGet]
        public ActionResult InvoiceList()
        {
            return View(DataHandler.getInvoiceList());
        }

    }
}