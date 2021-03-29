using System;
using System.Collections.Generic;
using domain;

namespace service
{
    public interface IStoreLogic
    {

        Customer getSingleCustomer(Guid id);
        void addCustomer(Customer customer);
        Order getCustomerOrder(string name);
        List<Store> getALlStores();
        List<Customer> getAllCustomers();
        
        List<Order> getAllOrder( string locationName);
        List<Order> getAllOrder(string name, string locationName);
        void deleteCustomer(Guid id);


    }
}
