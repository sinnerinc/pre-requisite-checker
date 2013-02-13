namespace Prerequisites.Validator.Environments.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Win32;
    using Extensions;

    public class DistributedTransactionsValidator
    {
        public bool IsInstalled()
        {
            RegistryKey baseKey = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey rk = baseKey.OpenSubKey(@"SOFTWARE\Microsoft\MSDTC\Security");
            if (rk == null)
            {
                return false;
            }

            // bool domainControllerState = ((int)rk.GetValue("DomainControllerState")).IntToBool();
            bool networkDtcAccess = ((int)rk.GetValue("NetworkDtcAccess")).IntToBool();
            bool networkDtcAccessAdmin = ((int)rk.GetValue("NetworkDtcAccessAdmin")).IntToBool();
            bool networkDtcAccessClients = ((int)rk.GetValue("NetworkDtcAccessClients")).IntToBool();
            bool networkDtcAccessInbound = ((int)rk.GetValue("NetworkDtcAccessInbound")).IntToBool();
            bool networkDtcAccessOutbound = ((int)rk.GetValue("NetworkDtcAccessOutbound")).IntToBool();
            // bool networkDtcAccessTip = ((int)rk.GetValue("NetworkDtcAccessTip")).IntToBool();
            bool networkDtcAccessTransactions = ((int)rk.GetValue("NetworkDtcAccessTransactions")).IntToBool();
            bool xaTransactions = ((int)rk.GetValue("XaTransactions")).IntToBool();
            bool luTransactions = ((int)rk.GetValue("LuTransactions")).IntToBool();

            return networkDtcAccess &&
                networkDtcAccessAdmin &&
                networkDtcAccessClients &&
                networkDtcAccessInbound &&
                networkDtcAccessOutbound &&
                networkDtcAccessTransactions &&
                xaTransactions &&
                luTransactions;
        }
    }
}
