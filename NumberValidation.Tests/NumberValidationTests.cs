using System;
using Xunit;
using JSON_NumberValidation;

namespace NumberValidation.Tests
{
    public class NumberValidationTests
    {
        [Fact]
        public void VerifyASimpleNumber()
        {
            string number = "123";
            
            Assert.True(Program.GetJsonNumber(number));
        }

        [Fact]
        public void CheckNegativeSimpleNumber()
        {
            string number = "-123";

            Assert.True(Program.GetJsonNumber(number));
        }

        [Fact]
        public void CheckWithNegativeMark()
        {
            string number = "-";

            Assert.False(Program.GetJsonNumber(number));
        }

        [Fact]
        public void VerifyNumberWith0First()
        {
            string number = "0123";

            Assert.False(Program.GetJsonNumber(number));
        }
        
        [Fact]
        public void VerifyFractionalNumber()
        {
            string number = "12.3";

            Assert.True(Program.GetJsonNumber(number));
        }

        [Fact]
        public void VerifyFractionalNumberWIthoutNumbersAfterDot()
        {
            string number = "12.";

            Assert.False(Program.GetJsonNumber(number));
        }

        [Fact]
        public void VerifyFractionalNumberWithTwoDotsAndNumbersAfterDots()
        {
            string number = "12..34";

            Assert.False(Program.GetJsonNumber(number));
        }

        [Fact]
        public void VerifyFractionalNumberWithExponent()
        {
            string number = "12.3e2";

            Assert.True(Program.GetJsonNumber(number));
        }

        [Fact]
        public void VerifyFractionalNumberWithExponentLastChar()
        {
            string number = "12.3e";

            Assert.False(Program.GetJsonNumber(number));
        }

        [Fact]
        public void VerifyFractionalNumberWithExponentWithAdditionOrSubstractionMark()
        {
            string number = "12.3e2+2";

            Assert.True(Program.GetJsonNumber(number));
        }

        [Fact]
        public void VerifyFractionalNumberWithExponentFollowdByAdditionOrSubstractionMark()
        {
            string number = "12.3e+2";

            Assert.True(Program.GetJsonNumber(number));
        }
    }
}
