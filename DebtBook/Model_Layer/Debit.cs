using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBook.Model
{
    public class Debit
    {
        public long Amount { get; set;}

        public DateTime Date { get; private set; }

        public Debit(long amount = 0)//skal den ikke være tom?
        {
            Amount = amount;
            Date = DateTime.Now;
        }
        
    }
}
