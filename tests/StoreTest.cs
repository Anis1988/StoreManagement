using System;
using domain;
using Xunit;

namespace tests
{
    public class StoreTest
    {
      
        [Fact]
        public void Test1()
        {
            var sut = new Store()
            {
                LocationName = "CA"
            };
            var expected = "CA";
            var actual = sut.LocationName;

            Assert.Equal(expected,actual);


        }
        [Theory]
        [InlineData("TX")]
        public void Test2(string expected)
        {
            var sut = new Store()
            {
                LocationName = "TX"
            };
            
            var actual = sut.LocationName;

            Assert.Equal(expected,actual);


        }
    }
}
