using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingSite.Models.Data;
using MarketingSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MarketingSite.Controllers
{
    public class SiteController : Controller
    {
        private AppDbContext db;
        public SiteController(AppDbContext context)
        {
            db = context;
        }
        public IActionResult RequestList(int page = 1)
        {
            var requests = db.Requests.Include(r => r.Application).ToList();

            //Проверка первой и последней страницы
            Page.CheckPage(ref page, requests.Count);

            //Текущая страница для пагинации
            ViewBag.page = page;
            return View(requests.Skip((page - 1) * 10).Take(10));
        }
        public IActionResult ApplicationList(int page = 1)
        {
            var applications = db.Applications.Include(a => a.Requests).ToList();

            // Проверка первой и последней страницы
            Page.CheckPage(ref page, applications.Count);

            //Текущая страница для пагинации
            ViewBag.page = page;

            return View(applications.Skip((page - 1) * 10).Take(10));
        }
        public IActionResult Edit(int id)
        {
            int applicationId = db.Requests.Single(r => r.Id == id).ApplicationId;

            //Выпадающий список с приложениями (отображается название, идентификатор - как передаваемое формой значение),
            //выбранное значение - текущее приложение
            ViewBag.ApplicationId = new SelectList(db.Applications.ToList(), "Id", "Name", applicationId);

            return View(db.Requests.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name,Description,Email,EndOfDevelopment,ApplicationId")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Update(request);
                db.SaveChanges();
                return RedirectToAction("RequestList");
            }
            return RedirectToAction("Edit", "Request", new { id = request.Id});
        }
        public IActionResult Create()
        {
            ViewBag.ApplicationId = new SelectList(db.Applications.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,Description,Email,EndOfDevelopment,ApplicationId")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Add(request);
                db.SaveChanges();
                return RedirectToAction("RequestList");
            }
            ViewBag.ApplicationId = new SelectList(db.Applications.ToList(), "Id", "Name");
            return View(request);
        }
    }
}