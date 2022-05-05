using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class QnA
    {
        private string category;
        private string question;
        private string answer;

        public QnA() { }
        public string Category { get => category; set => category = value; }
        public string Question { get => question; set => question = value; }
        public string Answer { get => answer; set => answer = value; }

        public QnA(string category)
        {
            this.category = category;
        }

        public QnA(string category, string question, string answer)
        {
            this.category = category;
            this.question = question;
            this.answer = answer;
        }

        public string ToString()
        {
            return category + ": " + question + ": " + answer; 
        }
    }//class
}//ns
