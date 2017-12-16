using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    public class MediumQuestion : GeneralQuestion,IComparable
    {
        public override string Question { get; set; }
        public override string[] Answers { get; set; }
        public override string RightAnswer { get; set; }
        
        public MediumQuestion(string question, string rightAnswer,string[] answers) : base(question, rightAnswer, answers)
        {
           
        }
        public int CompareTo(object obj)
        {
            return rand.Next(-1,1);
        }
    }
}
