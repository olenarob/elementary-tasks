using System;

namespace NumberToString
{
    public class NumberToString
    {
        enum NumbersName
        {
            Zero = 0, One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
            Eleven, Twelve, Thirteen, Fourteen, Fifteen, Sixteen, Seventeen,
            Eighteen, Nineteen, Twenty, Thirty = 30, Fourty = 40, Fifty = 50,
            Sixty = 60, Seventy = 70, Eighty = 80, Ninety = 90, Hundred = 100,
            Thousand = 1_000, Million = 1_000_000, Billion = 1_000_000_000
        }
    
        private int number;

        public int Number
        {
            get { return number; }
            set
            {
                if (value < 1)
                {
                    throw new OverflowException
                        ($"The number can not be less 1. Please use positive integer more than zero.");
                }
                else    
                    this.number = value;
            }
        }
        public NumberToString (int num)
        {
            Number = num;            
        }
        
        static string ToName (int num)
        {
            return Enum.GetName((NumbersName)num);
        }
        
        public override string ToString()
        {
            string text = string.Empty;

            int divisor = 1_000_000_000;
            
            do
            {
                int tripleDigitNumber = number / divisor % 1000;
            
                if (tripleDigitNumber != 0)
                {
                    text += TripleDigitNumberToString(tripleDigitNumber);
                    
                    if (divisor > 1)
                    {
                        text += $" { ToName(divisor)}\n";
                    }
                }
                
                divisor /= 1000;
            }
            while (divisor != 0);

            return text.ToLower();
        }
        private static string TripleDigitNumberToString(int tripleDigitNumber)
        {
            string text = string.Empty;
            
            int hundreds = tripleDigitNumber / 100;
            int remainder = tripleDigitNumber % 100;
            
            if (hundreds != 0)
            {
                text += $"{ToName(hundreds)} {ToName(100)} ";
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
                    text += $"{ToName(tens)} {ToName(tripleDigitNumber % 10)}";
                }
            }
            return text;
        }
    }
}
