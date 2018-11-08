using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TimerTest.ScoreBehavior;

namespace TimerTest.Model
{
    public class Question 
    {
        public IScoreBehavior _IScore { get; set; }
        public string _QuestionText { get; set; }
        public IList<Option> _OptionsList { get; set; }
        public int _QuestionID { get; set; }

        public  int  _QuizID { get; set; }
        public double _PointScore { get; set; }

        private static System.Random nrg => new System.Random();

        public Question(int quizID, int questionID, string question)
        {
            _IScore = (IScoreBehavior) new SimpleScore(20);
            _OptionsList = (IList<Option>) new List<Option>();
            _QuestionID = questionID;
            _QuizID = quizID;
            _QuestionText = question;
            _PointScore = 0;

        }

        public void AddOption(Option option)
        {
            _OptionsList.Add(option);

        }

        public void AddOption(string optionText, bool isRight)
        {
            Option option = new Option(optionText: optionText, isRight: isRight);

            _OptionsList.Add(option);
        }

        public void RandomizeOptionOrder()
        {
            
            int n = _OptionsList.Count;
            while (n > 1)
            {
                n--;
                int k =nrg.Next(n + 1);
                Option opt = _OptionsList[k];
                _OptionsList[k] = _OptionsList[n];
                _OptionsList[n] = opt;
            }
        }

        

    }
}
