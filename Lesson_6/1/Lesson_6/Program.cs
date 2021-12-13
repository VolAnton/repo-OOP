using System;
using MyHomeWork.Core;

namespace Lesson_6
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

        ConsoleLogger message = new ConsoleLogger();

        private BankAccount()
        {
            GenerateAccountNumber();
            message.ShowMessage($"Банковский счет №{AccountNumber} успешно создан.");
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
                if (value.GetType().ToString() == "Lesson_6.BankAccountType")
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
            message.ShowMessage($"Номер счета: {AccountNumber}. Баланс: {AccountBalance}. Тип счета: {AccountType}.");
        }

        public void DepositMoney(decimal inletMoney)
        {
            AccountBalance += inletMoney;
            message.ShowMessage($"Операция пополнения счета на сумму {inletMoney} руб. выполнена успешно.");
            message.ShowMessage($"Текущий баланс равен {AccountBalance} руб.");
        }

        public void WithdrawMoney(decimal outletMoney)
        {
            if ((AccountBalance - outletMoney) >= 0)
            {
                AccountBalance -= outletMoney;
                message.ShowMessage($"Операция снятия со счета средств {outletMoney} руб. выполнена успешно.");
                message.ShowMessage($"Текущий баланс равен {AccountBalance} руб.");
            }
            else
            {
                message.ShowMessage($"Недостаточно средств. Текущий баланс составляет {AccountBalance} руб.");
            }
        }

        public void TransferMoney(BankAccount sourceAccount, decimal value)
        {
            if ((sourceAccount.AccountBalance - value) >= 0)
            {
                sourceAccount.AccountBalance -= value;
                AccountBalance += value;
                /*
                Верхние 2 строчки можно заменить на:
                sourceAccount.WithdrawMoney(value);
                DepositMoney(value);
                */
                message.ShowMessage($"Операция перевода средств со счета №{sourceAccount.AccountNumber} на счет {AccountNumber} в размере {value} руб. выполнена успешно.");
                message.ShowMessage($"Текущий баланс счета №{sourceAccount.AccountNumber} равен {sourceAccount.AccountBalance} руб.");
                message.ShowMessage($"Текущий баланс счета №{AccountNumber} равен {AccountBalance} руб.");
            }
            else
            {
                message.ShowMessage($"На счете №{sourceAccount.AccountNumber} недостаточно средств для перевода {value} руб., остаток составляет {sourceAccount.AccountBalance} руб.");
            }
        }

        public static bool operator ==(BankAccount v1, BankAccount v2)
        {
            return ((v1.AccountBalance == v2.AccountBalance) && (v1.AccountType == v2.AccountType));
        }

        public static bool operator !=(BankAccount v1, BankAccount v2)
        {
            return ((v1.AccountBalance != v2.AccountBalance) || (v1.AccountType != v2.AccountType));
        }

        public bool Equal(BankAccount account)
        {
            return account == this;
        }

        public override bool Equals(object obj)
        {
            return Equal(obj as BankAccount);
        }

        public override int GetHashCode()
        {
            int hashCode = _accountNumber.GetHashCode() + _accountBalance.GetHashCode() + _accountType.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return $"Вывод информации о счете {AccountNumber}:\n" +
                $"Баланс: {AccountBalance}.\n" +
                $"Тип счета: {AccountType}.";
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            ConsoleLogger mes = new ConsoleLogger();

            mes.ShowMessage("Создание экземпляра класса BankAccount account1 = new BankAccount(32167m, BankAccountType.Deposit)");
            BankAccount account1 = new BankAccount(32167m, BankAccountType.Deposit);

            mes.SkippingLines(1);
            mes.ShowMessage("Создание экземпляра класса BankAccount account2 = new BankAccount(0m, BankAccountType.Credit)");
            BankAccount account2 = new BankAccount(0m, BankAccountType.Credit);

            mes.SkippingLines(1);
            mes.ShowMessage(account1.ToString());

            mes.SkippingLines(1);
            mes.ShowMessage(account2.ToString());

            mes.SkippingLines(1);
            mes.ShowMessage("Проверка оператора равенства (account1==account2)");
            Console.WriteLine(account1 == account2);

            mes.SkippingLines(1);
            mes.ShowMessage("Проверка оператора неравенства (account1!=account2)");
            Console.WriteLine(account1 != account2);

            mes.SkippingLines(1);
            mes.ShowMessage("Проверка метода (account1.GetHashCode())");
            Console.WriteLine(account1.GetHashCode());

            mes.SkippingLines(1);
            mes.ShowMessage("Проверка метода (account1.Equals(account2)");
            Console.WriteLine(account1.Equals(account2));


            mes.SkippingLines(1);
            mes.ShowMessage("выполняем команду account2.AccountBalance = 32167m");
            account2.AccountBalance = 32167m;

            mes.SkippingLines(1);
            mes.ShowMessage("выполняем команду account2.AccountType = BankAccountType.Deposit");
            account2.AccountType = BankAccountType.Deposit;

            mes.SkippingLines(1);
            mes.ShowMessage("Проверка метода (account1.Equals(account2)");
            Console.WriteLine(account1.Equals(account2));

            mes.SkippingLines(1);
            mes.ShowMessage(account1.ToString());

            mes.SkippingLines(1);
            mes.ShowMessage(account2.ToString());

            Console.ReadKey();
        }
    }
}
