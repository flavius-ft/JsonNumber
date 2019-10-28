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
    }
}
