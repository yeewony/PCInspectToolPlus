using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace PCInspectTool_Splash
{
    class OSVersionCheck
    {
        private static ManagementObject GetManagementObject(string classname)
        {
            var wmi = new ManagementClass(classname);

            foreach (var o in wmi.GetInstances())
            {
                var mo = (ManagementObject)o;
                if (mo!=null)
                {
                    return mo;
                }
            }

            return null;
        }

        private static string GetOSver()
        {
            try
            {
                ManagementObject mo = GetManagementObject("Win32_OperatingSystem");

                if (null == mo)
                {
                    return string.Empty;
                }
                return mo["Version"] as string;

            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string Run()
        {
            string[] osver = GetOSver().Split('.');

            return osver[0];
        }
    }
}
