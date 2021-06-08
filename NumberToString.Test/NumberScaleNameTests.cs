using System;
using Xunit;

namespace NumberToString.Test
{
    public class NumberScaleNameTests
    {
        [Fact]
        public void ToString_power0_emptyString()
        {
            ushort power = 0;
            string expected = "";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power2_million()
        {
            ushort power = 2;
            string expected = "million";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power10_nonillion()
        {
            ushort power = 10;
            string expected = "nonillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power17_sedecillion()
        {
            ushort power = 17;
            string expected = "sedecillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power20_novendecillion()
        {
            ushort power = 20;
            string expected = "novendecillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power24_tresvigintillion()
        {
            ushort power = 24;
            string expected = "tresvigintillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power30_novemvigintillion()
        {
            ushort power = 30;
            string expected = "novemvigintillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power38_septentrigintillion()
        {
            ushort power = 38;
            string expected = "septentrigintillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power41_quadragintillion()
        {
            ushort power = 41;
            string expected = "quadragintillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power101_centillion()
        {
            ushort power = 101;
            string expected = "centillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power102_uncentillion()
        {
            ushort power = 102;
            string expected = "uncentillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power161_sexagintacentillion()
        {
            ushort power = 161;
            string expected = "sexagintacentillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power378_septenseptuagintatrecentillion()
        {
            ushort power = 378;
            string expected = "septenseptuagintatrecentillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power999_octononagintanongentillion()
        {
            ushort power = 999;
            string expected = "octononagintanongentillion";

            string actual = NumberScaleName.ToString(power);

            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ToString_power1000_Exception()
        {
            ushort power = 1000;

            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => NumberScaleName.ToString(power));

            Assert.Equal("Use a positive integer number less than 1000!", ex.Message);
        }
    }
}
