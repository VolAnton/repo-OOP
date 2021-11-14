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
        private ulong _accountNumber;
        private decimal _accountBalance;
        private BankAccountType _accountType;

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

        public void SetAccountNumber(ulong accountNumber)
        {
            _accountNumber = accountNumber;
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
            Random rnd = new Random();

            BankAccount account = new BankAccount();

            account.SetAccountNumber(((ulong)(rnd.Next(1_000_000_001, 1_999_999_999))));
            account.SetAccountBalance(1_000_000m);
            account.SetAccountType(BankAccountType.Deposit);

            account.PrintAccountInfo();

            Console.ReadKey();
        }
    }
}
