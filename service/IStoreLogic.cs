using System;
using System.Collections.Generic;
using domain;

namespace service
{
    public interface IStoreLogic
    {

        Customer getSingleCustomer(Guid id);
        Customer addCustomer(Customer customer);
        Order getCustomerOrder(string name);
        List<Store> getALlStores();
        List<Customer> getAllCustomers();
        List<Order> getAllOrder( string locationName);
        List<Order> getAllOrder(string name, string locationName);
        void deleteCustomer(Guid id);
        List<Product> getAllProducts();
        void addProductToAcustomer(Order order);
        List<Order> getAllOrder();
        Product getSingleProducts(Guid id);
        Store getSingleStore(string name);
    }
}
