using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DebtBookApp.ViewModel
{
    public class DebtBookViewModel : INotifyPropertyChanged
    {
        private Model.DebtBook DebtBook;

        public DebtBookViewModel(Model.DebtBook debtBook)
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
