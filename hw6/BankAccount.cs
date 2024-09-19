using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public BankAccount(string accountNumber, decimal balance) {
            AccountNumber = accountNumber;
            Balance = balance;
        }
        public delegate void BankOperationHandler(object sender, BankOperationEventArgs e);
        public event BankOperationHandler? OnBankOperation;

        public void Deposit(decimal amount)
        {
            Balance += amount;
            OnBankOperation.Invoke(this, new BankOperationEventArgs(this, amount, "Deposit"));
        }
        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                OnBankOperation.Invoke(this, new BankOperationEventArgs(this, amount, "Withdraw"));
            }
        }

        public override string ToString()
        {
            return $"Number: {AccountNumber}, Balance: {Balance}";
        }
    }

    public class TransactionManager
    {
        public BankAccount _BankAccount;

        public TransactionManager(BankAccount bankAccount)
        {
            _BankAccount = bankAccount;
        }
        public void Deposit(decimal amount)
        {
            _BankAccount.Deposit(amount);
        }
        public void Withdraw(decimal amount)
        {
            _BankAccount.Withdraw(amount);
        }
    }

    public class BankOperationEventArgs
    {
        public BankAccount Account;
        public decimal Amount { get; }
        public string OperationType { get; }

        public BankOperationEventArgs(BankAccount account, decimal amount, string operationType)
        {
            Account = account;
            Amount = amount;
            OperationType = operationType;
        }
    }
}
