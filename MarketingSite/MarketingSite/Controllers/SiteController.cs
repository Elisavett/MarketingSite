using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketingSite.Models.Data;
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
        public IActionResult RequestList()
        {
            return View(db.Requests.Include(r => r.Application).ToList());
        }
        public IActionResult ApplicationList()
        {
            return View(db.Applications.Include(a => a.Requests).ToList());
        }
        public IActionResult Edit(int? id)
        {
            int applicationId = db.Requests.Single(r => r.Id == id).ApplicationId;
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