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
                // create LDAP connection object

                DirectoryEntry myLdapConnection = createDirectoryEntry();

                // create search object which operates on LDAP connection object
                // and set search object to only find the user specified

                DirectorySearcher search = new DirectorySearcher(myLdapConnection);
                search.Filter = "(cn=" + username + ")";

                // create results objects from search object

                SearchResult result = search.FindOne();
                
                if (result != null)
                {
                    // user exists, cycle through LDAP fields (cn, telephonenumber etc.)

                    ResultPropertyCollection fields = result.Properties;

                    foreach (String ldapField in fields.PropertyNames)
                    {
                        // cycle through objects in each field e.g. group membership
                        // (for many fields there will only be one object such as name)

                        foreach (Object myCollection in fields[ldapField]) 
                            Console.WriteLine(String.Format("{0,-20} : {1}", ldapField, myCollection.ToString()));
                               
                    }
                }

                else
                {
                    // user does not exist
                    Console.WriteLine("User not found!");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception caught:\n\n" + e.ToString());
            }
        }

        static DirectoryEntry createDirectoryEntry()
        {
            // create and return new LDAP connection with desired settings

            DirectoryEntry ldapConnection     = new DirectoryEntry("rizzo.leeds-art.ac.uk");
            ldapConnection.Path               = "LDAP://OU=staffusers,DC=leeds-art,DC=ac,DC=uk";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

            return ldapConnection;
        }
    }
}
