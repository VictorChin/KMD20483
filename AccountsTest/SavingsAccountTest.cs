using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accounts;

namespace AccountsTest
{
    [TestClass]
    public class SavingsAccountTest
    {
        [TestMethod]
        public void SavingsAccountShouldHaveSameFunctionAsBankAccount()
        {
            //Arrange, Acct
            SavingsAccount account = new SavingsAccount("Alice",1000);
            //Assert
            Assert.IsTrue(account is BankAccount);
        }

        [TestMethod]
        public void SavingsAccountCanBeReferencedByBankAccount()
        {
            //Arrange, Acct
            SavingsAccount account = new SavingsAccount("Alice", 1000);
            BankAccount ba = account;
            //Assert
            Assert.AreSame(ba, account);
        }
        [TestMethod]
        public void ClassVsStructure()
        {
            BankAccount x = new SavingsAccount("Alice", 1000);
            BankAccount y = x;
            if ( x is SavingsAccount) {
                //SavingsAccount z = (SavingsAccount)x;
                //
                SavingsAccount z = x as SavingsAccount;

                Assert.AreSame(x, y);
                Assert.AreSame(z, y);
                Assert.AreSame(z, x);
            }
            

          
        }
    }
}
