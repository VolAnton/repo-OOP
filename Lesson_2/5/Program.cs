using System;

namespace Lesson_2
{
    public enum BankAccountType
    {
        Deposit,
        Credit
    }

    public class BankAccount
    {
        private static ulong lastAccountNumber = 1_000_000_001;
        private ulong _accountNumber;
        private decimal _accountBalance;
        private BankAccountType _accountType;

        public BankAccount()
        {
            GenerateAccountNumber();
        }

        public ulong AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                if (value.GetType().ToString() == "System.UInt64")
                {
                    _accountNumber = value;
                }
            }
        }

        public decimal AccountBalance
        {
            get
            {
                return _accountBalance;
            }
            set
            {
                if (value.GetType().ToString() == "System.Decimal")
                {
                    _accountBalance = value;
                }
            }
        }

        public BankAccountType AccountType
        {
            get
            {
                return _accountType;
            }
            set
            {
                if (value.GetType().ToString() == "Lesson_2.BankAccountType")
                {
                    _accountType = value;
                }
            }
        }

        private void GenerateAccountNumber()
        {
            _accountNumber = lastAccountNumber;
            lastAccountNumber = _accountNumber + 1;
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {_accountNumber}. Баланс: {_accountBalance}. Тип счета: {_accountType}.");
        }

        public void DepositMoney(decimal inletMoney)
        {
            _accountBalance += inletMoney;
            Console.WriteLine($"Операция пополнения счета на сумму {inletMoney} руб. выполнена успешно.");
            Console.WriteLine($"Текущий баланс равен {_accountBalance} руб.");
        }

        public void WithdrawMoney(decimal outletMoney)
        {
            if ((AccountBalance - outletMoney) >= 0)
            {
                _accountBalance -= outletMoney;
                Console.WriteLine($"Операция снятия со счета средств {outletMoney} руб. выполнена успешно.");
                Console.WriteLine($"Текущий баланс равен {_accountBalance} руб.");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств. Текущий баланс составляет {_accountBalance} руб.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            account.AccountBalance = 32167m;
            account.AccountType = BankAccountType.Deposit;
            account.PrintAccountInfo();

            Console.WriteLine();

            account.DepositMoney(700m);

            Console.WriteLine();

            account.WithdrawMoney(1000m);

            Console.WriteLine();

            account.WithdrawMoney(30000m);

            Console.WriteLine();

            account.WithdrawMoney(1867m);

            Console.WriteLine();

            account.WithdrawMoney(1000m);

            Console.WriteLine();

            account.DepositMoney(1_000_000m);

            Console.WriteLine();

            account.PrintAccountInfo();

            Console.ReadKey();
        }
    }
}
