using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static bool isCorrect;
        static void Main(string[] args)
        {
            int choice = -1;            
            do
            {
                Console.WriteLine("WELCOME TO ASSIGNMENT 5");
                String playContinue = "y";
                print_menu();
                Console.Write("Please choice your option: ");
                while (!(Int32.TryParse(Console.ReadLine(), out choice)))
                {
                    Console.Write("Bad input. Try-again: ");
                }
                
                switch (choice)
                {
                    case 1: // Hangman game
                        while (playContinue.Equals("y"))
                        {
                            String word;
                            Console.Write("Enter the hangman word: ");
                            word = Console.ReadLine();
                            String hiddenWord = getHiddenWord(word);
                            int count = 0;
                            while (!word.Equals(hiddenWord))
                            {
                                Console.Write("(Guess) Enter a letter in word " + hiddenWord + " > ");
                                char ch = Console.ReadKey().KeyChar;
                                Console.WriteLine();

                                if (!IsAlreadyInWord(hiddenWord, ch))
                                {

                                    hiddenWord = getGuess(word, hiddenWord, ch);

                                    if (!isCorrect)
                                    {
                                        Console.WriteLine(ch + " is not in the word.");
                                        count++;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine(ch + " is already in word.");
                                }

                            }
                            Console.WriteLine("The word is '" + hiddenWord + "'. You missed " + count + " time(s).");
                            Console.Write("Do you want to guess another word? Enter y or n>: ");
                            playContinue = Console.ReadLine();
                        }
                        Console.WriteLine("Good-bye and thanks for playing");
                        break;
                    case 2: //Baby name popularity ranking
                        while (playContinue.Equals("y"))
                        {
                            string filePath;
                            int year;
                            string gender, name;
                            Console.Write("Enter the directory path of the data files: ");
                            filePath = Console.ReadLine();
                            Console.Write("Enter the year: ");
                            while (!(Int32.TryParse(Console.ReadLine(), out year)))
                            {
                                Console.Write("Bad input. Try-again: ");
                            }
                            Console.Write("Enter the gender (M/F): ");
                            while (true)
                            {
                                gender = Console.ReadLine();
                                if (gender.Equals("M") || gender.Equals("F"))
                                    break;
                                else
                                {
                                    Console.Write("Bad input. Try-again: ");
                                }
                            }
                            Console.Write("Enter the name: ");
                            name = Console.ReadLine();

                            //Read in file and lookup for name
                            string filename = filePath + "\\yob" + year.ToString() + ".txt";
                            // Read each line of the file into a string array. Each element
                            // of the array is one line of the file.
                            string[] lines = System.IO.File.ReadAllLines(filename);
                            int ranked = 0;
                            bool found = false;
                            foreach (string line in lines)
                            {
                                string[] atti = line.Split(',');
                                //Console.WriteLine(line);
                                ranked++;
                                if (atti[0].Equals(name) && atti[1].Equals(gender))
                                {
                                    Console.WriteLine(name + " is ranked #" + ranked.ToString() + " in year " + year.ToString());
                                    found = true;
                                }
                            }
                            // Not found this name in the database
                            if (found == false)
                            {
                                Console.WriteLine("The name " + name + " is no ranked in year " + year.ToString());
                            }
                            Console.Write("Do you want to continue? Enter y or n>: ");
                            playContinue = Console.ReadLine();

                        }
                        break;
                    case 3: // Ranking Summary
                        while (playContinue.Equals("y"))
                        {
                            string filePath;
                            int year, ranking;
                            Console.Write("Enter the directory path of the data files: ");
                            filePath = Console.ReadLine();
                            Console.Write("Enter the year: ");
                            while (!(Int32.TryParse(Console.ReadLine(), out year)))
                            {
                                Console.Write("Bad input. Try-again: ");
                            }
                            Console.Write("Enter the number of rankings: ");
                            while (!(Int32.TryParse(Console.ReadLine(), out ranking)))
                            {
                                Console.Write("Bad input. Try-again: ");
                            }
                            //Read in file and lookup for name
                            string filename = filePath + "\\yob" + year.ToString() + ".txt";
                            // Read each line of the file into a string array. Each element
                            // of the array is one line of the file.
                            string[] lines = System.IO.File.ReadAllLines(filename);                            
                            bool found = false;
                            string[] TopMaleBaby = new string[ranking];
                            string[] TopFemaleBaby = new string[ranking];
                            int mraking, fraking;
                            mraking = fraking = 0;
                            foreach (string line in lines)
                            {
                                string[] atti = line.Split(',');
                                if (atti[1].Equals("M") && mraking < ranking)
                                {
                                    TopMaleBaby[mraking] = atti[0];
                                    mraking++;
                                    found = true;
                                }
                                if (atti[1].Equals("F") && fraking < ranking)
                                {
                                    TopFemaleBaby[fraking] = atti[0];
                                    fraking++;
                                    found = true;
                                }
                            }
                            // Not found this name in the database
                            if (found == false)
                            {
                                Console.WriteLine("No Female or Male exist in " + year.ToString());
                            }
                            else
                            {
                                Console.WriteLine("Top " + ranking.ToString() + " Baby Names of " + year.ToString());
                                Console.WriteLine("--------------------------------------------------------------------");
                                Console.WriteLine("Rank\t\tMale name\t\tFemale name");
                                Console.WriteLine("--------------------------------------------------------------------");
                                for (int i = 0; i < ranking; ++i)
                                {
                                    Console.Write(" " + (i + 1).ToString() + "\t\t");

                                    if (i < mraking)
                                        Console.Write(TopMaleBaby[i] + "\t\t");
                                    else
                                        Console.Write("\t\t\t");
                                    if (i < fraking)
                                        Console.Write(TopFemaleBaby[i]);
                                    Console.WriteLine();
                                }
                            }
                            Console.Write("Do you want to continue? Enter y or n>: ");
                            playContinue = Console.ReadLine();
                        }
                        break;
                    case 4: // BankAccount class
                        BankAccount bankAccount;
                        bankAccount = new BankAccount();
                        int menuChoice = 0;
                        bool bValid = false;
                        Console.Write("\nNew Account Information");
                        Console.Write("\n---------------------------");
                        Console.Write("\nEnter account id: ");
                        int accountID;
                        while (!(Int32.TryParse(Console.ReadLine(), out accountID)))
                        {
                            Console.Write("Invalid Account ID. Try-again: ");
                        }
                        bankAccount.SetID(accountID);
                        //GET BALANCE
                        double value = 0;
                        bankAccount.SetBalanceAsk();                     

                        do
                        {
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Account Menu");
                                    Console.WriteLine("----------------");
                                    Console.WriteLine("1. Set Annual Interest Rate");
                                    Console.WriteLine("2. Withdraw");
                                    Console.WriteLine("3. Deposit");
                                    Console.WriteLine("4. Print Account Information");
                                    Console.WriteLine("5. Exit");
                                    Console.Write("Enter a choice: ");

                                    while (!(Int32.TryParse(Console.ReadLine(), out menuChoice)))
                                    {
                                        Console.Write("Bad input. Try-again: ");
                                    }                                    
                                    bValid = true;
                                }
                                catch (Exception l)
                                {
                                    bValid = false;
                                    Console.WriteLine("Invalid data, please input your menu choice again.");
                                }
                            } while (bValid == false);

                            switch (menuChoice)
                            {
                                case 1: //Annual Interest Rate
                                    {
                                        bankAccount.SetAnnualInterestRate();
                                        bankAccount.GetAnnualInterestRate();
                                        break;
                                    }
                                case 2: //Withdraw
                                    {
                                        bankAccount.Withdraw();
                                        break;
                                    }
                                case 3: //Deposit
                                    {
                                        bankAccount.Deposit();
                                        break;
                                    }
                                case 4: //Print Account Information
                                    {
                                        double annualInterestRate = bankAccount.GetAnnualInterestRate();
                                        double monthlyInterestRate = bankAccount.CalculateMonthlyInterestRate(annualInterestRate);
                                        DateTime getDateTime = bankAccount.GetDateTime();

                                        Console.WriteLine("Account Info");
                                        Console.WriteLine("---------------");
                                        Console.WriteLine("ID: {0}", bankAccount.GetID());
                                        Console.WriteLine("Balance: ${0}", bankAccount.GetBalance());
                                        Console.WriteLine("Monthly Interest Rate: {0}", bankAccount.CalculateMonthlyInterestRate(annualInterestRate));
                                        Console.WriteLine("Monthly Interest: ${0}", bankAccount.CalculateMonthlyInterest(bankAccount.GetBalance(), monthlyInterestRate));
                                        Console.WriteLine("Date Created: {0}", getDateTime.ToShortDateString());
                                        break;
                                    }
                                case 5:
                                    {
                                        Console.WriteLine("Thank you for using the Bank Account Manager");
                                        break;
                                    }
                                default:
                                    {
                                        Console.Write("Please input your menu choice again: ");
                                        break;
                                    }
                            } //closes menuChoice switch
                        } while (menuChoice != 5);
                        break;                        
                    case 5: // ATM Machine
                        bool exit = false;
                        while (playContinue.Equals("y"))
                        {
                            Console.Write("Enter the full path of the data file: ");
                            string pathfile = Console.ReadLine();
                            BankAccount[] dataBankAccount = new BankAccount[10];
                            BankAccount account = new BankAccount();
                            string[] lines = System.IO.File.ReadAllLines(pathfile);
                            int indexBank = 0;
                            foreach (string line in lines)
                            {
                                if(indexBank >= 10)
                                {
                                    Console.WriteLine("Data file contain more than 10 bank account. Just take 10 account data.");
                                    break;
                                }
                                string[] atti = line.Split(',');
                                int id;
                                if (!Int32.TryParse(atti[0], out id))                                    
                                {
                                    Console.WriteLine("Invalid data in data file. Exit to main menu.");
                                    exit = true;
                                    break;
                                }
                                double balance;
                                if (!Double.TryParse(atti[1], out balance))                                    
                                {
                                    Console.WriteLine("Invalid data in data file. Exit to main menu.");
                                    exit = true;
                                    break;
                                }
                                dataBankAccount[indexBank] = new BankAccount(id, balance);
                                indexBank++;
                            }
                            if (exit == true)
                                break;
                            bool found = false;                            
                            while (found == false)
                            {
                                int bankid;
                                Console.Write("Enter account id: ");
                                while (!(Int32.TryParse(Console.ReadLine(), out bankid)))
                                {
                                    Console.Write("Bad input. Try-again: ");
                                }                               

                                for (int i = 0; i < 10; ++i)
                                {
                                    if (dataBankAccount[i].GetID() == bankid)
                                    {
                                        account = dataBankAccount[i];
                                        found = true;
                                        break;
                                    }
                                }
                                Console.WriteLine("Invalid count id. There are no accounts that account id");
                            }
                            int atmchoice = -1;
                            while(atmchoice != 4)
                            {
                                Console.WriteLine("Main menu");
                                Console.WriteLine("1: check baclance");
                                Console.WriteLine("2: withdraw");
                                Console.WriteLine("3: deposit");
                                Console.WriteLine("4: exit");
                                Console.Write("Enter a choice: ");
                                while (!(Int32.TryParse(Console.ReadLine(), out atmchoice)))
                                {
                                    Console.Write("Bad input. Try-again: ");
                                }
                                switch(atmchoice)
                                {
                                    case 1: // check balace
                                        Console.WriteLine("The balance is $" + account.GetBalance().ToString());
                                        break;
                                    case 2: // withdraw
                                        account.Withdraw();
                                        break;
                                    case 3: // deposit
                                        account.Deposit();
                                        break;
                                    case 4:
                                        Console.WriteLine("Exit the Main menu for ATM Machine");
                                        exit = true;
                                        break;
                                    default:
                                        Console.WriteLine("Invalid choice. Try again.");
                                        break;
                                }
                            }
                            if (exit == true)
                                break;
                            Console.Write("Do you want to continue? Enter y or n>: ");
                            playContinue = Console.ReadLine();
                        }
                        break;
                    case 6: // Exit
                        Console.WriteLine("Exit the program!!!!");
                        return;                        
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            } while (choice != 6);
        }
        public static void print_menu()
        {
            Console.WriteLine("======MENU=======");
            Console.WriteLine("1. Hangman Game");
            Console.WriteLine("2. Baby name popularity ranking");
            Console.WriteLine("3. Baby Name Ranking Summary");
            Console.WriteLine("4. BankAccount class");
            Console.WriteLine("5. ATM Machine");
            Console.WriteLine("6. Exit");
        }
        public static String getHiddenWord(String word)
        {

            String hidden = "";
            for (int i = 0; i < word.Length; i++)
            {
                hidden += "*";
            }
            return hidden;
        }

        static public String getGuess(String word, String hiddenWord, char ch)
        {

            isCorrect = false;
            StringBuilder s = new StringBuilder(hiddenWord);
            for (int i = 0; i < word.Length; i++)
            {

                if (ch == word[i] && s[i] == '*')
                {
                    isCorrect = true;
                    s.Replace(s[i], ch, i, 1);
                }
            }
            return s.ToString();
        }

        public static bool IsAlreadyInWord(String hiddenWord, char ch)
        {

            for (int i = 0; i < hiddenWord.Length; i++)
            {

                if (ch == hiddenWord[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
    class BankAccount
    {
        private int iD = 0;
        private double balance = 0;
        private double annualInterestRate = 0;
        private DateTime dateCreated;

        public BankAccount(int id = 0, double bal = 0, double annual = 0)
        {
            iD = id;
            balance = bal;
            annualInterestRate = annual;
            dateCreated = DateTime.Now;
        }

        public void SetID(int value)
        {
            iD = value;
        } //closes SetID()
        public int GetID()
        {
            return iD;
        } //closes GetID()
        public void SetBalanceAsk()
        {
            bool bValid = false;
            double value;

            do
            {
                Console.Write("Enter initial account balance: ");
                while (!(Double.TryParse(Console.ReadLine(), out value)))
                {
                    Console.Write("Bad input. Try-again: ");
                }
                if (value > 0)
                {
                    bValid = true;
                    balance = value;
                }
                else
                {
                    bValid = false;
                    Console.WriteLine("Invalid balance - balance must be greater than zero. ");
                }
            } while (bValid == false);

        } //closes SetBalanceAsk()
        public void SetBalance(double ba)
        {
            balance = ba;
        }
        public double GetBalance()
        {
            return balance;
        } //closes GetBalance()
        public void SetAnnualInterestRate()
        {
            bool bValid = false;
            double value = 0;
            do
            {
                Console.Write("Enter annual interest rate: ");
                while (!(Double.TryParse(Console.ReadLine(), out value)))
                {
                    Console.Write("Bad input. Try-again: ");
                }                
                if (value > 0)
                {
                    bValid = true;
                    annualInterestRate = value / 100;
                }
                else
                {
                    bValid = false;
                    Console.WriteLine("Invalid annual interest rate - rate must be greater than 0. ");
                }
            } while (bValid == false);
        } //closes SetAnnualInterestRate()
        public double GetAnnualInterestRate()
        {
            return annualInterestRate;
        } //closes GetAnnualInterestRate()
        public DateTime GetDateTime()
        {
            //dateCreated = DateTime.Today;
            return dateCreated;
        }
        public double CalculateMonthlyInterestRate(double annualInterestRate)
        {
            //Will return the monthly interest rate
            //Note: annualInterestRate is a percentage, for example 4.5%. You need to divide it by 100.
            double monthlyInterestRate = 0;
            monthlyInterestRate = annualInterestRate / 12;

            return monthlyInterestRate;
        } //closes CalculateMonthlyInterestRate()
        public double CalculateMonthlyInterest(double balance, double monthlyInterestRate)
        {
            //Will return the monthly interest amount ($$)
            double monthlyInterest = 0;
            monthlyInterest = balance * monthlyInterestRate;

            return monthlyInterest;
        } //closes CalculateMonthlyInterest()
        public double Withdraw()
        {
            Console.Write("Enter an amount to withdraw: ");
            double withdraw;
            while (!(Double.TryParse(Console.ReadLine(), out withdraw)))
            {
                Console.Write("Bad input. Try-again: ");
            }
            if (withdraw > balance)
            {
                Console.WriteLine("Invalid withdraw amount");
            }
            else
            {
                balance = balance - withdraw;
            }
            return balance;
        } //closes Withdraw()
        public double Deposit()
        {
            Console.Write("Enter an amount to deposit: ");
            double deposit;
            while (!(Double.TryParse(Console.ReadLine(), out deposit)))
            {
                Console.Write("Bad input. Try-again: ");
            }
            balance = balance + deposit;
            return balance;
        } //closes Deposit()

    }
}
