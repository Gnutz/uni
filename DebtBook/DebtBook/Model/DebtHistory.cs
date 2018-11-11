using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBook.Model
{
    public class DebtHistory
    {
        private ICollection<Debit> Debt => new List<Debit>();

        public DebtHistory(string debtor = "", long initialAmount = 0)
        {
            Debtor = debtor;

            if (initialAmount != 0)
            {
                Debt.Add(new Debit(initialAmount));
            }

        }
        public string Debtor { get; set; }

        public long Total
        {
            get
            {
                long total_ = 0;

                foreach (var amount in Debt)
                {
                    total_ += amount.Amount;
                }

                return total_;
            }
        }

        public void AddDebit(long amount)
        {
            Debt.Add(new Debit(amount));
        }

    }
}
