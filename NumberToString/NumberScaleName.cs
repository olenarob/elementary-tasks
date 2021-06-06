namespace NumberToString
{
    class NumberScaleName
    {
        public static string ToString(int power = 0)
        {
            // Do this first and get out quick as it is the most used 99% of the time
            // You may delete following line if only interested in Powers above 10 (i.e. 1,000^11 and above)
            if (power < 11)
            {
                string[] vs = { "", "thousand", "million", "billion", "trillion", "quadrillion",
                    "quintillion", "sextillion", "septillion", "octillion", "nonillion" };
                return vs[power];
            }

            power -= 1; // Adjust the sequence above power of 10 as these are now systematic

            string[] TensList = {"", "deci", "viginti", "triginta", "quadraginta", "quinquaginta",
                "sexaginta", "septuaginta", "octoginta", "nonaginta" };
            /*       {{ "",{"", "", "", "", "", "", "", "", "", "", false } },
                                   ["deci",["","","","" ,"","","" ,"n","","n",false]], // 10
       ["viginti"     ,["","","","s","","","s","m","","m",false]], // 20
       ["triginta"    ,["","","","s","","","s","n","","n",true ]], // 30
       ["quadraginta" ,["","","","s","","","s","n","","n",true ]], // 40
       ["quinquaginta",["","","","s","","","s","n","","n",true ]], // 50
       ["sexaginta"   ,["","","","" ,"","","" ,"n","","n",true ]], // 60
       ["septuaginta" ,["","","","" ,"","","" ,"n","","n",true ]], // 70
       ["octoginta"   ,["","","","" ,"","","x","m","","m",true ]], // 80
       ["nonaginta"   ,["","","","" ,"","","" ,"" ,"","" ,true ]]];  // 90*/

            string[] HundredsList = { "", "centi", "ducenti", "trecenti", "quadringenti",
                "quingenti", "sescenti", "septingenti", "octingenti", "nongenti" };

            /*   = {{ "",{"", "", "", "", "", "", "", "", "", "" } },
                                       { "centi",{"","","","" ,"","","x","n","","n"} }, // 100
                                       {"ducenti"     ,{"","","","" ,"","","" ,"n","","n"}}, // 200
                                       { "trecenti"    ,{"","","","s","","","s","n","","n"}}, // 300
                                       { "quadringenti",{"","","","s","","","s","n","","n"}}, // 400
                                       { "quingenti"   ,{"","","","s","","","s","n","","n"}}, // 500
                                       { "sescenti"    ,{"","","","" ,"","","" ,"n","","n"}}, // 600
                                       { "septingenti" ,{"","","","" ,"","","" ,"n","","n"}}, // 700
                                       { "octingenti"  ,{"","","","" ,"","","x","m","","m"}}, // 800
                                       { "nongenti"    ,{"","","","" ,"","","" ,"" ,"","" }}};  // 900*/


            int Hund = power / 100;      // Hundred Digit
            int Ten = power % 100 / 10; // Ten Digit
            int Unit = power % 10 % 10;              // Unit Digit
            string[] UnitList = { "", "un", "duo", "tre", "quattuor", "quin", "se", "septe", "octo", "nove" };
            
            
            string UnitName = UnitList[Unit]; // Get Unit Name from Array
            string TenName = TensList[Ten];            // Get Tens Name from Array
            string HundName = HundredsList[Hund];        // Get Hundreds Name from Array
            
            if (Unit == 6 && Ten == 80)
            {
                UnitName += "x";
            }
            
            switch (Unit)
            {
                case 3:
                case 6:
                    switch (Ten)
                    {
                        case 20:
                        case 30:
                        case 40:
                        case 50:
                            UnitName += "s";
                            break;
                    }
                    break;
                case 7:
                case 9:
                    switch (Ten)
                    {
                        case 10:
                        case 30:
                        case 40:
                        case 50:
                        case 60:
                        case 70:
                            UnitName += "n";
                            break;
                        case 20:
                        case 80:
                            UnitName += "m";
                            break;
                    }
                    break;
            }
            // convert Ten names ending with "a" to "i" if it was prceeding the "llion" word
            /*    if (!Hund && TensList[Ten][1][10])
                {
                    TenName = TenName.slice(0, -1) + "i";
                }

                // Pickup and add the correct suffix to the Unit Name (s,x,n, or m)
                if (Ten)
                {
                    TenName = TensList[Ten][1][Unit] + TenName;
                }

                if (Hund && !Ten)
                {
                    HundName = HundredsList[Hund][1][Unit] + HundName;
                }
            */
            return UnitName + TenName + HundName + "llion"; // Create name
        }
    }
}
