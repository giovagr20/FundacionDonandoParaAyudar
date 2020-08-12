using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundacionDonandoParaAyudar.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboRoles()
        {
            List<SelectListItem> listItems = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "[Selecciona..]", Disabled = true },
                new SelectListItem { Value = "1", Text = "User", Selected= true }
            };

            return listItems;
        }
    }
}