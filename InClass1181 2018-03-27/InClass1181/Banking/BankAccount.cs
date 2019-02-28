using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BankingExceptions;

namespace Banking
{
    public class BankAccount
    {

        private string _CustomerName;
        private double _Balance;
        private bool _frozen = false;

        //public const string DebitAmountMoreThanBalance = "Debit Amount is More than balance.";
        //public const string DebitAmountEqualOrBelowZero = "Deit Amount is Equal or Below Zero.";


        public BankAccount()
        {
            _CustomerName = "";
            _Balance = 0;
        }
        public BankAccount(string CustomerName, double OpendingBalance)
        {
            _CustomerName = CustomerName;
            _Balance = OpendingBalance;
        }

        public string CustomerName
        {
            get
            {
                return _CustomerName;
            }
        }

        public double Balance
        {
            get
            {
               return _Balance;
            }
        }

        public bool Frozen
        {
            set
            {
                _frozen = value;
            }
        }

        public void Debit (double amount)
        {
            if (_frozen)
                throw new AccountFrozenExcetption();

            if (amount <= 0)
                //throw new Exception(DebitAmountEqualOrBelowZero);
                throw new AmountEqualOrBelowZeroException();

            if (amount > Balance)
                //throw new Exception(DebitAmountMoreThanBalance);
                throw new AmountMoreThanBalanceExcetption();


            _Balance -= amount; // bug here -- fixed
        }

        public void Credit(double amount)
        {
            _Balance += amount;
        }


    }
}
