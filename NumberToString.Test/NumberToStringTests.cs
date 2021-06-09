using System;
using System.Numerics;
using Xunit;

namespace NumberToString.Test
{
    public class NumberToStringTests
    {
        [Fact]
        public void NumberToString_DefaultInitialisation_Zero()
        {
            BigInteger number = 0;
            BigInteger expected = number;

            var instance = new PositiveIntegerToString();
            BigInteger actual = instance.Number;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NumberToString_Number3e50_InctanceInicialized()
        {
            var number = BigInteger.Parse("300000000000000000000000000000000000000000000000000");
            BigInteger expected = number;

            var instance = new PositiveIntegerToString();
            instance.Number = number;
            BigInteger actual = instance.Number;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void NumberToString_NegativeNumber_Exception()
        {
            BigInteger number = -1000000000000000000;
            string expected = "Please use a positive integer number!";
            
            var instance = new PositiveIntegerToString();
            var ex = Assert.Throws<OverflowException>(() => instance.Number = number);
            string actual = ex.Message;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1", "one")]
        [InlineData("17", "seventeen")]
        [InlineData("52", "fifty two")]
        [InlineData("100", "one hundred")]
        [InlineData("310", "three hundred ten")]
        [InlineData("7999", "seven thousand nine hundred ninety nine")]
        [InlineData("111222333", "one hundred eleven million two hundred twenty two thousand three hundred thirty three")]
        [InlineData("9005000008", "nine billion five million eight")]
        [InlineData("1234567000", "one billion two hundred thirty four million five hundred sixty seven thousand")]
        [InlineData("16005004003002000000", "sixteen quintillion five quadrillion four trillion three billion two million")]
        [InlineData("2080000000000000000000000000000000000000000000000000000000000", "two novendecillion eighty octodecillion")]
        public void ToString_ValidNumber_ExpectedString(string sourceLine, string expected)
        {
            var number = BigInteger.Parse(sourceLine);
            var instance = new PositiveIntegerToString();
            instance.Number = number;
            
            string actual = instance.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
