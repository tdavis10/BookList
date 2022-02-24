﻿//using Amazon.Models;
using Amazon.Models;
using Amazon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Controllers
{
    public class HomeController : Controller
    {

        private IBookRepository repo;

        public HomeController(IBookRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string categoryType, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == categoryType || categoryType == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    //Find the total num of books depending on the category
                    TotalNumBooks = (categoryType == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == categoryType).Count()),

                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }

            };

            return View(x);
        }

    }
}
