using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTest.Model
{
    public class QuizManager
    {

        //need database util
        public Quiz _CurrentQuiz { get; set; }

        public void LoadQuiz(int quizID)
        {
            _CurrentQuiz = new Quiz();
            _CurrentQuiz._QuizID = quizID;

                //util.GetQuiz(ref Quiz)
            

        }



        //If Necessary Add Load Option and LoadQuestion
    }
}
