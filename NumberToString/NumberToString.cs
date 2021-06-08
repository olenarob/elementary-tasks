using System;
using System.Collections.Generic;
using System.Numerics;

namespace NumberToString
{
    public class NumberToString
    { 
        public static string ToString(BigInteger number)
        {
            if (number < 1)
            {
                throw new OverflowException
                    ($"Please use a positive integer number more than zero!");
            }
            
            var stack = new Stack<string>();
            
            int powerOfThousand = 0;
            while(number != 0)
            {
                int threeDigits = (int)(number % 1000);
                if (threeDigits != 0)
                {
                    stack.Push(NumberScaleName.ToString(powerOfThousand));
                    ThreeDigitsToString(threeDigits, stack);
                }
                number /= 1000;
                powerOfThousand++;
            }

            return string.Join(" ", stack).ToLower();
        }
        
        private static void ThreeDigitsToString(int threeDigits, Stack<string> stack)
        {
            int remainder = threeDigits % 100;
            int hundred = threeDigits / 100;

            if (remainder != 0)
            {
                if (Enum.IsDefined(typeof(SmallNumber), remainder))
                {
                    stack.Push(ToName(remainder));
                }
                else
                {
                    int unit = threeDigits % 10;
                    int ten = remainder / 10 * 10;
                    
                    stack.Push(ToName(unit));
                    stack.Push(ToName(ten));
                }
            }
            
            if (hundred != 0)
            {
                stack.Push(ToName(100));
                stack.Push(ToName(hundred));
            }
        }

        private static string ToName(int num)
        {
            return Enum.GetName((SmallNumber)num);
        }
    }
}
