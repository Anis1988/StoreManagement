using System;
using System.Collections.Generic;
using System.Linq;
using domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using repository;

namespace service
{
    public class LogicStore : IStoreLogic
    {
        private StoreContext storeContext;

        public LogicStore() {}
        public LogicStore(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }


        public Customer addCustomer(Customer customer)
        {
            customer.CustomerId = new Guid();
            storeContext.Customers.Add(customer);
            storeContext.SaveChanges();

            return customer;
        }

        public Order getCustomerOrder(string name)
        {
            return storeContext.Orders
                .Include(a => a.Customer).FirstOrDefault(p => p.Customer.FirstName == name || p.Customer.LastName == name);
        }

        public Store GetAsingleStore(Guid id)
        {
           return storeContext.Stores.FirstOrDefault(c=> c.StoreId == id);
        }
        public List<Store> getALlStores()
        {
            return storeContext.Stores.ToList();
        }

        public List<Customer> getAllCustomers()
        {
            return storeContext.Customers.ToList();
        }

        public List<Order> getAllOrder(string userInput )
        {
            
            return storeContext.Orders.Include(a => a.Store)
                .Where(p=>p.Store.LocationName==userInput).ToList();
        }

        public List<Order> getAllOrder(string name, string locationName)
        {
            return storeContext.Orders.Include(p => p.Store)
                .Include(o => o.Customer).
                Where(p =>p.Store.LocationName == locationName && (p.Customer.FirstName == name || p.Customer.LastName == name)).ToList();

        }

        public void deleteCustomer(Guid id)
        {
            var customer = getSingleCustomer(id);
            if (customer == null)
            {
                throw new Exception("No Customer by this name");
            }
            storeContext.Customers.Remove(customer);
            storeContext.SaveChanges();
        }

        public List<Product> getAllProducts()
        {
            return storeContext.Products.ToList();
        }

        public Customer getSingleCustomer(Guid id)
        {
           return storeContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public void addProductToAcustomer(Order order)
        {
            var customer = getSingleCustomer(order.CustomerId);
            var store = GetAsingleStore(order.StoreId);
            var product = getSingleProducts(order.ProductId);
            order.Products.Add(product);


            customer.CustomerId = order.CustomerId;
            store.StoreId = order.StoreId;
            product.ProductId = order.ProductId;
            order.OrderId = new Guid();
            order.DateTime = DateTime.Now;



            storeContext.Orders.Add(order);
            storeContext.SaveChanges();
        }

        public List<Order> getAllOrder()
        {
            return storeContext.Orders.ToList();
        }

        public Product getSingleProducts(Guid id)
        {
            return storeContext.Products.SingleOrDefault(p=>p.ProductId == id);
        }

        public Store getSingleStore(string name)
        {
            return storeContext.Stores.FirstOrDefault(s => s.LocationName == name);
        }
    }
}
