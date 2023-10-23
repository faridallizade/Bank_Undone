using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Bank.Enums;
using Bank.Exceptions;

namespace Bank.Models
{
    internal class BankAccount : IAccount
    {

        public string AccountID { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public Transaction[] transactions;
        private int transactionCount;



        public BankAccount(string accountId, AccountType accountType, CurrencyType currencyType)
        {
            AccountID = accountId;
            AccountType = accountType;
            CurrencyType = currencyType;
            Balance = 0;



        }

        public void Deposit(decimal amount)
        {
            Random randomId = new Random();
            if (amount <= 0)
            {
                throw new InvalidAmountException("Daxil edilen mebleg 0 veya menfi ola bilmez");
            }
            else
                Balance += amount;
            Array.Resize(ref transactions, transactions.Length + 1);
            transactions[transactions.Length - 1] = new Transaction(Guid.NewGuid().ToString().Substring(0,5), TransactionType.Deposit, amount);
            transactionCount++;

        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new InvalidAmountException("Daxil edilen mebleg 0 veya menfi ola bilmez");
            }
            if (amount > Balance)
            {
                throw new InsufficientFundsException("Hesabinizda kifayet qeder vesait yoxdur");
            }
            else
                Balance -= amount;
            Array.Resize(ref transactions, transactions.Length + 1);
            transactions[transactions.Length - 1] = new Transaction(Guid.NewGuid().ToString().Substring(0,5), TransactionType.Withdraw, amount);
            transactionCount++;

        }

    }
}
