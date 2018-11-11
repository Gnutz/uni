using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;

namespace TimerTest.ScoreBehavior
{
    class SimpleScore : INotifyPropertyChanged
    {
        string time;
        double timeLeft;
        double totalPoints;
        public SimpleScore(int timeLeftForAnswerInSecs)
        {
            timeLeft = timeLeftForAnswerInSecs;
            totalPoints = 20000;
            Update();
            StartTimer();
        }

        public void Update()
        {
            Time = DateTime.Now.ToLongTimeString();
            TimeLeft -= 1;
            TotalPoints = TimeLeft * 100;
        }

        public string Time
        {
            get { return time; }
            private set
            {
                if (time != value)
                {
                    time = value;
                    Notify("Time");
                }
            }
        }

        public double TimeLeft
        {
            get { return timeLeft; }
            private set
            {
                if (timeLeft != value)
                {
                    if (value < 0)
                    {
                        timeLeft = 0;
                    }
                    else
                    {
                        timeLeft = value;
                        Notify("TimeLeft");
                    }
                }
            }
        }

        public double TotalPoints
        {
            get { return totalPoints; }
            private set
            {
                if (totalPoints != value)
                {
                    totalPoints = value;
                    Notify("TotalPoints");
                }
            }
        }


        private void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }   
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void StartTimer()
        {
            Timer timer = new System.Timers.Timer(1000);
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(Timer_Tick);
            timer.AutoReset = true;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            Update();
        }

    }

}
