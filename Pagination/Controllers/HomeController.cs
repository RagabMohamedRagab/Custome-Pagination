using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pagination.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using cloudscribe.Web.Pagination;


namespace Pagination.Controllers
{
    public class HomeController : Controller
    {
        readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(int pageNumber=1)
        {
            int pagesize = 5;

            var skip = (pageNumber * pagesize) - pagesize;
            IQueryable<Customer> customers = _context.Customers.Skip(skip).Take(pagesize);
            var result = new PagedResult<Customer>()
            {
                Data = customers.AsNoTracking().ToList(),
                TotalItems = _context.Customers.Count(),
                PageNumber = pageNumber,
                PageSize = pagesize
            };
            return View(result);
        }
        
        

        public IActionResult Privacy()
        {
            return View();
        }
        
    }
}
