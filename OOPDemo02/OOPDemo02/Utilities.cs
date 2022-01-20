using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo02
{
    // A static class prevents the creation of an object (instance) of the class
    internal static class Utilities
    {
        public static bool IsValidNameLength(string name, int minLength)
        {
            bool isValid = false;
            
            if(!string.IsNullOrEmpty(name) && name.Trim().Length >= minLength)
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
