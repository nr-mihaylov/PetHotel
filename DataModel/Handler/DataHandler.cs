using System;
using System.Collections.Generic;
using System.Linq;
using DataModel.PetHotelORM;
using System.Data.Entity;

namespace DataModel.Handler
{
    public class DataHandler
    {

        public static IList<species> getSpeciesList()
        {
            using (var db = new PTContext())
            {
                return db.species.ToList();
            }
        }
        public static reservation getReservation(int id)
        {
            using (var db = new PTContext())
            {
                return db.reservation
                    .Include(x => x.customer)
                    .Include(x => x.species)
                    .Where(x => x.reservationID == id)
                    .Single();
            }
        }

        public static reservation getReservation(string code)
        {
            using (var db = new PTContext())
            {
                return db.reservation
                    .Include(x => x.customer)
                    .Include(x => x.species)
                    .Where(x => x.code == code)
                    .Single();
            }
        }

        public static IList<reservation> getReservationList()
        {
            using (var db = new PTContext())
            {
                return db.reservation
                    .Include(x => x.customer)
                    .Include(x => x.species)
                    .ToList();
            }

        }

        public static void editReservation(reservation reservation)
        {
            using (var db = new PTContext())
            {
                reservation.customer.customerID = reservation.customerID;
                db.Entry(reservation).State = EntityState.Modified;
                db.Entry(reservation.customer).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void newReservation(reservation reservation)
        {

            using (var db = new PTContext())
            {
                db.reservation.Add(reservation);
                db.SaveChanges();

            }
        }

        

        public static ICollection<vInvoiceList> getInvoiceList()
        {
            using (var db = new PTContext())
            {
                return db.vInvoiceList.ToList();
            }
        }

        public static ICollection<vEmployeeList> getEmployeeList()
        {
            using (var db = new PTContext())
            {
                return db.vEmployeeList.ToList();
            }
        }
        
        public static ICollection<vPriceList> getPriceList()
        {

            using (var db = new PTContext())
            {

                var result = db.vPriceList.ToList();
                return result;

            }

        }

        public static ICollection<vContactList> getContactList()
        {

            using (var db = new PTContext())
            {

                return db.vContactList.ToList();

            }

        }

    }
}
