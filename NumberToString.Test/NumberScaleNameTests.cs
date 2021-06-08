using System;
using Xunit;

namespace NumberToString.Test
{
    public class NumberScaleNameTests
    {
        [Fact]
        public void ToString_()
        {
            function test(n, should)
            {
                var result = numberScaleNameShortScale(n);
                if (result !== should)
                {
                    console.log(`${ n}
                Output: ${ result}`);
            console.log(`${ n}
            Should be: ${ should}`);
            return 1;
        }
    }
}
    }
}
