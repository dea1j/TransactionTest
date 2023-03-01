using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductionCode
{
    public class Account
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();
        public decimal Balance { get; set; }

        public Account()
        {
             
        }

        public Account(Transaction transaction)
        {
            _transactions.Add(transaction);
        }

        public void Withdraw(decimal amount)
        {
            var newAmount = Balance - amount;
            if(newAmount < 0)
            {
                throw new Exception("Not enough funds to process transaction");
            }

            Balance -= amount;
        }

        public void SetBalance(decimal amount)
        {
            Balance = amount;
        }

        public Transaction GetMostRecentTransaction()
        {
            return _transactions.OrderByDescending(t => t.DateAndTimeOfTransaction).FirstOrDefault();
        }
    }
}

