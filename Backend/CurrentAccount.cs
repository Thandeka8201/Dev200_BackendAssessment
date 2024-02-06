using Backend.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class CurrentAccount : Account
    {
        private int OverdraftLimit { get; set; }

        public CurrentAccount(long id, string customerNumber, int initialBalance, int overdraftLimit) : base(id, customerNumber, initialBalance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override void Withdraw(int amount)
        {
            if (Balance + OverdraftLimit < amount)
            {
                throw new WithdrawalAmountTooLargeException($"Cannot withdraw more than {Balance + OverdraftLimit}");
            }
            Balance -= amount;
        }

        public override void Deposit(int amount)
        {
            Balance += amount;
        }
    }
}
