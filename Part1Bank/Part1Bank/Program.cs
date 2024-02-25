using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Bank application!");

        // დავიწყოთ ბანკომატის ფაილის შექმნით
        string filePath = "bank.txt";


         using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine("123456789,1000.00");
                    writer.WriteLine("987654321,500000.50");
                }

                Console.WriteLine("File 'bank.txt' created successfully.");
            
   
    

        while (true)
        {
            Console.WriteLine("\nPlease select an option:");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CheckBalance(filePath);
                    break;
                case "2":
                    DepositMoney(filePath);
                    break;
                case "3":
                    WithdrawMoney(filePath);
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CheckBalance(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            Console.WriteLine($"Account Number: {parts[0]}, Balance: {parts[1]}");
        }
    }

    static void DepositMoney(string filePath)
    {
        Console.Write("Enter your account number: ");
        string accountNumber = Console.ReadLine();

        Console.Write("Enter the amount to deposit: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        UpdateAccountBalance(filePath, accountNumber, amount);
        Console.WriteLine("Deposit successful!");
    }

    static void WithdrawMoney(string filePath)
    {
        Console.Write("Enter your account number: ");
        string accountNumber = Console.ReadLine();

        Console.Write("Enter the amount to withdraw: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        string[] lines = File.ReadAllLines(filePath);

        bool accountExists =  false;
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts[0] == accountNumber)
            {
                accountExists = true;
                decimal balance = decimal.Parse(parts[1]);
                if (balance < amount)
                {
                    Console.WriteLine("Insufficient balance. Withdrawal failed.");
                    return;
                }
            }
        }
        if (accountExists)
        {
            UpdateAccountBalance(filePath, accountNumber, -amount);
            Console.WriteLine("Withdrawal successful!");
        }
        else { Console.WriteLine("Try other account number! "); }
    }

    static void UpdateAccountBalance(string filePath, string accountNumber, decimal amount)
    {
        string tempFile = Path.GetTempFileName();
        bool accountExists = false;

        using (var writer = new StreamWriter(tempFile))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0] == accountNumber)
                {
                    accountExists = true;
                    decimal balance = decimal.Parse(parts[1]) + amount;
                    writer.WriteLine($"{accountNumber},{balance}");
                }
                else
                {
                    writer.WriteLine(line);
                }
            }
        }
        if (accountExists)
        {
            File.Delete(filePath);
            File.Move(tempFile, filePath);
        }
        else { Console.WriteLine("Try other account number. "); }

    }
}
