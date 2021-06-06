using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace NumberToString
{
    public class NumberToString
    {
        enum SmallNumber
        {
            One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
            Eleven, Twelve, Thirteen, Fourteen, Fifteen, Sixteen, Seventeen,
            Eighteen, Nineteen, Twenty, Thirty = 30, Fourty = 40, Fifty = 50,
            Sixty = 60, Seventy = 70, Eighty = 80, Ninety = 90, Hundred = 100
        }
        enum PowerOfTen
        {
            Thousand = 3, Million = 6, Billion = 9, Trillion = 12, Quadrillion = 15,
            Quintillion = 18, Sextillion = 21, Septillion = 24, Octillion = 27,
            Nonillion = 30, Decillion = 33, Undecillion = 36, Doudecillion = 39,
            Tredecillion = 42, Quattuordecillion = 45, Quindecillion = 48,
            Sexdecillion = 51, Septendecillion = 54, Octodecillion = 57,
            Novemdecillion = 60, Vigintillion = 63
        }

        private BigInteger number;

        public BigInteger Number
        {
            get { return number; }
            set
            {
                if (value < 1)
                {
                    throw new OverflowException
                        ($"Please use positive integer number more than zero!");
                }
                else    
                    this.number = value;
            }
        }

        public NumberToString()
        {
        }
        public NumberToString (BigInteger num)
        {
            Number = num;            
        }
        
        static string ToName (int num)
        {
            return Enum.GetName((SmallNumber)num);
        }
        
        public override string ToString()
        {
            var stack = new Stack<string>();
            int rank = 0;
            
            while(number != 0)
            {
                int threeDigits = (int)(number % 1000);
                if (threeDigits != 0)
                {
                    stack.Push(NumberScaleName.ToString(rank));
                    TripleDigitNumberToString(threeDigits, stack);
                }
                number /= 1000;
                rank++;
            }

            return string.Join(" ", stack).ToLower();
        }
        
        private static void TripleDigitNumberToString(int threeDigits, Stack<string> stack)
        {
            int remainder = threeDigits % 100;
            int hundreds = threeDigits / 100;

            if (remainder != 0)
            {
                if (Enum.IsDefined(typeof(SmallNumber), remainder))
                {
                    stack.Push(ToName(remainder));
                }
                else
                {
                    int units = threeDigits % 10;
                    int tens = remainder / 10 * 10;
                    stack.Push(ToName(units));
                    stack.Push(ToName(tens));
                }
            }
            if (hundreds != 0)
            {
                stack.Push(ToName(100));
                stack.Push(ToName(hundreds));
            }
        }
    }
}
