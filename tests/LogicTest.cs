using System;
using repository;
using service;
using Xunit;

namespace tests
{
    public class LogicTest
    {
        private readonly StoreContext storeContext;

        public LogicTest(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        [Fact]
        public void Test1()
        {
            var sut = new LogicStore(storeContext);

        }
    }
}
