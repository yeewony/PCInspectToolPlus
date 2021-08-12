using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace PCInspectTool_Splash
{
    class InspectReady
    {
        //public static List<string> list = new List<string>();
        public static JObject jsonobject = new JObject();

        public static string jsonpath = @"log.json";

        public static string RunCmdCommand(string Command)
        {
            Process process = new Process();

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = @"cmd.exe";
            process.StartInfo.Arguments = @"/c " + Command;
            process.StartInfo.WorkingDirectory = Environment.CurrentDirectory;

            process.Start();

            string output = process.StandardOutput.ReadToEnd();

            //string output;
            //while ((output = process.StandardOutput.ReadLine()) != null)
            //{
            //    list.Add(output);
            //    //output = process.StandardOutput.ReadLine();
            //}

            process.WaitForExit();

            return output;

        }

        //public static void JsonAdd(string ParentNode, List<string> CommandOutput)
        //{
        //    var Serialized = JsonConvert.SerializeObject(CommandOutput);
        //    var jarray = JArray.Parse(Serialized);

        //    jsonobject.Add(ParentNode, jarray);

        //    list.Clear();
        //}

        public static void Run()
        {

            jsonobject.Add("SYSTEMINFO", RunCmdCommand("systeminfo"));
            jsonobject.Add("NETSTAT", RunCmdCommand("netstat -ano"));
            jsonobject.Add("NETSTART", RunCmdCommand("net start"));
            jsonobject.Add("IPCONFIG", RunCmdCommand("ipconfig /all"));


            Console.WriteLine(jsonobject);

            File.WriteAllText(jsonpath, jsonobject.ToString());

        }
    }
}
