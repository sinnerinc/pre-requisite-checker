using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using Prerequisites.Validator.Products.SqlServer;
using Prerequisites.Validator.Environments.DotNet;
using Prerequisites.Validator.Environments.Services;
using Prerequisites.Validator.Environments.JavaRuntime;

namespace Prerequisites.Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindSqlServerR2();
            FindSqlServerR2Any();
            CheckAspNetMvc3();
            CheckMsdtcInstalled();
            CheckMsmqInstalled();
            CheckeJreInstalled();
        }

        private static void CheckeJreInstalled()
        {
            var validator = new Java17RuntimeValidator();
            var isInstalled = validator.IsInstalled();
            Console.WriteLine("JRE 1.7 Installed: " + isInstalled);
        }

        private static void CheckMsmqInstalled()
        {
            var validator = new MessageQueuingValidator();
            var isInstalled = validator.IsInstalled();
            Console.WriteLine("MSMQ Installed: " + isInstalled);
        }

        private static void CheckMsdtcInstalled()
        {
            var validator = new DistributedTransactionsValidator();
            var isInstalled = validator.IsInstalled();
            Console.WriteLine("MSDTC Installed: " + isInstalled);
        }

        private static void FindSqlServerR2Any()
        {
            var validator = new SqlServer2008R2Validator();
            bool r2sqlExists = validator.IsInstalled();            
            Console.WriteLine("SQL Server installed: " + r2sqlExists);
        }

        private static void FindSqlServer()
        {
            var sqlServerValidator = new SqlServerValidator();

            string versionToFind = "10.50.2500.0";
            Console.WriteLine("Looking for sql version: " + versionToFind);

            bool r2sqlExists = sqlServerValidator.SqlServerVersionExists(versionToFind);
            Console.WriteLine("SQL Server installed: " + r2sqlExists);
        }

        private static void CheckAspNetMvc3()
        {
            var executor = new AspNetMVC3Validator();
            bool isInstalled = executor.IsInstalled();
            Console.WriteLine("Is ASP.NET MVC3 installed: " + isInstalled);
        }
    }
}
