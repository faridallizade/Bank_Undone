using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Exceptions
{
    internal class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message)     //İstifadəçi sıfırdan kiçik və ya mənasız bir məbləği daxil etdiyində.
        {
        }
    }
}
