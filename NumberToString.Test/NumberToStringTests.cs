using System;
using System.Numerics;
using Xunit;

namespace NumberToString.Test
{
    public class NumberToStringTests
    {
        [Fact]
        public void ToString_number22_twentytwo()
        {
            BigInteger number = 22;
            string expected = "twenty two ";

            NumberToString instance = new NumberToString(number);
            string actual = instance.ToString();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_number7000_sevenThousand()
        {
            BigInteger number = 7000;
            string expected = "seven thousand";

            NumberToString instance = new NumberToString(number);
            string actual = instance.ToString();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_number6000000000_sixbillion()
        {
            BigInteger number = 6000000000;
            string expected = "six billion";

            NumberToString instance = new NumberToString(number);
            string actual = instance.ToString();

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_number0_Exception()
        {
            BigInteger number = 0;
            NumberToString instance = new NumberToString(number);
            string actual = instance.ToString();

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => NumberScaleName.ToString());

            Assert.Equal("Please use a positive integer number more than zero!", ex.Message);
        }
    }
}
