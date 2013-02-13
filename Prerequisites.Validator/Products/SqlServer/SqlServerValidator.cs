namespace Prerequisites.Validator.Products.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32;

    public class SqlServerValidator
    {
        public bool SqlServerVersionExists(string versionStartsWith)
        {
            if (string.IsNullOrWhiteSpace(versionStartsWith))
                return false;

            RegistryKey baseKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey rk = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL");
            if (rk == null)
            {
                return false;
            }

            string[] instances = rk.GetValueNames();
            if (instances.Length == 0)
            {
                return false;
            }

            foreach (var instance in instances)
            {
                string instanceSubkey = string.Concat(@"SOFTWARE\Microsoft\Microsoft SQL Server\", instance, @"\MSSQLServer\CurrentVersion");
                RegistryKey instanceRegKey = Registry.LocalMachine.OpenSubKey(instanceSubkey);
                if (instanceRegKey == null)
                {
                    continue;
                }

                string instanceVersion =  (string)instanceRegKey.GetValue("CurrentVersion", "0.0.0.0");
                if (instanceVersion.StartsWith(versionStartsWith))
                {
                    return true;
                }
            }


            return false;
        }
    }
}
