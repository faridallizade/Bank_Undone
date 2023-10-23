using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Exceptions
{
    internal class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message)    //Daxil edilən hesab nömrəsi mövcud deyil olduğunda.
        {
        }
    }
}
