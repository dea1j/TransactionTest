using System;
namespace ProductionCode
{
    public class Transaction
    {

        public Transaction(decimal amount, DateTime dateAndTimeOfTransaction, TransactionStatus status)
        {
            Amount = amount;
            DateAndTimeOfTransaction = dateAndTimeOfTransaction;
            Status = status;
        }

        public decimal Amount { get; set; }
        public DateTime DateAndTimeOfTransaction { get; set; }
        public  TransactionStatus Status { get; set; }
    }
}
 
