/*  Construct full name of the Short Scale Numeral System
    Using the Conway-Guy system for forming number prefixes
*/
using System;

namespace NumberToString
{
    public class NumberScaleName
    {
        private static readonly string[] SmallRanks =
            { "", "thousand", "million", "billion", "trillion", "quadrillion",
              "quintillion", "sextillion", "septillion", "octillion", "nonillion" };

        private static readonly string[] UnitsList =
            { "", "un", "duo", "tre", "quattuor", "quin", "se", "septe", "octo", "nove" };

        private static readonly (string Tens, string[] Prefix, bool IsSuffix)[] TensList = new[]
            {
                (""            , new[] {"","","", "","","", "", "","", ""}, false),
                ("deci"        , new[] {"","","", "","","", "","n","","n"}, false), // 10
                ("viginti"     , new[] {"","","","s","","","s","m","","m"}, false), // 20
                ("triginta"    , new[] {"","","","s","","","s","n","","n"}, true),  // 30
                ("quadraginta" , new[] {"","","","s","","","s","n","","n"}, true),  // 40
                ("quinquaginta", new[] {"","","","s","","","s","n","","n"}, true),  // 50
                ("sexaginta"   , new[] {"","","", "","","", "","n","","n"}, true),  // 60
                ("septuaginta" , new[] {"","","", "","","", "","n","","n"}, true),  // 70
                ("octoginta"   , new[] {"","","", "","","","x","m","","m"}, true),  // 80
                ("nonaginta"   , new[] {"","","", "","","", "", "","", ""}, true),  // 90
            };

        private static readonly (string Hundreds, string[] Prefix)[] HundredsList = new[]
            {
                (""            , new[] {"","","", "","","", "", "","", ""}),
                ("centi"       , new[] {"","","", "","","","x","n","","n"}), // 100
                ("ducenti"     , new[] {"","","","" ,"","","" ,"n","","n"}), // 200
                ("trecenti"    , new[] {"","","","s","","","s","n","","n"}), // 300
                ("quadringenti", new[] {"","","","s","","","s","n","","n"}), // 400
                ("quingenti"   , new[] {"","","","s","","","s","n","","n"}), // 500
                ("sescenti"    , new[] {"","","","" ,"","","" ,"n","","n"}), // 600
                ("septingenti" , new[] {"","","","" ,"","","" ,"n","","n"}), // 700
                ("octingenti"  , new[] {"","","","" ,"","","x","m","","m"}), // 800
                ("nongenti"    , new[] {"","","","" ,"","","" ,"" ,"","" }), // 900
            };

        public static string ToString(ushort power = 0)
        {
            if (power > 1000)
            {
                throw new ArgumentException(
                    "Use a positive integer number not more than 1000!");
            }

            if (power < 11)
            {
                return SmallRanks[power];
            }

            power -= 1; // Adjust the sequence above power of 10 as these are now systematic

            int hundred = power / 100;  // Hundred Digit
            int ten = power % 100 / 10; // Ten Digit
            int unit = power % 10 % 10; // Unit Digit
            
            string unitName = UnitsList[unit];                // Get Unit Name from Array
            string tenName = TensList[ten].Tens;              // Get Tens Name from Array
            string hundName = HundredsList[hundred].Hundreds; // Get Hundreds Name from Array

            // convert Ten names ending with "a" to "i" if it was preceding the "llion" word
            if (hundred == 0 && TensList[ten].IsSuffix)
            {
                tenName = tenName[0..^1] + "i";
            }

            // Pickup and add the correct suffix to the Unit Name (s, x, n, or m)
            if (ten != 0)
            {
                tenName = TensList[ten].Prefix[unit] + tenName;
            }
            else if (hundred != 0)
            {
                hundName = HundredsList[hundred].Prefix[unit] + hundName;
            }

            return unitName + tenName + hundName + "llion"; // Create name
        }
    }
}
