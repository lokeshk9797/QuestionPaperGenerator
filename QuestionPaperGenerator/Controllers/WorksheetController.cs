using QuestionPaperGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestionPaperGenerator.ViewModels;

namespace QuestionPaperGenerator.Controllers
{
    public class WorksheetController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Worksheet
        public ActionResult Index()
        {
            return View();
        }

        // GET: Worksheet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Worksheet/Create
        public ActionResult AddWorksheet()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            List<Template> templates = db.Templates.ToList();
            List<int> maxFrequencies = new List<int>();
            foreach (var template in templates)
            {
                selectListItems.Add(new SelectListItem() { Text = template.Name, Value = template.Id.ToString() });
            }
            ViewBag.Templates = selectListItems;
            return View();
        }

        // POST: Worksheet/Create
        [HttpPost]
        public ActionResult Create(WorksheetViewModel worksheetView)
        {
            Worksheet worksheet = new Worksheet {WorksheetName=worksheetView.Worksheet.WorksheetName };
            for(var i=0;i<worksheetView.QuestionPatterns.Count;i++)
            {
                QuestionPattern question = new QuestionPattern();
                question = worksheetView.QuestionPatterns[i];
                worksheet.QuestionPatterns.Add(question);
            }
            db.Worksheets.Add(worksheet);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // GET: Worksheet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Worksheet/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Worksheet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Worksheet/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
