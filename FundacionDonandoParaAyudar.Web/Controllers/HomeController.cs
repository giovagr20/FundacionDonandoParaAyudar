using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FundacionDonandoParaAyudar.Web.Models;
using FundacionDonandoParaAyudar.Web.Data;
using FundacionDonandoParaAyudar.Web.Data.Entities;
using FundacionDonandoParaAyudar.Web.Helpers;

namespace FundacionDonandoParaAyudar.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly IMailHelper _mailHelper;

        public HomeController(
            DataContext context,
            IMailHelper mailHelper)
        {
            _context = context;
            _mailHelper = mailHelper;
        }

        public async Task<IActionResult> _PartialComments()
        {
            return PartialView(await _context.Comments
                  .Include(c => c.Comments)
                  .Take(3)
                  .ToListAsync());
        }

        public async Task<IActionResult> Index()
        {
            /*var list = await (from c in _context.Comments
                              join u in _context.
                              from u 
                        orderby c.User.FullName
                        select c).Take(5).ToListAsync();*/
            return View(await _context.Comments
                   .Include(c => c.User)
                   .Take(4)
                   .ToListAsync());
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(SendMessageEntity model)
        {
            if (ModelState.IsValid)
            {
                var response = _mailHelper.SendMail("giovagr20@yopmail.com",
                    $"{model.FirstName + " " + model.LastName} te ha enviado un mensaje desde la pagina web", 
                    $"<h1> Te han escrito el siguiente mensaje: </h1>" +
                    $"<br/>" +
                    $"<p>{model.Message}</p>");

                if (response.IsSuccess)
                {
                    ViewBag.Message = "Ha sido enviado el mensaje";
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Contact));
                    //"$<div class=""modal"" tabindex=""- 1""><div class=""modal-dialog""><div class=""modal-content""><div class=""modal-body""><p>Ha sido enviado el correo con exito.</p></div><div class=""modal-footer""><button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</button></div></div></div></div>";
                }
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("error/404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
