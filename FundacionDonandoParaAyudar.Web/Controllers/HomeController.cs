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
        private readonly IUserHelper _userHelper;
        private ReceiveDataModel _dataModel;

        public HomeController(
            DataContext context,
            IMailHelper mailHelper,
            IUserHelper userHelper)
        {
            _context = context;
            _mailHelper = mailHelper;
            _userHelper = userHelper;
        }

        public async Task<IActionResult> _UploadImage()
        {
            return PartialView(await _context.Comments
                  .Include(c => c.Comments)
                  .ToListAsync());
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
                var response = _mailHelper.SendMail("donandoparaayudar@gmail.com",
                    $"{model.FirstName + " " + model.LastName} te ha enviado un mensaje!", 
                    $"<h1> En fundación donando para ayudar en contáctenos </h1> " +
                    $"<h4>Te han escrito el siguiente mensaje: </h4>" +
                    $"<br/>" +
                    $"<p>{model.Message}</p>" +
                    $"<br/> del Correo: {model.Email}");

                if (response.IsSuccess)
                {
                    ViewBag.Message = "Ha sido enviado el mensaje";
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    UserEntity user = await _userHelper.GetUserAsync(model.Email);
                    if (user == null)
                    {                        
                        return RedirectToAction("Register", "Account");
                    }
                    return RedirectToAction(nameof(Contact));
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
