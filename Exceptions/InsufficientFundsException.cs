using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Exceptions
{
    internal class InsufficientFundsException : Exception      //İstifadəçinin çıxartmağa çalışdığı məbləğ hesabda mövcud balanstan böyük olduğunda.
    {

        public InsufficientFundsException(string message) : base(message)
        {
        }
    }
}
