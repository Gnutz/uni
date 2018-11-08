using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;
using TimerTest.Model;

namespace TimerTest.ViewModel
{
    class ScoreViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ScoreModel scoreModel = new ScoreModel();

        public double TimeLeft
        {
            get => scoreModel.TimeLeft;
            set
            {
                if (value != scoreModel.TimeLeft)
                {
                    scoreModel.TimeLeft = value;
                    OnPropertyChanged();
                }
            }
        }

        public double TotalPoints
        {
            get => scoreModel.TotalPoints;
            set
            {
                if (value != scoreModel.TotalPoints)
                {
                    scoreModel.TotalPoints = value;
                    OnPropertyChanged();
                }
            }
        }

        private void CalcScore()
        {
            TotalPoints = scoreModel.CalculateScore();
            OnPropertyChanged("TotalPoints");
        }
        
        private bool CalcScoreCanExecute()
        {
            bool paramsAreValid = (TimeLeft > 0);
            return paramsAreValid;
        }

        private bool TimerCanStart()
        {
            bool paramsAreValid = (TimeLeft >= 20);
            return paramsAreValid;
        }

        private ICommand _calcScoreCommand;

        public ICommand CalcScoreCommand => 
            _calcScoreCommand ?? (_calcScoreCommand = new RelayCommand(CalcScore, CalcScoreCanExecute));
        
        private ICommand _startQuizTimer;

        public ICommand StartQuizCommand =>
            _startQuizTimer ?? (_startQuizTimer = new RelayCommand(StartTimer, TimerCanStart));

        public void StartTimer()
        {
            Timer timer = new System.Timers.Timer(500);
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(Timer_Tick);
            timer.AutoReset = true;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            TimeLeft = scoreModel.UpdateTimeLeft();
            OnPropertyChanged("TimeLeft");
        }
    }
}
