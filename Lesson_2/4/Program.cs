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
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account_1 = new BankAccount();
            BankAccount account_2 = new BankAccount();
            BankAccount account_3 = new BankAccount();

            account_1.PrintAccountInfo();
            account_2.PrintAccountInfo();
            account_3.PrintAccountInfo();

            Console.WriteLine();

            account_1.AccountBalance = 798m;
            account_1.AccountType = BankAccountType.Credit;
            account_2.AccountBalance = 97985m;
            account_2.AccountNumber = 9999999999;
            account_3.AccountBalance = 32167m;
            account_3.AccountType = BankAccountType.Credit;
            account_3.AccountNumber = 1_000_000_123;

            account_1.PrintAccountInfo();
            account_2.PrintAccountInfo();
            account_3.PrintAccountInfo();

            Console.WriteLine();

            Console.WriteLine($"Баланс счета равен: {account_3.AccountBalance}");
            Console.WriteLine($"Тип счета: {account_3.AccountType}");
            Console.WriteLine($"Номер счета: {account_3.AccountNumber}");

            Console.ReadKey();
        }
    }
}
