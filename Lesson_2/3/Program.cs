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

        private BankAccount()
        {
            GenerateAccountNumber();
        }

        //Если при создании экземпляра класса указан только баланс, то тип класса по-умолчанию будет Deposit.
        public BankAccount(decimal accountBalance) : this(accountBalance, (BankAccountType)0)
        {
            _accountBalance = accountBalance;
        }

        //Если при создании экземпляра класса указан только тип, то баланс по-умолчанию будет равен 0. 
        public BankAccount(BankAccountType accountType) : this(0m, accountType)
        {
            _accountType = accountType;
        }

        public BankAccount(decimal accountBalance, BankAccountType accountType) : this()
        {
            _accountBalance = accountBalance;
            _accountType = accountType;
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

        public void PrintAccountInfo()
        {
            Console.WriteLine($"Номер счета: {_accountNumber}. Баланс: {_accountBalance}. Тип счета: {_accountType}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account_1 = new BankAccount(1001m);
            BankAccount account_2 = new BankAccount(BankAccountType.Credit);
            BankAccount account_3 = new BankAccount(32167m, BankAccountType.Deposit);

            account_1.PrintAccountInfo();
            account_2.PrintAccountInfo();
            account_3.PrintAccountInfo();

            Console.ReadKey();
        }
    }
}
