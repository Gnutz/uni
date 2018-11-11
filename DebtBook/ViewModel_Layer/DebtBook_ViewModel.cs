using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace DebtBook.ViewModel
{
    public class DebtBook_ViewModel: INotifyPropertyChanged
    {
        private Model.DebtBook DebtBook;

        public DebtBook_ViewModel(Model.DebtBook debtBook)
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
