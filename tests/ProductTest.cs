using System;
using domain;
using Xunit;

namespace tests
{
    public class ProductTest
    {
        [Fact]
        public void Test1()
        {
            var sut = new Product()
            {
                Name = "Veggie"
            };
            var expected = "Veggie";
            var actual = sut.Name;

            Assert.Equal(expected,actual);

        }

        [Theory]
        [InlineData(45)]
        public void Test2(int expected)
        {
            var sut = new Product()
            {
                UnitPrice = 45
            };
            
            var actual = sut.UnitPrice;

            Assert.Equal(expected,actual);


        }
    }
}
