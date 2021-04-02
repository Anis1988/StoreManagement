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

        /// <summary>
        /// this method takes a Customer input and saves it
        /// </summary>
        /// <param name="customer"></param>
        /// <returns type="Customer"></returns>
        public Customer addCustomer(Customer customer)
        {
            customer.CustomerId = new Guid();
            storeContext.Customers.Add(customer);
            storeContext.SaveChanges();

            return customer;
        }

        /// <summary>
        /// this methode takes string name to get  order
        /// </summary>
        /// <param name="name"></param>
        /// <returns type="Order" ></returns>
        public Order getCustomerOrder(string name)
        {
            return storeContext.Orders
                .Include(a => a.Customer).FirstOrDefault(p => p.Customer.FirstName == name || p.Customer.LastName == name);
        }

        /// <summary>
        /// takes and ID of type GUID to find the right store
        /// </summary>
        /// <param name="id"></param>
        /// <returns type="Store"></returns>
        public Store GetAsingleStore(Guid id)
        {
           return storeContext.Stores.FirstOrDefault(c=> c.StoreId == id);
        }
        /// <summary>
        ///  doesn't take any parameter and return a List of store
        /// </summary>
        /// <returns type="List<Store>"></returns>
        public List<Store> getALlStores()
        {
            return storeContext.Stores.ToList();
        }
        /// <summary>
        /// doesn't take any parameter and return a List of customer
        /// </summary>
        /// <returns type="List<Customer>"></returns>
        public List<Customer> getAllCustomers()
        {
            return storeContext.Customers.ToList();
        }
        /// <summary>
        /// takes an input string ans return a List of Order
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns type="List<Order>"></returns>
        public List<Order> getAllOrder(string userInput )
        {

            return storeContext.Orders.Include(a => a.Store)
                .Where(p=>p.Store.LocationName==userInput).ToList();
        }

        /// <summary> and return a List of Order
        /// takes 2 string input
        /// </summary>
        /// <param name="name"></param>
        /// <param name="locationName"></param>
        /// <returns type = "List<Order>"></returns>
        public List<Order> getAllOrder(string name, string locationName)
        {
            return storeContext.Orders.Include(p => p.Store)
                .Include(o => o.Customer).
                Where(p =>p.Store.LocationName == locationName && (p.Customer.FirstName == name || p.Customer.LastName == name)).ToList();

        }
        /// <summary>
        ///  delete a customer with the right ID
        /// doesn't return anything
        /// </summary>
        /// <param name="id"></param>
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
        /// <summary>
        /// return a List of product with any parameter
        /// </summary>
        /// <returns></returns>
        public List<Product> getAllProducts()
        {
            return storeContext.Products.ToList();
        }
        /// <summary>
        /// get one customer with the right ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns type="Customer"></returns>
        public Customer getSingleCustomer(Guid id)
        {
           return storeContext.Customers.FirstOrDefault(c => c.CustomerId == id);
        }
        /// <summary>
        /// adds an order to a customer
        /// </summary>
        /// <param name="order"></param>
        public void addProductToAcustomer(Order order)
        {
            var customer = getSingleCustomer(order.CustomerId);
            var store = GetAsingleStore(order.StoreId);
            var product = getSingleProducts(order.ProductId);
            order.Products = new List<Product> {product};


            customer.CustomerId = order.CustomerId;
            store.StoreId = order.StoreId;
            product.ProductId = order.ProductId;
            order.OrderId = new Guid();
            order.DateTime = DateTime.Now;



            storeContext.Orders.Add(order);
            storeContext.SaveChanges();
        }

        /// <summary>
        /// return all products in the database
        /// </summary>
        /// <returns type="List<Order>"></returns>
        public List<Order> getAllOrder()
        {
            return storeContext.Orders.ToList();
        }
        /// <summary>
        /// get a single product with the right ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns type="Product"></returns>
        public Product getSingleProducts(Guid id)
        {
            return storeContext.Products.SingleOrDefault(p=>p.ProductId == id);
        }

        /// <summary>
        /// takes on  input string and return a STore
        /// </summary>
        /// <param name="name"></param>
        /// <returns type="Store"></returns>
        public Store getSingleStore(string name)
        {
            return storeContext.Stores.FirstOrDefault(s => s.LocationName == name);
        }

        /// <summary>
        ///  take the product to edit and decrease the quantity by 1
        /// </summary>
        /// <param name="product"></param>
        public void reduceCount(Product product)
        {

            var product1 = storeContext.Products.Find(product.ProductId);
            if (product1 != null)
            {
                product1.QuantityInStock = product.QuantityInStock -1;
                product1.Name = product.Name;
                product1.UnitPrice = product.UnitPrice;
                product1.ProductUrl = product.ProductUrl;

                storeContext.Products.Update(product1);
                storeContext.SaveChanges();
            }
        }
    }
}
