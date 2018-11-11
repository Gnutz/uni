using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLayer
{
    public class ViewModelLocator
    {
        private DebtBook.Model.DebtBook DebtBook => new DebtBook.Model.DebtBook();
        public DebtBook_ViewModel DBViewModel
        {
            get
            {
                return new DebtBook_ViewModel(DebtBook);
            }
        }
        // Add Other viewModels here
    }
}

