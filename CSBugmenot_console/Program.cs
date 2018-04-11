using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBugmenot;

namespace CSBugmenot_console
{
    class Program
    {
        static void Main(string[] args)
        {
            // CsBugmenot.MinimumSuccessRate = 40;
            List<Account> accounts = CsBugmenot.GetAllAccounts("leakforums.net");
            WriteHeader("Accounts found: " + accounts.Count);

            foreach (Account account in accounts)
            {
                Console.WriteLine("\nUsername: {0}", account.Username);
                Console.WriteLine("Password: {0}", account.Password);
                Console.WriteLine("Other: {0}", account.Other != "" ? account.Other : "/");
                Console.WriteLine("{0}% success rate - {1} votes - added at {2:dd-MM-yyyy}\n", account.Stats, account.Votes, account.AddingDate);
            }

            Console.WriteLine("Press [ENTER] to exit...");
            Console.ReadLine();
        }

        private static void WriteHeader(string title)
        {
            Console.WriteLine(new String('*', 30));
            Console.WriteLine(title);
            Console.WriteLine(new String('*', 30));
        }
    }
}
