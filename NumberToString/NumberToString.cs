using System;
using System.Collections.Generic;
using System.Numerics;

namespace NumberToString
{
    public class NumberToString
    {
        private BigInteger number;

        public BigInteger Number
        {
            get { return number; }
            set
            {
                if (value < 1)
                {
                    throw new OverflowException
                        ($"Please use a positive integer number more than zero!");
                }
                else
                {
                    this.number = value;
                }
            }
        }

        public NumberToString()
        {
        }
        
        public NumberToString(BigInteger number)
        {
            Number = number;
        }

        public override string ToString()
        {
            var stack = new Stack<string>();
            
            BigInteger bignumber = this.number;
            ushort powerOfThousand = 0;
            
            while(bignumber != 0)
            {
                int threeDigits = (int)(bignumber % 1000);
                if (threeDigits != 0)
                {
                    stack.Push(NumberScaleName.ToString(powerOfThousand));
                    ThreeDigitsToString(threeDigits, stack);
                }
                bignumber /= 1000;
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
