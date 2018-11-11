using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel_Layer
{
    class DisplayDebtHistory_ViewModel : INotifyPropertyChanged
    {

        private DebtBook.Model.DebtBook DebtBook;

        public DisplayDebtHistory_ViewModel(DebtBook.Model.DebtBook debtBook)
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
