namespace Bankomaten_GIT
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
    }
}
