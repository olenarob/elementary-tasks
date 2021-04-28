using System;

namespace NumberToString
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = 42;
            Console.Write(new Ones(value));
            //Console.WriteLine(new Tens(value));
        }
    }
    public class Numbers
    {
        protected enum NumbersName
        {
            One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
            Eleven, Twelve, Thirteen, Fourteen, Fifteen, Sixteen, Seventeen, Eighteen, Nineteen,
            Twenty, Thirty = 30, Fourty = 40, Fifty = 50, Sixty = 60, Seventy = 70, Eighty = 80,
            Ninety = 90
        }

    }

    public class Ones : Numbers
    {
        private NumbersName _ones;
        public Ones(int value)
        {
            _ones = (NumbersName)(value % 100);
            
        }

        public override string ToString()
        {
            if (!Enum.IsDefined(typeof(NumbersName), _ones))
            {
                _ones = ((int)_ones) / 10;
            }
            return _ones.ToString();
        }
    }

    public class Thousents
    {
        private Tens _tens;
        public Thousents(int value)
        {
            _tens = new Tens((value % 10000) / 1000);
        }

        public override string ToString()
        {
            return _tens.ToString() + " Thousents ";
        }
    }

    public class Tens
    {
        private int _tens;
        public Tens(int value)
        {
            _tens = (value % 100) / 10;
        }

        public override string ToString()
        {
            switch (_tens)
            {
                case 1: return "ten ";
                case 2: return "twony ";
                default: return _tens.ToString();
            }
        }
    }
}
