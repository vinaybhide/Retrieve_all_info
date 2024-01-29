using System;
using System.DirectoryServices.AccountManagement;

namespace new_ad_exmaple
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // enter AD settings
                PrincipalContext AD = new PrincipalContext(ContextType.Domain, "leeds-art.ac.uk");

                // create search user and add criteria
                Console.Write("Enter logon name: ");
                UserPrincipal u = new UserPrincipal(AD);
                u.SamAccountName = Console.ReadLine();

                // search for user
                PrincipalSearcher search = new PrincipalSearcher(u);
                UserPrincipal result = (UserPrincipal)search.FindOne();
                search.Dispose();

                // show some details
                Console.WriteLine("Display Name : " + result.DisplayName);
                Console.WriteLine("Phone Number : " + result.VoiceTelephoneNumber);
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
