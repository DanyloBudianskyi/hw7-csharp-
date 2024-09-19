namespace hw7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("123456", 1000m);
            BankAccount account2 = new BankAccount("789012", 2000m);
            BankAccount account3 = new BankAccount("345678", 500m);

            account1.OnBankOperation += (sender, e) => {
                Console.WriteLine($"Operation: {e.OperationType}, Account: {e.Account.AccountNumber}, New Balance: {e.Account.Balance}");
            };
            account2.OnBankOperation += (sender, e) => {
                Console.WriteLine($"Operation: {e.OperationType}, Account: {e.Account.AccountNumber}, New Balance: {e.Account.Balance}");
            };
            account3.OnBankOperation += (sender, e) => {
                Console.WriteLine($"Operation: {e.OperationType}, Account: {e.Account.AccountNumber}, New Balance: {e.Account.Balance}");
            };

            TransactionManager manager1 = new TransactionManager(account1);
            TransactionManager manager2 = new TransactionManager(account2);
            TransactionManager manager3 = new TransactionManager(account3);

            manager1.Withdraw(200m);
            manager2.Withdraw(500m);
            manager3.Deposit(100m);   
        }
    }
}
