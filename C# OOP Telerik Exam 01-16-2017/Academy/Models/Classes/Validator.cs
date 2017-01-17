using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Classes
{
    public static class Validator
    {
        public static void CheckForNullName(string value,string kindOfError)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException($"{kindOfError} cannot be null or emptry");
            }
        }
    }
}
