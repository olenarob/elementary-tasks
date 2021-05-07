using System;

namespace ArgumentsProcessor
{
    public class Argument
    {
        public static double Parse(string s)
        {
            double result = 0;

            try
            {
                result = double.Parse(s);
                if (result <= 0)
                {
                    throw new ArgumentOutOfRangeException("Side of envelope must be greater than zero!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public static bool TryParseInt(string s, int min, int max, out int value)
        {
            bool success = true;
            try
            {
                    value = int.Parse(s);

                    if ((value < min) || (value > max))
                        throw new ArgumentOutOfRangeException();
            }
            catch
            {
                success = false;
                value = 0;
            }
            return success;
        }
        public static bool TryParse<T>(string s, T min, T max, out T value)
            where T : struct, IComparable<T>, IConvertible
        {
            value = default;
            bool success = true;
            try
            {
                value = (T)Convert.ChangeType(s, typeof(T));

                if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                    throw new ArgumentOutOfRangeException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
            }
            return success;
        }
    }
}
