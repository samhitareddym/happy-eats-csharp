using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JustNom___Capstone_project
{
    // This class contains methods for error checks, it also contains another method used to display the price in pounds.
    public class SError
    {        
        public static bool IsAlphaNumeric(string input)
        {
            
            string pattern = @"^[a-zA-Z0-9\s]+$";
          
            if (!Regex.IsMatch(input, pattern))
            {
                throw new Exception("Fail - name must be at least one alphanumeric character");
            }

            return true;
        }
        public static bool IsNameNotNull(string input)
        {

            if (input == null)
            {
                throw new Exception("Fail - Name not first");
            }
            return true;
        }

        public static bool IsNegative(double input)
        {

             if(input < 0)
             {
                throw new Exception("Fail - negative price");
             }
           
            return true;
        }


        public static double ParseDouble(string input)
        {
            double val = 0;

            try
            {
                val = double.Parse(input);

            }
            catch (Exception)
            {

                throw new Exception("Fail - non-numeric price");
            }

            SError.IsNegative(val);

            return val;
        }


        // StrPrice method converts the price into pounds
        public static string StrPrice(double Price)
        {
            string fs = String.Format("{0:£#,##0.00;0}", Price / (double)100);
            return fs;
        }       

    }
}
