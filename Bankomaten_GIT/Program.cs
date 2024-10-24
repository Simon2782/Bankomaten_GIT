﻿namespace Bankomaten_GIT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Arrays för användare och konton
            string[,] usersAndPins = new string[5, 2];
            decimal[][] accounts = new decimal[5][];
            string[] accountNames = { "Lönekonto", "Sparkonto", "Semesterkonto" };

            //Användare med pinkod och kontosaldo
            usersAndPins[0, 0] = "Jens";
            usersAndPins[0, 1] = "0000";
            usersAndPins[1, 0] = "Lenny";
            usersAndPins[1, 1] = "1111";
            usersAndPins[2, 0] = "Benny";
            usersAndPins[2, 1] = "2222";
            usersAndPins[3, 0] = "Kenny";
            usersAndPins[3, 1] = "3333";
            usersAndPins[4, 0] = "Penny";
            usersAndPins[4, 1] = "4444";

            accounts[0] = [30000.25m];
            accounts[1] = [20000.85m, 350000m, 20000];
            accounts[2] = [50000.75m, 120000m];
            accounts[3] = [60000.55m, 550000m];
            accounts[4] = [12000.35m, 400000m, 30000];


            while (true) //Fortsätt programmet tills användaren väljer att logga ut
            {
                Console.WriteLine("Välkommen till banken!");

                //Inloggningslogik
                int userIndex = Login(usersAndPins);

                if (userIndex == -1)
                {
                    Console.WriteLine("Fel inloggning, programmet avslutas.");
                    return;
                }

                //Meny och menyval
                bool loggedIn = true;

                while (loggedIn)
                {
                    Console.WriteLine("1. Se dina konton och saldo");
                    Console.WriteLine("2. Överföring mellan konton");
                    Console.WriteLine("3. Ta ut pengar");
                    Console.WriteLine("4. Logga ut");

                    string input = Console.ReadLine();

                    switch (input)
                    {
                        //Visar konton och saldon
                        case "1":
                            ShowAccountBalances(accounts, accountNames, userIndex);
                            break;

                        //Överför pengar mellan konton
                        case "2":
                            TransferBetweenAccounts(accounts, accountNames, userIndex);
                            break;

                        //Ta ut pengar
                        case "3":
                            WithdrawMoney(accounts, accountNames, userIndex, usersAndPins);
                            break;

                        //Logga ut
                        case "4":
                            loggedIn = false;
                            Console.WriteLine("Du har loggats ut.");
                            break;

                        default:
                            Console.WriteLine("Ogiltigt val, försök igen.");
                            break;
                    }
                    if (loggedIn)
                    {
                        Console.WriteLine("Klicka enter för att komma till huvudmenyn");
                        Console.ReadLine(); //Väntar på ett knapptryck för att visa upp menyn igen
                    }

                }

            }
        }

        //Inloggningsfunktion
        static int Login(string[,] usersAndPins)
        {
            int loginAttempts = 0;

            while (loginAttempts < 3)
            {
                Console.WriteLine("Skriv ditt användarnamn: ");
                string userName = Console.ReadLine();

                int userIndex = -1;

                //Räknar hur många försök man gjort
                for (int i = 0; i < usersAndPins.GetLength(0); i++)
                {
                    if (userName == usersAndPins[i, 0])
                    {
                        userIndex = i;
                        break;
                    }
                }
                if (userIndex == -1)
                {
                    Console.WriteLine("Användaren finns inte.");
                    return -1;
                }
                Console.WriteLine("Skriv din pinkod");
                string userPin = Console.ReadLine();

                if (usersAndPins[userIndex, 1] == userPin)
                {
                    Console.WriteLine($"Du är inloggad som {usersAndPins[userIndex, 0]}.");
                    return userIndex;
                }
                else
                {
                    Console.WriteLine("Fel pinkod, försök igen.");
                    loginAttempts++;
                }
            }
            Console.WriteLine("Du har skrivit in fel pinkod tre gånger. Programmet avslutas.");
            return -1;
        }

        //Metod för att visa konton och saldon
        static void ShowAccountBalances(decimal[][] accounts, string[] accountNames, int userIndex)
        {
            Console.WriteLine("Dina konton och saldo:");
            for (int i = 0; i < accounts[userIndex].Length; i++)
            {
                Console.WriteLine($"{accountNames[i]}: {accounts[userIndex][i]:C}");
            }
        }

        //Metod för att överföra pengar mellan konton
        static void TransferBetweenAccounts(decimal[][] accounts, string[] accountNames, int userIndex)
        {
            Console.WriteLine("Överföring mellan konton:");
            Console.WriteLine("Från vilket konto vill du överföra pengar?");

            ShowAccountBalances(accounts, accountNames, userIndex);
            int fromAccount = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine("Till vilket konto vill du överföra pengar?");
            int toAccount = int.Parse(Console.ReadLine()) - 1;



            if (fromAccount < 0 || fromAccount >= accounts[userIndex].Length || toAccount >= accounts[userIndex].Length)
            {
                Console.WriteLine("Ogiltigt konto valt.");
                return;
            }

            Console.WriteLine("Hur mycket vill du överföra?");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (accounts[userIndex][fromAccount] >= amount)
            {
                accounts[userIndex][fromAccount] -= amount;
                accounts[userIndex][toAccount] += amount;
                Console.WriteLine($"Överfört {amount:C} från {accountNames[fromAccount]} till {accountNames[toAccount]}");
                Console.WriteLine($"Nytt saldo för {accountNames[fromAccount]}: {accounts[userIndex][fromAccount]:C}");
                Console.WriteLine($"Nytt saldo för {accountNames[toAccount]}: {accounts[userIndex][toAccount]:C}");
            }


            else
            {
                Console.WriteLine("Otillräckligt saldo för överföringen.");
            }
        }

        //Metod för att ta ut pengar
        static void WithdrawMoney(decimal[][] accounts, string[] accountNames, int userIndex, string[,] usersAndPins)
        {
            Console.WriteLine("Ta ut pengar:");
            ShowAccountBalances(accounts, accountNames, userIndex);

            Console.WriteLine("Från vilket konto vill du ta ut pengar?");
            int account = int.Parse(Console.ReadLine()) - 1;





            if (account < 0 || account >= accounts[userIndex].Length)
            {
                Console.WriteLine("Ogiltigt konto valt.");
                return;
            }
            Console.WriteLine("Hur mycket vill du ta ut?");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (accounts[userIndex][account] >= amount)
            {
                Console.WriteLine("Skriv in din pinkod för att bekräfta uttaget: ");
                string userPin = Console.ReadLine();

                if (usersAndPins[userIndex, 1] == userPin)
                {
                    accounts[userIndex][account] -= amount;
                    Console.WriteLine($"Du har tagit ut {amount:C} Nytt saldo: {accounts[userIndex][account]:C}");
                }
                else
                {
                    Console.WriteLine("Fel pinkod. Uttaget misslyckades.");
                }
            }
            else
            {
                Console.WriteLine("Otilräckligt saldo.");
            }
        }
    }
}
