﻿using QuestionPaperGenerator.Models;
using QuestionPaperGenerator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;


namespace QuestionPaperGenerator.Engine
{
    public class QuestionGeneratorEngine
    {
        public List<int[]> numbers = new List<int[]>();
        QuestionPaperViewModel QuestionPaper = new QuestionPaperViewModel();

        public QuestionPaperViewModel  GeneratorEngine(Worksheet worksheet)
        {
            QuestionPaper.PaperName = worksheet.WorksheetName;
            for(var i=0;i<worksheet.QuestionPatterns.Count;i++)
            {
                QuestionPattern question = worksheet.QuestionPatterns.ElementAt(i);
                String QuestionName = question.Template.Name.ToString();
                GetVariables(question);
            }

            return QuestionPaper;

        }
        public void GetVariables(QuestionPattern question)
        {
            
            var count = question.Template.Variables.Count();
            var variables = question.Template.Variables.ToList();
            string formula = question.Template.Formula.ToString();
            //var ArrayOfVariables = Regex.Matches(formula, @"[^{\}]+(?=})").Cast<Match>().Select(m=>m.Value).ToList();
                   
            Regex operatorRegexPattern = new Regex(@"(\+|-|\*|\/)");
            Match operatorInside = operatorRegexPattern.Match(formula);

            string[] result = Regex.Split(formula, operatorRegexPattern.ToString());


            int noOfVariablesInFirstNumber = Regex.Matches(result[0].ToString(), @"[^{\}]+(?=})").Count;
            for(var i = 0; i < question.Frequency; i++)
            {
                GetNumbers(variables, noOfVariablesInFirstNumber,operatorInside.ToString(),question.Marks);

            }


        }

        public void GetNumbers(List<Variable> Variables,int noOfVariablesInFirstNumber,string operatorInside,int marks)
        {
            var count = Variables.Count();
            int firstNumber = 0;
            int secondNumber = 0;
            for (var i = 0; i < count; i++)
            {
                //int RandNum = new Random().Next(Variables.ElementAt(i).MinValue, Variables.ElementAt(i).MaxValue);
                int RandNum = NextRandom(Variables.ElementAt(i).MinValue, Variables.ElementAt(i).MaxValue);

                if (i < noOfVariablesInFirstNumber)
                {
                    firstNumber += Convert.ToInt32(RandNum * Math.Pow(10, i));
                }
                else
                {
                    secondNumber += Convert.ToInt32(RandNum * Math.Pow(10, i - noOfVariablesInFirstNumber));
                }
            }
            QuestionModel question = new QuestionModel() { FirstOperand = firstNumber, SecondOperand = secondNumber, Operator = operatorInside,Mark=marks };
            QuestionPaper.Questions.Add(question);
            
        }

        public static int NextRandom(int min, int max)
        {
            if (min >= max)
            {
                throw new ArgumentException("Min value is greater or equals than Max value.");
            }
            byte[] intBytes = new byte[4];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetNonZeroBytes(intBytes);
            }
            return min + Math.Abs(BitConverter.ToInt32(intBytes, 0)) % (max - min + 1);
        }
    }

}