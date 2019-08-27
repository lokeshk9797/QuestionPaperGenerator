using QuestionPaperGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionPaperGenerator.ViewModels
{
    public class TemplateViewModel
    {
        public List<Variable> Variables{ get; set; }
        public String SelectedId { get; set; }
        public Template Template { get; set; }
    }
}