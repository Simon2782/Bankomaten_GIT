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
        }
    }
}
