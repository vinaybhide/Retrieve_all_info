using System;
using System.Text;
using System.DirectoryServices;

namespace activeDirectoryLdapExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter user: ");
            String username = Console.ReadLine();

            try
            {
                DirectoryEntry myLdapConnection = createDirectoryEntry();
                DirectorySearcher search = new DirectorySearcher(myLdapConnection);
                search.Filter = "(cn=" + username + ")";

                // create an array of properties that we would like and
                // add them to the search object

                string[] requiredProperties = new string[]{"cn", "postofficebox", "mail"};
                foreach (String property in requiredProperties) search.PropertiesToLoad.Add(property);

                SearchResult result = search.FindOne();
                
                if (result != null)
                {
                    foreach (String property in requiredProperties)
                        foreach (Object myCollection in result.Properties[property]) 
                            Console.WriteLine(String.Format("{0,-20} : {1}", property, myCollection.ToString()));
                }

                else Console.WriteLine("User not found!");
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception caught:\n\n" + e.ToString());
            }
        }

        static DirectoryEntry createDirectoryEntry()
        {
            // create and return new LDAP connection with desired settings

            DirectoryEntry ldapConnection = new DirectoryEntry("rizzo.leeds-art.ac.uk");
            ldapConnection.Path = "LDAP://OU=staffusers,DC=leeds-art,DC=ac,DC=uk";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
            return ldapConnection;
        }
    }
}
