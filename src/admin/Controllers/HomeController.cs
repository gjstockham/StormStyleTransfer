using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StormStyleTransfer.Admin.Core.Data;

namespace StormStyleTransfer.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            // List Existing Models

            return View(_dbContext.ReferenceStyles);
        }
    }
}
