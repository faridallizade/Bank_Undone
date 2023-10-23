using System.Threading.Channels;
using Bank.Enums;
using Bank.Models;

namespace Bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank_class bank = new Bank_class();
            Console.WriteLine("Welcome to Limon Bank");

            do
            {
                Console.WriteLine("1. Yeni hesab yarat");
                Console.WriteLine("2. Pul yatır");
                Console.WriteLine("3. Pul çıxart");
                Console.WriteLine("4. Əməliyyatların siyahısı");
                Console.WriteLine("5. Bütün hesabların siyahısı");
                Console.WriteLine("6. Hesablar arası pul köçürmə");
                Console.WriteLine("7. Valyuta çevirmə");
                Console.WriteLine("8. Çıxış");
                Console.WriteLine("");
                Console.Write("Əməliyyatın nömrəsini daxil edin: ");

                if (Enum.TryParse<Operation>(Console.ReadLine(), out var operation))
                {
                    try
                    {
                        switch (operation)
                        {
                            case Operation.CreateAccount:
                                Console.Write("Hesab növünü seçin (0 - Checking, 1 - Savings, 2 - Business): ");
                                if (Enum.TryParse<AccountType>(Console.ReadLine(), out var accountType))
                                {
                                    Console.Write("Valyuta növünü seçin (0 - USD, 1 - AZN, 2 - EUR): ");
                                    if (Enum.TryParse<CurrencyType>(Console.ReadLine(), out var currencyType))
                                    {
                                        bank.CreateAccount(accountType, currencyType);
                                        Console.WriteLine("Hesab yaradildi");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Yanlis valyuda novu");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yanlis hesab novu");
                                }
                                break;
                            case Operation.DepositMoney:
                                Console.Write("Hesab id daxil edin : ");
                                string DepositAccountID = Console.ReadLine();
                                Console.Write(" Yatirilacaq meblegi daxil edin : ");
                                if(decimal.TryParse(Console.ReadLine(), out var decimalAmount)){
                                    bank.DepositMoney(DepositAccountID, decimalAmount);
                                }
                                break;
                            case Operation.WithdrawMoney:
                                Console.Write("Hesab id daxil edin : ");
                                string WithdrawAccountID = Console.ReadLine();
                                Console.Write(" Cekilecek meblegi daxil edin : ");
                                if (decimal.TryParse(Console.ReadLine(), out var wdDecimalAmount))
                                {
                                    bank.DepositMoney(WithdrawAccountID, wdDecimalAmount);
                                }
                                break;

                        }



                    }
                    catch { }



                }
            } while (bank != null);
        }
    }
}
