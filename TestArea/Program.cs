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
            string rawdata = Command.Cmd("net share");
            string refineddata;

            List<string> DataToList = new List<string>(rawdata.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            //refineddata = DataToList.Where(d => d.Contains("기본 공유")).Select(d => d.Replace("기본 공유", string.Empty)).ToArray()[0].Trim();
            refineddata = DataToList.Where(d => d.Contains("기본 공유")).ToArray()[0].Trim();




            Console.WriteLine(rawdata);
            Console.WriteLine(refineddata);
            Console.ReadLine();

        }

    }
}
