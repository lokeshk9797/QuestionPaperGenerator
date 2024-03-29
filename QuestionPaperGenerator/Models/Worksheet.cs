﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuestionPaperGenerator.Models
{
    [Table("WorksheetMaster")]
    public class Worksheet
    {
        public Worksheet()
        {
            this.QuestionPatterns = new List<QuestionPattern>();
        }
        public int Id { get; set; }
        [Required]
        public String WorksheetName { get; set; }
        public virtual ICollection<QuestionPattern> QuestionPatterns { get; set; }

    }
}