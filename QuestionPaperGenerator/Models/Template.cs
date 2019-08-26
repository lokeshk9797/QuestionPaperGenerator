using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuestionPaperGenerator.Models
{
    [Table ("TemplateMaster")]
    public class Template
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [StringLength(100)]
        public String  Formula { get; set; }
         
    }
}