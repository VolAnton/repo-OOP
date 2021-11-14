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

        private void GenerateAccountNumber()
        {
            _accountNumber = lastAccountNumber;
            lastAccountNumber = _accountNumber + 1;
        }

        public ulong GetAccountNumber()
        {
            return _accountNumber;
        }

        public decimal GetAccountBalance()
        {
            return _accountBalance;
        }

        public BankAccountType GetAccountType()
        {
            return _accountType;
        }

        public void SetAccountBalance(decimal accountBalance)
        {
            _accountBalance = accountBalance;
        }

        public void SetAccountType(BankAccountType accountType)
        {
            _accountType = accountType;
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

            account_1.SetAccountBalance(1_000_000m);
            account_1.SetAccountType(BankAccountType.Deposit);
            account_1.PrintAccountInfo();

            account_2.SetAccountBalance(2_000_000m);
            account_2.SetAccountType(BankAccountType.Credit);
            account_2.PrintAccountInfo();

            account_3.SetAccountBalance(3_000_000m);
            account_3.SetAccountType(BankAccountType.Deposit);
            account_3.PrintAccountInfo();

            Console.ReadKey();
        }
    }
}
