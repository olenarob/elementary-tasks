using ArgumentsProcessor;
using System;

namespace NumberToString
{
    class Program
    {
        static void Main(string[] args)
        {
            int value;
            
            if ((args.Length > 0) &&
                Argument.TryParseInt(args[0], 1, int.MaxValue, out value))
            {
                Console.Write(new Numbers(value));
            }
            else
            {
                Console.WriteLine("Usage: NumberToString.exe [number]");
            }
        }
    }
    public class Numbers
    {
        enum NumbersName
        {
            One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
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
        static string ToName (int value)
        {
            return ((NumbersName)value).ToString();
        }
        public override string ToString()
        {
            int div = 1_000_000_000;
            int v = (int)_number;

            string s = string.Empty;
            do
            {
                int temp = v / div;
                int rem = v % div;
            
                if (temp != 0)
                {
                    s += ToStringInternal(temp) + " " + ToName(div) + " ";
                    v = v - temp * div;
                }
                div = div / 1000;
            }
            while (div != 1);

            s += ToStringInternal((int)_number % 1000);
            return s;
        }
        private string ToStringInternal(int dividend) // 999
        {
            string s = string.Empty;

            int divisor = 100;
            int remainder = dividend % divisor; // 99
            int bases = dividend - remainder; // 900
            
            do
            {
                if (bases == 0)
                {
                    if (!Enum.IsDefined(typeof(NumbersName), remainder))
                    {
                        divisor = divisor / 10;       //10  
                        bases = remainder / divisor * divisor; //90
                        remainder = remainder % divisor;//9
                        
                        if (Enum.IsDefined(typeof(NumbersName), bases))
                        {
                            s += ToName(bases) + " " + ToName(remainder) + " ";
                            bases = 0;
                            remainder = 0;
                        }
                    }
                    else
                    {
                        s += ToName(remainder);
                        remainder = 0;
                    }
                }
                else
                {
                    int quotient = bases / divisor;
                    s += ToName(quotient) + " " + ToName(divisor) + " ";
                    bases = 0;
                }
            }
            while (remainder != 0) ;

            return s;
        }
    }
}
