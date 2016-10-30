using DataModel.PetHotelORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHotelMVC.Util
{
    public class DDContentGenerator
    {
        public static List<SelectListItem> convertSpecies(ICollection<species> data)
        {

            List<SelectListItem> result = new List<SelectListItem>();

            foreach(species s in data)
            {
                result.Add(new SelectListItem {
                    Text = s.speciesName,
                    Value = Convert.ToString(s.speciesID)
                });
            }

            return result;
        }
    }
}