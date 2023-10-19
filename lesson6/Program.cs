using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    enum BankAccountType
    {
        Current,
        Savings
    }
    class BankAccount
    {
        private int _accountNumber;
        private decimal balance;
        private BankAccountType type;
        public BankAccount(int accountNumber, decimal balance, BankAccountType type)
        {
            _accountNumber = GenerateAccountNumber();
            this.balance = balance;
            this.type = type;
        }
        private static int lastAccountNumber = 0;
        private static int GenerateAccountNumber()
        {
            lastAccountNumber++;
            return lastAccountNumber;
        }

        public int GetAccountNumber()
        {
            return _accountNumber;
        }
        public void SetAccountNumber(int accountNumber)
        {
            _accountNumber = accountNumber;
        }

        public void Print()
        {
            Console.WriteLine($"Номер счета: {GenerateAccountNumber()}\nБаланс: {balance} руб.\nТип счета: {type}\n");
        }
        
        public void Deposit(decimal amount, decimal balance)
        {
            balance += amount;
            Console.WriteLine($"Внесено на счет: {amount} руб. Баланс после операций: {balance} руб.\n");
        }
        public void Withdraw(decimal amount, decimal balance)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Снято со счета: {amount} руб. Баланс после операций: {balance} руб.\n");
            }
            else
            {
                Console.WriteLine($"Невозможно снять сумму, недостаточно средств на счете! Баланс: {balance}\n");
            }
        }



        

    }

    class Building
    {
        private int buildingNumber;
        private double height;
        private int floors;
        private int apartments;
        private int entrances;

        private static int lastBuildingNumber = 0;

        public Building(double height, int floors, int apartments, int entrances)
        {
            buildingNumber = GenerateBuildingNumber();
            this.height = height;
            this.floors = floors;
            this.apartments = apartments;
            this.entrances = entrances;
        }

        private static int GenerateBuildingNumber()
        {
            lastBuildingNumber++;
            return lastBuildingNumber;
        }

        public int GetBuildingNumber()
        {
            return buildingNumber;
        }

        public double GetHeight()
        {
            return height;
        }

        public int GetFloors()
        {
            return floors;
        }

        public int GetApartments()
        {
            return apartments;
        }

        public int GetEntrances()
        {
            return entrances;
        }
        
    }

    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнения 7.1 - 7.3. Создание класса <Счет в банке>\n");
            BankAccount bankAccount = new BankAccount(1, 100000, BankAccountType.Current);
            bankAccount.Print();
            bankAccount.Deposit(200, 10000);
            BankAccount bankAccount2 = new BankAccount(2, 200000, BankAccountType.Savings);
            bankAccount2.Print();
            bankAccount2.Withdraw(500000, 10000);

            Console.WriteLine("Д/з 7.1. Реализация класса для описания здания.");
            Building building = new Building(50.5, 10, 100, 5);

            Console.WriteLine("Номер здания: " + building.GetBuildingNumber());
            Console.WriteLine("Высота здания: " + building.GetHeight());
            Console.WriteLine("Этажность: " + building.GetFloors());
            Console.WriteLine("Количество квартир: " + building.GetApartments());
            Console.WriteLine("Количество подъездов: " + building.GetEntrances());

            Console.ReadKey();

        }
    }
}
