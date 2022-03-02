using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerRepository repo { get; set; }
        private Basket basket { get; set; }
        public CustomerController(ICustomerRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }


        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Checkout(Customer customer)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty.");
            }

            if (ModelState.IsValid)
            {
                customer.Lines = basket.Items.ToArray();
                repo.SaveCustomer(customer);
                basket.ClearBasket();

                return RedirectToPage("/Confirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
