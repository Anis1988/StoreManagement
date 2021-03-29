using System;
using domain;
using Xunit;

namespace tests
{
    public class CustomerTest
    {
        [Fact]
        public void Test1()
        {
            var sut = new Customer()
            {
                Email = "Anis@gmail.com"
            };
            var expected = "Anis@gmail.com";
            var actual = sut.Email;

            Assert.Equal(expected,actual);

        }

        [Theory]
        [InlineData("password")]
        public void Test2(string expected)
        {
            var sut = new Customer()
            {
                Password = "password"
            };
            
            var actual = sut.Password;

            Assert.Equal(expected,actual);


        }
    }
}
