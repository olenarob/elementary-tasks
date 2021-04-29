using System;

namespace NumberToString
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = int.Parse(args[0]);
            Console.Write(new Ones(value));
            //Console.WriteLine(new Tens(value));
        }
    }
    public class Numbers
    {
        protected enum NumbersName
        {
            One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
            Eleven, Twelve, Thirteen, Fourteen, Fifteen, Sixteen, Seventeen,
            Eighteen, Nineteen, Twenty, Thirty = 30, Fourty = 40, Fifty = 50,
            Sixty = 60, Seventy = 70, Eighty = 80, Ninety = 90, Hundred = 100,
            Thousand = 1000, Million = 1000000, Billion = 1000000000
        }

    }

    public class Ones : Numbers
    {
        private int _ones;
        public Ones(int value)
        {
            _ones = value;            
        }
        static string ToName (int value)
        {
            return ((NumbersName)value).ToString();
        }

        public override string ToString()
        {
            string s = string.Empty;
            int div = 1_000_000_000;
            int v = (int)_ones;
            do
            {
                int temp = v / div;
                int rem = v % div;
            
                if (temp != 0)
                {
                    s = s + " " + ToStringInternal(temp) + " " + ToName(div) + " ";
                    v = v - temp * div;
                }
                div = div / 1000;
            }
            while (div != 1);
            s = s + ToStringInternal((int)_ones % 1000);
            return s;
        }
        private string ToStringInternal(int dividend)
        {
            string s = string.Empty;

            int divisor = 100;
            int remainder = dividend % divisor; //925
            int bases = dividend - remainder; // 1000
            
            do
            {
                if (bases == 0)
                {
                    if (!Enum.IsDefined(typeof(NumbersName), remainder))
                    {
                        divisor = divisor / 10;         // 100 10
                        bases = remainder / divisor * divisor; //900 20
                        remainder = remainder % divisor; // 25 5
                        if (Enum.IsDefined(typeof(NumbersName), bases))
                        {
                            s = s + bases.ToString() + " " + remainder.ToString() + " ";
                            bases = 0;
                            remainder = 0;
                        }
                    }
                    else
                    {
                        s = s + remainder.ToString();
                        remainder = 0;
                    }
                }
                else
                {
                    int quotient = bases / divisor; //1 9
                    s = s + quotient.ToString() + " " + divisor.ToString() + " ";
                    bases = 0;
                }
            }
            while (remainder != 0) ;

            return s;
        }
    }
}
