using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hinode.Data;
using Hinode.Models;
using Microsoft.AspNet.Identity;

namespace Hinode.Controllers
{
    public class UserConfigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserConfigsController(ApplicationDbContext context)
        {
            _context = context;
        }



 //---------------------------------------------------------------------------------------------------------------------------------------カスタム開始       
        public async Task<IActionResult> Menu()
        {
            ViewBag.Message = "Your contact page. ";
            if (User.Identity.IsAuthenticated)
            {
                // GetUserId() によりユニークなユーザ識別子を取得
                // (例: "6f95ed96-730c-4c01-ad76-ea6080a19fbe")
                string id = User.Identity.GetUserId();
                ViewBag.Message = "Your id = " + id;

                var UC = await _context.UserConfig.FirstOrDefaultAsync(m => m.UserId == id);

                if (UC == null)
                {
                    //UserIdがなかった場合の処理（初回）
                    _context.Add(new UserConfig
                    {
                        UserId = id,
                        UserCategoryId = 0
                    });

                    await _context.SaveChangesAsync();

                }

                return View(UC);

            }
            else
            {
                ViewBag.Message = "No login information";
            }

            return View();

        }
//--------------------------------------------------------------------------------------------------------------------------------カスタムここまで

        // GET: UserConfigs
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserConfig.ToListAsync());
        }

        // GET: UserConfigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userConfig = await _context.UserConfig
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userConfig == null)
            {
                return NotFound();
            }

            return View(userConfig);
        }

        // GET: UserConfigs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserConfigs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,UserCategoryId")] UserConfig userConfig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userConfig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userConfig);
        }

        // GET: UserConfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userConfig = await _context.UserConfig.FindAsync(id);
            if (userConfig == null)
            {
                return NotFound();
            }
            return View(userConfig);
        }

        // POST: UserConfigs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,UserCategoryId")] UserConfig userConfig)
        {
            if (id != userConfig.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userConfig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserConfigExists(userConfig.Id))
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
            return View(userConfig);
        }

        // GET: UserConfigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userConfig = await _context.UserConfig
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userConfig == null)
            {
                return NotFound();
            }

            return View(userConfig);
        }

        // POST: UserConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userConfig = await _context.UserConfig.FindAsync(id);
            _context.UserConfig.Remove(userConfig);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserConfigExists(int id)
        {
            return _context.UserConfig.Any(e => e.Id == id);
        }
    }
}
