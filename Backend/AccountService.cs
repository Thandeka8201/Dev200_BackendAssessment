using Backend.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class AccountService : IAccountService
    {
        public void withdraw(long accountId, int amountToWithdraw)
        {
            var account = SystemDB.Instance.GetAccount(accountId);
            if (account == null)
            {
                throw new AccountNotFoundException();
            }

            try
            {
                account.Withdraw(amountToWithdraw);
            }
            catch (Exception ex)
            {
                throw new WithdrawalAmountTooLargeException(ex.Message);
            }
        }

        public void deposit(long accountId, int amountToDeposit)
        {
            var account = SystemDB.Instance.GetAccount(accountId);
            if (account == null)
            {
                throw new AccountNotFoundException();
            }

            account.Deposit(amountToDeposit);

        }

        public void openSavingsAccount(long accountId, int amountToDeposit, string customerNumber)
        {
            var newSavingsAccount = new SavingsAccount(accountId, customerNumber, amountToDeposit);
            SystemDB.Instance.TryAddAccount(accountId, newSavingsAccount);
        }

        public void openCurrentAccount(long accountId, int amountToDeposit, string customerNumber, int overdraftLimit)
        {
            var newCurrentAccount = new CurrentAccount(accountId, customerNumber, amountToDeposit, overdraftLimit);
            SystemDB.Instance.TryAddAccount(accountId, newCurrentAccount);
        }
    }
}
