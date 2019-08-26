using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuestionPaperGenerator.Models
{
    [Table("WorksheetDetails")]
    public class QuestionPattern
    {
        public int Id { get; set; }
        [Required]
        public int Frequency { get; set; }
        [Required]
        public int Marks { get; set; }

        [ForeignKey("Template")]
        public virtual int Template_Id { get; set; }
        public virtual Template Template { get; set; }

        [ForeignKey("Worksheet")]
        public virtual int Worksheet_Id { get; set; }
        public virtual Worksheet Worksheet { get; set; }
    }
}