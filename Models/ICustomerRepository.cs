using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Customers { get; }

        void SaveCustomer(Customer customer);
    }
}
