namespace Prerequisites.Validator.Environments.DotNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class AspNetMVC3Validator
    {
        public bool IsInstalled()
        {
            // Based on answer here:
            // http://stackoverflow.com/questions/4750305/how-to-check-if-asp-net-mvc-3-is-installed

            string pathToTest = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86),
                "Microsoft ASP.NET", "ASP.NET MVC 3");

            return Directory.Exists(pathToTest);
        }
    }
}
