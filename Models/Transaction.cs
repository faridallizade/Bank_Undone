using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank.Enums;

namespace Bank.Models
{
    internal class Transaction
    {
        public string TransactionID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionType transactionType { get; set; }

        public Transaction(string transactionId , TransactionType transactionType ,  decimal amount)
        {
            TransactionID = transactionId;
            Amount = amount;
            TransactionDate = DateTime.Now;
            this.transactionType = transactionType;
        }

    }
}
