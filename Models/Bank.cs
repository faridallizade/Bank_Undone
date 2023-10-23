using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Bank.Enums;
using Bank.Exceptions;

namespace Bank.Models
{
    internal class Bank_class
    {
        private BankAccount[] accounts;


        public Bank_class()
        {
            accounts = new BankAccount[0];
        }

        private string GenerateAccountId()
        {
            return Guid.NewGuid().ToString().Substring(0, 5);
        }
        public void DepositMoney(string accountId, decimal amount)
        {
            var account = FindAccountByID(accountId);
            account.Deposit(amount);
        }

        public void WithdrawMoney(string accountId, decimal amount)
        {
            var account = FindAccountByID(accountId);
            account.Withdraw(amount);
        }

        public BankAccount CreateAccount(AccountType accountType, CurrencyType currencyType)
        {
            BankAccount newAccount = new BankAccount(GenerateAccountId(), accountType, currencyType);
            Array.Resize(ref accounts, accounts.Length + 1);
            accounts[accounts.Length - 1] = newAccount;
            return newAccount;
        }

        private BankAccount FindAccountByID(string accountId)
        {
            foreach (BankAccount account in accounts)
            {
                if (account.AccountID == accountId)
                {
                    return account;
                }
            }
            throw new AccountNotFoundException("Hesab tapilmadi");
        }

        public void GettAllAccounts()
        {
            foreach (BankAccount account in accounts)
            {
                Console.WriteLine(account);
            }
        }

        public void TransferMoney(string fromAccountId, string toAccountId, decimal amount)
        {
            BankAccount fromAccount = FindAccountByID(fromAccountId);
            BankAccount toAccount = FindAccountByID(toAccountId);

            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
        }


        private decimal ConvertCurrency(decimal amount, CurrencyType fromCurrency, CurrencyType toCurrency)
        {

            if (fromCurrency == CurrencyType.AZN && toCurrency == CurrencyType.USD)
            {
                return amount * 0.59m; //AZN to USD
            }
            else if (fromCurrency == CurrencyType.AZN && toCurrency == CurrencyType.EUR)
            {
                return amount * 0.56m; //AZN to EUR
            }
            else if (fromCurrency == CurrencyType.USD && toCurrency == CurrencyType.AZN)
            {
                return amount * 1.7m;  //USD to AZN
            }
            else if (fromCurrency == CurrencyType.USD && toCurrency == CurrencyType.EUR)
            {
                return amount * 0.95m;  //USD to EUR
            }
            else if (fromCurrency == CurrencyType.EUR && toCurrency == CurrencyType.AZN)
            {
                return amount * 1.8m;  //EUR to AZN
            }
            else if (fromCurrency == CurrencyType.EUR && toCurrency == CurrencyType.USD)
            {
                return amount * 1.06m; //EUR to USD
            }
            return amount;
        }




    }

}
