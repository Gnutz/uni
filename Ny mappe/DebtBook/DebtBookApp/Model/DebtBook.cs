using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBookApp.Model
{
    public class DebtBook
    {
        private ICollection<DebtHistory> Debts => new List<DebtHistory>();

        public void AddNewHistory(string debtor = "", long initialAmount = 0)
        {
            Debts.Add(new DebtHistory(debtor, initialAmount));
        }

        public void AddDebit(string debtor = "", long amount = 0)
        {
            foreach (var history in Debts)
            {
                if (history.Debtor == debtor)
                {
                    history.AddDebit(amount);
                }
            }
        }

    }
}
