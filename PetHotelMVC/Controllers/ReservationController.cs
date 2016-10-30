using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataModel.PetHotelORM;
using DataModel.Handler;
using PetHotelMVC.Util;

namespace PetHotelMVC.Controllers
{
    public class ReservationController : Controller
    {
        [HttpGet]
        public ActionResult Book()
        {
            bool isEdited = Convert.ToBoolean(Session["isEdited"] ?? false);
            ViewBag.speciesList = DDContentGenerator.convertSpecies(DataHandler.getSpeciesList());

            if (isEdited)
            {
                return View((reservation)Session["reservationDraft"]);
            }

            return View(new reservation());

        }

        [HttpPost]
        public ActionResult Book(reservation res)
        {

            if(ModelState.IsValid)
            {

                if(res.reservationID == 0)
                {

                    res.code = AlphaNumbericGenerator.getRandom(8);
                    res.employeeID = 1;
                    DataHandler.newReservation(res);

                    Session["code"] = res.code;
                    Session["title"] = "Booking complete!";
                    Session["text"] = "You have succesfully booked a reservation at our hotel.";

                    return RedirectToAction("Complete");

                } else
                {
                    reservation r = (reservation)Session["reservationDraft"];
                    res.code = r.code;
                    res.employeeID = r.employeeID;
                    DataHandler.editReservation(res);
                    Session["reservationDraft"] = null;
                    Session["isEdited"] = null;

                    Session["code"] = null;
                    Session["title"] = "Booking edited!";
                    Session["text"] = "You have succesfully edited your reservation at our hotel.";

                    return RedirectToAction("Complete");

                }

            }

            ViewBag.speciesList = DDContentGenerator.convertSpecies(DataHandler.getSpeciesList());

            return View(res);

        }

        [HttpGet]
        public ActionResult Complete()
        {
            ViewBag.title = Session["title"];
            ViewBag.text = Session["text"];
            ViewBag.code = Session["code"];

            return View();
        }

        [HttpGet]
        public ActionResult ReservationCode()
        {
            return View();
        }

        [HttpGet]
        public ActionResult NewReservation()
        {
            Session["isEdited"] = false;
            return RedirectToAction("Book");
        }

        [HttpPost]
        public ActionResult ReservationCode(FormCollection fc)
        {
            reservation reservationDraft = DataHandler.getReservation(fc["code"]);
            Session["reservationDraft"] = reservationDraft;
            bool isEdited = true;
            Session["isEdited"] = isEdited;
             
            return RedirectToAction("Book");
        }

    }
}
