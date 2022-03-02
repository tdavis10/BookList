using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class EFCustomerRepository : ICustomerRepository
    {

        private BookstoreContext context; 

        public EFCustomerRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Customer> Customers => context.Customers.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveCustomer(Customer customer)
        {
            context.AttachRange(customer.Lines.Select(x => x.Book));

            if (customer.UserId == 0)
            {
                context.Customers.Add(customer);
            }

            context.SaveChanges();
        }
    }
}
