using System;
using System.Collections.Generic;
using System.Linq;
using domain;
using Microsoft.EntityFrameworkCore;
using repository;
using service;
using Xunit;

namespace tests
{
    public class LogicTest
    {

        DbContextOptions<StoreContext> testOptions = new DbContextOptionsBuilder<StoreContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;        


        [Fact]
        public void Test1()
        {
            var sut = new LogicStore();
            Customer customer = new Customer()
            {
                FirstName = "Anis",
                LastName = "Medini",
                UserName = "user"
            };
            Customer result = new Customer();
            Customer result2 = new Customer();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
               result2 = msr.addCustomer(customer);
                context.SaveChanges();
            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                 result = contex2.Customers.FirstOrDefault(c => c.LastName == customer.LastName);
                
            }
            Assert.Equal(result.LastName,result2.LastName);
        }
       
        [Fact]
        public void Test2()
        {
            var sut = new LogicStore();
            var product1 = new Product()
            {
                ProductId = Guid.NewGuid(),
               Name = "Cloths",
               UnitPrice = 45
            };
            var result = new Product();
            var result2 = new Product();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getSingleProducts(product1.ProductId);
                
            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Products.Find(product1.ProductId);

            }
            Assert.Equal(result,result2);
        }
        [Fact]
        public void Test3()
        {
            var sut = new LogicStore();
            var customer = new Customer()
            {
                CustomerId = Guid.NewGuid(),
                FirstName = "Anis",
                Email = "Anis@gmail.com"
            };
            var result = new Customer();
            var result2 = new Customer();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getSingleCustomer(customer.CustomerId);
                
            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Customers.Find(customer.CustomerId);

            }
            Assert.Equal(result,result2);
        }

        [Fact]
        public void Test4()
        {
            var sut = new LogicStore();
            var store = new Store()
            {
                StoreId = Guid.NewGuid(),
                LocationName = "Cloths",
                
            };
            var result = new Store();
            var result2 = new Store();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getSingleStore(store.LocationName);
                
            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Stores.FirstOrDefault(s => s.LocationName == store.LocationName);

            }
            Assert.Equal(result,result2);
        }
        [Fact]
        public void Test5()
        {
            var sut = new LogicStore();
            var order = new Order()
            {
               OrderId = Guid.NewGuid(),
               Customer = new Customer()
               {
                   CustomerId = Guid.NewGuid(),
                   FirstName = "Anis"
               }
            };
            var result = new Order();
            var result2 = new Order();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getCustomerOrder(order.Customer.FirstName);
                
            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Orders.FirstOrDefault(o =>o.Customer.FirstName == order.Customer.FirstName);

            }
            Assert.Equal(result,result2);
        }
        [Fact]
        public void Test6()
        {
            var sut = new LogicStore();
            var product1 = new List<Product>();
            product1.Add(new Product(){ProductId = Guid.NewGuid(),Name = "Tshirt"});
            product1.Add(new Product(){ProductId = Guid.NewGuid(),Name = "paint"});


            var result = new List<Product>();
            var result2 = new List<Product>();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getAllProducts();
                
            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Products.FromSqlRaw("Select * from Products").ToList();

            }
            Assert.Equal(result,result2);
        }
        [Fact]
        public void Test7()
        {
            var sut = new LogicStore();
            var customersList = new List<Customer>();
            customersList.Add(new Customer(){FirstName = "Anis"});
            customersList.Add(new Customer(){FirstName = "Brad"});
            customersList.Add(new Customer(){FirstName = "John"});



            var result = new List<Customer>();
            var result2 = new List<Customer>();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getAllCustomers();

            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Customers.FromSqlRaw("Select * from Customer").ToList();

            }
            Assert.Equal(result,result2);
        }
        [Fact]
        public void Test8()
        {
            var sut = new LogicStore();
            var storeList = new List<Store>();
            storeList.Add(new Store(){LocationName = "FLORIDA"});
            storeList.Add(new Store(){LocationName = "CANADA"});
            var result = new List<Store>();
            var result2 = new List<Store>();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getALlStores();

            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Stores.FromSqlRaw("Select * From Stores").ToList();

            }
            Assert.Equal(result,result2);
        }
        [Fact]
        public void Test9()
        {
            var sut = new LogicStore();
            var customer = new Customer()
            {
                CustomerId = Guid.NewGuid(),
                FirstName = "Cloths",
                LastName = "Roza"
            };
            var result = new Customer();
            var result2 = new Customer();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getSingleCustomer(customer.CustomerId);

            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Customers.Find(customer.CustomerId);

            }
            Assert.Equal(result,result2);
        }
        [Fact]
        public void Test10()
        {
            
            var order = new Order()
            {
                OrderId = Guid.NewGuid(),
                Customer = new Customer(){FirstName = "Anis"},
               
            };
            var result = new Order();
            var result2 = new Order();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getCustomerOrder(order.Customer.FirstName);
                
            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Orders.FirstOrDefault(o => o.Customer.FirstName == order.Customer.FirstName);

            }
            Assert.Equal(result,result2);
        }
        [Fact]
        public void Test11()
        {
            
            var product1 = new Product()
            {
                ProductId = Guid.NewGuid(),
                Name = "Cloths",
                UnitPrice = 45
            };
            var result = new Product();
            var result2 = new Product();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getSingleProducts(product1.ProductId);
                
            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Products.Find(product1.ProductId);

            }
            Assert.Equal(result,result2);
        }

        [Fact]
        public void Test12()
        {

            var product1 = new List<Product>();
            
            product1.Add(new Product(){ProductId = Guid.NewGuid(),Name = "TSHIR"});
            product1.Add(new Product(){ProductId = Guid.NewGuid(),Name = "Pant"});

            var result = new List<Product>();
            var result2 = new List<Product>();
           
            using (var context = new StoreContext(testOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var msr = new LogicStore(context);
                result2 = msr.getAllProducts();
                
            }

            using (var contex2 = new StoreContext(testOptions))
            {
                contex2.Database.EnsureCreated();
                result = contex2.Products.FromSqlRaw("Select * from Products").ToList();

            }
            Assert.Equal(result,result2);
        }
    }
}
