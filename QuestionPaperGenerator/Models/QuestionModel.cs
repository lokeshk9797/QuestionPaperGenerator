using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestionPaperGenerator.Models
{
    public class QuestionModel
    {
        public int FirstOperand { get; set; }
        public int SecondOperand { get; set; }
        public String Operator { get; set; }
        public int Answer { get; set; }
        public int Mark { get; set; }
    }
}