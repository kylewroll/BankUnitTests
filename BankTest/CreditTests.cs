/* Author: Kyle Rolland
 * Date: 4/22/2021
 * File: CreditTests.cs
 * Description: Contains implementation of credit unit tests
 */
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;
using System;

namespace BankTest
{
    [TestClass]
    public class CreditTests
    {
        // unit test code
        [TestMethod]
        public void Credit_WithAValidAmount_UpdatesBalance()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            double expected = 16.54;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            account.Credit(creditAmount);

            // assert  
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not dredited correctly");
        }

        // unit test method  
        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange  
            double beginningBalance = 11.99;
            double creditAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act  
            try
            {
                account.Credit(creditAmount);
            }

            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("No exception was thrown.");
        }

        // unit test method
        [TestMethod]
        public void Credit_WhenAccountFrozen_ShouldThrowException()
        {
            // arrange
            double beginningBalance = 11.99;
            double creditAmount = 4.55;
            BankAccount account = new BankAccount("Mr. Byran Walton", beginningBalance);

            account.ToggleFreeze();

            // act
            try
            {
                account.Credit(creditAmount);
            }

            catch (Exception e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.AccountFrozenMessage);
                return;
            }

            Assert.Fail("No exception was thrown");
        }
    }
}
