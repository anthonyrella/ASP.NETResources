using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingExceptions
{
    public class AmountEqualOrBelowZeroException: Exception
    {
        public AmountEqualOrBelowZeroException() : base("Amount is Equal or Below Zero.")
        {
            
        }

    }

    public class AmountMoreThanBalanceExcetption : Exception
    {
        public AmountMoreThanBalanceExcetption() : base("Amount is More Than Balance.")
        {

        }
    }

    public class AccountFrozenExcetption : Exception
    {
        public AccountFrozenExcetption() : base("Amount is Freezed.")
        {

        }
    }

}
