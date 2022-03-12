using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get; }

        void SaveCustomer(Order order);
    }
}
