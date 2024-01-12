using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class SavingsAccount : Account
    {
        private const int MinimumBalance = 1000;

        public SavingsAccount(long id, string customerNumber, int initialBalance) : base(id, customerNumber, initialBalance)
        {
            if (initialBalance < MinimumBalance)
            {
                throw new Exception($"Initial balance must be at least {MinimumBalance}");
            }
        }

        public override void Withdraw(int amount)
        {
            if (Balance - amount < MinimumBalance)
            {
                throw new Exception($"Cannot withdraw more than {Balance - MinimumBalance}");
            }
            Balance -= amount;
        }

        public override void Deposit(int amount)
        {
            Balance += amount;
        }
    }
}
