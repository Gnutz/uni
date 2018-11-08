using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTest.Model
{
    public class Quiz
    {
        public string  _QuizName { get; set; }
        public int _QuizID { get; set; }
        public int _TopicID { get; set; }
        public double _TotalScore { get; set; }
        public IList<Question> _QuestionList { get; set; }

        public Quiz()
        {
            Question q = new Question();
            q.S
        }

        public Quiz(string quizName, int quizID, int topicID)
        {
            _QuizName = quizName;
            _QuizID = quizID;
            _TopicID = topicID;

            _QuestionList = (IList<Question>)new List<Question>();

        }
        


    }
}
