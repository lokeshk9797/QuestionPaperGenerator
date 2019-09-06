using QuestionPaperGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using QuestionPaperGenerator.Models;

namespace QuestionPaperGenerator.Controllers
{
    public class TemplateController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Template
        public ActionResult Index()
        {
            return View();
        }

        // GET: Template/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Template/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Template/Create
        [HttpPost]
        public ActionResult Create(TemplateViewModel templateView)
        {

            Template template = new Template { Name = templateView.Template.Name, Formula = templateView.Template.Formula };
            var max = 1;
                for (var i = 0; i < templateView.Variables.Count; i++)
            {
                Variable variable = new Variable();
                variable = templateView.Variables[i];
                max = max * ((variable.MaxValue - variable.MinValue) + 1);
                template.Variables.Add(variable);
            }
            db.Templates.Add(template);
            db.SaveChanges();
            return RedirectToAction("Index","Home");


        }

        // GET: Template/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Template/Edit/5
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

        // GET: Template/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Template/Delete/5
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
