using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test_Progect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Test_Progect.Controllers
{
    public class HomeController : Controller
    {
        UserContext db;
        public HomeController(UserContext context)
        {
            db = context;
        }

        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            db.Books.Add(book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Book book = await db.Books.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null)
                    return View(book);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Book book = await db.Books.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null)
                    return View(book);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book phone)
        {
            db.Books.Update(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Book book = await db.Books.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null)
                    return View(book);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
               Book book = await db.Books.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null)
                {
                    db.Books.Remove(book);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
