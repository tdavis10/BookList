using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Infrastructure;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Amazon.Pages
{
    public class CartModel : PageModel
    {

        private IBookRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public CartModel (IBookRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int BookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == BookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
