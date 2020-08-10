using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FundacionDonandoParaAyudar.Web.Data;
using FundacionDonandoParaAyudar.Web.Data.Entities;
using FundacionDonandoParaAyudar.Web.Helpers;

namespace FundacionDonandoParaAyudar.Web.Controllers
{
    public class FoundationController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public FoundationController(
            DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        // GET: Foundation
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comments
                    .Include(c => c.User)
                    .ToListAsync());
        }

        // GET: Foundation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundationEntity = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foundationEntity == null)
            {
                return NotFound();
            }

            return View(foundationEntity);
        }

        // GET: Foundation/Create
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FoundationEntity model)
        {
            if (ModelState.IsValid)
            {
                UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);

                model.User = user;

                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundationEntity = await _context.Comments.FindAsync(id);
            if (foundationEntity == null)
            {
                return NotFound();
            }
            return View(foundationEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FoundationEntity foundationEntity)
        {
            if (id != foundationEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foundationEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoundationEntityExists(foundationEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(foundationEntity);
        }

        // GET: Foundation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foundationEntity = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (foundationEntity == null)
            {
                return NotFound();
            }

            return View(foundationEntity);
        }

        // POST: Foundation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foundationEntity = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(foundationEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoundationEntityExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
