using System;
using System.DirectoryServices.AccountManagement;
using System.IO;

namespace new_ad_exmaple
{
    class Program
    {
            //        // set up domain context
            //        PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

            //        // find current user
            //        UserPrincipal user = UserPrincipal.Current;

            //if(user != null)
            //{
            //   string loginName = user.SamAccountName; // or whatever you mean by "login name"
            //    }
    static void Main(string[] args)
        {
            try
            {
                //string fullPath = AppDomain.CurrentDomain.BaseDirectory + @"output.txt";
                //using (StreamWriter writer = new StreamWriter(fullPath, true))
                { 
                    Console.WriteLine("Using UserPrincipal directly for the current user who is running this app");
                    ////writer.WriteLine("Using UserPrincipal directly for the current user who is running this app");
                    try
                    {
                        // enter AD settings
                        //PrincipalContext AD = new PrincipalContext(ContextType.Domain, "maxionwheels.com.local");
                        UserPrincipal user = UserPrincipal.Current;
                        Console.WriteLine("Name : " + user.Name);
                        ////writer.WriteLine("Name : " + user.Name);

                        Console.WriteLine("SamAccountName : " + user.SamAccountName);
                        ////writer.WriteLine("SamAccountName : " + user.SamAccountName);

                        Console.WriteLine("UserPrincipalName : " + user.UserPrincipalName);
                        //writer.WriteLine("UserPrincipalName : " + user.UserPrincipalName);

                        Console.WriteLine("EmailAddress : " + user.EmailAddress);
                        //writer.WriteLine("EmailAddress : " + user.EmailAddress);

                        Console.WriteLine("GivenName : " + user.GivenName);
                        //writer.WriteLine("GivenName : " + user.GivenName);

                        Console.WriteLine("Surname : " + user.Surname);
                        //writer.WriteLine("Surname : " + user.Surname);

                        Console.WriteLine("Display Name : " + user.DisplayName);
                        //writer.WriteLine("Display Name : " + user.DisplayName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //writer.WriteLine(ex.Message);
                    }
                    Console.WriteLine("-------------------------------------------------------------");
                    //writer.WriteLine("-------------------------------------------------------------");

                    Console.WriteLine("Using Principal Context with domain name maxionwheels.com with current users environment.username= " + System.Environment.UserName);
                    //writer.WriteLine("Using Principal Context with domain name maxionwheels.com with current users environment.username= " + System.Environment.UserName);
                    try
                    {
                        PrincipalContext AD = new PrincipalContext(ContextType.Domain, "maxionwheels.com");
                        UserPrincipal u = new UserPrincipal(AD);
                        u.SamAccountName = System.Environment.UserName;//"e.papavasiliova";//System.Environment.UserName;
                        Console.WriteLine("SamAccountName: " + u.SamAccountName);
                        //writer.WriteLine("SamAccountName: " + u.SamAccountName);

                        // search for user
                        PrincipalSearcher search = new PrincipalSearcher(u);
                        UserPrincipal result = (UserPrincipal)search.FindOne();
                        search.Dispose();
                        if (result != null)
                        {
                            // show some details
                            Console.WriteLine("Name : " + result.Name);
                            //writer.WriteLine("Name : " + result.Name);

                            Console.WriteLine("UserPrincipalName : " + result.UserPrincipalName);
                            //writer.WriteLine("UserPrincipalName : " + result.UserPrincipalName);
                            Console.WriteLine("EmailAddress : " + result.EmailAddress);
                            //writer.WriteLine("EmailAddress : " + result.EmailAddress);
                            Console.WriteLine("GivenName : " + result.GivenName);
                            //writer.WriteLine("GivenName : " + result.GivenName);
                            Console.WriteLine("Surname : " + result.Surname);
                            //writer.WriteLine("Surname : " + result.Surname);
                            Console.WriteLine("Display Name : " + result.DisplayName);
                            //writer.WriteLine("Display Name : " + result.DisplayName);
                        }
                        else
                        {
                            Console.WriteLine("No result found for user: " + u.SamAccountName);
                            //writer.WriteLine("No result found for user: " + u.SamAccountName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //writer.WriteLine(ex.Message);
                    }
                    Console.WriteLine("-------------------------------------------------------------");
                    //writer.WriteLine("-------------------------------------------------------------");

                    Console.WriteLine("Using Principal Context with domain name MAX with current users environment.username= " + System.Environment.UserName);
                    //writer.WriteLine("Using Principal Context with domain name MAX with current users environment.username= " + System.Environment.UserName);
                    try
                    {
                        PrincipalContext AD = new PrincipalContext(ContextType.Domain, "MAX");
                        UserPrincipal u = new UserPrincipal(AD);
                        u.SamAccountName = System.Environment.UserName;//"e.papavasiliova";//System.Environment.UserName;
                        Console.WriteLine("SamAccountName: " + u.SamAccountName);
                        //writer.WriteLine("SamAccountName: " + u.SamAccountName);

                        // search for user
                        PrincipalSearcher search = new PrincipalSearcher(u);
                        UserPrincipal result = (UserPrincipal)search.FindOne();
                        search.Dispose();
                        if (result != null)
                        {
                            // show some details
                            Console.WriteLine("Name : " + result.Name);
                            //writer.WriteLine("Name : " + result.Name);

                            Console.WriteLine("UserPrincipalName : " + result.UserPrincipalName);
                            //writer.WriteLine("UserPrincipalName : " + result.UserPrincipalName);
                            Console.WriteLine("EmailAddress : " + result.EmailAddress);
                            //writer.WriteLine("EmailAddress : " + result.EmailAddress);
                            Console.WriteLine("GivenName : " + result.GivenName);
                            //writer.WriteLine("GivenName : " + result.GivenName);
                            Console.WriteLine("Surname : " + result.Surname);
                            //writer.WriteLine("Surname : " + result.Surname);
                            Console.WriteLine("Display Name : " + result.DisplayName);
                            //writer.WriteLine("Display Name : " + result.DisplayName);
                        }
                        else
                        {
                            Console.WriteLine("No result found for user: " + u.SamAccountName);
                            //writer.WriteLine("No result found for user: " + u.SamAccountName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //writer.WriteLine(ex.Message);
                    }
                    Console.WriteLine("-------------------------------------------------------------");
                    //writer.WriteLine("-------------------------------------------------------------");


                    Console.WriteLine("Using Principal Context without domain name with current users environment.username");
                    //writer.WriteLine("Using Principal Context without domain name with current users environment.username");
                    try
                    {
                        PrincipalContext AD = new PrincipalContext(ContextType.Domain);
                        UserPrincipal u = new UserPrincipal(AD);
                        u.SamAccountName = System.Environment.UserName;//"e.papavasiliova";//System.Environment.UserName;
                        Console.WriteLine("SamAccountName: " + u.SamAccountName);
                        //writer.WriteLine("SamAccountName: " + u.SamAccountName);

                        // search for user
                        PrincipalSearcher search = new PrincipalSearcher(u);
                        UserPrincipal result = (UserPrincipal)search.FindOne();
                        search.Dispose();
                        if (result != null)
                        { 
                            // show some details
                            Console.WriteLine("Name : " + result.Name);
                            //writer.WriteLine("Name : " + result.Name);
                            
                            Console.WriteLine("UserPrincipalName : " + result.UserPrincipalName);
                            //writer.WriteLine("UserPrincipalName : " + result.UserPrincipalName);
                            Console.WriteLine("EmailAddress : " + result.EmailAddress);
                            //writer.WriteLine("EmailAddress : " + result.EmailAddress);
                            Console.WriteLine("GivenName : " + result.GivenName);
                            //writer.WriteLine("GivenName : " + result.GivenName);
                            Console.WriteLine("Surname : " + result.Surname);
                            //writer.WriteLine("Surname : " + result.Surname);
                            Console.WriteLine("Display Name : " + result.DisplayName);
                            //writer.WriteLine("Display Name : " + result.DisplayName);
                        }
                        else
                        {
                            Console.WriteLine("No result found for user: " + u.SamAccountName);
                            //writer.WriteLine("No result found for user: " + u.SamAccountName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        //writer.WriteLine(ex.Message);
                    }

                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.WriteLine("-------END------");
            //Console.Write("Hit enter to exit.....");
            //Console.ReadLine();
        }
    }
}
