using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Bank.Enums;

namespace Bank.Models
{
    internal interface IAccount
    {
        public string AccountID{ get; set; }
        public decimal Balance{ get; set; }
        public AccountType AccountType{ get; set; }
        public CurrencyType CurrencyType{ get; set; }



        public void Deposit(decimal depositAmount)
        {
        }
        public void Withdraw(decimal withdrawAmount)
        {
        }
    }
}
