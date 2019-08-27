using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuestionPaperGenerator;
using QuestionPaperGenerator.Models;

namespace QuestionPaperGenerator.Controllers
{
    public class WorksheetController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Worksheet
        public ActionResult Index()
        {
            return View(db.Worksheets.ToList());
        }

        // GET: Worksheet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = db.Worksheets.Find(id);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(worksheet);
        }

        // GET: Worksheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Worksheet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorksheetName")] Worksheet worksheet)
        {
            if (ModelState.IsValid)
            {
                db.Worksheets.Add(worksheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(worksheet);
        }

        // GET: Worksheet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = db.Worksheets.Find(id);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(worksheet);
        }

        // POST: Worksheet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorksheetName")] Worksheet worksheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(worksheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(worksheet);
        }

        // GET: Worksheet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Worksheet worksheet = db.Worksheets.Find(id);
            if (worksheet == null)
            {
                return HttpNotFound();
            }
            return View(worksheet);
        }

        // POST: Worksheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Worksheet worksheet = db.Worksheets.Find(id);
            db.Worksheets.Remove(worksheet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
