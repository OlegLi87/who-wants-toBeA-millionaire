using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    public abstract class GeneralQuestion 
    {
        public abstract string Question { get; set; }
        public abstract string[] Answers { get; set; }
        public abstract string RightAnswer { get; set; }
        protected static Random rand = new Random();

        protected GeneralQuestion(string question,string rightAnswer,string[] answers)
        {
            this.Question = question;
            this.Answers = new string[answers.Length];
            Array.Copy(answers, this.Answers, answers.Length);
            this.RightAnswer = rightAnswer;
        }
    }
}
