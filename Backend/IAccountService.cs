using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public interface IAccountService
    {
        void openSavingsAccount(long accountId, int amountToDeposit, string customerNumber);
        void openCurrentAccount(long accountId, int amountToDeposit, string customerNumber, int overdraftLimit);
        void withdraw(long accountId, int amountToWithdraw);
        void deposit(long accountId, int amountToDeposit);
    }
}
