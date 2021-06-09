using System;
using Xunit;

namespace NumberToString.Test
{
    public class NumberScaleNameTests
    {
        [Theory]
        [InlineData(0, "")]
        [InlineData(1, "thousand")]
        [InlineData(2, "million")]
        [InlineData(3, "billion")]
        [InlineData(4, "trillion")]
        [InlineData(5, "quadrillion")]
        [InlineData(6, "quintillion")]
        [InlineData(7, "sextillion")]
        [InlineData(8, "septillion")]
        [InlineData(9, "octillion")]
        [InlineData(10, "nonillion")]
        [InlineData(11, "decillion")]
        [InlineData(12, "undecillion")]
        [InlineData(13, "duodecillion")]
        [InlineData(14, "tredecillion")]
        [InlineData(15, "quattuordecillion")]
        [InlineData(16, "quindecillion")]
        [InlineData(17, "sedecillion")]
        [InlineData(18, "septendecillion")]
        [InlineData(19, "octodecillion")]
        [InlineData(20, "novendecillion")]
        [InlineData(21, "vigintillion")]
        [InlineData(22, "unvigintillion")]
        [InlineData(23, "duovigintillion")]
        [InlineData(24, "tresvigintillion")]
        [InlineData(25, "quattuorvigintillion")]
        [InlineData(26, "quinvigintillion")]
        [InlineData(27, "sesvigintillion")]
        [InlineData(28, "septemvigintillion")]
        [InlineData(29, "octovigintillion")]
        [InlineData(30, "novemvigintillion")]
        [InlineData(31, "trigintillion")]
        [InlineData(32, "untrigintillion")]
        [InlineData(33, "duotrigintillion")]
        [InlineData(34, "trestrigintillion")]
        [InlineData(35, "quattuortrigintillion")]
        [InlineData(36, "quintrigintillion")]
        [InlineData(37, "sestrigintillion")]
        [InlineData(38, "septentrigintillion")]
        [InlineData(39, "octotrigintillion")]
        [InlineData(40, "noventrigintillion")]
        [InlineData(41, "quadragintillion")]
        [InlineData(51, "quinquagintillion")]
        [InlineData(61, "sexagintillion")]
        [InlineData(71, "septuagintillion")]
        [InlineData(81, "octogintillion")]
        [InlineData(91, "nonagintillion")]
        [InlineData(101, "centillion")]
        [InlineData(102, "uncentillion")]
        [InlineData(111, "decicentillion")]
        [InlineData(112, "undecicentillion")]
        [InlineData(121, "viginticentillion")]
        [InlineData(122, "unviginticentillion")]
        [InlineData(131, "trigintacentillion")]
        [InlineData(141, "quadragintacentillion")]
        [InlineData(151, "quinquagintacentillion")]
        [InlineData(161, "sexagintacentillion")]
        [InlineData(171, "septuagintacentillion")]
        [InlineData(181, "octogintacentillion")]
        [InlineData(191, "nonagintacentillion")]
        [InlineData(201, "ducentillion")]
        [InlineData(251, "quinquagintaducentillion")]
        [InlineData(301, "trecentillion")]
        [InlineData(351, "quinquagintatrecentillion")]
        [InlineData(378, "septenseptuagintatrecentillion")]
        [InlineData(401, "quadringentillion")]
        [InlineData(451, "quinquagintaquadringentillion")]
        [InlineData(454, "tresquinquagintaquadringentillion")]
        [InlineData(501, "quingentillion")]
        [InlineData(601, "sescentillion")]
        [InlineData(701, "septingentillion")]
        [InlineData(801, "octingentillion")]
        [InlineData(901, "nongentillion")]
        [InlineData(999, "octononagintanongentillion")]
        [InlineData(1000, "novenonagintanongentillion")]
        public void ToString_ValidData_ExpectedName(ushort power, string expected)
        {
            string actual = NumberScaleName.ToString(power);
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1001)]
        [InlineData(65535)]
        public void ToString_power1000_Exception(ushort power)
        {
            string expected = "Use a positive integer number not more than 1000!";

            var ex = Assert.Throws<ArgumentException>(() => NumberScaleName.ToString(power));
            string actual = ex.Message;

            Assert.Equal(expected, actual);
        }
    }
}
