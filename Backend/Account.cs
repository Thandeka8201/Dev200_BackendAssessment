using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public abstract class Account
    {
        public long Id { get; set; }
        public string CustomerNumber { get; set; }
        public int Balance { get; set; }

        public Account(long id, string customerNumber, int initialBalance)
        {
            Id = id;
            CustomerNumber = customerNumber;
            Balance = initialBalance;
        }

        public virtual void Deposit(int amount)
        {
            Balance += amount;
        }

        public abstract void Withdraw(int amount);
    }
}
