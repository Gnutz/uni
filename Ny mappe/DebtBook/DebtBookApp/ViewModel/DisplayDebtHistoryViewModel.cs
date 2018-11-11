using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DebtBookApp.Model;

namespace DebtBookApp.ViewModel
{
    public class DisplayDebtHistoryViewModel : INotifyPropertyChanged
    {

        private DebtBook DebtBook;

        public DisplayDebtHistoryViewModel(DebtBook debtBook)
        {
            DebtBook = debtBook;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void INotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
