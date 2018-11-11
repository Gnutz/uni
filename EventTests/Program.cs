using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerTest.Model;

namespace EventTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Quiz currentQuiz = new Quiz(quizID: 1, quizName: "Name", topicID: 1);

            //Question 1:
            Question firstQuestion = new Question();
            firstQuestion._QuestionText = "question 1?";
            
            Option opt1 = new Option("option 1", true);
            Option opt2 = new Option("option 2", false);
            Option opt3 = new Option("option 3", false);
            Option opt4 = new Option("option 4", false);

            firstQuestion.AddOption(new Option("option 1", true));
            firstQuestion.AddOption(new Option("option 2", false));
            firstQuestion.AddOption(new Option("option 3", false));
            firstQuestion.AddOption(new Option("option 4", false));

            firstQuestion.RandomizeOptionOrder();

            foreach (Option opt in firstQuestion._OptionsList)
            {
                Console.WriteLine($"{opt._OptionText}, {opt._IsRight}");
            }


            Question currentQuestion = new Question();


            Console.ReadKey();


        }
    }
}
