using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TimerTest.ScoreBehavior;
using TimerTest.ViewModel;

namespace TimerTest.Model
{
    class ScoreModel : IScoreBehavior
    {
        
        public ScoreModel()
        {
            TimeLeft = 20;
            TotalPoints = 0;
            
        }

        public double TimeLeft;
        public double TotalPoints;

        public double CalculateScore( bool isRight)
        {
            return (isRight == true)? TimeLeft * 100 : 0;
        }

        public double UpdateTimeLeft()
        {
            return TimeLeft -= 0.5;
        }

        
        
    }
}
