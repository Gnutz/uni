using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTest.ScoreBehavior
{
    public interface IScoreBehavior
    {
        double CalculateScore(bool isRight);
        
    }
}
