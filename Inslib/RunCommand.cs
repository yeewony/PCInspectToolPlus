using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Inslib
{
    public class RunCommand
    {
        public static string PowerShell(string Command)
        {
            Process process = new Process();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = @"powershell.exe";
            process.StartInfo.Arguments = @"/c " + Command;
            process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            //string output;
            //while ((output = process.StandardOutput.ReadLine()) != null)
            //{
            //    list.Add(output);
            //    //output = process.StandardOutput.ReadLine();
            //}1

            process.WaitForExit();

            return output;

        }
    }
}
