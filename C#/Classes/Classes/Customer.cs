using System.Collections.Generic;

namespace Classes
{

    class Customer
    {
        public List<Order> Orders;
        public int Id;
        public string Name;

        public Customer()
        {
            Orders = new List<Order>();
        }

        public Customer(int id)
            : this()
        {
            this.Id = id;
        }

        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
        }
    }
}
