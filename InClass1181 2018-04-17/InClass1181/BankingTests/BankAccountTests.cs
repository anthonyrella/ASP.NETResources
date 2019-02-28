using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Banking;
using BankingExceptions;

namespace BankingTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_DecreaseBalance()
        {

            //Arrange
            double OpeningBalance = 1000;
            string CustomerName = "Amandeep Patti";
            
            BankAccount BA = new BankAccount(CustomerName, OpeningBalance);

            double DebitAmount = 90;
            double ExpectedBalance = 910;


            // Act
            BA.Debit(DebitAmount);
            double ActualBalance = BA.Balance;
            
            //Assert
            Assert.AreEqual(ExpectedBalance, ActualBalance);

        }

        [TestMethod]
        public void Credit_WithValidAmount_IncreaseBalance()
        {
            // Arrange
            double OpeningBalance = 1000;
            string CustomerName = "Amandeep Patti";

            BankAccount BA = new BankAccount(CustomerName, OpeningBalance);

            double CreditAmount = 50;
            double ExpectedBalance = 1050;

            // Act 
            BA.Credit(CreditAmount);
            double ActualBalance = BA.Balance;

            // Assert
            Assert.AreEqual(ExpectedBalance, ActualBalance);
        }




        //[TestMethod]
        //public void Debit_WithBelowZero_Exception()
        //{

        //    //Arrange
        //    double OpeningBalance = 1000;
        //    string CustomerName = "Amandeep Patti";

        //    BankAccount BA = new BankAccount(CustomerName, OpeningBalance);

        //    double DebitAmount = -100;
        //    string ExpectedMessage = BankAccount.DebitAmountEqualOrBelowZero;


        //    // Act
        //    try
        //    {
        //        BA.Debit(DebitAmount);
        //        Assert.Fail();
        //    }
        //    catch (Exception ex)
        //    {
        //        string ActualMessage = ex.Message;
        //        Assert.AreEqual(ExpectedMessage, ActualMessage);

        //    }


        //    //Assert


        //}

        [TestMethod]
        [ExpectedException(typeof(AmountEqualOrBelowZeroException))]
        public void Debit_WithBelowZero_Exception()
        {

            //Arrange
            double OpeningBalance = 1000;
            string CustomerName = "Amandeep Patti";

            BankAccount BA = new BankAccount(CustomerName, OpeningBalance);

            double DebitAmount = -100;



            // Act
            BA.Debit(DebitAmount);

            
            //Assert
            // automatically handled by expected exception type

        }


        [TestMethod]
        [ExpectedException(typeof(AccountFrozenExcetption))]
        public void Debit_FromFreezedAccount_Exception()
        {

            //Arrange
            double OpeningBalance = 1000;
            string CustomerName = "Amandeep Patti";

            BankAccount BA = new BankAccount(CustomerName, OpeningBalance);
            BA.Frozen = true;

            double DebitAmount = 100;

            // Act
            BA.Debit(DebitAmount);


            //Assert
            // automatically handled by expected exception type

        }
    }
}
