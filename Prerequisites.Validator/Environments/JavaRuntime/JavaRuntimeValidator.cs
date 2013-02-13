namespace Prerequisites.Validator.Environments.JavaRuntime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32;

    public class JavaRuntimeValidator
    {
        public bool JavaVersionExist(string versionStartsWith)
        {
            if (string.IsNullOrWhiteSpace(versionStartsWith))
                return false;

            RegistryKey baseKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey rk = baseKey.OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment");
            if (rk == null)
            {
                return false;
            }

            string[] javaVersionKeys = rk.GetSubKeyNames();
            foreach (string key in javaVersionKeys)
            {
                if (key.StartsWith(versionStartsWith))
                    return true;
            }

            return false;
        }
    }
}
