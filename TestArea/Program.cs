using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;

namespace TestArea
{
    class Program
    {
        public static string InsName = "PC02";

        public static string[] res = new string[3];
        static void Main(string[] args)
        {
            string username = Environment.MachineName;

            try
            {
                using (var userEntry = new DirectoryEntry("WinNT://"+Environment.MachineName +"/"+Environment.UserName))
                {
                    DateTime Exdate = (DateTime)userEntry.InvokeGet("PasswordExpirationDate");

                    Exdate = Exdate.AddDays(1);

                    res[1] = Exdate.ToString();
                    res[2] = DateTime.Now.ToString();
                    res[0] = (Exdate - DateTime.Now).Days.ToString();


                    Console.WriteLine(res[2]);
                    Console.WriteLine(res[1]);
                    Console.WriteLine(res[0]);
                    Console.WriteLine(username);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
            

        }

    }
}
