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
            var sb = new StringBuilder();
            
            int rank = 0;
            
            while(number != 0)
            {
                int threeDigits = (int)(number % 1000);
                
                if (threeDigits != 0)
                {
                    TripleDigitNumberToString(threeDigits, sb);
                    
                    if (rank >= 0)
                    {
                        //sb.Append(' ').AppendLine(Enum.GetName((PowerOfTen)rank));
                        sb.Append(' ').AppendLine(NumberScaleName.numberScaleNameShortScale(rank));
                    }
                }
                
                number /= 1000;
                rank ++;
                
                stack.Push(sb.ToString());
                sb.Clear();
            }

            foreach (var item in stack)
            {
                sb.Append(item);
            }
            
            return sb.ToString().ToLower();
        }
        
        private static void TripleDigitNumberToString(int threeDigits, StringBuilder sb)
        {
            int remainder = threeDigits % 100;
            int hundreds = threeDigits / 100;

            if (hundreds != 0)
            {
                sb.Append(' ').Append(ToName(hundreds))
                  .Append(' ').Append(ToName(100));
            }
            
            if (remainder != 0)
            {
                if (Enum.IsDefined(typeof(SmallNumber), remainder))
                {
                    sb.Append(' ').Append(ToName(remainder));
                }
                else
                {
                    int tens = remainder / 10 * 10;
                    int units = threeDigits % 10;
                    sb.Append(' ').Append(ToName(tens))
                      .Append(' ').Append(ToName(units));
                }
            }
        }
    }
}
