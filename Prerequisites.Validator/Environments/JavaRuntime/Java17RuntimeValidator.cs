namespace Prerequisites.Validator.Environments.JavaRuntime
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Java17RuntimeValidator
    {
        public bool IsInstalled()
        {
            string versionToFind = "1.7";

            var runtimeValidator = new JavaRuntimeValidator();
            bool jreExists = runtimeValidator.JavaVersionExist(versionToFind);

            return jreExists;
        }
    }
}
