using System;
using System.Text;

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
            var sb = new StringBuilder();

            int divisor = 1_000_000_000;
            
            do
            {
                int tripleDigitNumber = number / divisor % 1000;
            
                if (tripleDigitNumber != 0)
                {
                    TripleDigitNumberToString(tripleDigitNumber, sb);
                    
                    if (divisor > 1)
                    {
                        sb.Append(' ').AppendLine(ToName(divisor));
                    }
                }
                
                divisor /= 1000;
            }
            while (divisor != 0);

            return sb.ToString().TrimStart().ToLower();
        }
        
        private static void TripleDigitNumberToString(int tripleDigitNumber, StringBuilder sb)
        {
            int hundreds = tripleDigitNumber / 100;
            int remainder = tripleDigitNumber % 100;
            
            if (hundreds != 0)
            {
                sb.Append(' ').Append(ToName(hundreds))
                  .Append(' ').Append(ToName(100));
            }
            
            if (remainder != 0)
            {
                if (Enum.IsDefined(typeof(NumbersName), remainder))
                {
                    sb.Append(' ').Append(ToName(remainder));
                }
                else
                {
                    int tens = remainder / 10 * 10;
                    sb.Append(' ').Append(ToName(tens))
                      .Append(' ').Append(ToName(tripleDigitNumber % 10));
                }
            }
        }
    }
}
