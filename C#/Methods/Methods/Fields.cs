using System;
using System.Collections.Generic;

namespace Methods
{
    public class Customer
    {
        public int Id;
        public string Name;
        public List<Order> Orders = new List<Order>();

        public Customer(int id)
        {
            this.Id = id;
        }

        public Customer(int id,string name)
            : this(id)
        {
            this.Name = name;
        }

        public void Promote()
        {

        }
    }

    public class Order
    {

    }

    class Fields
    {
        public static void Main(string[] args)
        {
            var customer = new Customer(1);
            customer.Orders.Add(new Order());
            customer.Orders.Add(new Order());

            Console.WriteLine(customer.Orders.Count);
        }
    }


}
