using QuestionPaperGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


namespace QuestionPaperGenerator.Engine
{
    public class QuestionGeneratorEngine
    {
        public List<int[][]> numbers = new List<int[][]>();
        public List<int[][]>  GeneratorEngine(Worksheet worksheet)
        {
            var name = worksheet.WorksheetName;
            for(var i=0;i<worksheet.QuestionPatterns.Count;i++)
            {
                QuestionPattern question = worksheet.QuestionPatterns.ElementAt(i);
                String QuestionName = question.Template.Name.ToString();
                GetNumbers(question);
            }
            return numbers;

        }
        public void GetNumbers(QuestionPattern question)
        {
            
            var count = question.Template.Variables.Count();
            string formula = question.Template.Formula.ToString();
            var ArrayOfVariables = Regex.Matches(formula, @"[^{\}]+(?=})").Cast<Match>().Select(m=>m.Value).ToList();
                   
            Regex operatorRegexPattern = new Regex(@"(\+|-|\*|\/)");
            Match operatorInside = operatorRegexPattern.Match(formula);

            var indexOfOperator=operatorInside.Index;

            foreach(var match in ArrayOfVariables)
            {
                
            }
           

            foreach (var variable in question.Template.Variables)
            {
                var RandNum = new Random().Next(variable.MinValue,variable.MaxValue);
                

            }
            //var firstNumber = numbers.ElementAt(0) * 10 + numbers.ElementAt(1);

            //var SecondNumbr = numbers.ElementAt(2) *10 + numbers.ElementAt(3); 

        }
    }
}