using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuestionPaperGenerator.Models
{
    [Table("TemplateDetails")]
    public class Variable
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        [Required]
        [Range(0, 9,ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MinValue { get; set; }
        [Required]
        [Range(0, 9,ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MaxValue { get; set; }

        [ForeignKey("Template")]
        public virtual int Template_Id { get; set; }
        public virtual Template Template { get; set; }

    }
}