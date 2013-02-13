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

            // bool domainControllerState = ((int)rk.GetValue("DomainControllerState", 0)).IntToBool();
            bool networkDtcAccess = ((int)rk.GetValue("NetworkDtcAccess", 0)).IntToBool();
            bool networkDtcAccessAdmin = ((int)rk.GetValue("NetworkDtcAccessAdmin", 0)).IntToBool();
            bool networkDtcAccessClients = ((int)rk.GetValue("NetworkDtcAccessClients", 0)).IntToBool();
            bool networkDtcAccessInbound = ((int)rk.GetValue("NetworkDtcAccessInbound", 0)).IntToBool();
            bool networkDtcAccessOutbound = ((int)rk.GetValue("NetworkDtcAccessOutbound", 0)).IntToBool();
            // bool networkDtcAccessTip = ((int)rk.GetValue("NetworkDtcAccessTip", 0)).IntToBool();
            bool networkDtcAccessTransactions = ((int)rk.GetValue("NetworkDtcAccessTransactions", 0)).IntToBool();
            bool xaTransactions = ((int)rk.GetValue("XaTransactions", 0)).IntToBool();
            bool luTransactions = ((int)rk.GetValue("LuTransactions", 0)).IntToBool();

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
