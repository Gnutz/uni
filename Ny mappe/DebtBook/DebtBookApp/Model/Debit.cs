using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBookApp.Model
{
    public class Debit
    {
        public long Amount { get; set; }

        public DateTime Date { get; private set; }

        public Debit(long amount = 0)
        {
            Amount = amount;
            Date = DateTime.Now;
        }

    }
}
