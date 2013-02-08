using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using Prerequisites.Validator.Products.SqlServer;

namespace Prerequisites.Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindSqlServerR2();

            
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
    }
}
