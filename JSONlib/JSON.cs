using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSONlib
{
    public class JSON
    {
        public static JObject JsonObject = new JObject();
        public static string jsonpath = @"Inspect_Log.json";

        public static void Add(string ParentNode, string LogNode)
        {
            JsonObject.Add(ParentNode,LogNode);
        }
    }
}
