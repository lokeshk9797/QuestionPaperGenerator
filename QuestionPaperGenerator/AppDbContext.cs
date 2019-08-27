using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using QuestionPaperGenerator.Models;

namespace QuestionPaperGenerator
{
    public class AppDbContext : DbContext
    {
        public AppDbContext():base("ProjectConnectionString")
        {

        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<Worksheet> Worksheets{ get; set; }
        public DbSet<QuestionPattern> QuestionPatterns { get; set; }

    }
}