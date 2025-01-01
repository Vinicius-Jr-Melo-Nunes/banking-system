using System;
using System.Collections.Generic;

namespace BankingSystem
{
    class Program
    {
        static List<BankAccount> accounts = new List<BankAccount>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Create account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check balance");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        Deposit();
                        break;
                    case "3":
                        Withdraw();
                        break;
                    case "4":
                        CheckBalance();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter initial deposit: ");
            double initialDeposit = double.Parse(Console.ReadLine());

            BankAccount account = new BankAccount(name, initialDeposit);
            accounts.Add(account);
            Console.WriteLine($"Account created successfully! Your account number is {account.AccountNumber}");
        }

        static void Deposit()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            BankAccount account = FindAccount(accountNumber);
            if (account != null)
            {
                Console.Write("Enter deposit amount: ");
                double amount = double.Parse(Console.ReadLine());
                account.Deposit(amount);
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void Withdraw()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            BankAccount account = FindAccount(accountNumber);
            if (account != null)
            {
                Console.Write("Enter withdrawal amount: ");
                double amount = double.Parse(Console.ReadLine());
                if (account.Withdraw(amount))
                {
                    Console.WriteLine("Withdrawal successful.");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void CheckBalance()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            BankAccount account = FindAccount(accountNumber);
            if (account != null)
            {
                Console.WriteLine($"Account balance: {account.Balance}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static BankAccount FindAccount(string accountNumber)
        {
            return accounts.Find(acc => acc.AccountNumber == accountNumber);
        }
    }

    class BankAccount
    {
        private static int accountCounter = 1000;

        public string AccountNumber { get; }
        public string Owner { get; }
        public double Balance { get; private set; }

        public BankAccount(string owner, double initialDeposit)
        {
            this.Owner = owner;
            this.Balance = initialDeposit;
            this.AccountNumber = (accountCounter++).ToString();
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
