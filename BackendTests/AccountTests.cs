using Backend;
using Backend.Exceptions;

namespace BackendTests
{
    public class AccountTests
    {
        [Fact]
        public void TestOpenSavingsAccount()
        {
            //Arrange
            var accountService = new AccountService();
            var accountId = 10;
            var customerNumber = "customerNum10";
            var initialBalance = 2000;

            //Act
            accountService.openSavingsAccount(accountId, initialBalance, customerNumber);

            //Assert
            var account = SystemDB.Instance.GetAccount(accountId);
            Assert.NotNull(account);
            Assert.Equal(accountId, account.Id);
            Assert.Equal(customerNumber, account.CustomerNumber);
            Assert.Equal(initialBalance, account.Balance);

        }
        [Fact]
        public void TestDeposit()
        {
            //Arrange
            var accountService = new AccountService();
            var accountId = 1;
            var customerNumber = "customerNum1";
            var initialBalance = 2000;
            var depositamount = 500;

            //Act
            accountService.openSavingsAccount(accountId, initialBalance, customerNumber);
            accountService.deposit(accountId, depositamount);

            //Assert
            var account = SystemDB.Instance.GetAccount(accountId);
            Assert.Equal(initialBalance + depositamount, account.Balance);
        }

        [Fact]
        public void TestOpenCurrentAccount()
        {
            //Arrange
            var accountService = new AccountService();
            var accountId = 5;
            var customerNumber = "customerNum5";
            var initialBalance = 1000;
            var overdraftLimit = 10000;

            //Act
            accountService.openCurrentAccount(accountId, initialBalance, customerNumber, overdraftLimit);

            //Assert
            var account = SystemDB.Instance.GetAccount(accountId);
            Assert.NotNull(account);
            Assert.Equal(accountId, account.Id);
            Assert.Equal(customerNumber, account.CustomerNumber);
            Assert.Equal(initialBalance, account.Balance);
        }

        [Fact]
        public void TestWithdraw()
        {
            //Arrange
            var accountservice = new AccountService();
            var accountId = 3;
            var customerNumber = "customerNum3";
            var initialBalance = 1000;
            var overdraftLimit = 10000;
            var withdrawalAmount = 500;

            //Act
            accountservice.openCurrentAccount(accountId, initialBalance, customerNumber, overdraftLimit);
            accountservice.withdraw(accountId, withdrawalAmount);

            //Assert
            var account = SystemDB.Instance.GetAccount(accountId);
            Assert.Equal(initialBalance - withdrawalAmount, account.Balance);
        }

        [Fact]
        public void TestWithdrawOverdraft()
        {
            //Arrange
            var accountService = new AccountService();
            var accountId = 3;
            var customerNumber = "customerNum3";
            var initialBalance = 1000;
            var overdraftLimit = 10000;
            var withdrawalAmount = initialBalance + overdraftLimit + 1;

            //Act
            accountService.openCurrentAccount(accountId, initialBalance, customerNumber, overdraftLimit);

            //Assert
            Assert.Throws<WithdrawalAmountTooLargeException>(() => accountService.withdraw(accountId, withdrawalAmount));
        }

        [Fact]
        public void TestWithdrawNegativeBalance()
        {
            //Arrange
            var accountService = new AccountService();
            var accountId = 4;
            var customerNumber = "customerNum4";
            var initialBalance = -5000;
            var overdraftLimit = 20000;
            var withdrawalAmount = initialBalance + overdraftLimit - 1;

            //Act
            accountService.openCurrentAccount(accountId, initialBalance, customerNumber, overdraftLimit);
            accountService.withdraw(accountId, withdrawalAmount);

            //Assert
            var account = SystemDB.Instance.GetAccount(accountId);
            Assert.True(account != null);
            Assert.True(account.Balance < 0);
        }
    }
}
