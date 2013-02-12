namespace Prerequisites.Validator.Products.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SqlServer2008R2Validator
    {
        public bool IsInstalled()
        {
            string versionToFind = "10.50";

            var sqlServerValidator = new SqlServerValidator();
            bool r2sqlExists = sqlServerValidator.SqlServerVersionExists(versionToFind);

            return r2sqlExists;
        }
    }
}
