﻿using QuestionPaperGenerator.Models;
using QuestionPaperGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuestionPaperGenerator.Engine;

namespace QuestionPaperGenerator.Controllers
{
    public class QuestionGeneratorController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: QuestionGenerator
        public ActionResult Index()
        {
            return View();
        }

        // GET: QuestionGenerator/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: QuestionGenerator/Create
        public ActionResult Create()
        {

            return View();
        }

        public ActionResult GetWorksheet()
        {
            ViewBag.Worksheets = new SelectList(db.Worksheets, "Id", "WorksheetName");
            return View();
        }
        [HttpPost]
        public ActionResult GetWorksheet(int Worksheets)
        {
            return RedirectToAction("GeneratePaper", "QuestionGenerator",new {worksheet= Worksheets });
        }


        public ActionResult GeneratePaper(int worksheet)
        {
            Worksheet worksheets = db.Worksheets.Where(s=>s.Id==worksheet).FirstOrDefault();
            
            
             worksheets.QuestionPatterns= db.QuestionPatterns.Where(s => s.Worksheet_Id == worksheet).ToList();
            //var templates = db.Templates.ToList();
            //List<Template> selectedTemplates = new List<Template>();
            //foreach(var questionPattern in questionPatterns)
            //{

            //    selectedTemplates.Add(templates.Where(s => s.Id == questionPattern.Template_Id).FirstOrDefault());
            //}
            //var variables = db.Variables.ToList();
            //List<Variable> selectedVariables = new List<Variable>();
            //foreach(var template in selectedTemplates){
            //    selectedVariables.Add(variables.Where(s => s.Template_Id == template.Id).FirstOrDefault());
            //}
            QuestionGeneratorEngine questionGeneratorEngine = new QuestionGeneratorEngine();
            QuestionPaperViewModel questionPaper= questionGeneratorEngine.GeneratorEngine(worksheets);
            return View(questionPaper);
        }

       

        // POST: QuestionGenerator/Create
        [HttpPost]
        public ActionResult GeneratePaper(QuestionPaperViewModel questionPaperWithAnswers)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuestionGenerator/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QuestionGenerator/Edit/5
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

        // GET: QuestionGenerator/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuestionGenerator/Delete/5
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
