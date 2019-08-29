using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionPaperGenerator.ViewModels
{
    public class QuestionPaperViewModel
    {
        public String PaperName { get; set; }
        public int MyProperty { get; set; }
        public List<int[]> Operands { get; set; }
        public List<string> Operators { get; set; }
    }
}