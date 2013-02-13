using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using Prerequisites.Validator.Products.SqlServer;
using Prerequisites.Validator.Environments.DotNet;
using Prerequisites.Validator.Environments.Services;

namespace Prerequisites.Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindSqlServerR2();
            //FindSqlServerR2Any();
            //CheckAspNetMvc3();
            //CheckMsdtcInstalled();
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

            if (r2sqlExists)
                Console.WriteLine("SQL Server version exists");
            else
                Console.WriteLine("SQL Server version does not exist");
        }

        private static void FindSqlServerR2()
        {
            var sqlServerValidator = new SqlServerValidator();

            string versionToFind = "10.50.2500.0";
            Console.WriteLine("Looking for sql version: " + versionToFind);

            bool r2sqlExists = sqlServerValidator.SqlServerVersionExists(versionToFind);

            if (r2sqlExists)
                Console.WriteLine("SQL Server version exists");
            else
                Console.WriteLine("SQL Server version does not exist");
        }

        private static void CheckAspNetMvc3()
        {
            var executor = new AspNetMVC3Validator();

            Console.WriteLine("Is ASP.NET MVC3 installed: ");
            Console.WriteLine(executor.IsInstalled());
        }
    }
}
