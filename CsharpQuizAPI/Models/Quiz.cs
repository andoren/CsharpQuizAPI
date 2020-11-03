using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsharpQuizAPI.Models
{
    public class Quiz
    {
        string _question;
        int _id;
        string _explanation;
        string[] _answers;
        string _corretAnswer;

        public Quiz(int id, string question,  string explanation, string[] answers, string corretAnswer)
        {
            _question = question ?? throw new ArgumentNullException(nameof(question));
            _id = id;
            _explanation = explanation ?? throw new ArgumentNullException(nameof(explanation));
            _answers = answers ?? throw new ArgumentNullException(nameof(answers));
            _corretAnswer = corretAnswer ?? throw new ArgumentNullException(nameof(corretAnswer));
        }


        public int Id
        {
            get { return _id; }
            private set {  _id = value; }
        }
        public string Question { 
            get {
                return _question;
            } 
            private set {
                _question = value;
            }
        }
        public string Explanation {
            get{
                return _explanation;
            }
            private set {
                _explanation = value;    
            }
        }

        public string[] Answers {
            get {
                return _answers;
            }
            set
            {
                _answers = value;
            }
        }
        public string CorrectAnswer {
            get {
                return _corretAnswer;
            }
            set {
                _corretAnswer = value;
            }
        }
    }
}
