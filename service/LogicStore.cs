using System;
using System.Collections.Generic;
using System.Linq;
using domain;
using Microsoft.EntityFrameworkCore;
using repository;

namespace service
{
    public class LogicStore : IStoreLogic
    {
        private StoreContext storeContext;

        public LogicStore(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }


        public void addCustomer(Customer customer)
        {
            customer.CustomerId = new Guid();
            storeContext.Customers.Add(customer);
            storeContext.SaveChanges();

        }

        public Order getCustomerOrder(string name)
        {
            throw new NotImplementedException();
        }

        public List<Store> getALlStores()
        {
           return storeContext.Stores.ToList();
        }

        public List<Customer> getAllCustomers()
        {
            return storeContext.Customers.ToList();
        }

        public List<Order> getAllOrder(string LocationName = "California" )
        {
            
            List<Order> orders = storeContext.Orders.FromSqlRaw("Select * from Orders ").ToList();
             return orders;
        }

        public List<Order> getAllOrder(string name, string locationName)
        {
            throw new NotImplementedException();
        }

        public void deleteCustomer(Guid id)
        {
            var customer = getSingleCustomer(id);
            if (customer == null)
            {
                throw new NotSupportedException("No Customer by this name");
            }
            storeContext.Customers.Remove(customer);
            storeContext.SaveChanges();
        }

        public Customer getSingleCustomer(Guid id)
        {
           return storeContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }
    }
}
