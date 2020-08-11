using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SummerTest.Classes
{
    public class PasswordValidateClass
    {
        public static bool CheckPassword1Upper_1Lower_6Symbols_1Num_1SpecSymbols(string password)
        {
            //lower check
            if (!password.Any(Char.IsLower))
                return false;

            //upper check
            if (!password.Any(Char.IsUpper))
                return false;

            //num check
            if(password.Intersect("0123456789").Count() <= 0)
                return false;

            //6 symbols check
            if (password.Length < 6)
                return false;

            //check space
            if (password.Contains(" "))
                return false;

            //check special symbols !@#$%^
            if (password.Intersect("!@#$%^").Count() == 0)            
                return false;
            

            return true;
        }

    }
}
