using System;

namespace NumberToString
{
    public class Numbers
    {
        enum NumbersName
        {
            Zero = 0, One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
            Eleven, Twelve, Thirteen, Fourteen, Fifteen, Sixteen, Seventeen,
            Eighteen, Nineteen, Twenty, Thirty = 30, Fourty = 40, Fifty = 50,
            Sixty = 60, Seventy = 70, Eighty = 80, Ninety = 90, Hundred = 100,
            Thousand = 1_000, Million = 1_000_000, Billion = 1_000_000_000
        }
    
        private int _number;
        public Numbers (int value)
        {
            _number = value;            
        }
        
        static string ToName (int number)
        {
            return Enum.GetName((NumbersName)number);
        }
        
        public override string ToString()
        {
            string text = string.Empty;

            int value = _number;
            int divisor = 1_000_000_000;
            
            do
            {
                int tripleDigitNumber = value / divisor;
            
                if (tripleDigitNumber != 0)
                {
                    text += TripleDigitNumberToText(tripleDigitNumber);
                    
                    if (divisor > 1)
                    {
                        text += " " + ToName(divisor) + "\n";
                    }
                    value -= tripleDigitNumber * divisor; //remainder
                }
                
                divisor /= 1000;
            }
            while (divisor != 0);

            return text.ToLower();
        }
        private static string TripleDigitNumberToText(int tripleNumber)
        {
            string text = string.Empty;
            
            int hundreds = tripleNumber / 100;
            int remainder = tripleNumber % 100;
            
            if (hundreds != 0)
            {
                text += ToName(hundreds) + " " + ToName(100) + " ";
            }
            
            if (remainder != 0)
            {
                if (Enum.IsDefined(typeof(NumbersName), remainder))
                {
                    text += ToName(remainder);
                }
                else
                {
                    int tens = remainder / 10 * 10;
                    remainder %= 10;
                    text += ToName(tens) + " " + ToName(remainder);
                }
            }
            return text;
        }
    }
}
