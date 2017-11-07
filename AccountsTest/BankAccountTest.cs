using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accounts;

namespace AccountsTest
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void ConstructorShouldSetInitialBalance()
        {
            //Arrange
            BankAccount testAccount;
            //Act
            testAccount = new BankAccount("Alice", 1000);
            //Assert
            Assert.AreEqual(1000, testAccount.Balance);

        }
        [TestMethod]
        [ExpectedException(typeof(OverdrawnException))]
        public void WithdrawShouldNotExceedAvailableBalance()
        {
            //Arrange
            BankAccount testAccount;
            //Act
            testAccount = new BankAccount("Alice", 1000);
            testAccount.MakeWithdraw(1001,DateTime.Now,null,"Test Limit");
        }

        [TestMethod]
        public void OverdrawnExceptionShouldIncludeWithdrawOverage()
        { //Arrange
            BankAccount testAccount;
            //Act
            testAccount = new BankAccount("Alice", 1000);
            try
            {
                testAccount.MakeWithdraw(1001, DateTime.Now, null, "Test Limit");
            }
            catch (OverdrawnException e)
            {//Assert
                Assert.AreEqual(1, e.WithdrawOverage);
            }

        }
    }
}
