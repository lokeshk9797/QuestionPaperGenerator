
using QuestionPaperGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionPaperGenerator.ViewModels
{
    public class QuestionPaperViewModel
    {
        public QuestionPaperViewModel()
        {
            this.Questions = new List<QuestionModel>();
        }
        public String PaperName { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}