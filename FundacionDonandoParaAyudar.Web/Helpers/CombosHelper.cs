using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundacionDonandoParaAyudar.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboDocumentTypes()
        {
            List<SelectListItem> listDocumentItems = new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "[Tipo]", Disabled = true },
                new SelectListItem { Value = "1", Text = "C.C", Selected = true },
                new SelectListItem { Value = "2", Text = "T.I" },
                new SelectListItem { Value = "3", Text = "C.E" },
                new SelectListItem { Value = "4", Text = "P.A" }
            };

            return listDocumentItems;
        }

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