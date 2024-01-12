using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class SystemDB
    {
        private static readonly Lazy<SystemDB> database = new Lazy<SystemDB>(() => new SystemDB());
        public static SystemDB Instance { get { return database.Value; } }

        public ConcurrentDictionary<long, Account> accounts;

        private SystemDB()
        {
            accounts = new ConcurrentDictionary<long, Account>();

            //initializing some hardcoded accounts
            accounts.TryAdd(1, new SavingsAccount(1, "customerNum1", 2000));
            accounts.TryAdd(2, new SavingsAccount(2, "customerNum2", 5000));
            accounts.TryAdd(3, new CurrentAccount(3, "customerNum3", 1000, 10000));
            accounts.TryAdd(4, new CurrentAccount(4, "customerNum4", -5000, 20000));
        }

        public bool TryAddAccount(long accountId, Account account)
        {
            return accounts.TryAdd(accountId, account);
        }

        public Account GetAccount(long accountId)
        {
            accounts.TryGetValue(accountId, out var account);
            return account;
        }
    }
}
