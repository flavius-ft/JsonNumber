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

        [Fact]
        public void TestFractionalNumberWithMultipleDots()
        {
            string number = "1.2.34";

            Assert.False(Program.GetJsonNumber(number));
        }

        [Fact]
        public void TestFractionalNumberWithExponentBeforeDot()
        {
            string number = "1e2.3";

            Assert.False(Program.GetJsonNumber(number));
        }

        [Fact]
        public void ValidateNUmberWithExponentInNumber()
        {
            string number = "12e3";

            Assert.True(Program.GetJsonNumber(number));
        }

        [Fact]
        public void ValidateNUmberWithExponentLast()
        {
            string number = "12e";

            Assert.False(Program.GetJsonNumber(number));
        }

        [Fact]
        public void ValidateNUmberWithTwoExponents()
        {
            string number = "1e2e3";

            Assert.False(Program.GetJsonNumber(number));
        }

        [Fact]
        public void ValidateFractionalNumberWithTwoExponents()
        {
            string number = "1.2e3e4";

            Assert.False(Program.GetJsonNumber(number));
        }

        [Fact]
        public void ValidateFractionalNumberWithTwoArithmeticSimbols()
        {
            string number = "1.2e+-3";

            Assert.False(Program.GetJsonNumber(number));
        }
    }
}
