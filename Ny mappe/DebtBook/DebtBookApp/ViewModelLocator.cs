using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebtBookApp.Model;
using DebtBookApp.ViewModel;

namespace DebtBookApp
{
    public class ViewModelLocator
    {
        private DebtBook DebtBook_ => new DebtBook();
        private NavigationService navService_;

        

        public ViewModelLocator(NavigationService navService = null)
        {
            if (navService != null)
                navService_ = navService;        }

        public DebtBookViewModel DebtBookViewModel
        {
            get
            {
                return new DebtBookViewModel(DebtBook_);
            }
        }

        public DisplayDebtHistoryViewModel DisplayDebtHistoryViewModel
        {
            get
            {
                return new DisplayDebtHistoryViewModel(DebtBook_);
            }

            private set
            {
                DisplayDebtHistoryViewModel = value;
            }
        }
        // Add Other viewModels here
    }
}
