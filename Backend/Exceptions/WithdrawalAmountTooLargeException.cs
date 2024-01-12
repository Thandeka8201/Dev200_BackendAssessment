using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Exceptions
{
    [Serializable]
    public class WithdrawalAmountTooLargeException : Exception
    {
        public WithdrawalAmountTooLargeException() { }
        public WithdrawalAmountTooLargeException(string message) : base(message) { }
        public WithdrawalAmountTooLargeException(string message, Exception inner) : base(message, inner) { }
    }
}
