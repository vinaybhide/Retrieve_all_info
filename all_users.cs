using System;
using System.Text;
using System.DirectoryServices;

namespace activeDirectoryLdapExamples
{
    class Program
    {
        static void _Main(string[] args)
        {
            Console.Write("Enter property: ");
            String property = Console.ReadLine();

            try
            {
                DirectoryEntry myLdapConnection = createDirectoryEntry();

                DirectorySearcher search = new DirectorySearcher(myLdapConnection);
                search.PropertiesToLoad.Add("cn");
                search.PropertiesToLoad.Add(property);

                SearchResultCollection allUsers = search.FindAll();

                foreach(SearchResult result in allUsers)
                {
                    if (result.Properties["cn"].Count > 0 && result.Properties[property].Count > 0)
                    {
                        Console.WriteLine(String.Format("{0,-20} : {1}",
                                          result.Properties["cn"][0].ToString(),
                                          result.Properties[property][0].ToString()));
                    }
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

            DirectoryEntry ldapConnection = new DirectoryEntry("rizzo.leeds-art.ac.uk");
            ldapConnection.Path = "LDAP://OU=staffusers,DC=leeds-art,DC=ac,DC=uk";
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
            return ldapConnection;
        }
    }
}
