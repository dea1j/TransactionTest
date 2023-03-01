using System;
using ProductionCode;
using Xunit;

namespace UnitTest
{
    public class AccountTest
    {
        [Fact]
        public void GivenUserAttemptsWithdrawal_WhenAttemptIsSuccessful_ShouldDeductAmountFromBalance()
        {
            var account = new Account();
            account.SetBalance(20);
            account.Withdraw(10);
            Assert.Equal(10, account.Balance);
        }

        [Fact]
        public void GivenAttemptsWithdrawal_WhenNotEnoughFundInAccount_ShouldThrowException()
        {
            var account = new Account();
            var exception = Assert.Throws<Exception>(() => account.Withdraw(10));
            Assert.Equal("Not enough funds to process transaction", exception.Message);
        }

        [Fact]
        public void GivenRetrievingTransaction_WhenThereAreNoTransaction_ShouldReturnNull()
        {
            var account = new Account();
            var mostRecentTransaction = account.GetMostRecentTransaction();
            Assert.Null(mostRecentTransaction);
        }

        [Fact]
        public void GivenRetrievingLatestTransaction_IfThereIsATransaction_ShouldReturnTheTransaction()
        {
            var transaction = new Transaction(10, new DateTime(2023, 03, 01), TransactionStatus.Accepted);
            var account = new Account(transaction);
            var mostRecentTransaction = account.GetMostRecentTransaction();

            Assert.NotNull(mostRecentTransaction);
            Assert.Equal(10, mostRecentTransaction.Amount);
            Assert.Equal(new DateTime(2023, 03, 01), mostRecentTransaction.DateAndTimeOfTransaction);
            Assert.Equal(TransactionStatus.Accepted, mostRecentTransaction.Status);
        }
    }
}

