using System;

namespace ArgumentsProcessor
{
    public class Argument
    {
        public static bool TryParse<T>(string s, T min, T max, out T value)
            where T : struct, IComparable<T>, IConvertible
        {
            value = default;
            bool success = true;
            try
            {
                value = Parse(s, min, max);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                success = false;
            }
            return success;
        }
        public static T Parse<T>(string s, T min, T max)
            where T : struct, IComparable<T>, IConvertible
        {
            T value;
            try
            {
                value = (T)Convert.ChangeType(s, typeof(T));

                if (value.CompareTo(min) < 0 || value.CompareTo(max) > 0)
                    throw new ArgumentOutOfRangeException();
            }
            catch (FormatException ex)
            {
                throw new FormatException("Input string is not a sequence of digits.", ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new ArgumentOutOfRangeException($"The number should be in range from {min} to {max}.", ex);
            }
            catch (OverflowException ex)
            {
                throw new OverflowException($"The number cannot fit in {typeof(T).Name}.", ex);
            }
            return value;
        }
    }
}
