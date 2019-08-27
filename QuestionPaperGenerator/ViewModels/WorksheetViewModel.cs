using QuestionPaperGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionPaperGenerator.ViewModels
{
    public class WorksheetViewModel
    {
        public Worksheet Worksheet { get; set; }
        public List<Template> Templates { get; set; }
        public List<QuestionPattern> QuestionPatterns { get; set; }
    }
}