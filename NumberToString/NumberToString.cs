using System;
using System.Collections.Generic;
using System.Numerics;
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
            Sixty = 60, Seventy = 70, Eighty = 80, Ninety = 90, Hundred = 100
        }
        enum RanksName
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
                        ($"The number can not be less 1. Please use positive integer more than zero.");
                }
                else    
                    this.number = value;
            }
        }
        
        public NumberToString (BigInteger num)
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
            var stack = new Stack<string>();
            int rank = 0;
            
            while(number != 0)
            {
                int tripleDigitNumber = (int)(number % 1000);
                
            
                if (tripleDigitNumber != 0)
                {
                    TripleDigitNumberToString(tripleDigitNumber, sb);
                    
                    if (rank > 0)
                    {
                        sb.Append(' ').AppendLine(Enum.GetName((RanksName)rank));
                    }
                }
                
                number /= 1000;
                rank += 3;
                
                stack.Push(sb.ToString());
                sb.Clear();
            }

            foreach (var item in stack)
            {
                sb.Append(item);
            }
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
