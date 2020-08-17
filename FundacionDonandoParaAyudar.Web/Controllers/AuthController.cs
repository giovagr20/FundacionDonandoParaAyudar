using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FundacionDonandoParaAyudar.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthenticationSchemeProvider _authentication;

        public AuthController(IAuthenticationSchemeProvider authentication)
        {
            _authentication = authentication;
        }
        public async Task<IActionResult> _IndexFacebook()
        {
            var AllSchemeProvider = (await _authentication.GetAllSchemesAsync())
                .Select(f => f.DisplayName).Where(f => !String.IsNullOrEmpty(f));
            return View(AllSchemeProvider);
        }

        public IActionResult SignIn(String provider)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" }, provider);
        }
    }
}