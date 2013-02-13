namespace Prerequisites.Validator.Environments.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32;
    using Extensions;

    public class MessageQueuingValidator
    {
        public bool IsInstalled()
        {
            RegistryKey baseKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey rk = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\MSMQ\Setup");
            if (rk == null)
            {
                return false;
            }

            bool msmq_ADIntegrated = ((int)rk.GetValue("msmq_ADIntegrated", 0)).IntToBool();
            bool msmq_Core = ((int)rk.GetValue("msmq_Core", 0)).IntToBool();
            bool msmq_CoreInstalled = ((int)rk.GetValue("msmq_CoreInstalled", 0)).IntToBool();
            bool msmq_HTTPSupport = ((int)rk.GetValue("msmq_HTTPSupport", 0)).IntToBool();
            bool msmq_LocalStorage = ((int)rk.GetValue("msmq_LocalStorage", 0)).IntToBool();

            return msmq_ADIntegrated &&
                msmq_LocalStorage &&
                msmq_Core &&
                msmq_CoreInstalled &&
                msmq_HTTPSupport;
        }
    }
}
