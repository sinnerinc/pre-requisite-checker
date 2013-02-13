namespace Prerequisites.Validator.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class RegistryExtensions
    {
        public static bool IntToBool(this int dwordValue)
        {
            return dwordValue > 0;
        }

    }
}
