using domain;
using System;
using Xunit;

namespace tests
{
    public class OrderTest
    {
        [Fact]
        public void Test1()
        {
            var sut = new Order()
            {
                Customer = new Customer()
                {
                    FirstName = "Anis"
                }
            };
            var expected = "Anis";
            var actual = sut.Customer.FirstName;

            Assert.Equal(expected,actual);

        }

        [Theory]
        [InlineData("Medini")]
        public void Test2(string expected)
        {
            var sut = new Order()
            {
                Customer = new Customer()
                {
                    LastName = "Medini"
                }
            };
            
            var actual = sut.Customer.LastName;

            Assert.Equal(expected,actual);


        }
        [Fact]
        public void Test3()
        {
            var sut = new Order()
            {
                Store= new Store()
                {
                    LocationName = "Florida"
                }
            };
            var expected = "Florida";
            var actual = sut.Store.LocationName;

            Assert.Equal(expected,actual);

        }
    }
}
